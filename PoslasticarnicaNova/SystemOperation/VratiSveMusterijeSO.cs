using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class VratiSveMusterijeSO : SystemOperationBase
    {
        public List<Musterija> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Musterija()).Cast<Musterija>().ToList();
        }
    }
}
