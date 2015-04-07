namespace AddressProcessing.Contracts
{
    public interface IWriteCsv 
    {
        void Open(string fileName);
        void Write(params string[] columns);
        void Close();
    }

}