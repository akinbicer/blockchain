using SimpleBlockchain.Blockchains;
using static System.Net.Mime.MediaTypeNames;

var blockchain = new Blockchain();

blockchain.AddBlock(new Block(DateTime.Now, new List<Transaction>
{
    new("Ali", "Veli", 100.0)
}));

blockchain.AddBlock(new Block(DateTime.Now, new List<Transaction>
{
    new("Ali", "Mehmet", 200.0), 
    new("Mehmet", "Veli", 50.0)
}));

Console.WriteLine($"Valid: {blockchain.IsChainValid()}");
Console.WriteLine($"Count: {blockchain.Chain.Count}");

Console.WriteLine("Chains:");
Console.WriteLine(string.Concat(Enumerable.Repeat("=", 50)));

foreach (var chain in blockchain.Chain)
{
    Console.WriteLine($"Value: {chain}");
}

Console.ReadKey();