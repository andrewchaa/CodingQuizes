using System;
using System.Collections.Generic;
using AddressProcessing.Contracts;

namespace AddressProcessing.CSV
{
    public class CsvReader : IReadCsv
    {
        private readonly IReadStream _streamReader;

        public CsvReader(IReadStream streamReader)
        {
            _streamReader = streamReader;
        }

        public void Open(string fileName)
        {
            _streamReader.Open(fileName);
        }

        public IEnumerable<string> Read()
        {
            var line = _streamReader.ReadLine();

            if (string.IsNullOrEmpty(line)) 
                return new String [] {};

            return line.Split('\t');
        }

        public void Close()
        {
            _streamReader.Close();
        }
    }
}