using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maximizing_Irrigation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] map;

            int height, width, radius;

            StreamReader reader = new StreamReader("input.txt");

            string[] line = reader.ReadLine().Split();

            height = int.Parse(line[0]);
            width = int.Parse(line[1]);
            radius = int.Parse(line[2]);

            map = new string[height];

            for (int h = 0; h < height; h++)
                    map[h] = reader.ReadLine();

            reader.Close();

            int maxX = 0;
            int maxY = 0;
            int maxCrops = 0;

            for (int h = 0; h < height; h++)
                for (int w = 0; w < width; w++)
                {
                    int crops = getCrops(h, w, height, width, radius, map);
                    if (crops > maxCrops)
                    {
                        maxCrops = crops;
                        maxX = w;
                        maxY = h;
                    }
                }

            map = paintMap(maxY, maxX, height, width, radius, map);

            StreamWriter writer = new StreamWriter("output.txt");

            for (int h = 0; h < height; h++)
                writer.WriteLine(map[h]);

            writer.Close();

        }
        public static int getCrops(int row, int col, int rows, int cols, int radius, string[] map)
        {
            int crops = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int a = r - row;
                    int b = c - col;
                    if (a * a + b * b <= radius * radius)
                    {
                        if (map[r][c] == 'x' && r != row && c != col)
                            crops++;
                    }
                }
            }
            return crops;
        }

        public static string[] paintMap(int row, int col, int rows, int cols, int radius, string[] map)
        {
            string[] newMap = new string[rows];

            for (int r = 0; r < rows; r++)
            {
                string line = "";
                for (int c = 0; c < cols; c++)
                {
                    int a = r - row;
                    int b = c - col;
                    if (a * a + b * b <= radius * radius)
                    {
                        if (r == row && c == col)
                            line += 'O';
                        else if (map[r][c] == 'x')
                            line += '@';
                        else if (map[r][c] == '.')
                            line += '~';
                    }
                    else
                        line += map[r][c];
                }
                newMap[r] = line;
            }
            return newMap;
        }
    }
}
