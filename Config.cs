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
                        MinecraftServer server = new MinecraftServer(name, path);
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
                    MinecraftServer.ServerList.Clear();
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
                        MinecraftServer server = new MinecraftServer(name, path);
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
                MinecraftServer.ServerList = JsonConvert.DeserializeObject<List<MinecraftServer>>(json);
            }
        }
        public static void ReloadConfigJson()
        {
            if (File.Exists("config.json"))
            {
                MinecraftServer.ServerList.Clear();
                string json = File.ReadAllText("config.json");
                MinecraftServer.ServerList = JsonConvert.DeserializeObject<List<MinecraftServer>>(json);
            }
        }
    }
    class MinecraftServer
    {
        public static List<MinecraftServer> ServerList = new List<MinecraftServer>();
        public string Name { get; set; }
        public string Path { get; set; }

        public MinecraftServer(string name , string path, string description = "")
        {
            this.Name = name;
            this.Path = path;
            ServerList.Add(this);
        }

        public static void LoopList() // DEBUG ONLY 
        {
            foreach (MinecraftServer server in ServerList)
            {
               // DEBUG ONLY Console.WriteLine("Writing " + server.Name + " " + server.Path);
            }
        }
    }
}
