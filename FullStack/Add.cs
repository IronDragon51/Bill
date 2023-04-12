using Bill.Backend;
using Bill.Definition;

namespace Bill.FullStack
{
    public class Add
    {
        public static void AddLoop(Receipt receipt, string currency)
        {
            string selectedGroupName = Select.SelectGroup(currency);
            Group group = AddItems(selectedGroupName, receipt, currency);
            string feeChoosen = Service.ChooseServiceFee(selectedGroupName);
            AddServiceFee(group, feeChoosen, currency, receipt);
        }


        public static void AddGroups(Groups groups)
        {
            Console.Clear();
            Console.Write("Add groups/people (separated with enter)  -- Press 0 to exit\n");

            string newGroup;
            while (true)
            {
                newGroup = Console.ReadLine()!;
                if (newGroup == "0")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(newGroup))
                {
                    Console.WriteLine("Empty name, try again:");
                }
                else if (Groups.groups.Any(n => n.Name == newGroup))
                {
                    Console.WriteLine($"{newGroup} already exists");
                }
                else
                {
                    groups.AddNewGroup(newGroup);
                }
            }
        }


        public static Group AddItems(string selectedGroupName, Receipt receipt, string currency)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Add item prices (separated with enter) to {selectedGroupName} -- Press 0 to exit");

            Group group = new("");
            double price = 0;
            while (true)
            {
                bool success = double.TryParse(Console.ReadLine(), out price);
                group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;

                if (success && price != 0)
                {
                    group!.Total += price;
                    receipt.Total += price;
                    Console.WriteLine($"Added {price} {currency}. Current total: {group.ToStringTotal(currency)}");
                }
                else if (success && price == 0)
                {
                    Console.WriteLine($"Total price to pay: {group.ToStringTotal(currency)}");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input, noting was added");
                }
            }

            return group;
        }


        public static void AddServiceFee(Group group, string feeChoosen, string currency, Receipt receipt)
        {
            double serviceFeePercent = 0;
            bool exit = false;
            while (!exit)
            {
                switch (feeChoosen)
                {
                    case "1":
                        serviceFeePercent = Calculation.SetFeePercent(out exit, ServiceFee.zero);
                        break;

                    case "2":
                        serviceFeePercent = Calculation.SetFeePercent(out exit, ServiceFee.low);
                        break;

                    case "3":
                        serviceFeePercent = Calculation.SetFeePercent(out exit, ServiceFee.medium);
                        break;

                    case "4":
                        serviceFeePercent = Calculation.SetFeePercent(out exit, ServiceFee.high);
                        break;

                    default:
                        Console.WriteLine("Wrong input, choose from 1,2,3,4 options");
                        break;
                }
            }

            Calculation.GetTotalsWithFee(group, receipt, serviceFeePercent);
            Show.ShowPricesDatas(group, currency, receipt);
            Calculation.CheckAllCalculated(receipt, currency);
        }
    }
}