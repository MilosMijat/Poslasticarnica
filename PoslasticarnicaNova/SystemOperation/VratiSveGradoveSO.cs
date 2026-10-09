using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class VratiSveGradoveSO : SystemOperationBase
    {
        public List<Grad> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Grad()).Cast<Grad>().ToList();
        }
    }
}
