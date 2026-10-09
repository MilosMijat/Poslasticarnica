using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class Grad : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        // =========================
        // IEntity implementacija
        // =========================
        public string TableName => "Grad";

        public string Values =>
            $"'{Naziv}'";

        // Grad nema potrebe za JOIN u osnovnoj formi
        public string Join => "";

        public string Set =>
            $"SET nazivGrada = '{Naziv}'";

        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        // =========================
        // Mapiranje iz SqlDataReader
        // =========================
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> gradovi = new List<IEntity>();

            while (reader.Read())
            {
                Grad g = new Grad
                {
                    Id = (int)reader["idGrad"],
                    Naziv = (string)reader["nazivGrada"]
                };

                gradovi.Add(g);
            }

            return gradovi;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
