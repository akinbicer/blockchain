namespace SimpleBlockchain.Blockchains;

public class Blockchain
{
    public List<Block> Chain { get; set; }
    public int Difficulty { get; set; } = 2;
 
    public Blockchain()
    {
        Chain = new List<Block> { new Block(DateTime.Now, new List<Transaction>(), "") };
    }
 
    public Block GetLatestBlock()
    {
        return Chain[Chain.Count - 1];
    }
 
    public void AddBlock(Block newBlock)
    {
        newBlock.PreviousHash = GetLatestBlock().Hash;
        newBlock.Hash = newBlock.CalculateHash();
        Chain.Add(newBlock);
    }
 
    public bool IsChainValid()
    {
        for (int i = 1; i < Chain.Count; i++)
        {
            var currentBlock = Chain[i];
            var previousBlock = Chain[i - 1];
 
            if (currentBlock.Hash != currentBlock.CalculateHash())
            {
                return false;
            }
 
            if (currentBlock.PreviousHash != previousBlock.Hash)
            {
                return false;
            }
        }
 
        return true;
    }
}