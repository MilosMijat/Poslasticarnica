using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public class PravnoLice : IEntity
    {
        public int IdMusterija { get; set; }
        public string Naziv { get; set; }
        public string PIB { get; set; }

        public string TableName => "Pravno_Lice";
        public string Values => $"{IdMusterija}, '{Naziv}', '{PIB}'";
        public string Join => "";
        public string Set => $"SET naziv = '{Naziv.Replace("'", "''")}', PIB = '{PIB.Replace("'", "''")}'";
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
