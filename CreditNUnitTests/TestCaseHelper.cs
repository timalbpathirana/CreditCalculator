using System.Reflection.Metadata.Ecma335;
using CreditCalculator;

namespace CreditNUnitTests
{
	public class TestCaseHelper
	{
		public static Customer getCustomerByAge(AgeGroups data)
		{
			var age = data switch
			{
				AgeGroups.Age18To25 => 18,
				AgeGroups.Age26To35 => 26,
				AgeGroups.Age36To50=> 36,
				AgeGroups.Age50Plus => 51,
				AgeGroups.Age0To17 => 15,
				_ => 0
			};

			var customerToReturn = new Customer(800, 0, 10, age);
			return customerToReturn;
		}
		
		public static Customer getCustomerByBScore(CreditScoreGroup data)
		{
			var score = data switch
			{
				CreditScoreGroup.Val0To450 => 200,
				CreditScoreGroup.Val451To700 => 600,
				CreditScoreGroup.Val701To850 => 800,
				CreditScoreGroup.Val851To1000 => 950,
				_ => 0
			};

			var customerToReturn = new Customer(score, 0, 0, 30);
			return customerToReturn;
		}
	}
}