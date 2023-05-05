using Bill.Interfaces;

namespace Bill.Ui
{
    public class UiConst
    {
        public const string divLineNBefore = "\n" + divLine;
        public const string divLineNAfter = divLine + "\n";
        public const string divLine = "--------------------------------";
        public const string numberWrongInputMessage = "Number name? Interesting. Try again!";
        public const string emptyNameWrongInputMessage = "Empty name, try again:";
        public const string nothingAddedWrongInputMessage = "Wrong input, noting was added";
        public const string noGroupsMessage = "Empty name list, add new one(s) before continuing!";
        public const string continueReturnMessage = "\n\nPress 0 to continue, 00 to return!";
        public const string returnMessage = "\nPress 00 to return!";
        public const string enterMessage = "\n(hit Enter after each input)";

        public static readonly IMenu _menu = new ConsoleImplementationMenu();
        public static readonly IMessage _message = new ConsoleImplementationMessage();
    }
}
