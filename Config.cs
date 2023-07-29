using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
    }
    class MinecraftServer
    {
        public static List<MinecraftServer> ServerList = new List<MinecraftServer>();
        public string Name { get; set; }
        public string Path { get; set; }

        public MinecraftServer(string name , string path)
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
