using System.Security.Principal;
using Microsoft.VisualBasic;

namespace Bank_Konto;

class BankApp
{
    static void Main(string[] args)
    {
        List<BankAccount> accounts = new List<BankAccount>();
        
        //------------------------------------------------------------
        
        //Login menu, Login or create a bankaccount
        
        //------------------------------------------------------------
        
        bool startMenuActive = true;
        int startMenuIndex = 0;
        
        while (startMenuActive)
        {
            Console.Clear();
            string[] startMenu = new string[]
            {
                "Logga in",
                "Skapa ett bankkonto"
            };
            
            Console.WriteLine("Välkommen till Sydea bank!");
            Console.WriteLine();
            //comment
            
            if (startMenuIndex == 0)
            {
                Console.WriteLine("> " + startMenu[0]);
                Console.WriteLine(startMenu[1]);
            }
            else if (startMenuIndex == 1)
            {
                Console.WriteLine(startMenu[0]);
                Console.WriteLine("> " + startMenu[1]);
            }
            
            var startMenuOrientation = Console.ReadKey();
            
            if (startMenuOrientation.Key == ConsoleKey.DownArrow && startMenuIndex != startMenu.Length - 1)
            {
                startMenuIndex++;
            }

            else if (startMenuOrientation.Key == ConsoleKey.UpArrow && startMenuIndex >= 1)
            {
                startMenuIndex--; 
            }
            else if (startMenuOrientation.Key == ConsoleKey.Enter)
            {
                switch (startMenuIndex)
                {
                    case 0:
                    {
                        //------------------------------------------------------------
        
                        //Login validation and bank services
        
                        //------------------------------------------------------------
                        
                        bool accountFound = false; 
                        
                        Console.Clear();
                        Console.WriteLine("Skriv in ditt förnamn:");
                        string validateUserFirstName = Console.ReadLine();
                        Console.WriteLine("Skriv in ditt personnummer:");
                        string validateUserSsn = Console.ReadLine();
                        
                        foreach (var account in accounts)
                        {
                            //------------------------------------------------------------
        
                            //Menu if login credentials match
        
                            //------------------------------------------------------------
                            if (validateUserFirstName == account.FirstName &&
                                validateUserSsn == account.SocialSecurityNumber)
                            {
                                accountFound = true;
                                Console.Clear();
                                Console.WriteLine($"välkommen tillbaka {account.FirstName}");
                                bool loggedInActive = true;
                                int bankAccountIndex = 0;
                                
                                string[] bankAccountMenu = new string[]
                                {
                                    "Visa saldo",
                                    "Sätt in pengar",
                                    "Uttag",
                                    "Transaktions historik",
                                    "Logga ut"
                                };
                                
                                while (loggedInActive)
                                {
                                    Console.Clear();
                                    if (bankAccountIndex == 0)
                                    {
                                        Console.WriteLine("> " + bankAccountMenu[0]);
                                        Console.WriteLine(bankAccountMenu[1]);
                                        Console.WriteLine(bankAccountMenu[2]);
                                        Console.WriteLine(bankAccountMenu[3]);
                                        Console.WriteLine(bankAccountMenu[4]);
                                    }
                                    else if (bankAccountIndex == 1)
                                    {
                                        Console.WriteLine(bankAccountMenu[0]);
                                        Console.WriteLine("> " + bankAccountMenu[1]);
                                        Console.WriteLine(bankAccountMenu[2]);
                                        Console.WriteLine(bankAccountMenu[3]);
                                        Console.WriteLine(bankAccountMenu[4]);
                                    }
                                    else if (bankAccountIndex == 2)
                                    {
                                        Console.WriteLine(bankAccountMenu[0]);
                                        Console.WriteLine(bankAccountMenu[1]);   
                                        Console.WriteLine("> " + bankAccountMenu[2]);
                                        Console.WriteLine(bankAccountMenu[3]);
                                        Console.WriteLine(bankAccountMenu[4]);
                                    }
                                    else if (bankAccountIndex == 3)
                                    {
                                        Console.WriteLine(bankAccountMenu[0]);
                                        Console.WriteLine(bankAccountMenu[1]);   
                                        Console.WriteLine(bankAccountMenu[2]);
                                        Console.WriteLine("> " + bankAccountMenu[3]);
                                        Console.WriteLine(bankAccountMenu[4]);
                                    }
                                    else if (bankAccountIndex == 4)
                                    {
                                        Console.WriteLine(bankAccountMenu[0]);
                                        Console.WriteLine(bankAccountMenu[1]);
                                        Console.WriteLine(bankAccountMenu[2]);
                                        Console.WriteLine(bankAccountMenu[3]);
                                        Console.WriteLine("> " + bankAccountMenu[4]);
                                    }
                                    var accountMenuOrientation = Console.ReadKey();
                                    
                                    if (accountMenuOrientation.Key == ConsoleKey.DownArrow && bankAccountIndex != bankAccountMenu.Length - 1)
                                    {
                                        bankAccountIndex++;
                                    }

                                    else if (accountMenuOrientation.Key == ConsoleKey.UpArrow && bankAccountIndex >= 1)
                                    {
                                        bankAccountIndex--; 
                                    }
                                    else if (accountMenuOrientation.Key == ConsoleKey.Enter)
                                    {
                                        switch (bankAccountIndex)
                                        {
                                            case 0: // Check balance
                                            {
                                                Console.Clear();
                                                double ShowBalance = account.ShowBalance();
                                                Console.WriteLine($"Du har {ShowBalance} Kr");
                                                Console.WriteLine();
                                                Console.WriteLine("Tryck valfri knapp för att återgå till menyn...");
                                                Console.ReadKey();
                                            }
                                                break;
                                            
                                            case 1: // Deposit money
                                            {
                                                string serviceType = "Deposit";
                                                string sign = "+";
                                                
                                                Console.Clear();
                                                Console.WriteLine("Skriv summan du vill sätta in:");
                                                
                                                decimal depositAmount = decimal.Parse(Console.ReadLine());
                                                decimal newBalance = account.DepositMoney(depositAmount);
                                                
                                                account.AddTransactionHistory(serviceType, depositAmount, sign, newBalance);
                                            }
                                                break;
                                            
                                            case 2: // Withdraw money
                                            {
                                                string serviceType = "Withdraw";
                                                string sign = "-";
                                                
                                                Console.Clear();
                                                Console.WriteLine("Skriv summan du vill ta ut:");
                                                
                                                decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                                                decimal newBalance = account.WithdrawMoney(withdrawAmount);
                                                
                                                account.AddTransactionHistory(serviceType, withdrawAmount, sign, newBalance);
                                            }
                                                break;
                                            case 3: // Transaction history
                                            {
                                                Console.Clear();
                                                account.PrintTransactionHistory();
                                            }
                                                break;
                                            case 4: // logout 
                                            {
                                                loggedInActive = false;
                                            }
                                                break;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        if (!accountFound)
                        {
                            Console.Clear();
                            Console.WriteLine("Kontot exiterar ej");
                            Console.ReadKey();
                        }
                    }
                        break;
                    case 1:
                    {
                        //------------------------------------------------------------
        
                        //Create a new bank account
        
                        //------------------------------------------------------------
                        Console.Clear();
                        
                        Console.WriteLine("Fyll i ditt förnamn:");
                        string firstName = Console.ReadLine();
                        
                        Console.WriteLine("Fyll i ditt efternamn:");
                        string lastName = Console.ReadLine();
                        
                        Console.WriteLine("Fyll i ditt personnummer:");
                        string socialSecurityNumber = Console.ReadLine();
                        
                        var newAccount = new BankAccount(firstName, lastName, socialSecurityNumber);
                        accounts.Add(newAccount);
                        
                        Console.Clear();
                        Console.WriteLine($"Välkommen till Sydea {firstName}, du kan nu använda våra tjänsten!");
                        Console.WriteLine("Tryck valfri knapp för att återgå till menyn...");
                        Console.ReadKey();

                    }
                        continue;
                }
            }
            
            
        }
        
    }
}