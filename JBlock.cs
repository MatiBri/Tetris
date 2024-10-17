using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class JBlock : Block
    {
        //Este es único porque ocupa todas las posiciones para cada estado de rotacion
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(1, 0), new(1,1), new(1,2)}, //Estado 0 del bloque
            new Position[] { new(0, 1), new(0, 2), new(1,1), new(2,1)}, //Estado 1 del bloque
            new Position[] { new(1, 0), new(1, 1), new(1,2), new(2,2)}, //Estado 2 del bloque
            new Position[] { new(0, 1), new(1, 1), new(2,0), new(2,1)} //Estado 3 del bloque
        };
        public override int Id => 2;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
