using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class StavkaPorudzbine : IEntity
    {
        public int Rb { get; set; }

        public int Kolicina { get; set; }
        public double Iznos { get; set; }

        public Porudzbina Porudzbina { get; set; }
        public Poslastica Poslastica { get; set; }

        // =========================
        // IEntity implementacija
        // =========================

        public string TableName => "Stavka_Porudzbine";

        public string Values =>
            $"{Porudzbina.Id}, {Kolicina}, {Iznos.ToString().Replace(',', '.')}, {Poslastica.Id}";

        public string Set =>
            $"SET kolicina = {Kolicina}, iznos = {Iznos.ToString().Replace(',', '.')}, idPoslastice = {Poslastica.Id}";

        public string Join =>
            "JOIN Poslastica ps ON (ps.idPoslastice = Stavka_Porudzbine.idPoslastice)";

        public string InsertCondition { get; set; }

        public string UpdateCondition { get; set; }

        public string DeleteCondition { get; set; }

        public string SelectCondition { get; set; }

        // =========================
        // Mapiranje iz baze
        // =========================

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> stavke = new List<IEntity>();

            while (reader.Read())
            {
                StavkaPorudzbine sp = new StavkaPorudzbine
                {
                    Rb = (int)reader["rb"],
                    Kolicina = (int)reader["kolicina"],
                    Iznos = (double)reader["iznos"],

                    Poslastica = new Poslastica
                    {
                        Id = (int)reader["idPoslastice"],
                        Naziv = (string)reader["naziv"],
                        Cena = (double)reader["cena"]
                    },

                    Porudzbina = new Porudzbina
                    {
                        Id = (int)reader["idPorudzbine"]
                    }
                };

                stavke.Add(sp);
            }

            return stavke;
        }

        public override string ToString()
        {
            return $"{Poslastica?.Naziv} x {Kolicina}";
        }
    }
}