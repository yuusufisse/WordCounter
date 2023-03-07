using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {

            //string path = "..\\oliver_twist.txt";
            string path = Environment.CurrentDirectory.Replace(@"\bin\Debug\net5.0.", "").
                Replace(@"\bin\Release\net5.0", "") + "\\";
            StreamReader sr = new StreamReader(path + "oliver_twist.txt");

            string text = System.IO.File.ReadAllText(path + "oliver_twist.txt");
            Regex reg_exp = new Regex("[^a-zA-Z0-9]");
            text = reg_exp.Replace(text, " ");
            //string[] words = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            //var word_query = (from string word in words orderby word select word).Distinct();
            //string[] result = word_query.ToArray();

            int counter = 0;
            string delim = "' ,.-!";
            string[] fields = null;
            string line = null;
            
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                line.Trim();
                fields = line.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                counter += fields.Length;
            }          
            sr.Close();
            string value = "Oliver, gentleman, Fagin, Twist, Crackit, Keyhole, funny";
            string[] array = value.Split(',', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Word frequency");
            foreach (string word in array)
                CountStringOccurrences(text, word);
            Console.WriteLine("......");
            Console.WriteLine("This is of course only a small part: there are {0} words in the book", counter);
        }
        public static void CountStringOccurrences(string text, string word)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(word, i)) != -1)
            {
                i += word.Length;
                count++;
            }     
            Console.WriteLine("{0} {1}", count, word);           
        }
    }
}
