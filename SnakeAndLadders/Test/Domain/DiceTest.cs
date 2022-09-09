using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using NUnit.Framework;

namespace Test.Domain
{
    public class DiceTests
    {
        private Func<IEnumerable<int>, int> _randomFunction;
        private List<int> _diceFaces;

        [SetUp]
        public void Setup()
        {
            _randomFunction = delegate (IEnumerable<int> options)
            {
                var faces = options.ToList();
                return faces[new Random().Next(faces.Count)];
            };
            _diceFaces = Enumerable.Range(1, 6).ToList();
        }

        [Test]
        public void WhenRollADiceShouldGetANaturalNumber()
        {
            var dice = new Dice(
                _diceFaces, 
                _randomFunction);

            Assert.IsTrue(dice.Roll() is int && dice.Roll() > 0);
        }

        [Test]
        public void WhenRollADiceShouldGetAFaceInRangeDice()
        {
            var dice = new Dice(_diceFaces, _randomFunction);
            Assert.IsTrue(_diceFaces.Contains(dice.Roll()));
        }
    }
}