using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace flood_fill
{
    public class Board
    {
        private char[,] board;
        private int rows;
        private int cols;
        private int fillRow;
        private int fillCol;
        private char fillChar;

        public Board(string inputFile)
        {
            var file = File.OpenText(inputFile);

            //get the dimensions
            string dimensions = file.ReadLine();
            string[] dim = dimensions.Split(new Char[] { ' ' });
            cols = int.Parse(dim[0]);
            rows = int.Parse(dim[1]);

            //fill the board
            board = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string temp = file.ReadLine();
                for (int j = 0; j < cols - 1; j++)
                {
                    board[i, j] = temp[j];
                }
                board[i, cols - 1] = '\n';
            }
            
            //get the fill position and char
            string tem = file.ReadLine();
            string[] fillInfo =  tem.Split(new Char[] { ' ' });
            fillCol = int.Parse(fillInfo[0]);
            fillRow = int.Parse(fillInfo[1]);
            fillChar = char.Parse(fillInfo[2]);

            file.Close();

            char replace = board[fillRow, fillCol];

            Fill(fillRow, fillCol, fillChar, replace);

            PrintBoard();
        }

        public void PrintBoard()
        {
            StreamWriter writer = new StreamWriter("output.txt");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    writer.Write(board[i, j]);
            }

            writer.Close();
        }

        public void Fill(int x, int y, char fillWith, char replace)
        {
            char temp = board[x, y];
            if (board[x,y] == replace)
            {
                board[x,y] = fillWith;
                if (x < rows - 1 && board[x + 1,y] == replace)
                    Fill(x + 1, y, fillWith, replace);

                if (x > 0 && board[x - 1, y] == replace)
                    Fill(x - 1, y, fillWith, replace);

                if (y < cols - 1 && board[x, y + 1] == replace)
                    Fill(x, y + 1, fillWith, replace);
                
                if (y > 0 && board[x, y - 1] == replace)
                    Fill(x, y - 1, fillWith, replace);
            }
        }
    }
}