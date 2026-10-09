using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class VratiStavkePorudzbineSO : SystemOperationBase
    {
        private readonly Porudzbina porudzbina;
        public List<StavkaPorudzbine> Result { get; private set; }

        public VratiStavkePorudzbineSO(Porudzbina porudzbina)
        {
            this.porudzbina = porudzbina;
        }

        protected override void ExecuteConcreteOperation()
        {
            // pravimo kriterijum za broker.GetByCondition
            StavkaPorudzbine sp = new StavkaPorudzbine();
            sp.SelectCondition = $"WHERE sp.idPorudzbina = {porudzbina.Id}";

            List<IEntity> lista = broker.GetByCondition(sp);
            Result = lista.Cast<StavkaPorudzbine>().ToList();
        }
    }
}
