using AddressProcessing.Address;

namespace AddressProcessing.Contracts
{
    public interface IParseAddress
    {
        AddressRecord Parse(string input);
    }
}