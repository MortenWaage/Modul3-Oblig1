using NUnit.Framework;
using Obligatorisk_Oppgave_1;

namespace UnitTesting2
{
    
    public class Tests
    {
        [Test]
        public void TestAllFields()
        {
            Census.Data.People.Clear();
            var p = new Person("Ola", "Nordmann", 2000, 3000)
            {
                Father = new Person("Per", "Nordmann", null, null),
                Mother = new Person("Lise", "Nordmann", null, null)
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=1) Født: 2000 Død: 3000 Far: Per (Id=2) Mor: Lise (Id=3)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestNoFields()
        {
            Census.Data.People.Clear();
            var p = new Person(null, null, null, null);

            //-- KOMMENTAR - Endret Fornavn i testen fra "" til "Unknown" for for å gi brukeren mer relevant informasjon når et fornavn ikke er angitt i Person.cs

            var actualDescription = p.GetDescription();
            var expectedDescription = "Unknown (Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestSomeFields()
        {
            Census.Data.People.Clear();
            var p = new Person("Mia", "Waage", null, null);

            var actualDescription = p.GetDescription();
            var expectedDescription = "Mia Waage (Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}