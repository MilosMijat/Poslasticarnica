using Common.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Server.SystemOperation
{
    public class PretraziPorudzbineSO : SystemOperationBase
    {
        private readonly Porudzbina kriterijum;

        public List<Porudzbina> Rezultat { get; private set; }

        public PretraziPorudzbineSO(Porudzbina kriterijum)
        {
            this.kriterijum = kriterijum;
            Rezultat = new List<Porudzbina>();
        }

        protected override void ExecuteConcreteOperation()
        {
            StringBuilder sb = new StringBuilder("WHERE 1=1");

            if (kriterijum != null)
            {
                if (kriterijum.Datum != DateTime.MinValue)
                {
                    sb.Append($" AND Porudzbina.datum = '{kriterijum.Datum:yyyy-MM-dd}'");
                }

                if (!string.IsNullOrWhiteSpace(kriterijum.AdresaZaDostavu))
                {
                    sb.Append($" AND Porudzbina.adresaZaDostavu LIKE '%{kriterijum.AdresaZaDostavu.Trim()}%'");
                }

                if (!string.IsNullOrWhiteSpace(kriterijum.NacinPlacanja))
                {
                    sb.Append($" AND Porudzbina.nacinPlacanja = '{kriterijum.NacinPlacanja}'");
                }

                if (kriterijum.Prodavac != null && kriterijum.Prodavac.Id > 0)
                {
                    sb.Append($" AND Porudzbina.idProdavac = {kriterijum.Prodavac.Id}");
                }

                if (kriterijum.Musterija != null && kriterijum.Musterija.Id > 0)
                {
                    sb.Append($" AND Porudzbina.idMusterija = {kriterijum.Musterija.Id}");
                }
            }

            Porudzbina p = new Porudzbina();
            p.SelectCondition = sb.ToString();

            Rezultat = broker.GetByCondition(p).ConvertAll(x => (Porudzbina)x);
        }
    }
}