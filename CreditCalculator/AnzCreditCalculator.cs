namespace CreditCalculator
{
	public class AnzCreditCalculator : ICreditCalculator
	{
		public decimal CalculateCredit(Customer customer)
		{
			var creditCalcHelper = new CreditCalculatorHelper();

			var customerBScore = creditCalcHelper.GetCustomerBScore(customer.BureauScore);
			var customerMissedScore = creditCalcHelper.GetCustomerMissedPaymentPoints(customer.MissedPaymentCount);
			var customerCompletedScore =
				creditCalcHelper.GetCustomerCompletedPaymentPoints(customer.CompletedPaymentCount);
			var totalPointsByAge = creditCalcHelper.GetCustomerPointsByAge(customer.AgeInYears);
			var totalPoints = customerBScore + customerMissedScore + customerCompletedScore;

			if (creditCalcHelper.IsValid)
			{
				return totalPoints > totalPointsByAge
					? creditCalcHelper.GetCustomerMaxCreditAmount(totalPointsByAge)
					: creditCalcHelper.GetCustomerMaxCreditAmount(totalPoints);
			}
			else return 0;
		}
	}
}