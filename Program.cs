﻿using Bill.Definition;
using Bill.FullStack;

namespace Bill
{
    public class Program
    {
        //public const char ESC = '\x1B';
        static void Main()
        {
            Groups groups = new();
            Receipt receipt = new();

            Add.AddGroups(groups);
            string currency = Select.SelectCurrency();
            Add.AddLoop(receipt, currency);
        }
    }
}