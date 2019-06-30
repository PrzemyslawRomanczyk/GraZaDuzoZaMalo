using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ModelGry.Gra;

namespace ModelGry
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Witam w grze za dużo za mało. Podaj zakres liczb do wylosowania: ");
            int min = Gra.WczytajLiczbe("Podaj zakres od: ");
            int max = WczytajLiczbe("Podaj zakres do: ");
        }
    }
}
