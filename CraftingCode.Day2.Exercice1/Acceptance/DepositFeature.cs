using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CraftingCode.Day2.Exercice1.Acceptance
{
	[TestClass]
	public class DepositFeature
	{
		private AccountService accountService;
		private string lastPrintScreen;

		[TestMethod]
		public void print_deposed_money()
		{
			// Given
			an_empty_account();
			
			//When
			i_depose(500);

			//Then
			print_looks_like(
				"DATE      |AMOUNT |BALANCE|" +
				"15/09/2015|500.0  |500.0  |");
		}

		private void an_empty_account()
		{
			accountService = new AccountService();
		}

		private void i_depose(int amount)
		{
			accountService.Deposit(amount);
		}

		private void print_looks_like(string dateAmountBalance)
		{
			accountService.PrintStatement();
			Assert.AreEqual(dateAmountBalance, lastPrintScreen);
		}


	}
}
