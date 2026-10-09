using Common.Domain;
using System.Linq;

namespace Server.SystemOperation
{
    public class LoginProdavacSO : SystemOperationBase
    {
        private readonly Prodavac kriterijum;
        public Prodavac Result { get; private set; }

        public LoginProdavacSO(Prodavac kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        protected override void ExecuteConcreteOperation()
        {
            // očekuje se da server postavi kriterijum.SelectCondition
            // npr: WHERE korisnickoIme='x' AND sifra='y'
            var lista = broker.GetByCondition(kriterijum).Cast<Prodavac>().ToList();
            Result = lista.FirstOrDefault();
        }
    }
}
