using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class VratiSveStrucneSpremeSO : SystemOperationBase
    {
        public List<StrucnaSprema> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new StrucnaSprema()).Cast<StrucnaSprema>().ToList();
        }
    }
}
