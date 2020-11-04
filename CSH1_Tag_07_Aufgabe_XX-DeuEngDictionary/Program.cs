using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH1_Tag_07_Aufgabe_XX_DeuEngDictionary
{
    class Program
    {
        static Dictionary<string, string> buch = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            char menuEingabe;

            while(true)
            {
                Console.WriteLine("Bitte auswählen");
                Console.WriteLine("1) Begriff anlegen");
                Console.WriteLine("2) Übersetzung suchen");
                Console.WriteLine("3) Alle Begriffe ausgeben");
                Console.WriteLine("4) Programm beenden");
                
                Console.Write(">>> ");
                menuEingabe = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (menuEingabe)
                {
                    case '1':
                        BegriffAnlegen();
                        break;
                    case '2':
                        Suchen();
                        break;
                    case '3':
                        BegriffeAusgeben();
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }

            }

            
        }

        static void BegriffAnlegen()
        {
            string deutsch, englisch;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Bitte Deutschen Begriff eingeben");
                Console.WriteLine("'!exit' um ins Hauptmenü zurückzukehren");
                Console.Write(">>> ");
                deutsch = Console.ReadLine();

                if (deutsch.Contains(" "))
                {
                    Console.WriteLine("Wort darf keine Leerzeichen enthalten!");
                    Console.ReadKey();
                    continue;
                }
                else if (buch.ContainsKey(deutsch))
                {
                    Console.WriteLine("Wort bereits vorhanden!");
                    Console.ReadKey();
                    continue;
                }
                else if (deutsch == "")
                {
                    Console.WriteLine("Kein Wort eingegeben!");
                    Console.ReadKey();
                    continue;
                }
                else if (deutsch == "!exit")
                {
                    Console.Clear();
                    return;
                }



                Console.Clear();
                Console.WriteLine($"Bitte Übersetzung für {deutsch} eingeben");
                Console.Write(">>> ");
                englisch = Console.ReadLine();

                if (englisch.Contains(" "))
                {
                    Console.WriteLine("Wort darf keine Leerzeichen enthalten!");
                    Console.ReadKey();
                    continue;
                }
                else if (englisch == "")
                {
                    Console.WriteLine("Kein Wort eingegeben!");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    buch.Add(deutsch.ToLower(), englisch);
                    Console.WriteLine($"Eintrag Nr. {buch.Count} erfolgreich hinzugefügt!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
            
            
        }

        static void Suchen()
        {

            while(true)
            {
                Console.Clear();

                Console.WriteLine("Bitte Deutschen Begriff eingeben");
                Console.WriteLine("'!exit' um ins Hauptmenü zurückzukehren");
                Console.Write(">>> ");
                string suche = Console.ReadLine();

                if (suche == "!exit")
                {
                    Console.Clear();
                    return;
                }

                if (buch.ContainsKey(suche.ToLower()))
                {
                    Console.Clear();
                    Console.WriteLine($"Übersetzung für {suche} lautet: {buch[suche.ToLower()]}");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Begriff nicht gefunden!");
                    Console.ReadKey();
                    continue;
                }
            }
            
        }

        static void BegriffeAusgeben()
        {
            Console.WriteLine($"{buch.Count} Einträge werden ausgegeben....");
            Console.Write("Deutsch");
            Console.WriteLine("\t\t|\tEnglisch");
            Console.WriteLine("-----------------------------------------------------------");
            foreach(var kv in buch)
            {
                Console.Write(kv.Key);
                Console.WriteLine($"\t\t|\t{kv.Value}");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
