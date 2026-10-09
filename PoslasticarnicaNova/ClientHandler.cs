using Common; // ako ti je JsonNetworkSerializer u namespace Common
using Common.Communication;
using Common.Domain;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    public class ClientHandler
    {
        private readonly JsonNetworkSerializer serializer;
        private readonly Socket socket;
        private readonly Server server;

        public ClientHandler(Socket socket, Server server)
        {
            this.socket = socket;
            this.server = server;
            serializer = new JsonNetworkSerializer(socket);
        }

        public void HandleRequests()
        {
            try
            {
                while (true)
                {
                    Request req = serializer.Receive<Request>();
                    Response res = ProcessRequest(req);
                    serializer.Send(res);
                }
            }
            catch (SocketException)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta (SocketException).");
            }
            catch (IOException)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta (IOException).");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Neocekivana greska u ClientHandler: " + ex.Message);
            }
            finally
            {
                try
                {
                    if (socket.Connected)
                        socket.Close();
                }
                catch { /* ignore */ }

                server.RemoveClient(this);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response r = new Response();

            try
            {
                switch (req.Operation)
                {
                    // =========================
                    // AUTH
                    // =========================
                    case Operation.LoginProdavac:
                        r.Result = Controller.Instance.LoginProdavac(
                            serializer.ReadType<Prodavac>(req.Argument)
                        );
                        break;

                    case Operation.VratiSveProdavce:
                        r.Result = Controller.Instance.VratiSveProdavce();
                        break;

                    // =========================
                    // SIFARNICI
                    // =========================
                    case Operation.VratiSveGradove:
                        r.Result = Controller.Instance.VratiSveGradove();
                        break;

                    case Operation.VratiSveStrucneSpreme:
                        r.Result = Controller.Instance.VratiSveStrucneSpreme();
                        break;

                    case Operation.KreirajStrucnuSpremu:
                        r.Result = Controller.Instance.KreirajStrucnuSpremu(
                            serializer.ReadType<StrucnaSprema>(req.Argument)
                        );
                        break;

                    case Operation.DodajStrucnuSpremuProdavcu:
                        Controller.Instance.DodajStrucnuSpremuProdavcu(
                            serializer.ReadType<PrSs>(req.Argument)
                        );
                        r.Result = true;
                        break;

                    // =========================
                    // POSLASTICE
                    // =========================
                    case Operation.KreirajPoslasticu:
                        r.Result = Controller.Instance.KreirajPoslasticu(
                            serializer.ReadType<Poslastica>(req.Argument)
                        );
                        break;

                    case Operation.VratiSvePoslastice:
                        r.Result = Controller.Instance.VratiSvePoslastice();
                        break;

                    // =========================
                    // MUSTERIJE
                    // =========================
                    case Operation.KreirajMusteriju:
                        r.Result = Controller.Instance.KreirajMusteriju(
                            serializer.ReadType<Musterija>(req.Argument)
                        );
                        break;

                    case Operation.VratiSveMusterije:
                        r.Result = Controller.Instance.VratiSveMusterije();
                        break;

                    case Operation.IzmeniMusteriju:
                        Controller.Instance.IzmeniMusteriju(
                            serializer.ReadType<Musterija>(req.Argument)
                        );
                        r.Result = true;
                        break;

                    case Operation.ObrisiMusteriju:
                        Controller.Instance.ObrisiMusteriju(
                            serializer.ReadType<Musterija>(req.Argument)
                        );
                        r.Result = true;
                        break;

                    // =========================
                    // PORUDZBINE
                    // =========================
                    case Operation.KreirajPorudzbinu:
                        // Očekuje se da Porudzbina ima List<StavkaPorudzbine> Stavke
                        r.Result = Controller.Instance.KreirajPorudzbinu(
                            serializer.ReadType<Porudzbina>(req.Argument)
                        );
                        break;

                    case Operation.VratiPorudzbineZaMusteriju:
                        r.Result = Controller.Instance.VratiPorudzbineZaMusteriju(
                            serializer.ReadType<Musterija>(req.Argument)
                        );
                        break;

                    case Operation.ObrisiPorudzbinu:
                        Controller.Instance.ObrisiPorudzbinu(
                            serializer.ReadType<Porudzbina>(req.Argument)
                        );
                        r.Result = true;
                        break;

                    case Operation.AzurirajUkupanIznosPorudzbine:
                        Controller.Instance.AzurirajUkupanIznosPorudzbine(serializer.ReadType<Porudzbina>(req.Argument));
                        break;
                    case Operation.PretraziPorudzbine:
                        r.Result = Controller.Instance.PretraziPorudzbine(
                            serializer.ReadType<Porudzbina>(req.Argument)
                        );
                        break;

                    case Operation.SacuvajIzmenePorudzbine:
                        Controller.Instance.SacuvajIzmenePorudzbine(
                            serializer.ReadType<Porudzbina>(req.Argument)
                        );
                        r.Result = true;
                        break;

                    // =========================
                    // STAVKE PORUDZBINE
                    // =========================
                    case Operation.SacuvajStavkePorudzbine:
                        Controller.Instance.SacuvajStavkePorudzbine(
                            serializer.ReadType<System.Collections.Generic.List<StavkaPorudzbine>>(req.Argument)
                        );
                        r.Result = true;
                        break;

                    case Operation.VratiStavkePorudzbine:
                        // Argument može biti Porudzbina, a Controller pravi kriterijum
                        r.Result = Controller.Instance.VratiStavkePorudzbine(
                            serializer.ReadType<Porudzbina>(req.Argument)
                        );
                        break;

                    default:
                        throw new InvalidOperationException($"Nepoznata operacija: {req.Operation}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                r.ExceptionMessage = ex.Message;
                r.Result = null;
            }

            return r;
        }

        internal void CloseSocket()
        {
            try { socket.Close(); } catch { /* ignore */ }
        }
    }
}
