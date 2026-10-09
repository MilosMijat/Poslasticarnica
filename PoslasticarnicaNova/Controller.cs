using Common.Domain;
using Server.SystemOperation;
using System.Collections.Generic;

namespace Server
{
    public class Controller
    {
        #region singleton
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                    instance = new Controller();
                return instance;
            }
        }

        private Controller() { }
        #endregion

        // =========================
        // AUTH
        // =========================
        public Prodavac LoginProdavac(Prodavac prodavac)
        {
            // U SO se očekuje da se koristi SelectCondition za username + password
            // Npr. prodavac.SelectCondition = $"WHERE korisnickoIme='{...}' AND sifra='{...}'";
            LoginProdavacSO so = new LoginProdavacSO(prodavac);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Prodavac> VratiSveProdavce()
        {
            VratiSveProdavceSO so = new VratiSveProdavceSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        // =========================
        // SIFARNICI
        // =========================
        public List<Grad> VratiSveGradove()
        {
            VratiSveGradoveSO so = new VratiSveGradoveSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<StrucnaSprema> VratiSveStrucneSpreme()
        {
            VratiSveStrucneSpremeSO so = new VratiSveStrucneSpremeSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public int KreirajStrucnuSpremu(StrucnaSprema strucnaSprema)
        {
            KreirajStrucnuSpremuSO so = new KreirajStrucnuSpremuSO(strucnaSprema);
            so.ExecuteTemplate();
            return so.Result;
        }

        // =========================
        // POSLASTICE
        // =========================
        public int KreirajPoslasticu(Poslastica poslastica)
        {
            KreirajPoslasticuSO so = new KreirajPoslasticuSO(poslastica);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Poslastica> VratiSvePoslastice()
        {
            VratiSvePoslasticeSO so = new VratiSvePoslasticeSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        // =========================
        // MUSTERIJE
        // =========================
        public int KreirajMusteriju(Musterija musterija)
        {
            KreirajMusterijuSO so = new KreirajMusterijuSO(musterija);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Musterija> VratiSveMusterije()
        {
            VratiSveMusterijeSO so = new VratiSveMusterijeSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public void IzmeniMusteriju(Musterija musterija)
        {
            IzmeniMusterijuSO so = new IzmeniMusterijuSO(musterija);
            so.ExecuteTemplate();
        }

        public void ObrisiMusteriju(Musterija musterija)
        {
            ObrisiMusterijuSO so = new ObrisiMusterijuSO(musterija);
            so.ExecuteTemplate();
        }

        // =========================
        // PORUDZBINE
        // =========================
        public int KreirajPorudzbinu(Porudzbina porudzbina)
        {
            KreirajPorudzbinuSO so = new KreirajPorudzbinuSO(porudzbina);
            so.ExecuteTemplate();
            return so.PorudzbinaId;
        }

        public List<Porudzbina> VratiPorudzbineZaMusteriju(Musterija musterija)
        {
            VratiPorudzbineZaMusterijuSO so = new VratiPorudzbineZaMusterijuSO(musterija);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void ObrisiPorudzbinu(Porudzbina porudzbina)
        {
            // Bezbedno brisanje: prvo stavke pa porudzbina
            ObrisiPorudzbinuISveStavkeSO so = new ObrisiPorudzbinuISveStavkeSO(porudzbina);
            so.ExecuteTemplate();
        }

        public void AzurirajUkupanIznosPorudzbine(Porudzbina p)
        {
            AzurirajUkupanIznosPorudzbineSO so = new AzurirajUkupanIznosPorudzbineSO(p);
            so.ExecuteTemplate();
        }
        public List<Porudzbina> PretraziPorudzbine(Porudzbina kriterijum)
        {
            PretraziPorudzbineSO so = new PretraziPorudzbineSO(kriterijum);
            so.ExecuteTemplate();
            return so.Rezultat;
        }

        public void SacuvajIzmenePorudzbine(Porudzbina porudzbina)
        {
            SacuvajIzmenePorudzbineSO so = new SacuvajIzmenePorudzbineSO(porudzbina);
            so.ExecuteTemplate();
        }
        // =========================
        // STAVKE PORUDZBINE
        // =========================
        public void SacuvajStavkePorudzbine(List<StavkaPorudzbine> stavke)
        {
            SacuvajStavkePorudzbineSO so = new SacuvajStavkePorudzbineSO(stavke);
            so.ExecuteTemplate();
        }

        public List<StavkaPorudzbine> VratiStavkePorudzbine(Porudzbina porudzbina)
        {
            VratiStavkePorudzbineSO so = new VratiStavkePorudzbineSO(porudzbina);
            so.ExecuteTemplate();
            return so.Result;
        }

        // =========================
        // PRSS (ako ti treba)
        // =========================
        public void DodajStrucnuSpremuProdavcu(PrSs veza)
        {
            DodajStrucnuSpremuProdavcuSO so = new DodajStrucnuSpremuProdavcuSO(veza);
            so.ExecuteTemplate();
        }
    }
}
