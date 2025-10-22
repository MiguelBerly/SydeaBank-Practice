using Microsoft.VisualBasic;

namespace Bank_Konto;

public class BankAccount
{
    /*
     * Skapa bankkonto, ska innehålla :
     * personnummer,
     * för och efternamn,
     * saldo,
     * historik (tid och datum) --
     */
    public string FirstName { get; }
    public string LastName { get; }
    public string SocialSecurityNumber { get; }
    private decimal _balance { get; set; }

    private List<string> _transactionHistory { get;}

    public BankAccount(string firstName, string lastName,
        string socialSecurityNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        SocialSecurityNumber = socialSecurityNumber;
        _balance = 0m;
        _transactionHistory = new List<string>();
    }

    public double ShowBalance()
    {
        double showBalance = (double)Math.Round(_balance, 2);
        return showBalance;
    }

    public decimal DepositMoney(decimal depositAmount)
    {
        decimal currentBalance = _balance;
        currentBalance += depositAmount;
        _balance = currentBalance;
        return currentBalance;
        
    }
    
    public decimal WithdrawMoney(decimal withdrawAmount)
    {
        decimal currentBalance = _balance;
        currentBalance -= withdrawAmount;
        _balance = currentBalance;
        return currentBalance;
    }

    public void AddTransactionHistory(string serviceType, decimal amount, string sign, decimal balance)
    {
        string datetime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        amount =  Math.Round(amount, 2);
        balance = Math.Round(balance, 2);
        _transactionHistory.Add($"{datetime} | {serviceType} | {sign}{amount} | Balance: {balance} ");
    }

    public void PrintTransactionHistory()
    {
        if (_transactionHistory.Count == 0)
        {
            Console.WriteLine("Inga transaktioner har gjorts ännu.");
            Console.ReadKey();
            return;
        }
        foreach (var transaction in _transactionHistory)
        {
            Console.WriteLine(transaction);
        }
        Console.WriteLine("Tryck valfri knapp för att återgå till menyn...");
        Console.ReadKey();
    }
}
