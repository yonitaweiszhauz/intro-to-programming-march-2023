
using Banking.Domain;

namespace Banking.UnitTest
{
    public class OverdraftNotAllowed
    {

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(account.GetBalance() + 0.1M);
            }
            catch (OverdraftException)
            {

                //Ignore this..
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }
    }

    [Fact]
    public void OverdraftThrowsException()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        Assert.Throws<OverdraftException>(() =>
        {
            account.Withdraw(account.GetBalance() + 0.1M);
        });
    }
}
