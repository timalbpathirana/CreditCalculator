using System;
using System.Collections;
using System.Linq;
using CreditCalculator;

namespace CreditNUnitTests
{
	public enum AgeGroups
	{
		Age0To17 = 15,
		Age18To25 = 18,
		Age26To35 = 26,
		Age36To50 = 36,
		Age50Plus = 51
	}

	public enum CreditScoreGroup
	{
		Val0To450 = 200,
		Val451To700 = 600,
		Val701To850 = 800,
		Val851To1000 = 950
	}
	
	
	public class ProcessCreditGenerator
	{
		private static AgeGroups[] GetAllAgeGroups =>
			Enum.GetValues(typeof(AgeGroups)).Cast<AgeGroups>().ToArray();
		
		private static CreditScoreGroup[] GetCreditScoreGroups =>
			Enum.GetValues(typeof(CreditScoreGroup)).Cast<CreditScoreGroup>().ToArray();



		public static IEnumerable AllAgesWithMaxPoints()
		{
			foreach (var allAgeGroup in GetAllAgeGroups)
			{
				yield return new object[] {allAgeGroup, new ProcessCredit(new CreditCalculator.AnzCreditCalculator())};
			}
		}
		
		public static IEnumerable AllBureauScoreWithMaxPoints()
		{
			foreach (var creditGroup in GetCreditScoreGroups)
			{
				yield return new object[] {creditGroup, new ProcessCredit(new CreditCalculator.AnzCreditCalculator())};
			}
		}
	}
}