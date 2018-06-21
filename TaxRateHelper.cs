namespace Invoicing
{
        public interface ITaxRateHelper
        {
            double GetTaxRate(string zipCode);
        }
}