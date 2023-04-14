namespace Bill.Definition
{
    public class Groups
    {
        public static List<Group> groups = new();

        public void AddNewGroup(string name)
        {
            groups.Add(new Group(name));
        }
    }
}