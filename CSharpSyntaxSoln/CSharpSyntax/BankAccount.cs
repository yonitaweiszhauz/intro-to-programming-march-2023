namespace CSharpSyntax;

public class BankAccount
{
    private string _accountNumber = string.Empty;
    private string _firstName = string.Empty;

    /*public string GetFirstName()
    {
        return _firstName;
    }

    public void SetFirstName(string value)
    {
        _firstName = value;
    }*/
    
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
    internal BankAccount(string accountNumber)
    {
        _accountNumber = accountNumber; 
    }

    public string GetAccountNumber()
    {
        return _accountNumber;
    }
}

public class AccountManager
{
    public BankAccount GetAccountById(string accountNumber)
    {
        return new BankAccount(accountNumber);
    }
}
