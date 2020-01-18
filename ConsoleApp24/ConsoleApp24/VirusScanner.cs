using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileManager
{
    public static class VirusScanner
    {
        static string GetKey1 { get; set; }
        static VirusScanner()
        {
            GetKey1 = ConfigurationManager.AppSettings["MalwareSize"]; //5.b
        }

        public static bool IsfileInfected(int File) //5.c
        {
            if (File == Convert.ToInt32(GetKey1))// todo GetKey1 to int , check casting
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}