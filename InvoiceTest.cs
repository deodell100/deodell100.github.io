using System;
using Invoicing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Invoice_Test
{
    [TestClass]
    public class InvoiceTest
    {
        [TestMethod]
        public void CalculateTest()
        {
            //Arrange
            var taxRateHelper = new Moq.Mock<ITaxRateHelper>();

            //taxRateHelper.Setup(x => x.GetTaxRate(It.IsAny<string>())).Returns(.08);
            taxRateHelper.Setup(x => x.GetTaxRate("75219")).Returns(.08);

            var invoice = new Invoice(taxRateHelper.Object)
            {
                SubTotal = (int)5,
                ZipCode = "75219"
            };

            //Act
            invoice.Calculate();

            //Assert
            //Verifies TaxRate is 75219 once
            taxRateHelper.Verify(x => x.GetTaxRate("75219"), Times.Once);

            Assert.AreEqual(.4, invoice.Tax);
        }
    }
}
