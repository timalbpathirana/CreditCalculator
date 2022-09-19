using CreditCalculator;
using NUnit.Framework;


namespace CreditNUnitTests
{
	[TestFixture]
	public class Tests
	{
		[SetUp]
		public void Init()
		{
			
		}
		
		[Test]
		[TestCaseSource(typeof(ProcessCreditGenerator), nameof(ProcessCreditGenerator.AllAgesWithMaxPoints))]
		public void ifUser_HasPointsMoreThanAge_CreditToBeApprovedForAgeGroup(AgeGroups sst, ProcessCredit process)
		{
			var customer = TestCaseHelper.getCustomerByAge(sst);
			var val = process.ProcessCustomerCredit(customer);
			
			switch (customer.AgeInYears)
			{
				case 18:
				Assert.AreEqual(300, val);
					break;
				case 26:
					Assert.AreEqual(400, val);
					break;
				case 36:
					Assert.AreEqual(500, val);
					break;
				case 51:
					Assert.AreEqual(600, val);
					break;
				case 15:
					Assert.AreEqual(0, val);
					break;
			}
			
		}
		
		[Test]
		[TestCaseSource(typeof(ProcessCreditGenerator), nameof(ProcessCreditGenerator.AllBureauScoreWithMaxPoints))]
		public void isUser_HasBadCreditScore_NoCreditToBeApproved(CreditScoreGroup csg, ProcessCredit process)
		{
			var customer = TestCaseHelper.getCustomerByBScore(csg);
			var val = process.ProcessCustomerCredit(customer);
			
			switch (customer.BureauScore)
			{
				case 200:
					Assert.AreEqual(0, val);
					break;
				case 600:
					Assert.AreEqual(100, val);
					break;
				case 800:
					Assert.AreEqual(200, val);
					break;
				case 950:
					Assert.AreEqual(300, val);
					break;
			}
		}
		
		[Test]
		public void isUser_HasGreatCreditScoreButUnderage_NoCreditToBeApproved()
		{
			var customer = new Customer(800, 0, 10, 15);
			var process = new ProcessCredit(new CreditCalculator.AnzCreditCalculator());
			
			Assert.AreEqual(0, process.ProcessCustomerCredit(customer));
		}
		
		[Test]
		public void isUser_HasBadCreditData_NoCreditToBeApproved()
		{
			var customer = new Customer(6953, 0, 10, 30);
			var process = new ProcessCredit(new CreditCalculator.AnzCreditCalculator());
			
			Assert.AreEqual(0, process.ProcessCustomerCredit(customer));
		}
		
		[Test]
		public void ifUser_HasNegativeTotalPoints_NoCreditToBeApproved()
		{
			var customer = new Customer(800, 10, 5, 30);
			var process = new ProcessCredit(new CreditCalculator.AnzCreditCalculator());
			
			Assert.AreEqual(0, process.ProcessCustomerCredit(customer));
		}
		
		[Test]
		public void ifUser_HasPositiveTotalPointsBelowAgeLimit_CreditToBeApproved()
		{
			var customer = new Customer(800, 0, 10, 30);
			var process = new ProcessCredit(new CreditCalculator.AnzCreditCalculator());
			
			Assert.AreEqual(400, process.ProcessCustomerCredit(customer));
		}
	}
}