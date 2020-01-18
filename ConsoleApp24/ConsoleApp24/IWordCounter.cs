using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{ 
    public interface IWordCounter // 3.b
    {
        int NumberOfWords { get; } // 3.b.1

        string this[int index] { get; set; } // 3.b.2
        int NumberOfPages { get; }// 3.b.3

        
    }
}
