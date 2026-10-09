using Common.Domain;
using System.Globalization;

namespace Server.SystemOperation
{
    public class KreirajPoslasticuSO : SystemOperationBase
    {
        private readonly Poslastica poslastica;
        public int Result { get; private set; }

        public KreirajPoslasticuSO(Poslastica poslastica)
        {
            this.poslastica = poslastica;
        }

        protected override void ExecuteConcreteOperation()
        {
            poslastica.InsertCondition =
                $"(naziv, vrstaPoslastice, cena, opis) output inserted.idPoslastica values ('{poslastica.Naziv.Replace("'", "''")}', '{poslastica.Vrsta.Replace("'", "''")}', {poslastica.Cena.ToString(CultureInfo.InvariantCulture)}, '{poslastica.Opis.Replace("'", "''")}')";
            Result = broker.Create(poslastica);
        }
    }
}
