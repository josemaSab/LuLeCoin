namespace LuLeCoin.Models
{
    public class Blockbak : IBlock
    {
        public byte[] Data { get; set; }
        public byte[] Hash { get; set; }
        public long Nonce { get; set; }
        public byte[] PrevHash { get; set; }
        public DateTime TimeStamp { get; set; }


        public Blockbak(byte[] data)
        {
            Data = data ?? throw new ArgumentException(nameof(data));
            Nonce = 0;
            PrevHash = new byte[] { 0x00 };
            TimeStamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{BitConverter.ToString(Hash).Replace("-","")}:\n " +
                $"{BitConverter.ToString(PrevHash).Replace("-","")}\n " +
                $"{Nonce} {TimeStamp}";
        }
    }
}
