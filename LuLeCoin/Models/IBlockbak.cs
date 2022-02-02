namespace LuLeCoin.Models
{
    public interface IBlockbak
    {
        byte[] Data { get; set; }
        byte[] Hash { get; set; }
        long Nonce { get; set; }
        byte[] PrevHash { get; set; }
        DateTime TimeStamp  { get; set; }
    }
}
