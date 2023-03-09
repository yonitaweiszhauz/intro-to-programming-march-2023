using Banking.UnitTests.TestDoubles;
using Banking.Domain;
using Moq;

namespace BankingUnitTest; 

public class BankAccountUsesBonusCalculator
{
    [Fact()]
    public void IntegratesWithBonusCalculator()
    {
        var bankAccount = new BankAccount(new StubbedBonusCalculator());

        bankAccount.Deposit(212.83M);

        Assert.Equal(5000M + 212.83M + 12M, bankAccount.GetBalance());
    }

    public void IntegratesWithBonusCalculatorwithStubbedObjects()
    {
        var stubbedBonusCalculator = new Mock<ICalculateBonuses>();
        var bankAccount = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = bankAccount.GetBalance();
        var amountOfDeposit = 212.83M;
        stubbedBonusCalculator.Setup(dil => dil.CalculateBankAccountDepositBonusFor(bankAccount.GetBalance(), amountOfDeposit)).Returns(12M);

        bankAccount.Deposit(amountOfDeposit);

        Assert.Equal(openingBalance + amountOfDeposit + 12M, bankAccount.GetBalance());
    }
}