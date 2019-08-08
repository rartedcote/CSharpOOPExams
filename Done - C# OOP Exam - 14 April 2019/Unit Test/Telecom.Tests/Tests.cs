namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void StartUp()
        {
            phone = new Phone("Huawei", "Hero");
        }

        [TearDown]
        public void Dispose()
        {
            phone = null;
        }

        [Test]
        public void ValidConstr()
        {
            Assert.IsNotNull(new Phone("asdf", "fds"));
        }

        [Test]
        public void InvalidConstrMake()
        {
            string invalidMake = string.Empty;

            Assert.Throws<ArgumentException>(() => 
            new Phone(invalidMake, "asdf"))
                .Message.Equals($"Invalid {invalidMake}!");
        }

        [Test]
        public void InvalidConstrModel()
        {
            string invalidModel = string.Empty;

            Assert.Throws<ArgumentException>(() =>
            new Phone("asdfxc", invalidModel))
                .Message.Equals($"Invalid {invalidModel}!");
        }

        [Test]
        public void ValidPhonebookAdd()
        {
            Assert.DoesNotThrow(() => phone.AddContact("mama", "352 453 2246"));
        }

        [Test]
        public void InvalidPhonebookAddContainsName()
        {
            string contactName = "mama";
            string number = "352 453 2246";

            phone.AddContact(contactName, number);

            Assert.Throws<InvalidOperationException>(() => phone.AddContact(contactName, number))
                .Message.Equals("Person already exists!");
        }

        [Test]
        public void ValidCall()
        {
            string name = "mama";
            string number = "352 453 2246";

            phone.AddContact(name, number);

            string expected = $"Calling {name} - {number}...";

            Assert.AreEqual(expected, phone.Call(name));
        }

        [Test]
        public void InvalidCallNonexistentName()
        {
            Assert.Throws<InvalidOperationException>(() => phone.Call("asdf"))
                .Message.Equals("Person doesn't exists!");
        }
    }
}