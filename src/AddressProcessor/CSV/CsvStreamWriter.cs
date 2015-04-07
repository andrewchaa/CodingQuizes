using System.IO;
using AddressProcessing.Contracts;

namespace AddressProcessing.CSV
{
    public class CsvStreamWriter : IWriteStream
    {
        private StreamWriter _streamWriter;

        public void Open(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            _streamWriter = fileInfo.CreateText();
        }

        public void WriteLine(string outPut)
        {
            _streamWriter.WriteLine(outPut);
        }

        public void Close()
        {
            _streamWriter.Close();
        }
    }
}