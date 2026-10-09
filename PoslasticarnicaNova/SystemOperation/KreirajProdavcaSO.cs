using Common.Domain;

namespace Server.SystemOperation
{
    public class KreirajProdavcaSO : SystemOperationBase
    {
        private readonly Prodavac prodavac;
        public int Result { get; private set; }

        public KreirajProdavcaSO(Prodavac prodavac)
        {
            this.prodavac = prodavac;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Create(prodavac);
        }
    }
}
