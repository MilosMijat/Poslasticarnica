using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation
{
    public abstract class SystemOperationBase
    {
        //broker vidljiv samo unutar klase i izvedenim
        protected Broker broker;

        public SystemOperationBase()
        {
            broker = new Broker();
        }

        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();
                ExecuteConcreteOperation();
                broker.Commit();
            }
            catch (Exception)
            {
                broker.RollBack();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }

        }

        protected abstract void ExecuteConcreteOperation();
    }
}
