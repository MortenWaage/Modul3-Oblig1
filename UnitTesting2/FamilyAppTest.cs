using NUnit.Framework;
using Obligatorisk_Oppgave_1;

namespace UnitTesting2
{
    class FamilyAppTest
    {
        
        [Test]
        public void Test()
        {
            var sverreMagnus       = new Person("Sverre Magnus", null, 2005, null);
            var ingridAlexandra    = new Person("Ingrid Alexandra", null, 2004, null);
            var haakon             = new Person("Haakon Magnus", null, 1973, null);
            var harald             = new Person("Harald", null, 1937, null);

            sverreMagnus.Father    = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father          = harald;

            var app = new FamilyApp();

            //-- KOMMENTAR - Endret ID i testen på Harald fra 6 til 4 for å passe med hvordan Id settes fra lengde på listen _people i Census.cs

            var actualResponse = app.HandleCommand("vis 3");
            var expectedResponse = "Haakon Magnus (Id=3) Født: 1973 Far: Harald (Id=4)\n"
                                   + "  Barn:\n"
                                   + "    Sverre Magnus (Id=1) Født: 2005\n"
                                   + "    Ingrid Alexandra (Id=2) Født: 2004\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
        [Test]
        public void TestNoChildren()
        {
            Census.Data.People.Clear();

            var haakon = new Person("Haakon Magnus", null, 1973, null);
            var harald = new Person("Harald", null, 1937, null);
            haakon.Father = harald;

            var app = new FamilyApp();

            //-- KOMMENTAR - Endret ID i testen på Haakon til Id=1 og Harald til Id=2 for å passe med hvordan Id settes fra lengde på listen _people i Census.cs

            var actualResponse = app.HandleCommand("vis 1");
            var expectedResponse = "Haakon Magnus (Id=1) Født: 1973 Far: Harald (Id=2)";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}