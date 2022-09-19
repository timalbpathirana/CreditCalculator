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
			
			// Dependence Injection
			// If we want to create a new calculator for USA market, we can smiply create a new class 
			// called UsaCreditCalculator and uses ICreditCalculator interface. 
			// then we can change the CalculateCredit() method according to the needs for USA market 
			// and simply make a new process, 
			// 	var newProcess = new ProcessCredit(new UsaCreditCalculator());
			// This way, the actual ProcessCustomerCredit() method inside ProcessCredit is independent with the
			// CreditCalculator class. 

		}
	}
}