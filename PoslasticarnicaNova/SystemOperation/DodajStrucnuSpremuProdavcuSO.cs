using Common.Domain;

namespace Server.SystemOperation
{
    public class DodajStrucnuSpremuProdavcuSO : SystemOperationBase
    {
        private readonly PrSs veza;

        public DodajStrucnuSpremuProdavcuSO(PrSs veza)
        {
            this.veza = veza;
        }

        protected override void ExecuteConcreteOperation()
        {
            veza.InsertCondition =
                $"(idProdavac, idStrucnaSprema, stepenSS, datumSticanja) VALUES ({veza.Prodavac.Id}, {veza.StrucnaSprema.Id}, {veza.StepenSS}, '{veza.DatumSticanja:yyyy-MM-dd}')";
            broker.AddWithCondition(veza);
        }
    }
}
