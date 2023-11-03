﻿namespace MJU23v_D10_inl_sveng
{
    internal class Program
    {
        
        static void Main(string[] args) //TODO: help commando
        {
            string defaultFile = "..\\..\\..\\dict\\sweeng.lis";
            Console.WriteLine("Welcome to the dictionary app!");
            do
            {
                Console.Write("> ");
                string[] argument = Console.ReadLine().Split();
                string command = argument[0];
                if (command.ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }
                else if (command.ToLower() == "load")
                {
                    funktions.load(defaultFile, argument);
                }
                else if (command.ToLower() == "list")
                {
                    foreach(funktions.SweEngGloss gloss in funktions.dictionary)//FIXME: Kastar error om inget är laddat
                    {
                        Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
                    }
                }
                else if (command.ToLower() == "new")//TODO: lägga till save för att spara nya
                {
                    funktions.New(argument);
                }
                else if (command.ToLower() == "delete")//TODO: lägga till save för spara om något ändrats
                {
                    funktions.Delete(argument);
                }
                else if (command.ToLower() == "translate")//TODO: inget händer om ordet inte finns
                {
                    funktions.translate(argument);
                }
                else
                {
                    Console.WriteLine($"Unknown command: '{command}'");
                }
            }
            while (true);

            
        }
        

        
    }
}