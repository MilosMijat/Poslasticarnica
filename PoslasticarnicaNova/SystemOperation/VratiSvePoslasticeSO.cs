using Common.Domain;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class VratiSvePoslasticeSO : SystemOperationBase
    {
        public List<Poslastica> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Poslastica());
            Result = lista.Cast<Poslastica>().ToList();
        }
    }
}
