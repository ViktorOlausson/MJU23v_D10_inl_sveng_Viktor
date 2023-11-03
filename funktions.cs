using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJU23v_D10_inl_sveng
{
    public class funktions
    {
        public static List<SweEngGloss> dictionary;
        public class SweEngGloss
        {
            public string word_swe, word_eng;
            public SweEngGloss(string word_swe, string word_eng)
            {
                this.word_swe = word_swe; this.word_eng = word_eng;
            }
            public SweEngGloss(string line)
            {
                string[] words = line.Split('|');
                this.word_swe = words[0]; this.word_eng = words[1];
            }
        }
        public static void translate(string[] argument)
        {
            if (argument.Length == 2)
            {
                string word = argument[1];
                foreach (SweEngGloss gloss in dictionary)
                {
                    if (gloss.word_swe == word)
                        Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                    if (gloss.word_eng == word)
                        Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                }
            }
            else if (argument.Length == 1)
            {
                Console.WriteLine("Write word to be translated: ");
                string word = Console.ReadLine();
                foreach (SweEngGloss gloss in dictionary)
                {
                    if (gloss.word_swe == word)
                        Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                    if (gloss.word_eng == word)
                        Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                }
            }
        }
        public static void load(string defaultFile, string[] argument)
        {
            if (argument.Length == 2)
            {
                using (StreamReader sr = new StreamReader(argument[1]))
                {
                    dictionary = new List<SweEngGloss>(); // Empty it!
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        SweEngGloss gloss = new SweEngGloss(line);
                        dictionary.Add(gloss);
                        line = sr.ReadLine();
                    }
                }
            }
            else if (argument.Length == 1)
            {
                using (StreamReader sr = new StreamReader(defaultFile))
                {
                    dictionary = new List<SweEngGloss>(); // Empty it!
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        SweEngGloss gloss = new SweEngGloss(line);
                        dictionary.Add(gloss);
                        line = sr.ReadLine();
                    }
                }
            }
        }

        public static void Delete(string[] argument)
        {
            if (argument.Length == 3)
            {
                int index = -1;
                for (int i = 0; i < dictionary.Count; i++)
                {
                    SweEngGloss gloss = dictionary[i];
                    if (gloss.word_swe == argument[1] && gloss.word_eng == argument[2])
                        index = i;
                }
                dictionary.RemoveAt(index);
            }
            else if (argument.Length == 1)
            {
                Console.WriteLine("Write word in Swedish: ");
                string swedish = Console.ReadLine();
                Console.Write("Write word in English: ");
                string english = Console.ReadLine();
                int index = -1;
                for (int i = 0; i < dictionary.Count; i++)
                {
                    SweEngGloss gloss = dictionary[i];
                    if (gloss.word_swe == swedish && gloss.word_eng == english)
                        index = i;
                }
                dictionary.RemoveAt(index);//FIXME: kastar error om fel stavning
            }
        }

        public static void New(string[] argument)
        {
            if (argument.Length == 3)
            {
                dictionary.Add(new SweEngGloss(argument[1], argument[2]));
            }
            else if (argument.Length == 1)
            {
                Console.WriteLine("Write word in Swedish: ");
                string swedish = Console.ReadLine();
                Console.Write("Write word in English: ");
                string english = Console.ReadLine();
                dictionary.Add(new SweEngGloss(swedish, english));
            }
        }
    }
}
