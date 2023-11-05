using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MCBACKUPGENERATOR
{
    class Config
    {
        public static void LoadConfig()
        {
            StreamReader reader = null;
            if (File.Exists("config.txt"))
            {
                try
                {
                    reader = new StreamReader("config.txt");
                    string radek = "";
                    while ((radek = reader.ReadLine()) != null)
                    {
                        /*if (reader.ReadLine().StartsWith("#"))
                        {
                            break;
                        }*/

                        string[] hodnoty = radek.Split(';');
                        string name = hodnoty[0];
                        string path = hodnoty[1];
                        Server server = new Server(name, path, "");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error : " + e);
                }
                finally
                {
                    reader.Close();
                }
            } 
            else
            {
                Console.WriteLine("Config File Does not exist");
            }
        }
        public static void ReloadConfig()
        {
            StreamReader reader = null;
            if (File.Exists("config.txt"))
            {
                try
                {
                    Server.ServerList.Clear();
                    reader = new StreamReader("config.txt");
                    string radek = "";
                    while ((radek = reader.ReadLine()) != null)
                    {
                        /*if (reader.ReadLine().StartsWith("#"))
                        {
                            break;
                        }*/

                        string[] hodnoty = radek.Split(';');
                        string name = hodnoty[0];
                        string path = hodnoty[1];
                        Server server = new Server(name, path, "");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error : " + e);
                }
                finally
                {
                    reader.Close();
                }
            }
            else
            {
                Console.WriteLine("Config File Does not exist");
            }
        }
        public static void LoadConfigJson()
        {
            if (File.Exists("config.json"))
            {
                string json = File.ReadAllText("config.json");
                Server.ServerList = JsonConvert.DeserializeObject<List<Server>>(json);
            }
        }
        public static void ReloadConfigJson()
        {
            if (File.Exists("config.json"))
            {
                Server.ServerList.Clear();
                string json = File.ReadAllText("config.json");
                Server.ServerList = JsonConvert.DeserializeObject<List<Server>>(json);
            }
        }
    }
    class Server
    {
        public static List<Server> ServerList = new List<Server>();
        public string Name { get; set; }
        public string Path { get; set; }
        public string Service { get; private set; }

        public Server(string name , string path, string service, string description = "")
        {
            this.Name = name;
            this.Path = path;
            this.Service = service;
            ServerList.Add(this);
        }

        public static void LoopList() // DEBUG ONLY 
        {
            foreach (Server server in ServerList)
            {
               // DEBUG ONLY Console.WriteLine("Writing " + server.Name + " " + server.Path);
            }
        }
    }
}
