using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TestRequest
{
    class Program
    {
        
        static int mainMenu()
        {
            Console.WriteLine("Escolha a opção pretendida:");
            Console.WriteLine("1 --> Portugal");
            Console.WriteLine("2 --> FIFA");
            Console.WriteLine("3 --> Alemanha");
            Console.WriteLine("0 --> Sair");
            
            
            bool safeGuard = true;
            int option = -1;
            while (safeGuard)
            {
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    safeGuard = false;
                }
                catch (FormatException FE)
                {
                    Console.WriteLine("Opção Inválida! " + FE.Message);
                }
            }
            
            return option;
        }
        
        static int portugalMenu()
        {
            Console.WriteLine("Escolha a opção pretendida:");
            Console.WriteLine("1 --> Primeira Liga - Portuguesa");
            Console.WriteLine("0 --> Sair");

            bool safeGuard = true;
            int option2 = -1;
            while (safeGuard)
            {
                try
                {
                    option2 = Convert.ToInt32(Console.ReadLine());
                    safeGuard = false;
                }
                catch (FormatException FE)
                {
                    Console.WriteLine("Opção Inválida! " + FE.Message);
                }
            }
            
            return option2;
        
        }
        static int portugalDentroMenu()
        {
            Console.WriteLine("Escolha a opção pretendida:");
            Console.WriteLine("1 --> Listar jogos");
            Console.WriteLine("2 --> Tabela classificativa");
            Console.WriteLine("0 --> Voltar");

            bool safeGuard = true;
            int option2 = -1;
            while (safeGuard)
            {
                try
                {
                    option2 = Convert.ToInt32(Console.ReadLine());
                    safeGuard = false;
                }
                catch (FormatException FE)
                {
                    Console.WriteLine("Opção Inválida! " + FE.Message);
                }
            }

            return option2;
        }
        
        static int fifaMenu()
        {
            Console.WriteLine("Escolha a opção pretendida:");
            Console.WriteLine("1 --> Campeonato do Mundo");
            Console.WriteLine("0 --> Voltar");

            bool safeGuard = true;
            int option2 = -1;
            while (safeGuard)
            {
                try
                {
                    option2 = Convert.ToInt32(Console.ReadLine());
                    safeGuard = false;
                }
                catch (FormatException FE)
                {
                    Console.WriteLine("Opção Inválida! " + FE.Message);
                }
            }

            return option2;
        }
        static int fifaDentroMenu()
        {
            Console.WriteLine("Escolha a opção pretendida:");
            Console.WriteLine("1 --> Listar jogos");
            Console.WriteLine("2 --> Tabela classificativa");
            Console.WriteLine("0 --> Voltar");

            bool safeGuard = true;
            int option2 = -1;
            while (safeGuard)
            {
                try
                {
                    option2 = Convert.ToInt32(Console.ReadLine());
                    safeGuard = false;
                }
                catch (FormatException FE)
                {
                    Console.WriteLine("Opção Inválida! " + FE.Message);
                }
            }

            return option2;
        }
        static int uefaMenu()
        {
            Console.WriteLine("Escolha a opção pretendida:");
            Console.WriteLine("1 --> Bundes Liga");
            Console.WriteLine("0 --> Voltar");
            
            bool safeGuard = true;
            int option2 = -1;
            while (safeGuard)
            {
                try
                {
                    option2 = Convert.ToInt32(Console.ReadLine());
                    safeGuard = false;
                }
                catch (FormatException FE)
                {
                    Console.WriteLine("Opção Inválida! " + FE.Message);
                }
            }

            return option2;
        }
        static int uefaDentroMenu()
        {
            Console.WriteLine("Escolha a opção pretendida:");
            Console.WriteLine("1 --> Listar jogos");
            Console.WriteLine("2 --> Tabela classificativa");
            Console.WriteLine("0 --> Voltar");

            bool safeGuard = true;
            int option2 = -1;
            while (safeGuard)
            {
                try
                {
                    option2 = Convert.ToInt32(Console.ReadLine());
                    safeGuard = false;
                }
                catch (FormatException FE)
                {
                    Console.WriteLine("Opção Inválida! " + FE.Message);
                }
            }

            return option2;
        }
        
        static void Main()
        {
            
            
            
            const string url = "http://api.football-data.org/v2/competitions/";
            const string myToken = "beeeba392ea0494881f01875c983d71e";
            string id;
            
            



            int option; 
            int option2;
            int option3;

            while ((option = mainMenu()) != 0)
            {
                switch (option)
                {
                    case 1:
                        while ((option2 = portugalMenu()) != 0)
                        {
                            switch (option2)
                            {
                                case 1:
                                    string urlPT = url + "2017";
                                    string listarPT = urlPT + "/matches";
                                    string posicaoPT = urlPT + "/standings";
                                    
                                    //1
                                    HttpWebRequest request2 = (HttpWebRequest) WebRequest.Create(listarPT);
                                    request2.Method = "GET";
                                    request2.Headers.Add("X-Auth-Token",myToken);

                                    HttpWebResponse response2 = (HttpWebResponse) request2.GetResponse();

                                    Stream responseStream2 = response2.GetResponseStream();
                                    StreamReader sr2 = new StreamReader(responseStream2);
                                    string json2 = sr2.ReadToEnd();
                                    JObject jObject2 = JObject.Parse(json2);
                                    
                                    
                                    using (StreamWriter output = new StreamWriter("portugal_matches.json"))
                                    {
                                        output.WriteLine(jObject2);
                                    }
                                    
                                    //2
                                    HttpWebRequest request3 = (HttpWebRequest) WebRequest.Create(posicaoPT);
                                    request3.Method = "GET";
                                    request3.Headers.Add("X-Auth-Token",myToken);

                                    HttpWebResponse response3 = (HttpWebResponse) request3.GetResponse();

                                    Stream responseStream3 = response3.GetResponseStream();
                                    StreamReader sr3 = new StreamReader(responseStream3);
                                    string json3 = sr3.ReadToEnd();
                                    JObject jObject3 = JObject.Parse(json3);
                                    
                                    using (StreamWriter output = new StreamWriter("portugal_posicao.json"))
                                    {
                                        output.WriteLine(jObject3);
                                    }

                                    while ((option3 = portugalDentroMenu()) != 0)
                                    {
                                        switch (option3)
                                        {
                                            case 1:
                                                int counter = Convert.ToInt32(jObject2["count"]);
                                                string homeTeam;
                                                
                                                for (int i = 0; i < counter; i++)
                                                {
                                                    homeTeam = jObject2["matches"][i]["homeTeam"]["name"].ToString();
                                                    var awayTeam = jObject2["matches"][i]["awayTeam"]["name"].ToString();
                                                    var glsHome =
                                                        jObject2["matches"][i]["score"]["fullTime"]["homeTeam"]
                                                            .ToString();
                                                    var glsAway =
                                                        jObject2["matches"][i]["score"]["fullTime"]["awayTeam"]
                                                            .ToString();

                                                    string winner;
                                                    if ((jObject2["matches"][i]["score"]["winner"]
                                                            .ToString()) == "AWAY_TEAM")
                                                    {
                                                        winner = awayTeam;
                                                    }else if ((jObject2["matches"][i]["score"]["winner"]
                                                                  .ToString()) == "HOME_TEAM")
                                                    {
                                                        winner = homeTeam;
                                                    }else if ((jObject2["matches"][i]["score"]["winner"]
                                                                  .ToString()) == "DRAW")
                                                    {
                                                        winner = "Empate";
                                                    }
                                                    else
                                                    {
                                                        winner = "Por jogar " + jObject2["matches"][i]["utcDate"].ToString();
                                                    }
                                                    
                                                    
                                                    Console.WriteLine("{0} {3} vs {4} {1} | -> {2}",  homeTeam, awayTeam, winner,glsHome,glsAway);    
                                                    Console.WriteLine("-----------------------------------");
                                                }
                                                
                                                
                                                
                                                
                                                break;
                                            case 2:   
                                                
                                                
                                                string posicao_eq, nome_eq;
                                                int jfeitos, pontos,empates,jperdidos,jganhos;
                                                
                                                Console.WriteLine("Os top 3");
                                                Console.WriteLine("Nome | Posição | Jogos Feitos | Jogos Ganhos | Empates | Jogos Perdidos | Pontos |");
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    nome_eq = jObject3["standings"][0]["table"][i]["team"]["name"].ToString();
                                                    posicao_eq = jObject3["standings"][0]["table"][i]["position"].ToString();
                                                    jfeitos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["playedGames"].ToString());
                                                    pontos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["points"].ToString());
                                                    empates = Convert.ToInt32(jObject3["standings"][0]["table"][i]["draw"].ToString());
                                                    jperdidos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["lost"].ToString());
                                                    jganhos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["won"].ToString());
                                                    
                                                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} ",  nome_eq,posicao_eq,jfeitos,jganhos,empates,jperdidos,pontos);    
                                                    Console.WriteLine("-----------------------------------");
                                                }
                                                
                                                break;
                                            default:
                                                Console.WriteLine("Opção invalida");
                                                break;
                                        }
                                    }

                                    break;
                                default:
                                    Console.WriteLine("Opção invalida");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        while ((option2 = fifaMenu()) != 0)
                        {
                            switch (option2)
                            {
                                case 1:
                                    string urlfifa = url + "2000";
                                    string listarfifa = urlfifa + "/matches";
                                    string posicaofifa = urlfifa + "/standings";
                                    
                                    //1
                                    HttpWebRequest request2 = (HttpWebRequest) WebRequest.Create(listarfifa);
                                    request2.Method = "GET";
                                    request2.Headers.Add("X-Auth-Token",myToken);

                                    HttpWebResponse response2 = (HttpWebResponse) request2.GetResponse();

                                    Stream responseStream2 = response2.GetResponseStream();
                                    StreamReader sr2 = new StreamReader(responseStream2);
                                    string json2 = sr2.ReadToEnd();
                                    JObject jObject2 = JObject.Parse(json2);
                                    
                                    
                                    using (StreamWriter output = new StreamWriter("fifa_matches.json"))
                                    {
                                        output.WriteLine(jObject2);
                                    }
                                    
                                    //2
                                    HttpWebRequest request3 = (HttpWebRequest) WebRequest.Create(posicaofifa);
                                    request3.Method = "GET";
                                    request3.Headers.Add("X-Auth-Token",myToken);

                                    HttpWebResponse response3 = (HttpWebResponse) request3.GetResponse();

                                    Stream responseStream3 = response3.GetResponseStream();
                                    StreamReader sr3 = new StreamReader(responseStream3);
                                    string json3 = sr3.ReadToEnd();
                                    JObject jObject3 = JObject.Parse(json3);
                                    
                                    using (StreamWriter output = new StreamWriter("fifa_posicao.json"))
                                    {
                                        output.WriteLine(jObject3);
                                    }

                                    while ((option3 = fifaDentroMenu()) != 0)
                                    {
                                        switch (option3)
                                        {
                                            case 1:
                                                int counter = Convert.ToInt32(jObject2["count"]);
                                                string homeTeam;
                                                
                                                for (int i = 0; i < counter; i++)
                                                {
                                                    homeTeam = jObject2["matches"][i]["homeTeam"]["name"].ToString();
                                                    var awayTeam = jObject2["matches"][i]["awayTeam"]["name"].ToString();
                                                    var glsHome =
                                                        jObject2["matches"][i]["score"]["fullTime"]["homeTeam"]
                                                            .ToString();
                                                    var glsAway =
                                                        jObject2["matches"][i]["score"]["fullTime"]["awayTeam"]
                                                            .ToString();

                                                    string winner;
                                                    if ((jObject2["matches"][i]["score"]["winner"]
                                                            .ToString()) == "AWAY_TEAM")
                                                    {
                                                        winner = awayTeam;
                                                    }else if ((jObject2["matches"][i]["score"]["winner"]
                                                                  .ToString()) == "HOME_TEAM")
                                                    {
                                                        winner = homeTeam;
                                                    }else if ((jObject2["matches"][i]["score"]["winner"]
                                                                  .ToString()) == "DRAW")
                                                    {
                                                        winner = "Empate";
                                                    }
                                                    else
                                                    {
                                                        winner = "Por jogar " + jObject2["matches"][i]["utcDate"].ToString();
                                                    }
                                                    
                                                    
                                                    Console.WriteLine("{0} {3} vs {4} {1} | -> {2}",  homeTeam, awayTeam, winner,glsHome,glsAway);    
                                                    Console.WriteLine("-----------------------------------");
                                                }
                                                
                                                
                                                
                                                
                                                break;
                                            case 2:   
                                                
                                                
                                                string posicao_eq, nome_eq;
                                                int jfeitos, pontos,empates,jperdidos,jganhos;
                                                
                                                Console.WriteLine("Os top 3");
                                                Console.WriteLine("Nome | Posição | Jogos Feitos | Jogos Ganhos | Empates | Jogos Perdidos | Pontos |");
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    nome_eq = jObject3["standings"][0]["table"][i]["team"]["name"].ToString();
                                                    posicao_eq = jObject3["standings"][0]["table"][i]["position"].ToString();
                                                    jfeitos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["playedGames"].ToString());
                                                    pontos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["points"].ToString());
                                                    empates = Convert.ToInt32(jObject3["standings"][0]["table"][i]["draw"].ToString());
                                                    jperdidos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["lost"].ToString());
                                                    jganhos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["won"].ToString());
                                                    
                                                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} ",  nome_eq,posicao_eq,jfeitos,jganhos,empates,jperdidos,pontos);    
                                                    Console.WriteLine("-----------------------------------");
                                                }
                                                
                                                break;
                                            default:
                                                Console.WriteLine("Opção invalida");
                                                break;
                                        }
                                    }

                                    break;
                                default:
                                    Console.WriteLine("Opção invalida");
                                    break;
                            }
                        }
                        break;
                    
                    case 3:
                        while ((option2 = uefaMenu()) != 0)
                        {
                            switch (option2)
                            {
                                case 1:
                                    string urluefa = url + "2002";
                                    string listaruefa = urluefa + "/matches";
                                    string posicaouefa = urluefa + "/standings";
                                    
                                    //1
                                    HttpWebRequest request2 = (HttpWebRequest) WebRequest.Create(listaruefa);
                                    request2.Method = "GET";
                                    request2.Headers.Add("X-Auth-Token",myToken);

                                    HttpWebResponse response2 = (HttpWebResponse) request2.GetResponse();

                                    Stream responseStream2 = response2.GetResponseStream();
                                    StreamReader sr2 = new StreamReader(responseStream2);
                                    string json2 = sr2.ReadToEnd();
                                    JObject jObject2 = JObject.Parse(json2);
                                    
                                    
                                    using (StreamWriter output = new StreamWriter("uefa_matches.json"))
                                    {
                                        output.WriteLine(jObject2);
                                    }
                                    
                                    //2
                                    HttpWebRequest request3 = (HttpWebRequest) WebRequest.Create(posicaouefa);
                                    request3.Method = "GET";
                                    request3.Headers.Add("X-Auth-Token",myToken);

                                    HttpWebResponse response3 = (HttpWebResponse) request3.GetResponse();

                                    Stream responseStream3 = response3.GetResponseStream();
                                    StreamReader sr3 = new StreamReader(responseStream3);
                                    string json3 = sr3.ReadToEnd();
                                    JObject jObject3 = JObject.Parse(json3);
                                    
                                    using (StreamWriter output = new StreamWriter("uefa_posicao.json"))
                                    {
                                        output.WriteLine(jObject3);
                                    }

                                    while ((option3 = uefaDentroMenu()) != 0)
                                    {
                                        switch (option3)
                                        {
                                            case 1:
                                                int counter = Convert.ToInt32(jObject2["count"]);
                                                string homeTeam;
                                                
                                                for (int i = 0; i < counter; i++)
                                                {
                                                    homeTeam = jObject2["matches"][i]["homeTeam"]["name"].ToString();
                                                    var awayTeam = jObject2["matches"][i]["awayTeam"]["name"].ToString();
                                                    var glsHome =
                                                        jObject2["matches"][i]["score"]["fullTime"]["homeTeam"]
                                                            .ToString();
                                                    var glsAway =
                                                        jObject2["matches"][i]["score"]["fullTime"]["awayTeam"]
                                                            .ToString();

                                                    string winner;
                                                    if ((jObject2["matches"][i]["score"]["winner"]
                                                            .ToString()) == "AWAY_TEAM")
                                                    {
                                                        winner = awayTeam;
                                                    }else if ((jObject2["matches"][i]["score"]["winner"]
                                                                  .ToString()) == "HOME_TEAM")
                                                    {
                                                        winner = homeTeam;
                                                    }else if ((jObject2["matches"][i]["score"]["winner"]
                                                                  .ToString()) == "DRAW")
                                                    {
                                                        winner = "Empate";
                                                    }
                                                    else
                                                    {
                                                        winner = "Por jogar " + jObject2["matches"][i]["utcDate"].ToString();
                                                    }
                                                    
                                                    
                                                    Console.WriteLine("{0} {3} vs {4} {1} | -> {2}",  homeTeam, awayTeam, winner,glsHome,glsAway);    
                                                    Console.WriteLine("-----------------------------------");
                                                }
                                                
                                                
                                                
                                                
                                                break;
                                            case 2:   
                                                
                                               
                                                string posicao_eq, nome_eq;
                                                int jfeitos, pontos,empates,jperdidos,jganhos;
                                                
                                                Console.WriteLine("Os top 3");
                                                Console.WriteLine("Nome | Posição | Jogos Feitos | Jogos Ganhos | Empates | Jogos Perdidos | Pontos |");
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    nome_eq = jObject3["standings"][0]["table"][i]["team"]["name"].ToString();
                                                    posicao_eq = jObject3["standings"][0]["table"][i]["position"].ToString();
                                                    jfeitos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["playedGames"].ToString());
                                                    pontos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["points"].ToString());
                                                    empates = Convert.ToInt32(jObject3["standings"][0]["table"][i]["draw"].ToString());
                                                    jperdidos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["lost"].ToString());
                                                    jganhos = Convert.ToInt32(jObject3["standings"][0]["table"][i]["won"].ToString());
                                                    
                                                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} ",  nome_eq,posicao_eq,jfeitos,jganhos,empates,jperdidos,pontos);    
                                                    Console.WriteLine("-----------------------------------");
                                                }
                                                
                                                break;
                                            default:
                                                Console.WriteLine("Opção invalida");
                                                break;
                                        }
                                    }

                                    break;
                                default:
                                    Console.WriteLine("Opção invalida");
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }
}