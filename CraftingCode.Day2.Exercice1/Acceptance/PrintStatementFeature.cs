using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CraftingCode.Day2.Exercice1.Acceptance
{
	[TestClass]
	public class PrintStatementFeature
	{
		private AccountService accountService;
		private string lastPrintScreen;

		[TestInitialize]
		public void TestInitialize()
		{
		}

		[TestMethod]
		public void print_statement_containing_transactions_in_reverse_chronological_order()
		{
			// Given
			an_empty_account();
			
			//When
			i_depose(500);
			i_withdraw(200);
			i_depose(100);

			//Then
			print_looks_like(
				"DATE      |AMOUNT |BALANCE|" +
				"15/09/2015|100.0  |400.0  |" +
				"15/09/2015|-200.0 |300.0  |" +
				"15/09/2015|500.0  |500.0  |");
		}

		private void an_empty_account()
		{
			accountService = new AccountService(new TransactionService(), new PrintService());
		}

		private void i_depose(int amount)
		{
			accountService.Deposit(amount);
		}

		private void i_withdraw(int amount)
		{
			accountService.Withdraw(amount);
		}

		private void print_looks_like(string dateAmountBalance)
		{
			accountService.PrintStatement();
			Assert.AreEqual(dateAmountBalance, lastPrintScreen);
		}


	}

	internal class PrintService : IPrintService
	{
		public void Print(IEnumerable<Transaction> alltransactions)
		{
			throw new NotImplementedException();
		}
	}

	internal class DateService : IDateService
	{
		public DateTime Now()
		{
			throw new NotImplementedException();
		}
	}

	public interface IPrintService
	{
		void Print(IEnumerable<Transaction> alltransactions);
	}
}
