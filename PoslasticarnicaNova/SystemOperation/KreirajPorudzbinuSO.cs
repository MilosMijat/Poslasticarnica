using Common.Domain;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class KreirajPorudzbinuSO : SystemOperationBase
    {
        private readonly Porudzbina porudzbina;
        public int PorudzbinaId { get; private set; }

        public KreirajPorudzbinuSO(Porudzbina porudzbina)
        {
            this.porudzbina = porudzbina;
        }

        protected override void ExecuteConcreteOperation()
        {
            // 1. Insert porudzbine
            PorudzbinaId = broker.Create(porudzbina);
            porudzbina.Id = PorudzbinaId;

            // 2. Insert stavki
            foreach (StavkaPorudzbine sp in porudzbina.Stavke)
            {
                sp.Porudzbina = porudzbina;
                broker.Add(sp);
            }
        }
    }
}
