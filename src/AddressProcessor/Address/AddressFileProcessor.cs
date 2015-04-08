using System.Linq;
using AddressProcessing.Address.v2;
using AddressProcessing.Contracts;

namespace AddressProcessing.Address
{
    public class AddressFileProcessor
    {
        private readonly IMailShot _mailShot;
        private readonly IReadCsv _csvReader;
        private readonly IParseAddress _addressParser;

        public AddressFileProcessor(IMailShot mailShot, IReadCsv csvReader, IParseAddress addressParser)
        {
            _mailShot = mailShot;
            _csvReader = csvReader;
            _addressParser = addressParser;
        }

        public void Process(string inputFile)
        {
            _csvReader.Open(inputFile);

            var columns = _csvReader.Read().ToList();

            while (columns.Count > 0)
            {
                var address = _addressParser.Parse(columns[1]);
                var contact = new Contact(columns[0], address, columns[2], columns[3]);

                _mailShot.SendPostalMailShot(contact.Name, address.Address, address.City, address.Province, address.Country, address.PostCode);
                _mailShot.SendEmailMailShot(contact.Name, contact.Email);
                _mailShot.SendSmsMailShot(contact.Name, contact.Phone);

                columns = _csvReader.Read().ToList();
            }

            _csvReader.Close();
        }
    }
}
