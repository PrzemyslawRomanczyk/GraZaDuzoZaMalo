using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komputer_zgaduje
{
    class Program
    {

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

        static string Ocena(int propozycja, int wylosowana)
        {
            if (propozycja < wylosowana)
                return "za mało";
            else if (propozycja > wylosowana)
                return "za dużo";
            else
                return "trafiono";
        }

        static int Algorytm_wyszukiwanie_binarne(int min, int max)
        {
            int propozycja;
            propozycja = (max - min) / 2 + min; 
            return propozycja;
        }

        static int Algorytm_random(int min, int max)
        {
            int propozycja;
            Random generator = new Random();
            propozycja = generator.Next(min, max + 1);
            return propozycja;
        }

        static void Gra()
        {
            Console.WriteLine("Wybierz algorytm według którego będę pracował: 1 - Losowanie, 2 - Wyszukiwanie binarne");
            int Alogrytm = WczytajLiczbe();
            Console.WriteLine("Podaj zakres w którym znajduje się twoja liczba:");
            Console.WriteLine("Minimum:");
            int Min = WczytajLiczbe();
            Console.WriteLine("Maksimum:");
            int Max = WczytajLiczbe();
            Console.WriteLine("Teraz podaj swoją wybraną liczbę:");
            int wylosowana = WczytajLiczbe();

            int licznik = 0;
            int propozycja = 0;

            do
            {
                try
                {   
                    if(Alogrytm == 1)
                        propozycja = Algorytm_random(Min, Max);
                    else if(Alogrytm == 2)
                        propozycja = Algorytm_wyszukiwanie_binarne(Min, Max);
                    else
                        {
                        Console.WriteLine("Wybrałeś nie dozwolny rodzaj algorytmu :(");
                        break;
                        }
                    licznik++;
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Wyjście awaryjne.");
                    return;  //wyjście z Main(), czyli opuszczenie programu
                }

                Console.WriteLine($"Wybrałem liczbę {propozycja} czy to twoja liczba?");

                string wynik = Ocena(propozycja, wylosowana);
                Console.WriteLine(wynik);
                if (wynik == "trafiono")
                {
                    Console.WriteLine($"Brawo udało mi się odgadnąć twoją liczbę po {licznik} próbach");
                    break;
                }
                else if(wynik == "za dużo")
                {
                    Max = propozycja;
                }
                else if (wynik == "za mało")
                {
                    Min = propozycja;
                }

            }
            while (true);

            Console.WriteLine("Koniec gry");
            Console.WriteLine("*******************************************************************************************************************");
            Console.WriteLine("Czy chcesz spróbować jeszcze raz(T - Tak, N - Nie)?");
            string decyzja = Console.ReadLine();
            if (decyzja == "T")
                Gra();
            else
            {
                Console.WriteLine("Wciśnij enter aby zamknąć program");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            Gra();
        }
    }
}
