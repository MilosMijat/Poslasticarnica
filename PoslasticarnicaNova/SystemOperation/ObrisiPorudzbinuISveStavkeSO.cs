using Common.Domain;

namespace Server.SystemOperation
{
    public class ObrisiPorudzbinuISveStavkeSO : SystemOperationBase
    {
        private readonly Porudzbina porudzbina;

        public ObrisiPorudzbinuISveStavkeSO(Porudzbina porudzbina)
        {
            this.porudzbina = porudzbina;
        }

        protected override void ExecuteConcreteOperation()
        {
            // 1️⃣ Brisanje stavki porudžbine
            StavkaPorudzbine sp = new StavkaPorudzbine();
            sp.DeleteCondition = $"WHERE idPorudzbina = {porudzbina.Id}";
            broker.DeleteEntity(sp);

            // 2️⃣ Brisanje porudžbine
            porudzbina.DeleteCondition = $"WHERE idPorudzbina = {porudzbina.Id}";
            broker.DeleteEntity(porudzbina);
        }
    }
}
