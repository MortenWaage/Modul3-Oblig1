namespace Obligatorisk_Oppgave_1
{
    public class Person
    {
        private string _firstName = null;
        private string _lastName = null;
        private int _birthYear = 0;
        private int _deathYear = 0;

        public int IntId { get; }
        public string StringId  => $" (Id={IntId})";
        public string FirstName => _firstName ?? "Unknown";
        public string LastName  => _lastName != null ? $" {_lastName}" : null;
        public string BirthYear => _birthYear == 0 ? null : $" Født: {_birthYear}";
        public string DeathYear => _deathYear == 0 ? null : $" Død: {_deathYear}";
        public Person Father { get; set; }
        public Person Mother { get; set; }

        public Person(string firstName = null, string lastName = null, int? birthYear = null, int? deathYear = null)
        {
            Census.Data.People.Add(this);
            IntId = Census.Data.People.Count;
            ModifyAttributes(firstName, lastName, birthYear, deathYear);
        }
        public void ModifyAttributes(string firstName = null, string lastName = null, int? birthYear = null, int? deathYear = null)
        {
            _firstName = firstName ?? _firstName;
            _lastName  = lastName  ?? _lastName;
            _birthYear = birthYear ?? _birthYear;
            _deathYear = deathYear ?? _deathYear;
        }
        public string GetDescription()
        {
            var self   = FirstName + LastName + StringId + BirthYear + DeathYear;
            var father = Father == null ? null : $" Far: {Father.FirstName}{Father.StringId}";
            var mother = Mother == null ? null : $" Mor: {Mother.FirstName}{Mother.StringId}";

            return $"{self}{father}{mother}{Children()}";

            string Children()
            {
                string children = null;
                foreach (var person in Census.Data.People)
                {
                    var fatherIntId = person.Father?.IntId ?? -1;
                    var motherIntId = person.Mother?.IntId ?? -1;

                    if (IntId == fatherIntId || IntId == motherIntId)
                        children += $"    {person.FirstName}{person.StringId}{person.BirthYear}\n";
                }
                return children == null ? null : "\n  Barn:\n" + children;
            }
        }
    }
}