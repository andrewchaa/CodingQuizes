using System;
using System.Collections.Generic;
using System.Linq;
using AddressProcessing.Address;
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
            var input = _streamReader.ReadLine();

            if (string.IsNullOrEmpty(input))
                return new List<string>();

            var columns = input.Split('\t').ToList();
            while (columns.Count < 4)
            {
                columns.Add(string.Empty);
            }

            return columns;
        }

        public void Close()
        {
            _streamReader.Close();
        }
    }
}