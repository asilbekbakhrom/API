namespace Bank;

public class Transaction
{
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    public DateTime Date { get; set; }

    public Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Note = note;
    }

    public override string ToString()
    {
        return $@"
        ====================
        Date: {Date:dd MMM, yyyy HH:MM:ss}
        Amount: {Amount:C}
        Note: {Note}
        ====================";
    }
}