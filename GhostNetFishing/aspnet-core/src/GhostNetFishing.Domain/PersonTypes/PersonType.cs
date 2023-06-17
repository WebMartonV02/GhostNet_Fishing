using GhostNetFishing.Persons;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.PersonTypes
{
    public class PersonType : Entity<int>
    {
        public string Type { get; set; }

        public ICollection<Person> Persons { get; set; }

        public PersonType(string type)
        {
            Type = type;
        }
    }
}
