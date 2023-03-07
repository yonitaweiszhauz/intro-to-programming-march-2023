
using Banking.Domain;

namespace Banking.UnitTest
{
    public class MakingDeposits
    {
        [Theory]
        [InlineData(100)]
        [InlineData(1.25)]
        public void DepositsIncreasesTheBalance( decimal amountToDeposit)
        {
            // Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance(); // Query (Func)
            //var amountToDeposit = 100M;

            // When
            account.Deposit(amountToDeposit); // Command (Action)

            // Then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}
