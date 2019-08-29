using System.Collections.Generic;
using System.Linq;

namespace DominoChainCore
{
    /// <summary>
    /// Extension methods for the Domino class.
    /// </summary>
    public static class DominoExtensions
    {
        /// <summary>
        /// Sorts a collection of dominoes by creating a valid chain.
        /// </summary>
        /// <param name="dominoes">Collection to be chained.</param>
        /// <returns>A collection of chained dominoes or null if no chain found.</returns>
        public static IEnumerable<Domino> ChainSort(this IEnumerable<Domino> dominoes)
        {
            // skip if empty
            if (!dominoes.Any())
                return dominoes;

            var first = dominoes.First();

            // if only a single piece head must equal tail
            if (dominoes.Count() == 1)
            {
                return first.Head == first.Tail ? dominoes : null;
            }

            // returns a stack for easy prepending
            var chain = dominoes.Skip(1).Chain(first.Head, first.Tail);
            chain?.Push(first);

            return chain;
        }

        /// <summary>
        /// Recursively sorts a collection of dominoes by creating a valid chain.
        /// </summary>
        /// <param name="dominoes">Collection to be chained.</param>
        /// <param name="head">Current chain head.</param>
        /// <param name="tail">Current chain tail.</param>
        /// <returns>A stack of chained dominoes or null if no chain found.</returns>
        private static Stack<Domino> Chain(this IEnumerable<Domino> dominoes, int head, int tail)
        {
            // determine if we're at the end of a valid chain
            if (!dominoes.Any())
            {
                return head == tail ? new Stack<Domino>() : null;
            }

            // iterate through the entire bag and every domino's rotation
            foreach (var indexedDomino in dominoes.SelectMany((domino, index) => new[] { (index, domino), (index, domino = domino.Flip()) }))
            {
                var domino = indexedDomino.Item2;

                // check if new head matches existing tail
                if (domino.Head != tail)
                {
                    continue;
                }

                // chain the rest of the bag to the current tail
                var chain = dominoes
                    .Take(indexedDomino.index)
                    .Concat(dominoes.Skip(indexedDomino.index + 1))
                    .Chain(head, domino.Tail);

                if (chain == null)
                {
                    continue;
                }

                // put the domino back on the valid chain
                chain.Push(domino);

                return chain;
            }

            // no valid chain found
            return null;
        }
    }
    
    /// <summary>
    /// A Tuple masquerading as a Domino.
    /// </summary>
    public class Domino
    {
        public int Head { get; set; } = 0;

        public int Tail { get; set; } = 0;

        public Domino Flip()
        {
            return new Domino { Head = this.Tail, Tail = this.Head };
        }

        #region Overrides

        // override object methods for ease of testing
        public override bool Equals(object o)
        {
            if (!(o is Domino domino))
            {
                return false;
            }

            return this.Head == domino.Head && this.Tail == domino.Tail;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"[{this.Head},{this.Tail}]";
        }

        #endregion
    }
}
