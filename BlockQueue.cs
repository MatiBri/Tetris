using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    //Esta clase será la responsable de elegir el próximo bloque del array
    public class BlockQueue
    {
        //Va a contener un arreglo de bloques, donde dentro estarán los 7 bloquea creados
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
        };
        private readonly Random random = new Random();

        public Block NextBlock { get; private set; }

        //Metodo que retorna un bloque al azar
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        //En el constructor, inicializamos el siguiente bloque con uno al azar
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        //Este metodo retorna el siguiente bloque y actualiza la propiedad
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);
            
            return block;
        }


    }
}
