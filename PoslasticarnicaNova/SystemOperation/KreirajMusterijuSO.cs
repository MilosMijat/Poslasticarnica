using Common.Domain;
using System;

namespace Server.SystemOperation
{
    public class KreirajMusterijuSO : SystemOperationBase
    {
        private readonly Musterija musterija;
        public int Result { get; private set; }

        public KreirajMusterijuSO(Musterija musterija)
        {
            this.musterija = musterija;
        }

        protected override void ExecuteConcreteOperation()
        {
            musterija.InsertCondition =
                $"(brojTelefona, idGrad) output inserted.idMusterija values ('{musterija.BrojTelefona.Replace("'", "''")}', {musterija.Grad.Id})";

            Result = broker.Create(musterija);
            SacuvajSpecijalizaciju(Result);
        }

        private void SacuvajSpecijalizaciju(int musterijaId)
        {
            if (musterija.JePravnoLice)
            {
                if (string.IsNullOrWhiteSpace(musterija.NazivPravnogLica))
                    throw new Exception("Naziv pravnog lica je obavezan.");

                if (string.IsNullOrWhiteSpace(musterija.PIB))
                    throw new Exception("PIB je obavezan.");

                PravnoLice pravnoLice = new PravnoLice
                {
                    IdMusterija = musterijaId
                };

                pravnoLice.InsertCondition =
                    $"(idMusterija, naziv, PIB) VALUES ({musterijaId}, '{musterija.NazivPravnogLica.Replace("'", "''")}', '{musterija.PIB.Replace("'", "''")}')";

                broker.AddWithCondition(pravnoLice);
                return;
            }

            if (string.IsNullOrWhiteSpace(musterija.Ime))
                throw new Exception("Ime musterije je obavezno.");

            if (string.IsNullOrWhiteSpace(musterija.Prezime))
                throw new Exception("Prezime musterije je obavezno.");

            FizickoLice fizickoLice = new FizickoLice
            {
                IdMusterija = musterijaId
            };

            fizickoLice.InsertCondition =
                $"(idMusterija, ime, prezime) VALUES ({musterijaId}, '{musterija.Ime.Replace("'", "''")}', '{musterija.Prezime.Replace("'", "''")}')";

            broker.AddWithCondition(fizickoLice);
        }
    }
}
