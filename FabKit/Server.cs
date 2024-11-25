using System.Net;
using System.Text;

namespace FabKit
{
    internal class Server
    {
        public HttpListener? Listener;
        private static HttpClient? client;
        public void StartServer()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client = new HttpClient(clientHandler);

            Listener = new HttpListener();
            Listener.Prefixes.Add(Constants.url);
            Listener.Start();

            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();

            Listener.Close();
        }

        public async Task HandleIncomingConnections()
        {
            while (true)
            {
                try
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    HttpListenerContext ctx = await Listener.GetContextAsync();

                    HttpListenerRequest req = ctx.Request;

                    var urlPath = req.Url.AbsolutePath.ToString();
                    Console.WriteLine($"request at {urlPath}");
                    HttpListenerResponse resp = ctx.Response;
                    byte[] data = [];

                    if (req.HttpMethod != "POST")
                    {
                        data = Encoding.UTF8.GetBytes(":3");
                        resp.ContentType = "text/html";
                        resp.ContentEncoding = Encoding.UTF8;
                        resp.ContentLength64 = data.LongLength;

                        await resp.OutputStream.WriteAsync(data, 0, data.Length);
                        resp.Close();
                        continue;
                    };

                    switch (urlPath)
                    {
                        case "/Client/GetUserInventory":

                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"Hijacking {urlPath} with a fake response");
                            // This is cock dick ass and I should not do it this way
                            data = Encoding.UTF8.GetBytes("{\"code\":200,\"status\":\"OK\",\"data\":{\"Inventory\":[{\"ItemId\":\"LBAAK.\",\"ItemInstanceId\":\"43B135A09472E71D\",\"PurchaseDate\":\"2024-08-17T19:11:25.458Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"MOD STICK\"},{\"ItemId\":\"LHAAC.\",\"ItemInstanceId\":\"43B135A09472E71D\",\"PurchaseDate\":\"2024-08-17T19:11:25.458Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"PARTY HAT\",\"UnitCurrency\":\"SR\",\"UnitPrice\":500},{\"ItemId\":\"LBAGY.\",\"ItemInstanceId\":\"99C88F8073D4CD\",\"PurchaseDate\":\"2024-07-26T18:07:21.961Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAGY.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LMAJA.\",\"ItemInstanceId\":\"3DA496073A0155CD\",\"PurchaseDate\":\"2024-07-16T17:58:16.788Z\",\"Annotation\":\"Granted via Game Manager\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAJA.\",\"UnitPrice\":0},{\"ItemId\":\"LBAGT.\",\"ItemInstanceId\":\"C8188A7039E07E9D\",\"PurchaseDate\":\"2024-06-28T17:13:16.647Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAGT.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LMABD.\",\"ItemInstanceId\":\"8F6DE2D4AFF1DC8A\",\"PurchaseDate\":\"2024-06-26T17:29:05.248Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"PINK DONUT BALLOON\",\"UnitCurrency\":\"SR\",\"UnitPrice\":2500},{\"ItemId\":\"LMAJT.\",\"ItemInstanceId\":\"939ADEF82159530E\",\"PurchaseDate\":\"2024-06-02T16:17:43.763Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAJT.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":3500},{\"ItemId\":\"LBAGP.\",\"ItemInstanceId\":\"BE9D16DA2953AC07\",\"PurchaseDate\":\"2024-06-02T16:11:07.714Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAGP.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LBAGO.\",\"ItemInstanceId\":\"9C7B96029B210151\",\"PurchaseDate\":\"2024-06-02T16:11:07.714Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAGO.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LBAGN.\",\"ItemInstanceId\":\"7C1513F9A71156AF\",\"PurchaseDate\":\"2024-06-02T16:11:07.713Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAGN.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LBAGE.\",\"ItemInstanceId\":\"5B793EC2F3D56932\",\"PurchaseDate\":\"2024-05-09T22:15:58.104Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAGE.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LMAJH.\",\"ItemInstanceId\":\"128133F3ED134AED\",\"PurchaseDate\":\"2024-04-06T04:40:47.343Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAJH.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":5000},{\"ItemId\":\"LBAGD.\",\"ItemInstanceId\":\"F833257E7EBFEB4B\",\"PurchaseDate\":\"2024-04-05T23:50:08.306Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAGD.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LBAFV.\",\"ItemInstanceId\":\"9BA94A49F8FE1D2\",\"PurchaseDate\":\"2024-03-08T21:00:35.616Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAFV.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LBAFW.\",\"ItemInstanceId\":\"625E47A21120475E\",\"PurchaseDate\":\"2024-03-08T20:09:30.097Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAFW.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":2200},{\"ItemId\":\"LMADC.\",\"ItemInstanceId\":\"7EFCA84D51FFE787\",\"PurchaseDate\":\"2024-03-01T00:01:45.493Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMADC.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":5000},{\"ItemId\":\"LMAII.\",\"ItemInstanceId\":\"F17094A6E5C4DF28\",\"PurchaseDate\":\"2024-02-23T18:19:22.992Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAII.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":5000},{\"ItemId\":\"LBAFL.\",\"ItemInstanceId\":\"6C5458648B24F59E\",\"PurchaseDate\":\"2024-02-09T22:16:44.336Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAFL.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LBAFN.\",\"ItemInstanceId\":\"182793A604895437\",\"PurchaseDate\":\"2024-02-09T22:16:19.045Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAFN.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LMAIL.\",\"ItemInstanceId\":\"A51EF8FA4D624348\",\"PurchaseDate\":\"2024-02-09T22:16:12.903Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAIL.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LMACM.\",\"ItemInstanceId\":\"380A00F0187F2C4B\",\"PurchaseDate\":\"2024-01-28T01:39:45.81Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMACM.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":3000},{\"ItemId\":\"LBAAT.\",\"ItemInstanceId\":\"EFC4C82F45780306\",\"PurchaseDate\":\"2024-01-26T22:28:42.93Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"ICICLE\",\"UnitCurrency\":\"SR\",\"UnitPrice\":4500},{\"ItemId\":\"LFABB.\",\"ItemInstanceId\":\"468C999B05D61E3\",\"PurchaseDate\":\"2024-01-26T21:55:26.81Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"ROSY CHEEKS\",\"UnitCurrency\":\"SR\",\"UnitPrice\":2000},{\"ItemId\":\"LBAET.\",\"ItemInstanceId\":\"A00E8708210D1943\",\"PurchaseDate\":\"2024-01-14T01:42:54.205Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAET.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LBAAR.\",\"ItemInstanceId\":\"EAC1FEC81690B2FE\",\"PurchaseDate\":\"2024-01-02T20:31:09.314Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"CANDY CANE\",\"UnitCurrency\":\"SR\",\"UnitPrice\":4000},{\"ItemId\":\"LBAEO.\",\"ItemInstanceId\":\"BB6E365AF6BD4D33\",\"PurchaseDate\":\"2023-12-01T18:58:56.008Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAEO.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LFAAW.\",\"ItemInstanceId\":\"A6343C2BBA54A248\",\"PurchaseDate\":\"2023-11-18T17:54:32.812Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"FACE SCARF\",\"UnitCurrency\":\"SR\",\"UnitPrice\":2000},{\"ItemId\":\"LBAAP.\",\"ItemInstanceId\":\"D43AAF7060FD1A7F\",\"PurchaseDate\":\"2023-11-18T05:24:26.469Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"TURKEY LEG\",\"UnitCurrency\":\"SR\",\"UnitPrice\":3500},{\"ItemId\":\"LBAEN.\",\"ItemInstanceId\":\"F46D4E323A105CAF\",\"PurchaseDate\":\"2023-11-12T11:22:38.371Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAEN.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":2000},{\"ItemId\":\"LBAAN.\",\"ItemInstanceId\":\"42B545EFCC158E11\",\"PurchaseDate\":\"2023-10-20T17:32:23.036Z\",\"CatalogVersion\":\"DLC\",\"BundleParent\":\"51132BE51D8CC547\",\"DisplayName\":\"WEREWOLF CLAWS\",\"UnitPrice\":0},{\"ItemId\":\"LSAAC.\",\"ItemInstanceId\":\"51132BE51D8CC547\",\"PurchaseDate\":\"2023-10-20T17:32:23.036Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"WEREWOLF SET\",\"UnitCurrency\":\"SR\",\"UnitPrice\":4500,\"BundleContents\":[\"LHAAX.\",\"LFAAT.\",\"LBAAN.\"]},{\"ItemId\":\"LFAAT.\",\"ItemInstanceId\":\"A6E707F37B5F0B54\",\"PurchaseDate\":\"2023-10-20T17:32:23.036Z\",\"CatalogVersion\":\"DLC\",\"BundleParent\":\"51132BE51D8CC547\",\"DisplayName\":\"WEREWOLF FACE\",\"UnitPrice\":0},{\"ItemId\":\"LHAAX.\",\"ItemInstanceId\":\"DEC4BD71BF06CB55\",\"PurchaseDate\":\"2023-10-20T17:32:23.036Z\",\"CatalogVersion\":\"DLC\",\"BundleParent\":\"51132BE51D8CC547\",\"DisplayName\":\"WEREWOLF EARS\",\"UnitPrice\":0},{\"ItemId\":\"LFADF.\",\"ItemInstanceId\":\"F8129836B6E99DED\",\"PurchaseDate\":\"2023-10-15T22:59:56.291Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LFADF.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LMAGJ.\",\"ItemInstanceId\":\"E238D16E9BC7C016\",\"PurchaseDate\":\"2023-09-26T06:00:27.261Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAGJ.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":5000},{\"ItemId\":\"LMAGH.\",\"ItemInstanceId\":\"50C85F811C3ACB5\",\"PurchaseDate\":\"2023-09-26T05:59:49.381Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAGH.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":4500},{\"ItemId\":\"LBAEB.\",\"ItemInstanceId\":\"7E64C12BF95C9CBC\",\"PurchaseDate\":\"2023-09-23T17:00:18.604Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAEB.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LMAGG.\",\"ItemInstanceId\":\"88E7D0FC86E83001\",\"PurchaseDate\":\"2023-09-23T06:15:58.775Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAGG.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":3200},{\"ItemId\":\"LBAEA.\",\"ItemInstanceId\":\"1386266BD69454BF\",\"PurchaseDate\":\"2023-09-23T00:35:32.295Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBAEA.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LFAAJ.\",\"ItemInstanceId\":\"C756118C1AF006B6\",\"PurchaseDate\":\"2023-09-13T09:34:23.851Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"DOUBLE EYEPATCH\",\"UnitCurrency\":\"SR\",\"UnitPrice\":1000},{\"ItemId\":\"LMABV.\",\"ItemInstanceId\":\"6BE6E0D7D1DDD33A\",\"PurchaseDate\":\"2023-09-08T05:05:13.268Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMABV.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":5000},{\"ItemId\":\"LBADB.\",\"ItemInstanceId\":\"7CC36F0D0D035DBD\",\"PurchaseDate\":\"2023-09-03T02:58:05.752Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBADB.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LMAFL.\",\"ItemInstanceId\":\"7D4CAD658B53D438\",\"PurchaseDate\":\"2023-08-19T22:33:20.988Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LMAFL.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":5000},{\"ItemId\":\"LBADS.\",\"ItemInstanceId\":\"E1EFB91D22A7EA02\",\"PurchaseDate\":\"2023-08-19T18:46:31.673Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LBADS.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":0},{\"ItemId\":\"LFAAC.\",\"ItemInstanceId\":\"A09B204164DE4E41\",\"PurchaseDate\":\"2023-08-19T18:40:53.085Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"BASIC EARRINGS\",\"UnitCurrency\":\"SR\",\"UnitPrice\":1000},{\"ItemId\":\"LHAAB.\",\"ItemInstanceId\":\"1D097942605A573\",\"PurchaseDate\":\"2023-01-02T11:17:50.792Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"CAT EARS\",\"UnitCurrency\":\"SR\",\"UnitPrice\":1000},{\"ItemId\":\"LFABX.\",\"ItemInstanceId\":\"77CAA4AB706177FB\",\"PurchaseDate\":\"2023-01-02T08:46:24.041Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"LFABX.\",\"UnitCurrency\":\"SR\",\"UnitPrice\":100},{\"ItemId\":\"LMAAT.\",\"ItemInstanceId\":\"D7F488B90812D3C9\",\"PurchaseDate\":\"2022-11-04T06:06:46.912Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"HEART BALLOON\",\"UnitCurrency\":\"SR\",\"UnitPrice\":1500},{\"ItemId\":\"LHAAR.\",\"ItemInstanceId\":\"1041E853D60B0EE9\",\"PurchaseDate\":\"2022-10-01T08:23:28.061Z\",\"CatalogVersion\":\"DLC\",\"DisplayName\":\"WHITE FEDORA\",\"UnitCurrency\":\"SR\",\"UnitPrice\":1500}],\"VirtualCurrency\":{\"SR\":420133727,\"TC\":100},\"VirtualCurrencyRechargeTimes\":{}}}");
                            //Console.WriteLine($"Returning: {Encoding.UTF8.GetString(data)}");
                            resp.ContentType = "application/json";
                            resp.ContentEncoding = Encoding.UTF8;
                            await resp.OutputStream.WriteAsync(data, 0, data.Length);
                            resp.Close();
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"No hijack for {urlPath} - passing to PlayFab");

                            StreamReader reader = new StreamReader(req.InputStream);
                            var reqData = reader.ReadToEnd();

                            //Console.WriteLine($"Req data: {reqData}");
                            client.DefaultRequestHeaders.Clear();
                            foreach (var key in req.Headers.AllKeys)
                            {
                                var value = req.Headers[key];
                                if (key == "X-Authorization" || key == "X-Entitytoken" || key == "Content-Type" || key == "User-Agent" || key == "Accept")
                                {
                                    client.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
                                }

                            }
                            
                            var content = new StringContent(reqData, Encoding.UTF8, req.ContentType);
                            var response = await client.PostAsync($"https://{Constants.TitleId}.playfabapi.com{urlPath}", content);
                            var responseBody = await response.Content.ReadAsStringAsync();
                            //Console.WriteLine($"Returning: {responseBody}");
                            resp.ContentType = "application/json";
                            resp.ContentEncoding = Encoding.UTF8;
                            await resp.OutputStream.WriteAsync(Encoding.UTF8.GetBytes(responseBody), 0, responseBody.Length);
                            resp.Close();
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
