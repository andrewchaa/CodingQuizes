using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressProcessing.Address;
using NUnit.Framework;

namespace AddressProcessing.Tests
{
    [TestFixture]
    public class AddressParserTests
    {
        [Test]
        public void It_should_parse_pipe_delimitted_address_string()
        {
            //arrange
            var parser = new AddressParser();
            const string line = "Ap #827-9064 Sapien. Rd.|Palo Alto|Fl.|HM0G 0YR|Cameroon";

            //act
            var address = parser.Parse(line);

            //assert
            Assert.That(address.Address, Is.EqualTo("Ap #827-9064 Sapien. Rd."));
            Assert.That(address.City, Is.EqualTo("Palo Alto"));
            Assert.That(address.Province, Is.EqualTo("Fl."));
            Assert.That(address.PostCode, Is.EqualTo("HM0G 0YR"));
            Assert.That(address.Country, Is.EqualTo("Cameroon"));
        }

        [Test]
        public void It_should_handle_single_column_address()
        {
            //arrange
            var parser = new AddressParser();
            const string line = "P.O. Box 954";

            //act
            var address = parser.Parse(line);

            //assert
            Assert.That(address.Address, Is.EqualTo(line));
            Assert.That(address.City, Is.Empty);
            Assert.That(address.Province, Is.Empty);
            Assert.That(address.PostCode, Is.Empty);
            Assert.That(address.Country, Is.Empty);
        }
    }
}
