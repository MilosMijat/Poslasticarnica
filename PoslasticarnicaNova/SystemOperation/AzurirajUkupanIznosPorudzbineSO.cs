using Common.Domain;

namespace Server.SystemOperation
{
    public class AzurirajUkupanIznosPorudzbineSO : SystemOperationBase
    {
        private readonly Porudzbina p;

        public AzurirajUkupanIznosPorudzbineSO(Porudzbina p)
        {
            this.p = p;
        }

        protected override void ExecuteConcreteOperation()
        {
            // Update samo ukupne cene
            p.UpdateCondition = $"WHERE idPorudzbina = {p.Id}";
            // Bitno: Porudzbina.Set mora da ukljuci ukupnaCena!
            broker.UpdateByCondition(p);
        }
    }
}