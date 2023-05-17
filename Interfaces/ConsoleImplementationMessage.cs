namespace Bill.Interfaces
{
    public class ConsoleImplementationMessage : IMessage
    {
        public void ShowMessage(string message)
        {
            if (message.Contains("Add groups") || message.Contains("Welcome"))
            {
                Console.Clear();
            }

            Console.WriteLine(message);

            if (message.Contains("Press any key"))
            {
                Console.ReadKey(true);
            }
            else if (message.Contains("persons calculated!"))
            {
                Environment.Exit(0);
            }
        }
    }
}