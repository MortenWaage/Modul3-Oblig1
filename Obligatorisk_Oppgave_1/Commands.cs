using System;

namespace Obligatorisk_Oppgave_1
{
    public static class Commands
    {
        public const string UnknownId          = "Could not find a person with this Id";
        public const string UnknownCommand     = "Unknown command. Please try again";
        public const string Help               = "help";
        public const string List               = "list";
        public const string Show               = "vis +id";
        public const string ShowInputFormat    = "vis ";
        public const string Clear              = "clear";
        public const string Exit               = "exit";
        public const string Welcome            = "Velkommen til family-app";
        public const string Input              = "\nWaiting for Input:";
        public static string AvailableCommands => $"\nKommandoer er: \n- {Help}\n- {List}\n- {Show}\n- {Clear}\n- {Exit}\n";

        public static void ExitApplication() => Environment.Exit(0);

        public static void GetUserInput(out string command)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Input);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(Input.Length, Console.CursorTop - 1);
            command = Console.ReadLine();
        }
    }
}
