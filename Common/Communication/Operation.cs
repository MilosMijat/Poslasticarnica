using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        LoginProdavac,
        VratiSveProdavce,
        VratiSvePoslastice,
        KreirajPoslasticu,
        KreirajMusteriju,
        VratiSveMusterije,
        IzmeniMusteriju,
        ObrisiMusteriju,
        KreirajPorudzbinu,
        VratiPorudzbineZaMusteriju,
        ObrisiPorudzbinu,
        SacuvajStavkePorudzbine,
        VratiStavkePorudzbine,
        VratiSveGradove,
        VratiSveStrucneSpreme,
        AzurirajUkupanIznosPorudzbine,
        PretraziPorudzbine,
        SacuvajIzmenePorudzbine,
        KreirajStrucnuSpremu,
        DodajStrucnuSpremuProdavcu
    }
}
