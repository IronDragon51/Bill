using System.Text;

namespace Bill.Definition
{
    public static class TextFiles
    {
        public static StreamWriter sw = new("C:\\VS\\BillTests\\Outputs\\output.txt", true, Encoding.UTF8);

    }
}
