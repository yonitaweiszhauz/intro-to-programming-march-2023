using Banking.Domain;

namespace BankingUnitTest.BonusCalculations
{
    public class BasicBonusCalculatorTests
    {
        // depsits that meet the criteria get a bonus
        [Theory]
        [InlineData(5000, 100, 10)]
        [InlineData(5000, 200, 20)] // at boundary
        [InlineData(4999.99, 100, 0)] // below boundary (add as needed)
        public void DepositsGetBonusBasedOnBalance(decimal balance, decimal amount, decimal expectedBonus)
        {
            // Given
            var bonusCalculator = new StandardBonusCalculator();

            // When
            decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(balance, amount);

            // Then
            Assert.Equal(expectedBonus, bonus);
        }
        // deposits that do not meet the criteria do not get a bonus
    }
}
