using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Prodavac : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }

        public string ImePrezime => Ime + " " + Prezime;

        // =========================
        // IEntity implementacija
        // =========================
        public string TableName => "Prodavac";

        public string Values =>
            $"'{Ime}', '{Prezime}', '{BrojTelefona}', '{Email}', '{KorisnickoIme}', '{Sifra}'";

        // JOIN za login / citanje prodavca
        public string Join => "";

        public string Set =>
            $"SET ime = '{Ime}', prezime = '{Prezime}', brojTelefona = '{BrojTelefona}', " +
            $"email = '{Email}', korisnickoIme = '{KorisnickoIme}', sifra = '{Sifra}'";

        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        // =========================
        // Mapiranje iz baze
        // =========================
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> prodavci = new List<IEntity>();

            while (reader.Read())
            {
                Prodavac p = new Prodavac
                {
                    Id = (int)reader["idProdavac"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    BrojTelefona = (string)reader["brojTelefona"],
                    Email = (string)reader["email"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"]
                };

                prodavci.Add(p);
            }

            return prodavci;
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
