namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            car = new Car("Honda", "ST 45434 BN");
            softPark = new SoftPark();
        }

        [TearDown]
        public void Dispose()
        {
            car = null;
        }

        [Test]
        public void ValidConstr()
        {
            Assert.DoesNotThrow(() => new SoftPark());
        }

        [Test]
        public void ValidPark()
        {
            string expected = "Car:ST 45434 BN parked successfully!";
            Assert.AreEqual(expected, softPark.ParkCar("A1", car));
        }

        [Test]
        public void InvalidParkSpot()
        {
            Assert.Throws<ArgumentException>(() => 
            softPark.ParkCar("ZXC", car))
            .Message.Equals("Parking spot doesn't exists!");
        }

        [Test]
        public void ParkingSpotTaken()
        {
            softPark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => 
            softPark.ParkCar("A1", car))
            .Message.Equals("Parking spot is already taken!");
        }

        [Test]
        public void CarAlreadyParked()
        {
            softPark.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() =>
            softPark.ParkCar("B1", car))
            .Message.Equals("Car is already parked!");
        }

        [Test]
        public void ValidRemoveCar()
        {
            string expected = "Remove car:ST 45434 BN successfully!";

            softPark.ParkCar("A1", car);

            Assert.AreEqual(expected, softPark.RemoveCar("A1", car));
        }

        [Test]
        public void InvalidParkSpotRemove()
        {
            Assert.Throws<ArgumentException>(() => 
            softPark.RemoveCar("asdd", car))
                .Message.Equals("Parking spot doesn't exists!");
        }

        [Test]
        public void NoCarOnParkSpot()
        {
            Assert.Throws<ArgumentException>(()
                => softPark.RemoveCar("A1", car))
                .Message.Equals("Car for that spot doesn't exists!");
        }
    }
}