using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    public class DbConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        //ne znam sta je ovde prob
        public DbConnection()
        {
            connection = new SqlConnection($@"Data Source=DESKTOP-BEVHKIN\SQLEXPRESS;Initial Catalog=PS_Poslasticarnica2;Integrated Security = True;Encrypt = False");
        }

        public void OpenConnection()
        {
            connection?.Open();
            Debug.WriteLine("Konekcija uspesna na " + connection.Database);
        }

        public void CloseConnection()
        {
            connection?.Close();
        }

        public void BeginTransaction()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            if (transaction != null)
            {
                return;
            }

            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }
        }
        public void Rollback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
            }
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }

    }
}