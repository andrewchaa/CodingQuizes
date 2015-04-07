using System.Collections.Generic;
using System.Linq;
using AddressProcessing.Contracts;

namespace AddressProcessing.Address
{
    public class AddressParser : IParseAddress
    {
        public AddressRecord Parse(string address)
        {
            var columns = address.Split('|').ToList();

            while (columns.Count < 5)
            {
                columns.Add(string.Empty);
            }

            return new AddressRecord(columns[0], columns[1], columns[2], columns[3], columns[4]);
        }
    }
}