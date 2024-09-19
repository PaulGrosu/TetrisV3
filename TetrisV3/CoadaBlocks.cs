using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris2.Clases
{
    public class CoadaBlock
    {
        private readonly Block[] blocks = new Block[]
            {
                new FormaLinie(),
                new Formaj(),
                new FormaL(),
                new FormaPatrat(),
                new FormaT(),
                new FormaS(),
            };
        private readonly Random random = new Random();

        public Block UrmatorulBlock { get; private set; } // *

        public CoadaBlock()
        {
            UrmatorulBlock = RandomBlock();

        }
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }
        public Block ReturnSIUpdateBlock()
        {
            Block block = UrmatorulBlock;
            do
            {
                UrmatorulBlock = RandomBlock();
            }
            while (block.Id == UrmatorulBlock.Id);

            return block;
        }
    }
}
