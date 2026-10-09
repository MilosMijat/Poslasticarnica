using Common.Domain;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class SacuvajStavkePorudzbineSO : SystemOperationBase
    {
        private readonly List<StavkaPorudzbine> stavke;

        public SacuvajStavkePorudzbineSO(List<StavkaPorudzbine> stavke)
        {
            this.stavke = stavke;
        }

        protected override void ExecuteConcreteOperation()
        {
            foreach (StavkaPorudzbine sp in stavke)
            {
                sp.InsertCondition =
             $"(idPorudzbine, kolicina, iznos, idPoslastice) VALUES ({sp.Porudzbina.Id}, {sp.Kolicina}, {sp.Iznos.ToString().Replace(',', '.')}, {sp.Poslastica.Id})";

                broker.AddWithCondition(sp);
            }
        }
    }
}
