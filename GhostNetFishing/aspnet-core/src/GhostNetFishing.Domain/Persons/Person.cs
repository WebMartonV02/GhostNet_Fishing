using GhostNetFishing.GhostNetAndPersons;
using GhostNetFishing.PersonTypes;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.Persons
{
    public class Person : Entity<int>
    {
        public string Name { get; set; }
        public string TelefonNummer { get; set; }
        public int PersonTypeId { get; set; }
        public PersonType PersonType { get; set; }
        public ICollection<GhostNetAndPerson> GhostNetAndPerson { get; set; }

        public Person() { }

        public Person(
            string name, 
            string telefonNummer, 
            int personTypeId)
        {
            Name = name;
            TelefonNummer = telefonNummer;
            PersonTypeId = personTypeId;
        }

        public Person Update(
            string name,
            string telefonNummer,
            int personTypeId)
        {
            Name = name;
            TelefonNummer = telefonNummer;
            PersonTypeId = personTypeId;

            return this;
        }
}
}
