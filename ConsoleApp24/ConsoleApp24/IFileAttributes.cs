using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
     interface IFileAttributes //2.d.6
    {
        int FileSize { get; }
        bool IsReadOnly { get; }
        bool IsZipped { get; }
        bool IsVirus { get; }

    }
}
