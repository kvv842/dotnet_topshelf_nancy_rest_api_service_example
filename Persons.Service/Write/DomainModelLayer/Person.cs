using System;

namespace Persons.Service.Write.DomainModelLayer
{
    public class Person
    {
        public virtual Guid Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual DateTime BirthDay { get; protected set; }

        public virtual int Age => new DateTime((DateTime.Now - BirthDay).Ticks).Year;

        private Person() {}

        public static Person Create(string name, DateTime birthDay)
        {
            var result = new Person
            {
                Id = Guid.NewGuid(),
                Name = name,
                BirthDay = birthDay,
            };

            if (!result.IsValid())
                return null;

            //TODO Event created

            return result;
        }

        public bool IsValid()
        {
            return !(string.IsNullOrWhiteSpace(Name) || Age > 120);
        }
    }
}
