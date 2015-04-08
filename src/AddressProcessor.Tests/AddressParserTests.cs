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
            const string line = "Shelby Macias	3027 Lorem St.|Kokomo|Hertfordshire|L9T 3D5|Finland	1 66 890 3865-9584	et@eratvolutpat.ca";

            //act
            var address = parser.Parse(line);

            //assert
            Assert.That(address.Address, Is.EqualTo("3027 Lorem St."));
            Assert.That(address.City, Is.EqualTo("Kokomo"));
            Assert.That(address.Province, Is.EqualTo("Hertfordshire"));
            Assert.That(address.PostCode, Is.EqualTo("L9T 3D5"));
            Assert.That(address.Country, Is.EqualTo("Finland"));
            Assert.That(address.Name, Is.EqualTo("Shelby Macias"));
            Assert.That(address.Phone, Is.EqualTo("1 66 890 3865-9584"));
            Assert.That(address.Email, Is.EqualTo("et@eratvolutpat.ca"));
        }

        [Test]
        public void It_should_handle_single_column_address()
        {
            //arrange
            var parser = new AddressParser();
            const string line = "Shelby Macias	P.O. Box 954	1 66 890 3865-9584	et@eratvolutpat.ca";

            //act
            var address = parser.Parse(line);

            //assert
            Assert.That(address.Address, Is.EqualTo("P.O. Box 954"));
            Assert.That(address.City, Is.Empty);
            Assert.That(address.Province, Is.Empty);
            Assert.That(address.PostCode, Is.Empty);
            Assert.That(address.Country, Is.Empty);
        }
    }
}
