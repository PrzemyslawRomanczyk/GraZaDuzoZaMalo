


using System;
using System.Collections.Generic;
using System.Text;

namespace ModelGry
{
    partial class Gra
    {
        // historia - lista ruchów
        private readonly List<Ruch> historia;
        public IReadOnlyList<Ruch> Historia => historia;

        // inner class
        public class Ruch
        {
            public readonly int propozycja;
            public readonly Odpowiedz odpowiedz;
            public readonly DateTime kiedy;

            internal Ruch(int prop, Odpowiedz odp)
            {
                propozycja = prop;
                odpowiedz = odp;
                kiedy = DateTime.Now;
            }

            public override string ToString() => $"( {propozycja}, {odpowiedz}, {kiedy})";
        }
    }
}
