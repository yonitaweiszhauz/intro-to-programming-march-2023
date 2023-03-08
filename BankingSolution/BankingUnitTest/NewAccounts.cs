using Banking.Domain;

namespace BankingUnitTest;

    public class NewAccounts
    {
        [Fact]
        public void NewAccountHasCorrectOpeningBalance()
        {
            // "Write the code you wish you had" (WTCYWYH)
            // Given
            var account = new BankAccount();
            // When
            decimal balance = account.GetBalance();
            // Then
            Assert.Equal(5000, balance);
        }
    }
