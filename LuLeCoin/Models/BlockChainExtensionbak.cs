using System.Security.Cryptography;

namespace LuLeCoin.Models
{
    public static  class BlockChainExtensionbak
    {
        public static byte[] GenerateHash(this IBlockbak block) 
        {
            using (SHA512 sha = new SHA512Managed())
            using (MemoryStream st = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(st))
            {
                bw.Write(block.Data);
                bw.Write(block.Nonce);
                bw.Write(block.TimeStamp.ToBinary());
                bw.Write(block.PrevHash);
                var starr = st.ToArray();
                return sha.ComputeHash(starr);
            }
        }
        public static byte[] MineHash(this IBlockbak block, byte[] difficulty) 
        {
            if (difficulty == null) throw new ArgumentException(nameof(difficulty));
            byte[] hash = new byte[0];
            int d = difficulty.Length;
            while (!hash.Take(2).SequenceEqual(difficulty))
            {
                block.Nonce++;
                hash = block.GenerateHash();
            }
            return hash;
        }
        public static bool IsValid(this IBlockbak block) 
        {
            var bk = block.GenerateHash();
            return block.Hash.SequenceEqual(bk);
        }
        public static bool isValidPrevBlock(this IBlockbak block, IBlockbak prevBlock) 
        {
            if (prevBlock == null) throw new ArgumentException(nameof(prevBlock));
            var prev = prevBlock.GenerateHash();
            return prevBlock.IsValid() && block.PrevHash.SequenceEqual(prev);
        }
        public static bool IsValid(this IEnumerable<IBlockbak> items) 
        {
            var enumerable = items.ToList();
            return enumerable.Zip(enumerable.Skip(1), Tuple.Create).All(block => block.Item2.IsValid() && block.Item2.isValidPrevBlock(block.Item1));
        }
    }
}
