using System;
using System.Linq;

namespace Obligatorisk_Oppgave_1
{
    public class FamilyApp
    {
        public string HandleCommand(string command)
        {
            return command switch
            {
                Commands.Exit  => Exit(),
                Commands.Clear => ResetConsole(false),
                Commands.Help  => ResetConsole(true),
                Commands.List  => ListPeople(),
                _              => Default(command)
            };
        }
        #region Command Methods
        static string Exit()
        {
            Commands.ExitApplication();
            return null;
        }
        static string ResetConsole(bool showCommands)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{Commands.Welcome}\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(showCommands ? Commands.AvailableCommands : null);

            return null;
        }
        static string ListPeople()
        {
            var people = "";
            foreach (var person in Census.Data.People)
                people += $"{person.IntId} - {person.FirstName}{person.LastName}\n";

            Console.ForegroundColor = ConsoleColor.Yellow;
            return people;
        }
        static string Default(string command)
        {
            if (!command.Contains(Commands.ShowInputFormat)) return Commands.UnknownCommand;

            var index = command.IndexOf(' ');
            var input = command.Substring(index+1);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            return DescriptionFromStringId(input);

            static string DescriptionFromStringId(string input = null)
            {
                var success = int.TryParse(input, out var id);
                if (!success) return Commands.UnknownId;

                foreach (var person in Census.Data.People.Where(person => person.IntId == id))
                    return person.GetDescription();

                return Commands.UnknownId;
            }
        }
        #endregion
    }
}