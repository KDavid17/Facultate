using System;
using System.IO;

namespace HexViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool UltimaLinie = false;
            int Contor = 0;
            sbyte i, Lungime = 16;
            string Cale, Text, Bucata = "";

            try
            {
                Console.Write(" Introduceti calea spre fisier: ");
                Cale = Console.ReadLine();

                if (File.Exists(Cale))
                {
                    Console.WriteLine("\n Continutul fisierului in hexazecimal este: \n");
                }
                else
                {
                    throw new FileNotFoundException("\n Fisierul nu a fost gasit. \n");
                }

                Text = File.ReadAllText(Cale);                      // Dam string-ului "Text" textul din fisier
                                                                    // prin string-ul "Cale" care reprezinta calea
                while (Text.Length > 0)                             // spre fisier.
                {
                    Console.Write($"{Contor:X7}" + "0: ");          // Afisam pentru fiecare linie noua contorul hexa.

                    for (i = 0; i < Lungime; i++)
                    {
                        Console.Write($"{(int)Text[i]:X2} ");       // Afisam pe rand cate un caracter in hexa.

                        Console.Write(i == 7 && Lungime > 8 ? "| " : "");

                        if (Text[i] > 31 && Text[i] != 127)
                        {
                            Bucata += (char)Text[i];                // In string-ul "Bucata" adaugam pe rand caracterele.
                        }                                           // Daca acestea sunt caractere de control, in locul
                        else                                        // lor adaugam "." .
                        {
                            Bucata += ".";
                        }
                    }
                    if (UltimaLinie == true)                        // Conditia pentru ultima linie. Adaugam spatii necesare.
                    {
                        Console.Write(Lungime > 8 ? Bucata.PadLeft(57 - 2 * Bucata.Length) + "\n\n" : Bucata.PadLeft(59 - 2 * Bucata.Length) + "\n\n");
                    }
                    else                                            // Afisam string-ul "Bucata" si il resetam, crescand
                    {                                               // contorul pentru rand.
                        Console.Write(" | " + Bucata + "\n");

                        Bucata = "";

                        Contor++;
                    }

                    Text = Text.Substring(Lungime);                 // Taiam din string-ul principal pentru a putea
                                                                    // repeta procesele de mai sus pana este parcus.
                    if (Text.Length < 16)
                    {
                        Lungime = (sbyte)Text.Length;               // Setam lungimea pentru ultimul rand daca nu
                                                                    // este intreg (16).
                        UltimaLinie = true;

                        Bucata = " | ";
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
