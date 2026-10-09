using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Musterija : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string BrojTelefona { get; set; } = string.Empty;
        public Grad Grad { get; set; } = new Grad();
        public string TipMusterije { get; set; } = string.Empty;
        public string NazivPravnogLica { get; set; } = string.Empty;
        public string PIB { get; set; } = string.Empty;

        public bool JePravnoLice =>
            string.Equals(TipMusterije, "Pravno", StringComparison.OrdinalIgnoreCase);

        public string ImePrezime =>
            JePravnoLice
                ? NazivPravnogLica
                : $"{Ime} {Prezime}".Trim();

        public string TableName => "Musterija";

        public string Values =>
            $"'{BrojTelefona.Replace("'", "''")}', {Grad.Id}";

        public string Join =>
            "LEFT JOIN Fizicko_Lice fl ON fl.idMusterija = Musterija.idMusterija " +
            "LEFT JOIN Pravno_Lice pl ON pl.idMusterija = Musterija.idMusterija " +
            "JOIN Grad g ON Musterija.idGrad = g.idGrad";

        public string Set =>
            $"SET brojTelefona = '{BrojTelefona.Replace("'", "''")}', idGrad = {Grad.Id}";

        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> musterije = new List<IEntity>();

            while (reader.Read())
            {
                bool jePravnoLice = reader["naziv"] != DBNull.Value;
                string nazivPravnogLica = reader["naziv"] == DBNull.Value ? string.Empty : (string)reader["naziv"];
                string pib = reader["PIB"] == DBNull.Value ? string.Empty : (string)reader["PIB"];
                string ime = reader["ime"] == DBNull.Value ? string.Empty : (string)reader["ime"];
                string prezime = reader["prezime"] == DBNull.Value ? string.Empty : (string)reader["prezime"];

                Musterija m = new Musterija
                {
                    Id = (int)reader["idMusterija"],
                    Ime = jePravnoLice ? nazivPravnogLica : ime,
                    Prezime = jePravnoLice ? pib : prezime,
                    BrojTelefona = (string)reader["brojTelefona"],
                    Grad = new Grad
                    {
                        Id = (int)reader["idGrad"],
                        Naziv = (string)reader["nazivGrada"]
                    },
                    TipMusterije = jePravnoLice ? "Pravno" : "Fizicko",
                    NazivPravnogLica = nazivPravnogLica,
                    PIB = pib
                };

                musterije.Add(m);
            }

            return musterije;
        }

        public override string ToString()
        {
            return ImePrezime;
        }
    }
}
