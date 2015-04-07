using System;
using System.Collections.Generic;
using AddressProcessing.Address;
using AddressProcessing.Contracts;

namespace AddressProcessing.CSV
{
    public class CsvReader : IReadCsv
    {
        private readonly IReadStream _streamReader;
        private readonly IParseContact _contactParser;

        public CsvReader(IReadStream streamReader, IParseContact contactParser)
        {
            _streamReader = streamReader;
            _contactParser = contactParser;
        }

        public void Open(string fileName)
        {
            _streamReader.Open(fileName);
        }

        public Contact Read()
        {
            var line = _streamReader.ReadLine();

            if (string.IsNullOrEmpty(line))
                return new NullContact();

            return _contactParser.Parse(line);
        }

        public void Close()
        {
            _streamReader.Close();
        }
    }
}