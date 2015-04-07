using AddressProcessing.Address;
using NUnit.Framework;

namespace AddressProcessing.Tests
{
    [TestFixture]
    public class ContactParserTests
    {
        [Test]
        public void It_should_parse_tab_delimitted_text_into_contact()
        {
            //arrange
            const string text = "Shelby Macias	3027 Lorem St.|Kokomo|Hertfordshire|L9T 3D5|Finland	1 66 890 3865-9584	et@eratvolutpat.ca";
            var parser = new ContactParser();

            //act
            var contact = parser.Parse(text);

            //assert
            Assert.That(contact.Name, Is.EqualTo("Shelby Macias"));
            Assert.That(contact.Address, Is.EqualTo("3027 Lorem St.|Kokomo|Hertfordshire|L9T 3D5|Finland"));
            Assert.That(contact.Phone, Is.EqualTo("1 66 890 3865-9584"));
            Assert.That(contact.Email, Is.EqualTo("et@eratvolutpat.ca"));
        }
    }
}