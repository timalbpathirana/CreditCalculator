using System;

namespace CreditCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			var newProcess = new ProcessCredit(new AnzCreditCalculator());
			var customerToReturn = new Customer(800, 0, 10, 30);
			Console.WriteLine($"3 Can get {newProcess.ProcessCustomerCredit(customerToReturn)}");
		}
	}
}