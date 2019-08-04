namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IHotel
    {
        IReadOnlyDictionary<string, IAnimal> Animals { get; }

        void Accommodate(IAnimal animal);
        string Adopt(string animalName, string owner);
    }
}
