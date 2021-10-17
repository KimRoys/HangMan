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
            Console.WriteLine("Du har 10 gissningar för att hitta ordet!");

            //Ord att välja från till programmet
            string[] words = {"test", "minne", "perspektiv", "utveckling", "konstruktiv", "abstrakt", "bråkig", "galant",
                "utifrån", "möjlighet", "analog", "digital", "kringbyggd", "differens", "kravbild", "individ",
                "erfarenhet", "betrakta", "sammanhang", "respektive", "beskrivning", "gemensam", "kontroll",
                "medkänsla", "respekt", "altanbygge", "skaraborg", "göteborg"
                };
            //räkna antal ord i urvalet för att kuna köra random på alla ingående ord
            int num = words.Length;
            Random myRd = new Random();
            var idx = myRd.Next(0, num);
            //Det valda ordet sparas till wordToGuess
            string wordToGuess = words[idx];

            //Antal gissningar startas på 0, antalet bokstäver att gissa på sätts till ordets längd
            int guesses = 0;
            char[] guess = new char[wordToGuess.Length];
            Console.Write("\nSkriv in din gissning: En bokstav eller hela ordet: ");

            //Skapar två olika instanser av StringBuilder, en till gissningarna, och en som sparar de felaktiga gissningarna
            StringBuilder myStrB = new();
            StringBuilder myIncorrectStrB = new();
            //tecknen i guess sätts till _
            for (int p = 0; p < wordToGuess.Length; p++)
                guess[p] = '_';
                        
            while (true)
            {   
                //börjar läsa in första inmatningen från anv.
                string userGuess = Console.ReadLine();
                
                //kollar om inmatn. är en bokstav eller helt ord
                bool charGuess = char.TryParse(userGuess, out char toGuess);
                //Kollar först om ordet somskrivits in är samma som det valda ordet
                if (userGuess == wordToGuess)
                {

                    Console.WriteLine("\nDu vann!!! Rätt ord är: " + wordToGuess);
                    Console.ReadLine();
                    break;
                }
                //Om det inte var rätt ord, eller bara bokstav, så fortsätter kollen med att antal gissningar inte överskridits
                else if (guesses <= 10 && charGuess)
                {
                    //kollar att bokstaven inte har gissats på förut
                    if (myIncorrectStrB.ToString().Contains(toGuess) || myStrB.ToString().Contains(toGuess))
                    {
                        Console.WriteLine($"\nDu har redan gissat på {toGuess}");
                    }
                    //Fortsätter annars att kolla om bokstaven ingår i det valda ordet
                    else if (wordToGuess.Contains(toGuess))
                    {
                        //Om det ingår så läggs bokstaven på rätt plats i guess
                        AppendUserInput(userGuess, myStrB);
                        for (int j = 0; j < wordToGuess.Length; j++)
                        {
                            if (toGuess == wordToGuess[j])
                            {
                                guess[j] = toGuess;
                            }
                        }
                        guesses++;
                    }
                    //Om bokstaven inte ingår o rätt ord så läggs den till i myIncorrectStrB
                    else
                    {
                        myIncorrectStrB.Append(toGuess);
                        guesses++;
                    }

                    //Kollar om bokstäverna som gissats på har bildat rätt ord
                    if (wordToGuess.Equals(string.Join(null, guess), StringComparison.OrdinalIgnoreCase))
                    {
                        
                        Console.WriteLine(guess);                        
                        Console.WriteLine("\nDu vann!!! Rätt ord är: " + wordToGuess);
                        Console.ReadLine();
                        break;
                    }

                    //skriver ut de bokstäver som hittills gissats på, ihop med _ för de som fattas
                    Console.WriteLine(guess);

                    //Kollar om max antal gissningar uppnåtts
                    if (guesses >= 10)
                    {
                        Console.WriteLine("\nDu förlorade! Du har bara 10 gissningar.");
                        Console.WriteLine("\nRätt ord var: " + wordToGuess);
                        Console.ReadLine();
                        break;

                    }
                    //Skriver ut antal gissningar + de felaktiga gissningarna
                    Console.WriteLine("\n\nGissning nr: " + guesses + "\nDina felaktiga gissningar är: " + myIncorrectStrB);
                    Console.WriteLine("\nSkriv in din nästa bokstav, eller hela ordet du gissar på: \n");
                }


            }
        }

        //Lägger till aktuell bokstav i StringBuilder myStrB
        private static void AppendUserInput(string userGuess, StringBuilder myStrB)
        {
            myStrB.Append(userGuess);
        }
    }
    }


   
