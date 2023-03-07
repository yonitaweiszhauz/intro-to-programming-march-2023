
using Banking.Domain;

namespace Banking.UnitTests;

public class OverdraftNotAllowed
{
    [Fact]
    public void BadBehaviorOverdraftIsAllowed()
    {
        var account = new BankAccount();

        account.Withdraw(account.GetBalance() + .01M);

        Assert.Equal(-.01M, account.GetBalance());
    }

    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        account.Withdraw(account.GetBalance() + .01M);

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
