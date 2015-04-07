namespace AddressProcessing.Contracts
{
    public interface IReadStream
    {
        void Open(string fileName);
        string ReadLine();
        void Close();
    }
}