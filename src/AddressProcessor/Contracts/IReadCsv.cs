using System.Collections;
using System.Collections.Generic;

namespace AddressProcessing.Contracts
{
    public interface IReadCsv
    {
        void Open(string inputFile);
        IEnumerable<string> Read();
        void Close();
    }
}