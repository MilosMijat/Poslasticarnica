using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Poslastica : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public double Cena { get; set; }
        public string Opis { get; set; }

        // =========================
        // IEntity implementacija
        // =========================
        public string TableName => "Poslastica";

        public string Values =>
            $"'{Naziv}', '{Vrsta}', {Cena.ToString().Replace(',', '.')}, '{Opis}'";

        public string Join => "";

        public string Set =>
            $"SET naziv = '{Naziv}', vrsta = '{Vrsta}', cena = {Cena.ToString().Replace(',', '.')}, opis = '{Opis}'";

        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        // =========================
        // Mapiranje iz baze
        // =========================
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> poslastice = new List<IEntity>();

            while (reader.Read())
            {
                Poslastica p = new Poslastica
                {
                    Id = (int)reader["idPoslastica"],
                    Naziv = (string)reader["naziv"],
                    Vrsta = (string)reader["vrstaPoslastice"],
                    Cena = (double)reader["cena"],
                    Opis = (string)reader["opis"]
                };

                poslastice.Add(p);
            }

            return poslastice;
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }
    }
}
