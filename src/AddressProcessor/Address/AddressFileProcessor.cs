using System.Linq;
using AddressProcessing.Address.v1;
using AddressProcessing.Contracts;

namespace AddressProcessing.Address
{
    public class AddressFileProcessor
    {
        private readonly IMailShot _mailShot;
        private readonly IReadCsv _csvReader;

        public AddressFileProcessor(IMailShot mailShot, IReadCsv csvReader)
        {
            _mailShot = mailShot;
            _csvReader = csvReader;
        }

        public void Process(string inputFile)
        {
            _csvReader.Open(inputFile);

            var columns = _csvReader.Read().ToList();
            while (columns.Any())
            {
                _mailShot.SendMailShot(columns[0], columns[1], columns[2], columns[3]);
                columns = _csvReader.Read().ToList();
            }

            _csvReader.Close();
        }
    }
}
