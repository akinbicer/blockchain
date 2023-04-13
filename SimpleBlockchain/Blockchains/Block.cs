using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace SimpleBlockchain.Blockchains;

public class Block
{
    public DateTime TimeStamp { get; set; }
    public List<Transaction> Transactions { get; set; }
    public string PreviousHash { get; set; }
    public string Hash { get; set; }
 
    public Block(DateTime timeStamp, List<Transaction> transactions, string previousHash = "")
    {
        TimeStamp = timeStamp;
        Transactions = transactions;
        PreviousHash = previousHash;
        Hash = CalculateHash();
    }
 
    public string CalculateHash()
    {
        var sha256 = SHA256.Create();
 
        var inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{string.Join(",", Transactions)}");
        var outputBytes = sha256.ComputeHash(inputBytes);
 
        return Convert.ToBase64String(outputBytes);
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}