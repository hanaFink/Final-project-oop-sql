using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{

        public abstract class MyFile : IFileAttributes,IComparable<MyFile>
        {
        public readonly string filePath;//2.a

            const bool HEBREWFILE = true;// 2.b
            public int FileSize { get; private set; }//2.d.1
            public bool IsReadOnly { get; private set; }//2.d.2
            public bool IsZipped { get; private set; }//2.d.3
            public bool IsVirus { get; private set; }//2.d.4

            static List<string> paths = new List<string>();//2.e


        public MyFile(string filePath, int FileSize, bool IsReadOnly, bool IsZipped)
            {
                this.filePath = filePath;
                this.FileSize = FileSize; //2.d.5
                this.IsReadOnly = IsReadOnly;//2.d.5
                this.IsZipped = IsZipped;//2.d.5
                paths.Add(filePath); //2.e


                IsVirus = VirusScanner.IsfileInfected(FileSize); // check is file is virus infected //6
                if (IsVirus == true)
                {
                    throw new InfectedFileDetectedException(filePath); // if file is infected throw exception//7
                }

            }

            abstract public void PrintFile(); // 2.c


        public static bool operator ==(MyFile f1, MyFile f2)// 10
        {

            if (ReferenceEquals(f1.filePath, null) && ReferenceEquals(f2.filePath, null))
            {
                return true;
            }

            if (ReferenceEquals(f1, null) || ReferenceEquals(f2, null))
            {
                return false;
            }

            if (f1.filePath == f2.filePath && f1.filePath == f2.filePath)
                return true;

            return false;
        }

        public static bool operator !=(MyFile p1, MyFile p2)//10
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj) //10
        {
            MyFile eqfile = obj as MyFile;
            return this == eqfile;
        }
        public override int GetHashCode() // to check //10
        {

            int HasCode = filePath.Length;
            return   HasCode;// to check
        }


        public int CompareTo(MyFile other)//sort by FileSize(default)  //8
        {
            return this.FileSize - other.FileSize;
        }

        

        }
    public class CompareByPath : IComparer<MyFile> //8
    {
        public int Compare(MyFile x, MyFile y)
        {
            return x.filePath.Length - y.filePath.Length;

        }
    }
}

