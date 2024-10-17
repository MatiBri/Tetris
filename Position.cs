using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    //Esta clase representa una posicion o celda en una grilla
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }
        //Constructor
        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
