using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class ImageFile<T> : MyFile
    {
        public T [,] Colors { get; set; } // Two-dimensional Arrays Property
        
        public ImageFile(string filePath, int FileSize, bool IsReadOnly, bool IsZipped, T [,] Colors) : base(filePath, FileSize, IsReadOnly, IsZipped)
        {
            this.Colors = Colors;
        }

        public override void PrintFile() // print every row separate 
        {
            for (int i = 0; i < Colors.GetLength(0); i++)
            {
                for (int j = 0; j < Colors.GetLength(1); j++)
                {
                    Console.Write(Colors[i, j]);
                }

                Console.WriteLine();
            }

        }
    }
}
    