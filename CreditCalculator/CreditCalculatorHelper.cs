namespace CreditCalculator
{
	public class CreditCalculatorHelper
	{
		public bool IsValid { get; private set; }

		public int GetCustomerBScore(int value)
		{
			var customerBureauScore = 0;
			IsValid = true; //0-450 Not Allowed to use Zip

			if (value <= 0) return customerBureauScore;

			if (value < 451)
			{
				customerBureauScore = 0;
				IsValid = false;
			}
			else if (value < 701)
			{
				customerBureauScore = 1;
			}
			else if (value < 851)
			{
				customerBureauScore = 2;
			}
			else if (value < 1001)
			{
				customerBureauScore = 3;
			}
			else //where Bscore is above 1000 for some reason
			{
				IsValid = false;
			}

			return customerBureauScore;
		}

		public int GetCustomerMissedPaymentPoints(int value)
		{
			var pointsToReturn = 0;

			if (value < 0) return pointsToReturn;
			switch (value)
			{
				case 0:
					pointsToReturn = 0;
					break;
				case 1:
					pointsToReturn = -1;
					break;
				case 2:
					pointsToReturn = -3;
					break;
				default:
				{
					pointsToReturn = -6;

					break;
				}
			}

			return pointsToReturn;
		}

		public int GetCustomerCompletedPaymentPoints(int value)
		{
			var pointsToReturn = 0;
			if (value < 0) return pointsToReturn;
			switch (value)
			{
				case 0:
					pointsToReturn = 0;
					break;
				case 1:
					pointsToReturn = 2;
					break;
				case 2:
					pointsToReturn = 3;
					break;
				default:
				{
					pointsToReturn = 4;
					break;
				}
			}

			return pointsToReturn;
		}

		public int GetCustomerPointsByAge(int age)
		{
			int pointsToReturn = 0;

			if (age < 18) return 0;

			if (age < 26)
			{
				pointsToReturn = 3;
			}
			else if (age < 36)
			{
				pointsToReturn = 4;
			}
			else if (age < 51)
			{
				pointsToReturn = 5;
			}
			else
			{
				pointsToReturn = 6;
			}

			return pointsToReturn;
		}

		public int GetCustomerMaxCreditAmount(int points)
		{
			int creditToReturn;
			if (points <= 0) return 0;

			switch (points)
			{
				case 1:
					creditToReturn = 100;
					break;
				case 2:
					creditToReturn = 200;
					break;
				case 3:
					creditToReturn = 300;
					break;
				case 4:
					creditToReturn = 400;
					break;
				case 5:
					creditToReturn = 500;
					break;
				default:
				{
					creditToReturn = 600;
					break;
				}
			}

			return creditToReturn;
		}
	}
}