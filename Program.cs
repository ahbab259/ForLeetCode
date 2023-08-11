using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLeetCode
{
    class Program
    {
        static int LengthOfLastWord(string s)
        {
            //string[] words = s.Split(' ');
            //List<string> wordS = words.Where(c => c.Length == 0).FirstOrDefault().Remove(0,0).ToList();
            s = s.Trim();
            List<string> words = s.Split(' ').Where(c=> c.Length > 0).ToList();
            return words[words.Count() - 1].Length;
        }
        static void Main(string[] args)
        {
            string s = "Hello  World   ";
            int result = LengthOfLastWord(s);
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
