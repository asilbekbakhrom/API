namespace Bank;

public class Account
{
    public string? Owner { get; set; }
    public string? Number { get; }
    public decimal Balance
    {
        get
        {
            return transactions.Sum(t => t.Amount);
        }
    }

    private static int numberSeed = 1;
    private List<Transaction> transactions = new();
    
    public Account(string name, decimal initialBalance)
    {
        Owner = name;
        Number = numberSeed.ToString();
        numberSeed++;

        MakeDeposit(initialBalance, "Initial deposit.");

        Console.WriteLine($"Created a new account with ID {Number} and balance {initialBalance}");
    }

    public void MakeWithdraw(decimal amount, string note)
    {
        if(amount < 1)
        {
            throw new ArgumentException("You must withdraw at least $1.");
        }

        if(amount > Balance)
        {
            throw new ArgumentException("Not enough amount to withdraw.");
        }

        Console.WriteLine($"Withdrawing {amount} from {Owner}'s account.");
        transactions.Add(new Transaction(-amount, DateTime.Now, note));
    }
    
    public void MakeDeposit(decimal amount, string note)
    {
        if(amount < 1)
        {
            throw new ArgumentException("Not enough deposit amount.");
        }

        Console.WriteLine($"Depositing {amount} to {Owner}'s account.");
        transactions.Add(new Transaction(amount, DateTime.Now, note));
    }

    public void GetAccountHistory()
    {
        transactions.ForEach(Console.WriteLine);
    }
}