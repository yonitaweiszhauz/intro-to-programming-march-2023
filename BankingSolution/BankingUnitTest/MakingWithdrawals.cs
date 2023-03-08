﻿
using Banking.Domain;

namespace Banking.UnitTest;

public class MakingWithdrawals
{
    [Theory]
    [InlineData(1)]
    [InlineData(1020.22)]
    public void MakingaWithdrawalDecreasesTheBalance(decimal amountToWithdraw)
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance(); // Query (Func)
        //var amountToWithdraw = 1M;

        // When
        account.Withdraw(amountToWithdraw); // Command (Action)

        // Then
        Assert.Equal(openingBalance + amountToWithdraw, account.GetBalance());
    }
}