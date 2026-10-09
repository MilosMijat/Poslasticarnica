using Common.Domain;
using System;

namespace Server.SystemOperation
{
    public class IzmeniMusterijuSO : SystemOperationBase
    {
        private readonly Musterija musterija;

        public IzmeniMusterijuSO(Musterija musterija)
        {
            this.musterija = musterija;
        }

        protected override void ExecuteConcreteOperation()
        {
            musterija.UpdateCondition = $"WHERE idMusterija = {musterija.Id}";
            broker.UpdateByCondition(musterija);

            ObrisiPostojeceSpecijalizacije();
            SacuvajSpecijalizaciju();
        }

        private void ObrisiPostojeceSpecijalizacije()
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
        }

        private void SacuvajSpecijalizaciju()
        {
            if (musterija.JePravnoLice)
            {
                if (string.IsNullOrWhiteSpace(musterija.NazivPravnogLica))
                    throw new Exception("Naziv pravnog lica je obavezan.");

                if (string.IsNullOrWhiteSpace(musterija.PIB))
                    throw new Exception("PIB je obavezan.");

                PravnoLice pravnoLice = new PravnoLice
                {
                    InsertCondition =
                        $"(idMusterija, naziv, PIB) VALUES ({musterija.Id}, '{musterija.NazivPravnogLica.Replace("'", "''")}', '{musterija.PIB.Replace("'", "''")}')"
                };

                broker.AddWithCondition(pravnoLice);
                return;
            }

            if (string.IsNullOrWhiteSpace(musterija.Ime))
                throw new Exception("Ime musterije je obavezno.");

            if (string.IsNullOrWhiteSpace(musterija.Prezime))
                throw new Exception("Prezime musterije je obavezno.");

            FizickoLice fizickoLiceZaUpis = new FizickoLice
            {
                InsertCondition =
                    $"(idMusterija, ime, prezime) VALUES ({musterija.Id}, '{musterija.Ime.Replace("'", "''")}', '{musterija.Prezime.Replace("'", "''")}')"
            };

            broker.AddWithCondition(fizickoLiceZaUpis);
        }
    }
}
