using Common.Domain;
using Microsoft.Data.SqlClient;

public class Porudzbina : IEntity
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public double UkupanIznos { get; set; }

    public Prodavac Prodavac { get; set; } = new Prodavac();
    public Musterija Musterija { get; set; } = new Musterija { Grad = new Grad() };

    public string NacinPlacanja { get; set; }
    public string AdresaZaDostavu { get; set; }

    public List<StavkaPorudzbine> Stavke { get; set; } = new List<StavkaPorudzbine>();

    public string TableName => "Porudzbina";

    public string Values =>
        $" {UkupanIznos.ToString().Replace(',', '.')},'{Datum:yyyy-MM-dd}', '{NacinPlacanja}', " +
        $"{(AdresaZaDostavu == null ? "NULL" : $"'{AdresaZaDostavu.Replace("'", "''")}'")}, {Prodavac.Id}, {Musterija.Id}";

    public string Join =>
        "JOIN Prodavac p ON (p.idProdavac = Porudzbina.idProdavac) " +
        "JOIN Musterija m ON (m.idMusterija = Porudzbina.idMusterija) " +
        "LEFT JOIN Fizicko_Lice fl ON (fl.idMusterija = m.idMusterija) " +
        "LEFT JOIN Pravno_Lice pl ON (pl.idMusterija = m.idMusterija) " +
        "JOIN Grad g ON (g.idGrad = m.idGrad) " +
        "CROSS APPLY (SELECT " +
        "p.idProdavac AS prodavacIdAlias, p.ime AS prodavacIme, p.prezime AS prodavacPrezime, " +
        "m.idMusterija AS musterijaIdAlias, m.brojTelefona AS musterijaBrojTelefona, " +
        "g.idGrad AS musterijaGradIdAlias, g.nazivGrada AS musterijaGradNaziv, " +
        "fl.ime AS fizickoIme, fl.prezime AS fizickoPrezime, pl.naziv AS pravnoNaziv, pl.PIB AS pravnoPIB) AS AliasPodaci";

    public string Set =>
        $"SET datum = '{Datum:yyyy-MM-dd}', ukupanIznos = {UkupanIznos.ToString().Replace(',', '.')}, " +
        $"nacinPlacanja = '{NacinPlacanja}', adresaZaDostavu = {(AdresaZaDostavu == null ? "NULL" : $"'{AdresaZaDostavu.Replace("'", "''")}'")}, " +
        $"idProdavac = {Prodavac.Id}, idMusterija = {Musterija.Id}";

    public string InsertCondition
    {
        get
        {
            return $"output inserted.idPorudzbina values ( {UkupanIznos.ToString().Replace(',', '.')}, " +
                   $"'{Datum:yyyy-MM-dd}', '{NacinPlacanja}', " +
                   $"{(AdresaZaDostavu == null ? "NULL" : $"'{AdresaZaDostavu.Replace("'", "''")}'")}, " +
                   $"{Prodavac.Id}, {Musterija.Id})";
        }
        set { }
    }

    public string UpdateCondition { get; set; }
    public string DeleteCondition { get; set; }
    public string SelectCondition { get; set; }

    public List<IEntity> GetReaderList(SqlDataReader reader)
    {
        List<IEntity> porudzbine = new List<IEntity>();

        while (reader.Read())
        {
            bool jePravnoLice = reader["pravnoNaziv"] != DBNull.Value;
            string nazivPravnogLica = reader["pravnoNaziv"] == DBNull.Value ? string.Empty : (string)reader["pravnoNaziv"];
            string pib = reader["pravnoPIB"] == DBNull.Value ? string.Empty : (string)reader["pravnoPIB"];
            string imeFizickog = reader["fizickoIme"] == DBNull.Value ? string.Empty : (string)reader["fizickoIme"];
            string prezimeFizickog = reader["fizickoPrezime"] == DBNull.Value ? string.Empty : (string)reader["fizickoPrezime"];

            porudzbine.Add(new Porudzbina
            {
                Id = (int)reader["idPorudzbina"],
                UkupanIznos = (double)reader["ukupanIznos"],
                Datum = (DateTime)reader["datum"],
                NacinPlacanja = (string)reader["nacinPlacanja"],
                AdresaZaDostavu = reader["adresaZaDostavu"] == DBNull.Value ? null : (string)reader["adresaZaDostavu"],
                Prodavac = new Prodavac
                {
                    Id = (int)reader["prodavacIdAlias"],
                    Ime = (string)reader["prodavacIme"],
                    Prezime = (string)reader["prodavacPrezime"]
                },
                Musterija = new Musterija
                {
                    Id = (int)reader["musterijaIdAlias"],
                    Ime = jePravnoLice ? nazivPravnogLica : imeFizickog,
                    Prezime = jePravnoLice ? pib : prezimeFizickog,
                    BrojTelefona = (string)reader["musterijaBrojTelefona"],
                    Grad = new Grad
                    {
                        Id = (int)reader["musterijaGradIdAlias"],
                        Naziv = (string)reader["musterijaGradNaziv"]
                    },
                    TipMusterije = jePravnoLice ? "Pravno" : "Fizicko",
                    NazivPravnogLica = nazivPravnogLica,
                    PIB = pib
                }
            });
        }

        return porudzbine;
    }
}
