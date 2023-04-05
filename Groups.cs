namespace Bill
{
    public static class Groups
    {
        public static List<Group> groups = new();

        public static void AddNewGroup(string name)
        {
            groups.Add(new Group(name));
        }
    }
}
