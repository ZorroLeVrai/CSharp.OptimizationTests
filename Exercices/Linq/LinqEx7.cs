namespace Exercices.Linq;

internal class LinqEx7 : RunBase<LinqEx7.InputData, IEnumerable<LinqEx7.PersonPet>>
{
    public override InputData Init()
    {
        var personnes = new Person[] {
            new Person(FirstName: "John", LastName: "Smith"),
            new Person("Mary", "Jones"),
            new Person("Peter", "Brown")
        };

        var pets = new Pet[]
        {
            new Pet(Name: "Chippy", Owner: personnes[1]),
            new Pet("Rex", personnes[2]),
            new Pet("Lassie", personnes[1])
        };

        return new InputData(personnes, pets );
    }
    public override IEnumerable<PersonPet> Process(InputData input)
    {
        var (personnes, pets) = input;
        //GroupJoin is the equivalent of a left join
        return personnes.GroupJoin(pets,
            personne => personne,
            pet => pet.Owner,
            (per, pet) => new PersonPet(per, pet));
    }

    public override void DisplayResult(IEnumerable<PersonPet> output)
    {
        Console.WriteLine(output.ToPrettyString());
    }

    public record Person(string FirstName, string LastName);
    public record Pet(string Name, Person Owner);
    public record InputData(IEnumerable<Person> Persons, IEnumerable<Pet> Pets);
    public record PersonPet(Person Person, IEnumerable<Pet> Pet)
    {
        public override string ToString()
        {
            var (fn, ln) = Person;
            var petNames = Pet.Select(pet => pet.Name);
            return $"[{fn} {ln} Pets:[{string.Join(", ", petNames)}]]";
        }
    }
}
