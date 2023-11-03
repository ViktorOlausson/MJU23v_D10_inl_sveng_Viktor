﻿using System;
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
                string word = argument[1].ToLower();
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
                string word = Console.ReadLine().ToLower();
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
            try
            {
                if (argument.Length == 2)
                {
                    using (StreamReader sr = new StreamReader(argument[1]))//FIXME: kastar error om inte standard, pga ligger inte under debug, funkar om man skirver in en sökväg
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
                    Console.WriteLine("Load successful!");
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
                    Console.WriteLine("Load successful!");
                }
            }catch (FileNotFoundException ex)
            {
                Console.WriteLine("file could not be loaded, file not found");
            }
            
        
    }

        public static void Delete(string[] argument)//TODO: skriva ut om Delete gick igenom
        {
            if (argument.Length == 3)
            {
                int index = -1;
                for (int i = 0; i < dictionary.Count; i++)
                {
                    SweEngGloss gloss = dictionary[i];
                    if (gloss.word_swe == argument[1].ToLower() && gloss.word_eng == argument[2].ToLower())
                        index = i;
                }
                dictionary.RemoveAt(index);
            }
            else if (argument.Length == 1)
            {
                Console.WriteLine("Write word in Swedish: ");
                string swedish = Console.ReadLine().ToLower();
                Console.Write("Write word in English: ");
                string english = Console.ReadLine().ToLower();
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
                dictionary.Add(new SweEngGloss(argument[1].ToLower(), argument[2].ToLower()));
            }
            else if (argument.Length == 1)
            {
                Console.WriteLine("Write word in Swedish: ");
                string swedish = Console.ReadLine().ToLower();
                Console.Write("Write word in English: ");
                string english = Console.ReadLine().ToLower();
                dictionary.Add(new SweEngGloss(swedish, english));
            }
        }
    }
}
