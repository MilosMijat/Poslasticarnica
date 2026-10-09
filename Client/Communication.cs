using Common;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Client
{
    public class Communication
    {
        #region Singleton
        private static Communication instance;
        public static Communication Instance
        {
            get
            {
                if (instance == null)
                    instance = new Communication();
                return instance;
            }
        }

        private Communication() { }
        #endregion

        private Socket socket;
        private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);
        }

        // =========================
        // LOGIN
        // =========================
        public Response LoginProdavac(Prodavac prodavac)
        {
            Request request = new Request
            {
                Operation = Operation.LoginProdavac,
                Argument = prodavac
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            response.Result = serializer.ReadType<Prodavac>(response.Result);
            return response;
        }

        public List<Prodavac> VratiSveProdavce()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveProdavce
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();

            return serializer.ReadType<List<Prodavac>>(response.Result);
        }

        // =========================
        // POSLASTICE
        // =========================
        public List<Poslastica> VratiSvePoslastice()
        {
            Request req = new Request { Operation = Operation.VratiSvePoslastice };
            serializer.Send(req);

            Response res = serializer.Receive<Response>();
            if (!string.IsNullOrEmpty(res.ExceptionMessage))
                throw new Exception(res.ExceptionMessage);

            return serializer.ReadType<List<Poslastica>>(res.Result) ?? new List<Poslastica>();
        }

        public int KreirajPoslasticu(Poslastica poslastica)
        {
            Request request = new Request
            {
                Operation = Operation.KreirajPoslasticu,
                Argument = poslastica
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();

            if (!string.IsNullOrEmpty(response.ExceptionMessage))
                throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<int>(response.Result);
        }

        // =========================
        // MUSTERIJE
        // =========================
        public int KreirajMusteriju(Musterija musterija)
        {
            Request request = new Request
            {
                Operation = Operation.KreirajMusteriju,
                Argument = musterija
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            if (!string.IsNullOrEmpty(response.ExceptionMessage))
                throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<int>(response.Result);
        }

        public List<Musterija> VratiSveMusterije()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveMusterije
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Musterija>>(response.Result);
        }

        public Response IzmeniMusteriju(Musterija musterija)
        {
            Request request = new Request
            {
                Operation = Operation.IzmeniMusteriju,
                Argument = musterija
            };

            serializer.Send(request);
            return serializer.Receive<Response>();
        }

        public Response ObrisiMusteriju(Musterija musterija)
        {
            Request request = new Request
            {
                Operation = Operation.ObrisiMusteriju,
                Argument = musterija
            };

            serializer.Send(request);
            return serializer.Receive<Response>();
        }

        // =========================
        // PORUDZBINE
        // =========================

        public void AzurirajUkupanIznosPorudzbine(Porudzbina p)
        {
            Request req = new Request
            {
                Operation = Operation.AzurirajUkupanIznosPorudzbine,
                Argument = p
            };
            serializer.Send(req);
            Response res = serializer.Receive<Response>();
            if (!string.IsNullOrEmpty(res.ExceptionMessage))
                throw new Exception(res.ExceptionMessage);
        }
        public int KreirajPorudzbinu(Porudzbina porudzbina)
        {
            Request request = new Request
            {
                Operation = Operation.KreirajPorudzbinu,
                Argument = porudzbina
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<int>(response.Result);
        }

        public List<Porudzbina> VratiPorudzbineZaMusteriju(Musterija musterija)
        {
            Request request = new Request
            {
                Operation = Operation.VratiPorudzbineZaMusteriju,
                Argument = musterija
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Porudzbina>>(response.Result);
        }

        public Response ObrisiPorudzbinu(Porudzbina porudzbina)
        {
            Request request = new Request
            {
                Operation = Operation.ObrisiPorudzbinu,
                Argument = porudzbina
            };

            serializer.Send(request);
            return serializer.Receive<Response>();
        }

        public List<Porudzbina> PretraziPorudzbine(Porudzbina kriterijum)
        {
            Request request = new Request
            {
                Operation = Operation.PretraziPorudzbine,
                Argument = kriterijum
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Porudzbina>>(response.Result);
        }

        public void SacuvajIzmenePorudzbine(Porudzbina porudzbina)
        {
            Request request = new Request
            {
                Operation = Operation.SacuvajIzmenePorudzbine,
                Argument = porudzbina
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            if (!string.IsNullOrEmpty(response.ExceptionMessage))
                throw new Exception(response.ExceptionMessage);
        }
        // =========================
        // STAVKE PORUDZBINE
        // =========================
        public Response SacuvajStavkePorudzbine(List<StavkaPorudzbine> stavke)
        {
            Request request = new Request
            {
                Operation = Operation.SacuvajStavkePorudzbine,
                Argument = stavke
            };

            serializer.Send(request);
            return serializer.Receive<Response>();
        }

        public List<StavkaPorudzbine> VratiStavkePorudzbine(Porudzbina porudzbina)
        {
            Request request = new Request
            {
                Operation = Operation.VratiStavkePorudzbine,
                Argument = porudzbina
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<StavkaPorudzbine>>(response.Result);
        }

        // =========================
        // SIFARNICI
        // =========================
        public List<Grad> VratiSveGradove()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveGradove
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<Grad>>(response.Result);
        }

        public List<StrucnaSprema> VratiSveStrucneSpreme()
        {
            Request request = new Request
            {
                Operation = Operation.VratiSveStrucneSpreme
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            return serializer.ReadType<List<StrucnaSprema>>(response.Result) ?? new List<StrucnaSprema>();
        }

        public int KreirajStrucnuSpremu(StrucnaSprema strucnaSprema)
        {
            Request request = new Request
            {
                Operation = Operation.KreirajStrucnuSpremu,
                Argument = strucnaSprema
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            if (!string.IsNullOrEmpty(response.ExceptionMessage))
                throw new Exception(response.ExceptionMessage);

            return serializer.ReadType<int>(response.Result);
        }

        public void DodajStrucnuSpremuProdavcu(PrSs veza)
        {
            Request request = new Request
            {
                Operation = Operation.DodajStrucnuSpremuProdavcu,
                Argument = veza
            };

            serializer.Send(request);
            Response response = serializer.Receive<Response>();
            if (!string.IsNullOrEmpty(response.ExceptionMessage))
                throw new Exception(response.ExceptionMessage);
        }
    }
}
