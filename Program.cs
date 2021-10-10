using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Hänga gubben!");

            string[] words = {"perspektiv", "utveckling", "konstruktiv", "abstrakt", "bråkig", "galant",
                "utifrån", "möjlighet", "analog", "digital", "kringbyggd", "differens", "kravbild", "individ",
                "erfarenhet", "betrakta", "sammanhang", "respektive", "beskrivning", "gemensam", "kontroll",
                "medkänsla", "respekt", "altanbygge", "skaraborg", "göteborg" };
            int num = words.Length;
            Random myRd = new Random();
            var idx = myRd.Next(0, num);
            string wordToGuess = words[idx];

            int guesses = 0;
            char[] guess = new char[wordToGuess.Length];
            Console.Write("Skriv in din gissning: En bokstav eller hela ordet: ");

            StringBuilder myStrB = new();
            StringBuilder myIncorrectStrB = new();
            for (int p = 0; p < wordToGuess.Length; p++)
                guess[p] = '_';

            while (true)
            {

                bool anyChar = false;
                string userGuess = Console.ReadLine();
                bool charGuess = char.TryParse(userGuess, out char toGuess);
                AppendUserInput(userGuess, myStrB);

                if (guesses <= 10 & userGuess == wordToGuess)
                {

                    Console.WriteLine("Du vann!!! Rätt ord är: " + wordToGuess);
                    Console.ReadLine();
                    break;
                }
                else if (guesses <= 10 & charGuess)
                {
                    for (int j = 0; j < wordToGuess.Length; j++)
                    {
                        if (toGuess == wordToGuess[j])
                        { 
                            guess[j] = toGuess; 
                        }
                        for (int i = 0; i < myStrB.Length; i++)
                        {
                            if (guess[j] == myStrB[i])
                            {
                                anyChar = true;
                            }
                            else anyChar = false;
                        }
                        
                    }
                    Console.WriteLine(guess);
                    if (anyChar == false)
                    {
                        guesses++;
                        myIncorrectStrB.Append(toGuess);
                    }
                    Console.WriteLine("\nDina felaktiga gissningar är: " + myIncorrectStrB);
                }

                else if (guesses >= 9)
                {
                    Console.WriteLine("Du förlorade! Du har bara 10 gissningar.");
                    Console.WriteLine("Rätt ord var: " + wordToGuess);
                    Console.ReadLine();
                    break;

                }
            }
        }
        private static void AppendUserInput(string userGuess, StringBuilder myStrB)
        {
            myStrB.Append(userGuess);
        }
    }
    }


   
