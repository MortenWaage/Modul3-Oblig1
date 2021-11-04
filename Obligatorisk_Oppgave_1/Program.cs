using System;

namespace Obligatorisk_Oppgave_1
{
    class Program
    {
        static FamilyApp _app;
        static void Main(string[] args)
        {
            Census.Data.AddPeople();

            _app = new FamilyApp();
            _app.HandleCommand(Commands.Help);

            while (true)
            {
                Commands.GetUserInput(out var command);
                var response = _app.HandleCommand(command);

                Console.WriteLine(response);
                Console.ForegroundColor = ConsoleColor.Gray; //--Reset Color back to Default before the next iteration of the loop
            }
        }
    }
}