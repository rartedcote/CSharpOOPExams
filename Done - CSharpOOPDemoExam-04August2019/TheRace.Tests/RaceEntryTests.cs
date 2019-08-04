using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [TearDown]
        public void Dispose()
        {
            raceEntry = null;
        }

        [Test]
        public void ValidConstr()
        {
            Assert.That(() => new RaceEntry(), Is.Not.Null);
        }

        [Test]
        public void ValidAddRider()
        {
            Assert.That(() => raceEntry.AddRider(new UnitRider("asdf", new UnitMotorcycle("asdf", 3453, 345345))).GetType() == typeof(string));
        }

        [Test]
        public void InvalidAddRiderNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null));
        }

        [Test]
        public void InvalidAddRiderSameName()
        {
            UnitRider unitRider = new UnitRider("asdf", new UnitMotorcycle("asdf", 3453, 345345));
            raceEntry.AddRider(unitRider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(unitRider));
        }

        [Test]
        public void InvalidAverageHorsePower()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void ValidAverageHorsePower()
        {
            UnitRider unitRider1 = new UnitRider("asdf", new UnitMotorcycle("asdf", 13, 145));
            UnitRider unitRider2 = new UnitRider("gsdfe", new UnitMotorcycle("xcvbt", 13, 145));


            raceEntry.AddRider(unitRider1);
            raceEntry.AddRider(unitRider2);

            Assert.AreEqual(13, raceEntry.CalculateAverageHorsePower());
        }
    }
}