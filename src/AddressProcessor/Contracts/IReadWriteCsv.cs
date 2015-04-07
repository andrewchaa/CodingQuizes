using AddressProcessing.CSV;

namespace AddressProcessing.Contracts
{
    public interface IReadWriteCsv
    {
        void Open(string fileName, Mode mode);
        bool Read(out string column1, out string column2);
        void Close();
    }
}