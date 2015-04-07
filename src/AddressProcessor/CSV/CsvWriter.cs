using System.Linq;
using AddressProcessing.Contracts;

namespace AddressProcessing.CSV
{
    public class CsvWriter : IWriteCsv
    {
        private readonly IWriteStream _streamWriter;

        public CsvWriter(IWriteStream streamWriter)
        {
            _streamWriter = streamWriter;
        }

        public void Open(string fileName)
        {
            _streamWriter.Open(fileName);
        }

        public void Write(params string[] columns)
        {
            _streamWriter.WriteLine(GetTabedLineFrom(columns));
        }

        public void Close()
        {
            _streamWriter.Close();
        }

        private static string GetTabedLineFrom(string[] columns)
        {
            string outPut = string.Empty;

            var lastColumn = columns.Last();
            foreach (var column in columns)
            {
                outPut += column;
                if (column != lastColumn)
                    outPut += "\t";
            }
            return outPut;
        }
    }
}