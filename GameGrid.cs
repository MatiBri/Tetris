using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        //Esta clase tendrá los arreglos multi-dimensionales rectangulares
        private readonly int[,] grid;

        //Propiedades para el número de filas y columnas
        public int Rows { get; }
        public int Columns { get; }
        
        //Indexador para proveer un acceso fácil al array
        public int this[int r, int c]
        {
            //Con eso podemos usar indexadores directamente en un objeto de GameGrid
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        
        //Constructor: Tomará el número de filas y columnas como parámetros
            //De esta forma la clase puede también ser usada en una micro o mega versión de Tetris con un tamaño de grilla no tradicional
        public GameGrid(int rows, int columns)
        {
            //En el body, guardamos el número de filas y columnas e inicializamos el array
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        //Métodos convenientes
            //1: El primer método verificará si una fila y columna estan dentro de una grilla o no
        public bool IsInside(int r, int c)
        {
         //Para estar dentro de la grilla, la fila debe ser mayor o igual a 0 y menores que el número de filas
         //Para estar dentro de la grilla, las columnas deben ser mayor o igual a 0 y menores que el número de columnas
            return r >= 0 && r <= Rows && c >= 0 && c <= Columns;
        }

            //2: Método que chequea si una celda dada está vacía o no
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0; 
            //Debe estar dentro de la grilla y el valor debe ser 0 en el array
        }
            //3: Método que chequea si una fila entera está llena
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //4: Método que chequea si una fila está vacía
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        //5: Método que limpia una fila
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }
        //6: Método que mueve una fila hacia abajo por un cierto número de filas
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        //7: Método que limpia varias filas
        public int ClearFullRows()
        {
            //La variable Cleared empieza de 0, y la movemos desde el fondo de abajo hacia arriba
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r++)
            {
                //Chequeamos si la fila actual está llena, y si lo está la limpiamos e incrementamos la variable
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if( cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }


        /*
            Notas:
                -La primer dimension es la fila. La segunda dimensión será la columna
                -
        */
    }
}
