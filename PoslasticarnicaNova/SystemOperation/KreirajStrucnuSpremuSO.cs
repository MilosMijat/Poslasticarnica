using Common.Domain;

namespace Server.SystemOperation
{
    public class KreirajStrucnuSpremuSO : SystemOperationBase
    {
        private readonly StrucnaSprema strucnaSprema;
        public int Result { get; private set; }

        public KreirajStrucnuSpremuSO(StrucnaSprema strucnaSprema)
        {
            this.strucnaSprema = strucnaSprema;
        }

        protected override void ExecuteConcreteOperation()
        {
            strucnaSprema.InsertCondition =
                $"output inserted.idStrucnaSprema values ('{strucnaSprema.Naziv.Replace("'", "''")}', {strucnaSprema.Trajanje})";
            Result = broker.Create(strucnaSprema);
        }
    }
}
