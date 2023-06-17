using GhostNetFishing.PersonTypes;

namespace GhostNetFishing.Persons
{
    public class PersonResultDto
    {
        public string Name { get; set; }
        public string TelefonNummer { get; set; }
        public PersonTypeResultDto PersonType { get; set; }
    }
}
