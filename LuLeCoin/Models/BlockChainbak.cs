using System.Collections;

namespace LuLeCoin.Models
{
    public class BlockChainbak : IEnumerable<IBlock>
    {
        //PROPERTIES
        
        private List<IBlock> _items = new List<IBlock>();
        public byte[] Difficulty { get; set; }
       
        //CONTRUCTORS

        public BlockChainbak(byte[] difficulty, IBlock genesisBlock)
        {
            Difficulty = difficulty;
            genesisBlock.Hash = genesisBlock.MineHash(difficulty);
            Items.Add(genesisBlock);
        }

       


        //METHODS

        public int Count => Items.Count;

        public void Add(IBlock item)
        {
            if(Items.LastOrDefault() != null)
            {
                item.PrevHash = Items.LastOrDefault()?.Hash;
            }
            item.Hash = item.MineHash(Difficulty);
            Items.Add(item);
        }
        
        public IEnumerator<IBlock> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        //GETTERS AND SETTERS

        public List<IBlock> Items
        {
            get => _items;
            set => _items = value;
        }

        public IBlock this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }
    }
}
