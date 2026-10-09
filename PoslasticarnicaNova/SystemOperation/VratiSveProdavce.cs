using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class VratiSveProdavceSO : SystemOperationBase
    {
        public List<Prodavac> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Prodavac());
            Result = lista.Cast<Prodavac>().ToList();
        }
    }
}