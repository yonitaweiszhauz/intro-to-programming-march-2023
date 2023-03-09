using Banking.Domain;

namespace BankingUnitTest.TestDoubles;

public class DummyBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountOfDeposit)
    {
        return 0;
    }
}
