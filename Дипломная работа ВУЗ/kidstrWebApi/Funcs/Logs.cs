using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using kidstrWebApi.Models;

namespace kidstrWebApi.Funcs
{
    public static class Logs
    {
        public static void AddLog(string current, string action, string table)
        {
            Directory.CreateDirectory("Logs");
            using (StreamWriter writer = File.AppendText("Logs/logfile.txt"))
            {
                writer.WriteLine($"{DateTime.UtcNow.AddHours(3)} : User {current} {action} 1 row to {table}");
            }
        }
        public static void Login(string current)
        {
            Directory.CreateDirectory("Logs");
            using (StreamWriter writer = File.AppendText("Logs/logfile.txt"))
            {
                writer.WriteLine($"{DateTime.UtcNow.AddHours(3)} : User {current} log in");
            }
        }
    }
}
