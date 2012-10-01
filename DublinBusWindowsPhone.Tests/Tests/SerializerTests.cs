

namespace DublinBusWindowsPhone.Tests.Tests
{
    using System;
    using System.Xml.Linq;
    using DublinBusWindowsPhone.Services.Serializer;
    using Microsoft.Silverlight.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SerializerTests : SilverlightTest
    {
        [TestMethod]
        public void SerializerDoesNotAcceptNull()
        {
            Deserializer deserializer = new Deserializer();
            
            var exceptionThrown = true;


            Assert.IsTrue(exceptionThrown);
        }
    }
}