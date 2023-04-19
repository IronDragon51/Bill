using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;

namespace Bill.FullStack
{
    public static class Add
    {
        private static readonly ISelectMsgShow selectMsgShow = new ConsoleImplementationSelectShow();
        private static readonly IShortMsgShow shortMsgShow = new ConsoleImplementationAddShow();

        public static void AddLoop(Receipt receipt, string currency)
        {
            string selectedGroupName = Select.SelectGroup(currency);
            Group group = AddItems(selectedGroupName, receipt, currency);
            string feeChoosen = Service.ChooseServiceFee(selectedGroupName);
            AddServiceFee(group, feeChoosen, currency, receipt);
        }

        public static void AddGroups(Groups groups)
        {
            shortMsgShow.AddGroupsMessage();

            while (true)
            {
                string newGroup = Console.ReadLine()!;

                if (newGroup == "0")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(newGroup))
                {
                    shortMsgShow.EmptyNameWrongInputMessage();
                }
                else if (int.TryParse(newGroup, out _))
                {
                    shortMsgShow.NumberWrongInputMessage();
                }
                else if (Groups.groups.Any(n => n.Name == newGroup))
                {
                    shortMsgShow.GroupExistsWrongInputMessage(newGroup);
                }
                else
                {
                    groups.AddNewGroup(newGroup);
                }
            }
        }


        public static Group AddItems(string selectedGroupName, Receipt receipt, string currency)
        {
            shortMsgShow.AddItemPricesMessage(selectedGroupName);
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
                    shortMsgShow.AddedPriceInfoMessage(currency, group, price);
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
                        feeChoosen = Console.ReadLine()!;
                        break;
                }
            }

            Calculation.GetTotalsWithFee(group, receipt, serviceFeePercent);
            selectMsgShow.ShowPricesDatas(group, currency, receipt);
            Calculation calculation = new();
            calculation.CheckAllCalculated(receipt, currency);
        }
    }
}