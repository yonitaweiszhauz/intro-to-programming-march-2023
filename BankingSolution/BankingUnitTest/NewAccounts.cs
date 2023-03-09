using Banking.Domain;
using BankingUnitTest.TestDoubles;
using Moq;

namespace BankingUnitTest;

    public class NewAccounts
    {
        [Fact]
        public void NewAccountHasCorrectOpeningBalance()
        {
            // "Write the code you wish you had" (WTCYWYH)
            // Given
            var account = new BankAccount(new Mock<ICalculateBonuses>().Object);
            // When
            decimal balance = account.GetBalance();
            // Then
            Assert.Equal(5000, balance);
        }
    }
