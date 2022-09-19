namespace CreditCalculator
{
	public class ProcessCredit
	{
		private readonly ICreditCalculator _creditCalculator;

		public ProcessCredit(ICreditCalculator calculator)
		{
			_creditCalculator = calculator;
		}

		public decimal ProcessCustomerCredit(Customer customer)
		{
			return _creditCalculator.CalculateCredit(customer);
		}
	}
}