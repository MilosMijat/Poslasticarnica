using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
        string Join { get; }
        string Set { get; }
        string InsertCondition { get; set; }
        string UpdateCondition { get; set; }
        string DeleteCondition { get; set; }
        string SelectCondition { get; set; }
        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
