using System;
using System.Collections.Generic;

namespace ModelGry
{
    public partial class Gra
    {
        // ineer types
        public enum Odpowiedz { ZaMalo = -1, ZaDuzo = 0, Trafiono = 1 }
        public enum StanGry { Trwa, Odgadnieta, Poddana }


        // fields
        public StanGry Stan { get; private set; }

        public readonly int ZakresOd, ZakresDo;

        //-----------------
        private readonly int wylosowana;
        public int? Wylosowana
        {
            get
            {
                if (Stan == StanGry.Poddana || Stan == StanGry.Odgadnieta)
                    return wylosowana;
                else
                    return null;
            }
            //set { }
        }
        //------------------

        // historia gry: ToDo
        public int LicznikRuchow { get; private set; }  = 0;

        //constructors
        public Gra(int a, int b)
        {
            ZakresOd = Math.Min(a,b);
            ZakresDo = Math.Max(a,b);
            wylosowana = Losuj(ZakresOd, ZakresDo);
            Stan = StanGry.Trwa;
            historia = new List<Ruch>();
        }

        public Odpowiedz Ocena( int propozycja )
        {
            LicznikRuchow++;
            Odpowiedz odp;
            if (propozycja < wylosowana)
                odp = Odpowiedz.ZaMalo;
            else if (propozycja > wylosowana)
                odp = Odpowiedz.ZaDuzo;
            else
            {
                Stan = StanGry.Odgadnieta;
                odp = Odpowiedz.Trafiono;
            }
            historia.Add(new Ruch(propozycja, odp));
            return odp;
        }

        public void Poddaj()
        {
            Stan = StanGry.Poddana;
        }

        /// <summary>
        /// Generuje liczbę pseudolosową z podanego zakresu, włącznie z krańcami
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Losuj(int a = 1, int b = 100)
        {
            if (a > b)
            { //swap  a<-->b
                int tmp = a;
                a = b;
                b = tmp;
            }
            Random generator = new Random();
            return generator.Next(a, b + 1);
        }

        public int WczytajLiczbe(string prompt = "Podaj liczbę (lub X aby zakończyć): ")
        {
            int propozycja = 0;
            while (true)
            {
                Console.Write(prompt);
                string tekst = Console.ReadLine();
                if (tekst.ToLower() == "x")
                    throw new OperationCanceledException("wprowadzono X");

                try
                {
                    propozycja = Convert.ToInt32(tekst);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie podano liczby! Spróbuj ponownie");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Liczba nie mieści się w rejestrze! Spróbuj ponownie");
                    continue;
                }

            }
            return propozycja;
        }
    }
}
