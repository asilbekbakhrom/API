using Bank;

var account = new Account("Wahid", 20);

Console.WriteLine($"Current balance is: {account.Balance}");

account.MakeWithdraw(10, "For lunch");
Console.WriteLine($"Current balance is: {account.Balance}");

account.GetAccountHistory();