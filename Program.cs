﻿using Bill.Definition;
using Bill.FullStack;
using Bill.Ui;

namespace Bill
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Groups groups = new();
            Receipt receipt = new();

            UiConst._message.ShowMessage(UiMessage.WelcomeMessage());
            UiConst._message.ShowMessage(UiMessage.ContinueMessage());
            Add.AddGroups(groups);
            string currency = Select.SelectCurrency();
            Add.AddLoop(receipt, currency);

        }
    }
}