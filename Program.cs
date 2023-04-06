namespace Bill
{
    public class Program
    {
        static void Main(string[] args)
        {
            Groups groups = new();
            Receipt receipt = new();
            string input = Add.AddGroups(groups);

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Select a group/person to add prices to");

            input = Console.ReadLine()!;

            try
            {
                if (!Groups.groups.Any(n => n.Name == input))
                {

                }
            }
            catch (Exception e)
            {
                throw new ArgumentException($"No group like this ({input}) / {e}");
            }

            Add.AddItems(input, groups, receipt);

            Service.ChooseServiceFee(input, groups, receipt);

        }


    }
}