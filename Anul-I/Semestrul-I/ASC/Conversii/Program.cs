using System;

namespace Conversii
{
    class Unelte                                                                      // Clasa pentru variable globale.
    {
        public static long Putere = 0;

        public static bool Semn = false;
    }
    class Program
    {
        static void Afisare_Parte_Fractionara(double Parte_Fractionara_10, sbyte Baza_2)
        {
            sbyte ContorZecimale = 0, p;

            Console.Write(".");                                                       // Afisarea are loc pana  cand apar 20 de zecimale sau 
                                                                                      // nu mai avem zecimale dupa virgula in urma inmultirii.
            while (Parte_Fractionara_10 != Math.Floor(Parte_Fractionara_10) && ContorZecimale <= 20)
            {
                ContorZecimale++;                     

                Parte_Fractionara_10 *= Baza_2;                                       // Se afiseaza partea intreaga in urma inmultirilor
                                                                                      // efectuate conform formulei de conversie din baza 10
                if (Parte_Fractionara_10 < 10)                                        // in baza tinta a numerelor cu partea fractionara.
                {
                    Console.Write(Math.Floor(Parte_Fractionara_10));
                }
                else
                {
                    p = (sbyte)Parte_Fractionara_10;

                    Console.Write(Convert.ToChar(p - 10 + 'A'));                      // Eventuala transoformare in litera daca este necesar.
                }

                if (Parte_Fractionara_10 >= 1)
                {
                    Parte_Fractionara_10 -= Math.Floor(Parte_Fractionara_10);         // Numarul revine sub valoarea 1 in caz ca a depasit-o.
                }
            }
            Console.Write("\n");
        }
        static void Conversie_In_Baza_Tinta(long Parte_Intreaga_10, sbyte Baza_2)
        {
            if (Parte_Intreaga_10 == 0)                                               // Aceasta este o functie recursiva, avand ca
            {                                                                         // punct de stop 0 si tinand cont de semn.
                Console.Write("\n Numarul obtinut in urma conversiei este: ");

                if (Unelte.Semn == true)                                              // Se tine cont daca numarul initial era negativ.
                {
                    Console.Write("-");
                }
            }
            else
            {
                Conversie_In_Baza_Tinta(Parte_Intreaga_10 / Baza_2, Baza_2);          // Se reapeleaza functia impartind succesiv
                                                                                      // partea intreaga la baza tinta.     
                if (Parte_Intreaga_10 % Baza_2 < 10)
                {
                    Console.Write(Parte_Intreaga_10 % Baza_2);                        // Se afiseaza resturile conform formulei de conversie
                }                                                                     // si eventuala transformare in litere daca este necesar.
                else
                {
                    Console.Write(Convert.ToChar(Parte_Intreaga_10 % Baza_2 - 10 + 'A'));
                }
            }
        }
        static void Afisare_Parte_Intreaga(long Parte_Intreaga_10, sbyte Baza_2)
        {
            if (Baza_2 == 10)                                                         // Daca baza tinta este 10, se afiseaza fara alte conversii.
            {
                Console.Write($"\n Numarul obtinut in urma conversiei este: ");

                if (Unelte.Semn == true)                                              // Se tine cont daca numarul initial era negativ.
                {
                    Console.Write("-");
                }

                Console.Write(Parte_Intreaga_10);
            }
            else if (Parte_Intreaga_10 > 0)
            {
                Conversie_In_Baza_Tinta(Parte_Intreaga_10, Baza_2);                   // Se face conversia in baza tinta (Linia 43).
            }
        }
        static void Afisare_Numar(long Parte_Intreaga_10, double Parte_Fractionara_10, sbyte Baza_2)
        {
            if (Parte_Fractionara_10 == 0)                                            // Daca nu avem parte fractionara se afiseaza 
            {                                                                         // doar partea intreaga (Linia 68).
                Afisare_Parte_Intreaga(Parte_Intreaga_10, Baza_2);

                Console.WriteLine("\n");
            }
            else                                                                      // Altfe, se afiseaza partea intreaga (Linia 68)
            {                                                                         // si apoi cea fractionara (Linia 13).                      
                if (Parte_Intreaga_10 == 0)
                {
                    Console.Write("\n Numarul obtinut in urma conversiei este: 0");
                }
                else
                {
                    Afisare_Parte_Intreaga(Parte_Intreaga_10, Baza_2);
                }

                Afisare_Parte_Fractionara(Parte_Fractionara_10, Baza_2);

                Console.Write("\n");
            }
            
        }
        static long Conversie_Caracter(char Caracter, sbyte Baza_1)
        {
            int Numar_Obtinut;

            if (Caracter >= 'a' && Caracter <= 'z')                                   // Deoarece baza initiala poate fi mai mare
            {                                                                         // decat 9, cifrele scrise cu litere mici
                Caracter = Convert.ToChar((int)Caracter - 32);                        // (exemplu: 'a') sunt transformate in litere 
            }                                                                         // mari (exemplu: 'A') pentru a putea fi convertite. 

            if ((int)Caracter >= '0' && (int)Caracter - '0' < Baza_1)                 // Daca cifra face deja parte din intervalul [0,9]
            {                                                                         // si este mai mica decat baza sa, aceasta se returneaza.
                Numar_Obtinut = (int)Caracter - '0';
                                                                                      // Aceasta este o verificare pentru exemple de genul:
                return Numar_Obtinut;                                                 // 5678 (baza 2), adica cifrele sunt mai mari decat baza.
            }

            else if ((int)Caracter - 'A' + 10 < Baza_1 && (int)Caracter - 'A' + 10 >= 10)
            {
                Numar_Obtinut = (int)Caracter - 'A' + 10;                             // Daca baza initiala este mai mare sau egala cu 10,
                                                                                      // se verifica daca cifra nu depaseste baza sa si se
                return Numar_Obtinut;                                                 // transforma in baza 10. 
            }

            else
            {
                throw new Exception();                                                // Exceptia intra in vigoare cand nu se excuta niciuna 
            }                                                                         // din conditiile de mai sus.
        }
        static long Conversie_In_Baza_10_Pe_Bucati(string Bucata, sbyte Baza_1)
        {
            int i;
            long Numar_Final = 0, Caracter_Convertit;

            for (i = Bucata.Length - 1; i >= 0; i--)
            {
                try
                {
                    Caracter_Convertit = Conversie_Caracter(Bucata[i], Baza_1);       // Se converteste caracterul printr-o functie (Linia 110)

                    if (Unelte.Putere == 0)
                    {
                        Numar_Final += Caracter_Convertit;                            // Conversia bucatii se realizeaza prin parcurgerea
                                                                                      // fiecarui caracter si inmultind valoarea lui in
                        Unelte.Putere = Baza_1;                                       // baza 10 cu o putere crescatoare a bazei sale.
                    }
                    else
                    {
                        Numar_Final += Caracter_Convertit * Unelte.Putere;            // Aceasta putere incepe de la 0 si creste cu 1
                                                                                      // cu fiecare caracter convertit. Avand o clasa 
                        Unelte.Putere *= Baza_1;                                      // separata, aceasta va tot creste, nu va mai fi 0;
                    }
                }
                catch (Exception)                                                     // Exceptia intra in vigoare in cazul in care nu se 
                {                                                                     // poate converti caracterul.
                    Console.WriteLine("\n Numarul introdus este invalid! \n");

                    return -1;
                }
            }
            return Numar_Final;
        }
        static long Conversie_In_Baza_10(string String_Parte, long Parte_Baza_10, sbyte Baza_1)
        {
            int j;
            string Bucata;
            long Parte_Auxiliar;

            for (j = String_Parte.Length - 1; j >= 0; j -= 4)                         // Conversia in baza 10 se realizeaza prin sectionarea in bucati
            {                                                                         // de cate 4 caractere a string-ului de la dreapta spre stanga,
                if (j - 4 >= 0)                                                       // acestea fiind ulterior eliminate.
                {
                    Bucata = String_Parte.Substring(j - 3);

                    String_Parte = String_Parte.Remove(j - 3, 4);
                }
                else
                {
                    Bucata = String_Parte.Substring(0);
                }

                Parte_Auxiliar = Conversie_In_Baza_10_Pe_Bucati(Bucata, Baza_1);      // Se foloseste un auxiliar pentru conversia bucatii (Linia 138).

                if (Parte_Auxiliar == -1)                                             // Daca acesta este -1, se iese din structura repetitiva,
                {                                                                     // ceea ce inseamna ca este un numar invalid. 
                    Parte_Baza_10 = -1;

                    break;
                }
                else                                                                  // In caz contrar, se formeaza partea intreaga sau fractionara
                {                                                                     // (in functie de apelarea functiei) prin adunari succesive a
                    Parte_Baza_10 += Parte_Auxiliar;                                  // bucatilor convertite.
                }
            }
            return Parte_Baza_10;                                                     // Se returneaza valoarea.
        }
        static void Prelucrare(string Numar_Initial, sbyte Baza_1, sbyte Baza_2)
        {
            bool Exista = false;
            int Pozitie;
            string String_Fractionar = "", String_Intreg;
            long Parte_Intreaga_10 = 0, Parte_Fractionara_Auxiliar = 0;
            double Parte_Fractionara_10 = 0;

            if (Numar_Initial.Contains("."))                                          // Verificam daca numarul este scris cu zecimale sau nu.
            {
                Pozitie = Numar_Initial.IndexOf(".");                                 // In caz afirmativ, impartim numarul in 2 stringuri 
                                                                                      // corespunzatoare celor 2 parti.
                String_Intreg = Numar_Initial.Substring(0, Pozitie);

                String_Fractionar = Numar_Initial.Substring(Pozitie + 1, Numar_Initial.Length - Pozitie - 1);

                Exista = true;                                                        // Dam valoare de adevar existentei partii fractionare.
            }
            else
            {
                String_Intreg = Numar_Initial;                                        // In caz contrar, atribuim intreg numarul string-ului partii intregi.
            }

            if (Baza_1 == 10)                                                         // Intreg programul se bazazeaza pe trecerea prin baza 10. 
            {                                                                         // In cazul in care numarul initial este deja in baza 10
                                                                                      // (caz special), nu va mai fi nevoie de conversia numarului in baza 10.
                try
                {
                    Parte_Intreaga_10 = long.Parse(String_Intreg);

                    if (Exista == true)                                               // Daca exista partea fractionara, printr-un string auxiliar 
                    {                                                                 // se transforma stringul fractionar in tip double.
                        Parte_Fractionara_Auxiliar = long.Parse(String_Fractionar);

                        Parte_Fractionara_10 = double.Parse("0." + Convert.ToString(Parte_Fractionara_Auxiliar));
                    }

                }
                catch (Exception)                                                     // Tratarea exceptiei in cazul in care 
                {                                                                     // numarul introdus nu corespunde cerintei.
                    Console.WriteLine("\n Numarul introdus este invalid! \n");

                    return;
                }                                                                     // Daca numarul initial nu este in baza 10, se
            }                                                                         // realizeaza conversia lui in aceasta baza (Linia 171).
            else           
            {
                Parte_Intreaga_10 = Conversie_In_Baza_10(String_Intreg, Parte_Intreaga_10, Baza_1);

                Unelte.Putere = Baza_1;                                               // Daca numarul contine parte fractionara, sufera si 
                                                                                      // aceasta la randul ei conversia in baza 10 (Linia 171).
                if (Exista == true && Parte_Intreaga_10 != -1)                      
                {
                    Parte_Fractionara_10 = double.Parse(Convert.ToString(Conversie_In_Baza_10(String_Fractionar, Parte_Fractionara_Auxiliar, Baza_1)));

                    if (Parte_Fractionara_10 != -1)
                    {
                        Parte_Fractionara_10 = double.Parse(Convert.ToString(Parte_Fractionara_10 / Unelte.Putere));
                    }
                }
            }

            if(Parte_Intreaga_10 != -1 && Parte_Fractionara_10 != -1)                 // Apelarea functiei pentru afisarea numarului 
            {                                                                         // final si valid (Linia 86).
                Afisare_Numar(Parte_Intreaga_10, Parte_Fractionara_10, Baza_2); 
            }           
        }                                                                    
        static void Main(string[] args)
        {
            string Numar_Initial = "";
            sbyte Baza_1 = 0, Baza_2 = 0;
            bool Date = false;

            do                                                                        // Citirea numerelor de la tastatura pana cand se 
            {                                                                         // introduce un set de date ce ar putea fi procesate.
                try
                {
                    Console.Write("\n Introduceti numarul pe care doriti sa il convertiti: ");
                    Numar_Initial = Console.ReadLine();

                    if (Numar_Initial[0] == '-')                                      // Verificam daca numarul introdus este negativ sau nu.
                    {
                        Numar_Initial = Numar_Initial.Substring(1);                   // In caz afirmativ, scoatem semnul din string. 

                        Unelte.Semn = true;                                           // Valorea de adevar va ajuta la scrierea finala 
                    }                                                                 // a numarului daca acesta va fi valid.
                    else if(Numar_Initial[0] == '+')
                    {
                        Numar_Initial = Numar_Initial.Substring(1);                   // Se scapa de semnul '+' pentru numere precum: +123 .
                    }

                    Console.Write("\n Introduceti baza din care se va face conversia: ");
                    Baza_1 = sbyte.Parse(Console.ReadLine());

                    Console.Write("\n Introduceti baza in care se va face conversia: ");
                    Baza_2 = sbyte.Parse(Console.ReadLine());

                    if (Numar_Initial.Length == 0 || Baza_1 < 2 || Baza_2 < 2 || Baza_1 > 16 || Baza_2 > 16)
                    {
                        throw new Exception();                                        // Aruncam exceptia daca datele nu corespund cerintei.
                    }

                    Date = true;                                                      // S-a introdus un set de date procesabile.
                }
                catch (Exception)                                                     // Exceptia in cazul nerespectarii cerintelor.
                {
                    Console.Write("\n\n\n Nu au fost introduse date intr-unul din campurile ");
                    Console.Write("enuntate sau acestea nu corespund cerintei. Reincercati! \n\n\n");
                }
            } while (Date == false);

            Prelucrare(Numar_Initial, Baza_1, Baza_2);                                // Apelarea functiei in scopul prelucrarii datelor (Linia 205).
            Console.ReadKey();
        }
    }
}
