using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMonolitycznie
{
    class Program
    {
        /// <summary>
        /// Generuje liczbę pseudolosową z podanego zakresu, włącznie z krańcami
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Losuj(int a = 1, int b = 100)
        {
            if( a > b )
            { //swap  a<-->b
                int tmp = a;
                a = b;
                b = tmp;
            }
            Random generator = new Random();
            return generator.Next(a, b+1);
        }

        static int WczytajLiczbe(string prompt = "Podaj liczbę (lub X aby zakończyć): ")
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

        static string Ocena(int propozycja)
        {
            if (propozycja < wylosowana)
                return "za mało";
            else if (propozycja > wylosowana)
                return "za dużo";
            else
                return "trafiono";
        }

        static void wybory()
        {
            int min = WczytajLiczbe("Podaj zakres od: ");
            int max = WczytajLiczbe("Podaj zakres do: ");

            wylosowana = Losuj(min, max);
            Console.WriteLine($"Wylosowałem liczbę od {min} do {max}. \n Odgadnij ją");
            int licznik = 0;

            do
            {
                int propozycja = 0;
                try
                {
                    propozycja = WczytajLiczbe("Podaj swoją propozycję: ");
                    licznik++;
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Wyjście awaryjne.");
                    return;  //wyjście z Main(), czyli opuszczenie programu
                }

                Console.WriteLine($"Przyjąłem wartość {propozycja}");

                string wynik = Ocena(propozycja);
                Console.WriteLine(wynik);
                if (wynik == "trafiono")
                {
                    Console.WriteLine($"Brawo udało Ci się odgadnąć liczbę po {licznik} próbach");
                    break;
                }
            }
            while (true);

            Console.WriteLine("Koniec gry");
            Console.WriteLine("*******************************************************************************************************************");
            Console.WriteLine("Czy chcesz spróbować jeszcze raz(T - Tak, N - Nie)?");
            string decyzja = Console.ReadLine();
            if (decyzja == "T")
                wybory();
            else
            {
                Console.WriteLine("Wciśnij enter aby zamknąć program");
                Console.ReadLine();
            }
        }

        static int wylosowana = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Witam w grze za dużo za mało. Podaj zakres liczb do wylosowania: ");
            wybory();
        }
    }
}

