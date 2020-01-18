using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class WordFile : MyFile, IWordCounter,ISpecificWordCount //3
    {
        public string MyText { get;protected set; } // text 3.a
        public string[] numWords;

        Dictionary<string, int> words = new Dictionary<string, int>(); // 12


        public WordFile(string myText, string filePath, int FileSize, bool IsReadOnly, bool IsZipped) : base(filePath, FileSize, IsReadOnly, IsZipped)
        {
            this.MyText = myText; //3.a
            string[] numWords = myText.Split(new char[] { ' ' });
            // 12
            words.Add(numWords[0], 1);
            for (int i = 1; i < numWords.Length; i++)
            {
                if (words.ContainsKey(numWords[i]))
                {
                    words[numWords[i]] += 1;
                }
                else
                    words.Add(numWords[i], 1);
            }
        }

        public int NumberOfWords // return number of words in MyText  //3.b
        {
            get
            {
                return numWords.Length;
            }
        }
        public int NumberOfPages// return number of pages //3.b
        {
            get
            {
                return (numWords.Length % 2 == 0) ? (numWords.Length / 10) : (numWords.Length / 10 + 1);
            }
        }

        string IWordCounter.this[int index]  // indexer get number return word //3.b
        {
            get
            {
                return numWords[index];
            }
            set
            {

            }
        }

        public override void PrintFile()// print every word in single row //3.c
        {
            foreach (var item in numWords)
            {
                Console.WriteLine(item);
            }
        }


        public static bool operator ==(WordFile f1, WordFile f2)// 10
        {
            
            if (ReferenceEquals(f1.MyText, null) && ReferenceEquals(f2.MyText, null))
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

        public static bool operator !=(WordFile p1, WordFile p2)//10
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj) //10
        {
            WordFile eqfile = obj as WordFile;
            return this == eqfile;
        }
        public override int GetHashCode() // to check //10
        {
            int HasCode = MyText.Length;
            return HasCode;// to check
        }



        public static WordFile operator +(WordFile p1, WordFile p2) // 11
        {
            if (p1.FileSize > p2.FileSize)
            {
                string newpath = (p1.filePath + ".mrg");
                WordFile AddedFile = new WordFile(p1.MyText+p2.MyText, newpath, p1.FileSize + p2.FileSize, p1.IsReadOnly, p1.IsZipped);
                return AddedFile;

            }
            else
            {
                string newpath = (p2.filePath + ".mrg");
                WordFile AddedFile = new WordFile(p1.MyText + p2.MyText, newpath, p1.FileSize + p2.FileSize, p2.IsReadOnly, p2.IsZipped);
                return AddedFile;
            }
        }

        public int GetSpecificWordCount (string word) //12
        {
            if (words.TryGetValue(word, out int value))
            {
                Console.WriteLine($"The word {word} appears {value} times");
                return words[word];
            }
            else
                return 0;
        }
       

      

    }


}