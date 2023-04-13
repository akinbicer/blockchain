namespace SimpleBlockchain.Blockchains;

public class Transaction
{
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }
    public double Amount { get; set; }
 
    public Transaction(string fromAddress, string toAddress, double amount)
    {
        FromAddress = fromAddress;
        ToAddress = toAddress;
        Amount = amount;
    }
}