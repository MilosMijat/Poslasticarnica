using Common.Domain;

namespace Server.SystemOperation
{
    public class ObrisiMusterijuSO : SystemOperationBase
    {
        private readonly Musterija musterija;

        public ObrisiMusterijuSO(Musterija musterija)
        {
            this.musterija = musterija;
        }

        protected override void ExecuteConcreteOperation()
        {
            FizickoLice fizickoLice = new FizickoLice
            {
                DeleteCondition = $"WHERE idMusterija = {musterija.Id}"
            };
            broker.DeleteEntity(fizickoLice);

            PravnoLice pravnoLice = new PravnoLice
            {
                DeleteCondition = $"WHERE idMusterija = {musterija.Id}"
            };
            broker.DeleteEntity(pravnoLice);

            musterija.DeleteCondition = $"WHERE idMusterija = {musterija.Id}";
            broker.DeleteEntity(musterija);
        }
    }
}
