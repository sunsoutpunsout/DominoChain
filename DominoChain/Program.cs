using System;
using System.Collections.Generic;

using DominoChainCore;

namespace DominoChain
{
    class Program
    {
        static void Main(string[] args)
        {
            // list could be randomized at some point
            var dominoes = new List<Domino>()
            {
                new Domino { Head = 1, Tail = 4 },
                new Domino { Head = 2, Tail = 3 },
                new Domino { Head = 1, Tail = 3 },
                new Domino { Head = 2, Tail = 4 },
                new Domino { Head = 1, Tail = 6 },
                new Domino { Head = 6, Tail = 2 },
                new Domino { Head = 5, Tail = 2 },
                new Domino { Head = 5, Tail = 1 },
                new Domino { Head = 5, Tail = 1 },
                new Domino { Head = 5, Tail = 1 }
            };

            var chain = dominoes.ChainSort();
                       
            var s = string.Empty;

            if (chain == null)
            {
                s = "Dominoes could not be chained.";
            }
            else
            {
                foreach (var domino in chain)
                {
                    s += domino.ToString();
                }
            }

            Console.WriteLine(s);
            Console.ReadLine();         
        }
    }
}
