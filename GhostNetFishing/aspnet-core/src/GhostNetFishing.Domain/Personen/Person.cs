using GhostNetFishing.GhostNetsAndPersonen;
using Volo.Abp.Domain.Entities;

namespace GhostNetFishing.Personen
{
    public class Person : Entity<int>
    {
        public string Name { get; set; }
        public string TelefonNummer { get; set; }
        public PersonTypEnum PersonTyp { get; set; }
        public GhostNetAndPerson GhostNetAndPerson { get; set; }
    }
}
