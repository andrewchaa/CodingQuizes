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

            var contact = _csvReader.Read();
            var address = _addressParser.Parse(contact.Address);

            while (!(contact is NullContact))
            {
                _mailShot.SendPostalMailShot(contact.Name, address.Address, address.City, address.Province, address.Country, address.PostCode);
                _mailShot.SendEmailMailShot(contact.Name, contact.Email);
                _mailShot.SendSmsMailShot(contact.Name, contact.Phone);

                contact = _csvReader.Read();
            }

            _csvReader.Close();
        }
    }
}
