using System.IO;
using AddressProcessing.Contracts;

namespace AddressProcessing.CSV
{
    public class CsvStreamReader : IReadStream
    {
        private StreamReader _streamReader;

        public void Open(string fileName)
        {
            _streamReader = File.OpenText(fileName);
        }

        public string ReadLine()
        {
            return _streamReader.ReadLine();
        }

        public void Close()
        {
            _streamReader.Close();
        }
    }
}
