using System;

namespace Invoicing
{
    public class Invoice
    {
        private ITaxRateHelper taxRateHelper;

        public Invoice(ITaxRateHelper taxRateHelper)
        {
            this.taxRateHelper = taxRateHelper;
        }

        public int SubTotal { get; set; }
        public double Tax { get; set; }
        public string ZipCode { get; set; }

        public void Calculate()
        {
            var taxRate = taxRateHelper.GetTaxRate(ZipCode);
            Tax = SubTotal * taxRate;
        }
    }
}