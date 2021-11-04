using System.Collections.Generic;

namespace Obligatorisk_Oppgave_1
{
    public class Census
    {
        public static Census Data { get; } = new Census();
        private List<Person> _people;
        public List<Person> People => _people ??= new List<Person>();

        public void AddPeople()
        {
            var sverreMagnus       = new Person("Sverre Magnus", null, 2005, null);
            var ingridAlexandra    = new Person("Ingrid Alexandra", null, 2004, null);
            var haakon             = new Person("Haakon Magnus", null, 1973, null);
            var metteMarit         = new Person("Mette-Marit", null, 1973, null);
            var marius             = new Person("Marius", "Borg Høiby", 1997, null);
            var harald             = new Person("Harald", null, 1937, null);
            var sonja              = new Person("Sonja", null, 1937, null);
            var olav               = new Person("Olav", null, 1903, 1991);

            sverreMagnus.Father    = haakon;
            sverreMagnus.Mother    = metteMarit;
            ingridAlexandra.Father = haakon;
            ingridAlexandra.Mother = metteMarit;
            marius.Mother          = metteMarit;
            haakon.Father          = harald;
            haakon.Mother          = sonja;
            harald.Father          = olav;
        }
    }
}