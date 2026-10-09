using Common.Domain;

namespace Server.SystemOperation
{
    public class SacuvajIzmenePorudzbineSO : SystemOperationBase
    {
        private readonly Porudzbina porudzbina;

        public SacuvajIzmenePorudzbineSO(Porudzbina porudzbina)
        {
            this.porudzbina = porudzbina;
        }

        protected override void ExecuteConcreteOperation()
        {
            porudzbina.UpdateCondition = $"WHERE idPorudzbina = {porudzbina.Id}";
            broker.UpdateByCondition(porudzbina);

            StavkaPorudzbine kriterijumZaBrisanje = new StavkaPorudzbine
            {
                DeleteCondition = $"WHERE idPorudzbine = {porudzbina.Id}"
            };
            broker.DeleteEntity(kriterijumZaBrisanje);

            if (porudzbina.Stavke == null)
                return;

            foreach (StavkaPorudzbine stavka in porudzbina.Stavke)
            {
                stavka.InsertCondition =
                    $"(idPorudzbine, kolicina, iznos, idPoslastice) VALUES ({porudzbina.Id}, {stavka.Kolicina}, {stavka.Iznos.ToString().Replace(',', '.')}, {stavka.Poslastica.Id})";
                broker.AddWithCondition(stavka);
            }
        }
    }
}
