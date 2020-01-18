using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileManager
{
    public class InfectedFileDetectedException : Exception //7
    {
        public InfectedFileDetectedException(string pathfile)
        {
            string PathFile = pathfile;
        }

        public InfectedFileDetectedException(string message, string pathfile) : base(message)
        {
        }

        public InfectedFileDetectedException(string message, Exception innerException, string pathfile) : base(message, innerException)
        {
        }

     
    }
}
