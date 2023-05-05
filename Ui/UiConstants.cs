using Bill.Interfaces;

namespace Bill.Ui
{
    public class UiConstants
    {
        public const string DivLineNBefore = $"\n + {DivLine}";
        public const string DivLineNAfter = $"{DivLine} + \n";
        public const string DivLine = "--------------------------------";
        public const string NumberWrongInputMessage = "Number name? Interesting. Try again!";
        public const string EmptyNameWrongInputMessage = "Empty name, try again:";
        public const string NothingAddedWrongInputMessage = "Wrong userInput, noting was added";
        public const string NoGroupsMessage = "Empty name list, add new one(s) before continuing!";
        public const string ContinueReturnMessage = "\n\nPress 0 to continue, 00 to return!";
        public const string ReturnMessage = "\nPress 00 to return!";
        public const string EnterMessage = "\n(hit Enter after each userInput)";

        public static readonly IMenu _menu = new ConsoleImplementationMenu();
        public static readonly IMessage _message = new ConsoleImplementationMessage();
    }
}
