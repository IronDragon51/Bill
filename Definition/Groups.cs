﻿namespace Bill.Definition
{
    public class Groups
    {
        public static List<Group> groups = new();
        public string? selectedGroupName { get; set; }

        public static void AddNewGroup(string name)
        {
            groups.Add(new Group(name));
        }
    }
}
