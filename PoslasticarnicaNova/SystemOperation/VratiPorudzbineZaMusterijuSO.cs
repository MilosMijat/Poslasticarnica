using Common.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class VratiPorudzbineZaMusterijuSO : SystemOperationBase
    {
        private readonly Musterija musterija;
        public List<Porudzbina> Result { get; private set; }

        public VratiPorudzbineZaMusterijuSO(Musterija musterija)
        {
            this.musterija = musterija;
        }

        protected override void ExecuteConcreteOperation()
        {
            Porudzbina p = new Porudzbina();
            p.SelectCondition = $"WHERE idMusterija = {musterija.Id}";

            List<IEntity> lista = broker.GetByCondition(p);
            Result = lista.Cast<Porudzbina>().ToList();
        }
    }
}
