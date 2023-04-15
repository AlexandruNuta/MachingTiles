using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1mvp
{
    public class Game
    {
        private int[,] board;

        public Game(int rows, int columns)
        {
            board = new int[rows, columns];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] =0;
                }
            }
        }

        public int GetCell(int row, int column)
        {
            return board[row, column];
        }
        public int GetRows()
        {
            return board.GetLength(0);
        }
        public int GetColumns()
        {
            return board.GetLength(1);
        }
    }
}
