using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class FizickoLice : IEntity
    {
        public int IdMusterija { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string TableName => "Fizicko_Lice";
        public string Values => $"{IdMusterija}, '{Ime}', '{Prezime}'";
        public string Join => "";
        public string Set => $"SET ime = '{Ime.Replace("'", "''")}', prezime = '{Prezime.Replace("'", "''")}'";
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }
        public string SelectCondition { get; set; }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            return new List<IEntity>();
        }
    }
}
