using System.Linq;

namespace AddressProcessing.Address
{
    public class ContactParser : IParseContact
    {
        public Contact Parse(string input)
        {
            var columns = input.Split('\t').ToList();

            while (columns.Count < 4)
            {
                columns.Add(string.Empty);
            }

            return new Contact(columns[0], columns[1], columns[2], columns[3]);
        }
    }
}