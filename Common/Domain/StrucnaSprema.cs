using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class StrucnaSprema : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Trajanje { get; set; }

        // =========================
        // IEntity
        // =========================
        public string TableName => "Strucna_Sprema";

        public string Values => $"'{Naziv}', {Trajanje}";

        public string Join => "";

        public string Set => $"SET nazivStrucnaSprema = '{Naziv}', trajanje = {Trajanje}";

        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        // =========================
        // Reader
        // =========================
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();

            while (reader.Read())
            {
                StrucnaSprema ss = new StrucnaSprema
                {
                    Id = (int)reader["idStrucnaSprema"],
                    Naziv = (string)reader["naziv"],
                    Trajanje = reader["trajanje"] == DBNull.Value ? 0 : (int)reader["trajanje"]
                };

                lista.Add(ss);
            }

            return lista;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
