namespace AddressProcessing.Contracts
{
    public interface IWriteStream
    {
        void Open(string fileName);
        void WriteLine(string outPut);
        void Close();
    }
}