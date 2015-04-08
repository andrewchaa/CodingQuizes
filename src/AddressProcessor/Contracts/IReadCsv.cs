using System.Collections;
using System.Collections.Generic;
using AddressProcessing.Address;

namespace AddressProcessing.Contracts
{
    public interface IReadCsv
    {
        void Open(string inputFile);
        IEnumerable<string> Read();
        void Close();
    }
}