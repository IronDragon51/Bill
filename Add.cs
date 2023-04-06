namespace Bill
{
    public class Add
    {
        public static string AddGroups(Groups groups)
        {
            Console.Write("Add groups/people (separated with enter)");
            Console.WriteLine(" -- Press 0 to exit");

            string input;
            while (true)
            {
                input = Console.ReadLine()!;

                if (input == "0")
                {
                    break;
                }
                else if (Groups.groups.All(n => n.Name != input))
                {
                    groups.AddNewGroup(input);
                }
                else
                {
                    Console.WriteLine($"{input} already exists");
                }
            }

            return input;
        }


        public static void AddItems(string input, Groups groups, Receipt receipt)
        {
            Console.WriteLine("--------------------------------");
            Console.Write($"Add item prices (separated with enter) to {input}");
            Console.WriteLine(" -- Press 0 to exit");

            double price = 0;
            while (true)
            {
                bool success = double.TryParse(Console.ReadLine(), out price);
                Group? group = Groups.groups.FirstOrDefault(g => g.Name == input);

                if (success && price != 0)
                {
                    group!.Total += price;
                    receipt.Total += price;
                    Console.WriteLine($"Added {price}. Current total: {group.Total}");
                }
                else if (success && price == 0)
                {
                    Console.WriteLine($"Total price to pay: {group!.Total}");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input, noting was added");
                }
            }
        }
    }
}