using System.Collections;

namespace LuLeCoin.Models
{
    public class BlockChainbak : IEnumerable<IBlockbak>
    {
        //PROPERTIES
        
        private List<IBlockbak> _items = new List<IBlockbak>();
        public byte[] Difficulty { get; set; }
       
        //CONTRUCTORS

        public BlockChainbak(byte[] difficulty, IBlockbak genesisBlock)
        {
            Difficulty = difficulty;
            genesisBlock.Hash = genesisBlock.MineHash(difficulty);
            Items.Add(genesisBlock);
        }

       


        //METHODS

        public int Count => Items.Count;

        public void Add(IBlockbak item)
        {
            if(Items.LastOrDefault() != null)
            {
                item.PrevHash = Items.LastOrDefault()?.Hash;
            }
            item.Hash = item.MineHash(Difficulty);
            Items.Add(item);
        }
        
        public IEnumerator<IBlockbak> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        //GETTERS AND SETTERS

        public List<IBlockbak> Items
        {
            get => _items;
            set => _items = value;
        }

        public IBlockbak this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }
    }
}
