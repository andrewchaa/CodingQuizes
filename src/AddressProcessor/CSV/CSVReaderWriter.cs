using System;
using System.Linq;
using AddressProcessing.Address;
using AddressProcessing.Contracts;

namespace AddressProcessing.CSV
{
    [Flags]
    public enum Mode { Read = 1, Write = 2 };

    [Obsolete("Use CvsReader and CvsWriter instead")]
    public class CSVReaderWriter : IReadWriteCsv
    {
        private readonly IReadCsv _csvReader;
        private readonly IWriteCsv _csvWriter;
        private Mode _mode;

        public CSVReaderWriter(IReadCsv csvReader, IWriteCsv csvWriter)
        {
            _csvReader = csvReader;
            _csvWriter = csvWriter;
        }

        public void Open(string fileName, Mode mode)
        {
            _mode = mode;

            if (_mode == Mode.Read)
            {
                _csvReader.Open(fileName);
                return;
            }

            _csvWriter.Open(fileName);
        }

        public void Write(params string[] columns)
        {
            _csvWriter.Write(columns);
        }

        public bool Read(out string column1, out string column2)
        {
            column1 = null;
            column2 = null;

            var contact = _csvReader.Read();

            if (contact is NullContact)
                return false;

            column1 = contact.Name;
            column2 = contact.Address;
                
            return true;
        }

        public void Close()
        {
            if (_mode == Mode.Read)
            {
                _csvReader.Close();
                return;
            }

            _csvWriter.Close();
        }
    }
}
