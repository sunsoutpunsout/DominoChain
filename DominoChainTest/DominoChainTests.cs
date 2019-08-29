using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using DominoChainCore;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ChainSort_EmptyCollection_ReturnsEmpty()
        {
            // Arrange
            var list = new List<Domino> { };

            // Act
            var actual = list.ChainSort();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ChainSort_MismatchedElement_ReturnsNull()
        {
            // Arrange
            var list = new List<Domino> { new Domino { Head = 1, Tail = 2 } };

            // Act
            var actual = list.ChainSort();

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void ChainSort_MismatchedElements_ReturnsNull()
        {
            // Arrange
            var list = new List<Domino> { new Domino { Head = 1, Tail = 2 }, new Domino { Head = 1, Tail = 1 } };

            // Act
            var actual = list.ChainSort();

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void ChainSort_ChainedElements_ReturnsChain()
        {
            // Arrange
            var list = new List<Domino> {
                new Domino { Head = 1, Tail = 6 },
                new Domino { Head = 6, Tail = 5 },
                new Domino { Head = 5, Tail = 1}
            };

            var expected = new List<Domino> {
                new Domino { Head = 1, Tail = 6 },
                new Domino { Head = 6, Tail = 5 },
                new Domino { Head = 5, Tail = 1 }
            };

            // Act
            var actual = list.ChainSort();

            // Assert
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
        
        [Test]
        public void ChainSort_FlippableElements_ReturnsChain()
        {
            // Arrange
            var list = new List<Domino> {
                new Domino { Head = 6, Tail = 5 },
                new Domino { Head = 2, Tail = 5 },
                new Domino { Head = 1, Tail = 2 },
                new Domino { Head = 6, Tail = 1 }
            };

            var expected = new List<Domino> {
                new Domino { Head = 6, Tail = 5 },
                new Domino { Head = 5, Tail = 2 },
                new Domino { Head = 2, Tail = 1 },
                new Domino { Head = 1, Tail = 6 }
            };

            // Act
            var actual = list.ChainSort();

            // Assert
            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [Test]
        public void ChainSort_SortableElements_ReturnsChain()
        {
            // Arrange
            var list = new List<Domino> {
                new Domino { Head = 1, Tail = 6 },
                new Domino { Head = 2, Tail = 1 },
                new Domino { Head = 5, Tail = 2 },
                new Domino { Head = 6, Tail = 5 }
            };

            var expected = new List<Domino> {
                new Domino { Head = 1, Tail = 6 },
                new Domino { Head = 6, Tail = 5 },
                new Domino { Head = 5, Tail = 2 },
                new Domino { Head = 2, Tail = 1 }
            };

            // Act
            var actual = list.ChainSort();

            // Assert
            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [Test]
        public void ChainSort_FlippableAndSortableElements_ReturnsChain()
        {
            // Arrange
            var list = new List<Domino> {
                new Domino { Head = 1, Tail = 6 },
                new Domino { Head = 2, Tail = 3 },
                new Domino { Head = 3, Tail = 4 },
                new Domino { Head = 5, Tail = 6 },
                new Domino { Head = 1, Tail = 2 },
                new Domino { Head = 7, Tail = 7 },
                new Domino { Head = 3, Tail = 1 },
                new Domino { Head = 1, Tail = 2 },
                new Domino { Head = 2, Tail = 7 },
                new Domino { Head = 1, Tail = 2 },
                new Domino { Head = 5, Tail = 3 },
                new Domino { Head = 3, Tail = 1 },
                new Domino { Head = 1, Tail = 2 },
                new Domino { Head = 7, Tail = 4 },
                new Domino { Head = 1, Tail = 4 },
                new Domino { Head = 3, Tail = 4 }
            };

            var expected = new List<Domino> {
                new Domino { Head = 1, Tail = 6 },
                new Domino { Head = 6, Tail = 5 },
                new Domino { Head = 5, Tail = 3 },
                new Domino { Head = 3, Tail = 2 },
                new Domino { Head = 2, Tail = 1 },
                new Domino { Head = 1, Tail = 3 },
                new Domino { Head = 3, Tail = 4 },
                new Domino { Head = 4, Tail = 7 },
                new Domino { Head = 7, Tail = 7 },
                new Domino { Head = 7, Tail = 2 },
                new Domino { Head = 2, Tail = 1 },
                new Domino { Head = 1, Tail = 2 },
                new Domino { Head = 2, Tail = 1 },
                new Domino { Head = 1, Tail = 3 },
                new Domino { Head = 3, Tail = 4 },
                new Domino { Head = 4, Tail = 1 }
            };

            // Act
            var actual = list.ChainSort();

            // Assert (these both should end up doing the same thing but wanted to test)
            Assert.That(actual, Is.EqualTo(expected));
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}