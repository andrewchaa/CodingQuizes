using System.Collections.Generic;
using System.Linq;
using AddressProcessing.Contracts;

namespace AddressProcessing.Address
{
    public class AddressParser : IParseAddress
    {
        public AddressRecord Parse(string input)
        {
            var columns = input.Split('\t').ToList();
            while (columns.Count < 4)
            {
                columns.Add(string.Empty);
            }

            var addressColumns = columns[1].Split('|').ToList();
            while (addressColumns.Count < 5)
            {
                addressColumns.Add(string.Empty);
            }

            return new AddressRecord(addressColumns[0], addressColumns[1], addressColumns[2], addressColumns[3], addressColumns[4], 
                columns[0], columns[2], columns[3]);
        }
    }
}