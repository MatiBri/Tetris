using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        //Añadiremos una sub clase para cada bloque específico

        //Array de 2 dimensiones que contiene las posiciones de los bloques en los 4 estados de rotacion
        protected abstract Position[][] Tiles { get; }

        //Un Start offset que especifica donde el bloque va a aparecer en la grilla
        protected abstract Position StartOffset { get; }

        //Integer ID el cual distingue a los bloques
        public abstract int Id { get; }

        private int rotationState;
        private Position offset;

        //Constructor
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }
        
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position pos in Tiles[rotationState])
            {
                yield return new Position(pos.Row + offset.Row, pos.Column + offset.Column); //El método recorre sobre las posiciones en los estados de rotación
            }
        }

        //Método que rotea el bloque 90°
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }
        public void RotateCCW()
        {
            if(rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }
        
        //Método que mueve el bloque por un número dado de filas y columnas
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        //Método que resetea la posicion y rotación
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
