namespace Bill.Interfaces
{
    public class ConsoleImplementationMessage : IMessage
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
            if (message.Contains("Press any key"))
            {
                Console.ReadKey();
            }
            else if (message.Contains("All groups / person calculated!"))
            {
                Environment.Exit(0);
            }
        }
    }
}