using System;
using System.Collections.Generic;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] wall = new char[n, n];

            FillMatrix(wall);

            
            //Dictionary<int, int> rods = new Dictionary<int, int>();
            //Dictionary<int, int> cables = new Dictionary<int, int>();
            //for (int i = 0; i < wall.GetLength(0); i++)
            //{
            //    for (int j = 0; j < wall.GetLength(1); j++)
            //    {
                    
            //        if (wall[i,j] == 'R')
            //        {
            //            rods.Add(i, j);
            //        }
            //        if (wall[i,j] == 'C')
            //        {
            //            cables.Add(i, j);
            //        }
            //    }
            //}
            string command;
            int hitRot = 0;
            int holeCount = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                int currRow = 0;
                int currCol = 0;
                for (int i = 0; i < wall.GetLength(0); i++)
                {
                    for (int j = 0; j < wall.GetLength(1); j++)
                    {
                        if (wall[i, j] == 'V')
                        {
                            currRow = i;
                            currCol = j;
                        }
                    }
                }

                if (command == "up")
                {
                    if (!ValidateIndexes(wall, currRow - 1, currCol))
                    {
                        continue;
                    }
                    if (wall[currRow - 1,currCol] == '-')
                    {
                        wall[currRow - 1, currCol] = 'V';
                        wall[currRow, currCol] = '*';
                        holeCount++;
                    }
                    else if (wall[currRow - 1, currCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        hitRot++;
                    }
                    else if (wall[currRow - 1, currCol] == 'C')
                    {
                        wall[currRow - 1, currCol] = 'E'; 
                        wall[currRow, currCol] = '*';
                        holeCount += 2;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");
                        break;
                    }
                    else if (wall[currRow - 1, currCol] == '*')
                    {
                        wall[currRow - 1, currCol] = 'V';
                        wall[currRow, currCol] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{currRow - 1}, {currCol}]!");
                    }
                }
                else if (command == "down")
                {
                    if (!ValidateIndexes(wall, currRow + 1, currCol))
                    {
                        continue;
                    }
                    if (wall[currRow + 1, currCol] == '-')
                    {
                        wall[currRow + 1, currCol] = 'V';
                        wall[currRow, currCol] = '*';
                        holeCount++;
                    }
                    else if (wall[currRow + 1, currCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        hitRot++;
                    }
                    else if (wall[currRow + 1, currCol] == 'C')
                    {
                        wall[currRow + 1, currCol] = 'E';
                        wall[currRow, currCol] = '*';
                        holeCount += 2;
                        
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");
                        break;
                    }
                    else if (wall[currRow + 1, currCol] == '*')
                    {
                        wall[currRow + 1, currCol] = 'V';
                        wall[currRow, currCol] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{currRow + 1}, {currCol}]!");
                    }
                }
                else if (command == "left")
                {
                    if (!ValidateIndexes(wall, currRow, currCol - 1))
                    {
                        continue;
                    }
                    if (wall[currRow, currCol - 1] == '-')
                    {
                        wall[currRow, currCol - 1] = 'V';
                        wall[currRow, currCol] = '*';
                        holeCount++;
                    }
                    else if (wall[currRow, currCol -1] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        hitRot++;
                    }
                    else if (wall[currRow, currCol - 1] == 'C')
                    {
                        wall[currRow, currCol - 1] = 'E';
                        wall[currRow, currCol] = '*'; 
                        holeCount += 2;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");
                        break;
                    }
                    else if (wall[currRow, currCol - 1] == '*')
                    {
                        wall[currRow, currCol - 1] = 'V';
                        wall[currRow, currCol] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{currRow}, {currCol - 1}]!");
                    }
                }
                else if (command == "right")
                {
                    if (!ValidateIndexes(wall, currRow, currCol + 1))
                    {
                        continue;
                    }
                    if (wall[currRow, currCol + 1] == '-')
                    {
                        wall[currRow, currCol + 1] = 'V';
                        wall[currRow, currCol] = '*';
                        holeCount++;
                    }
                    else if (wall[currRow, currCol + 1] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        hitRot++;
                    }
                    else if (wall[currRow, currCol + 1] == 'C')
                    {
                        wall[currRow, currCol + 1] = 'E';
                        wall[currRow, currCol] = '*';
                        holeCount += 2;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");
                        break;
                    }
                    else if (wall[currRow, currCol + 1] == '*')
                    {
                        wall[currRow, currCol + 1] = 'V';
                        wall[currRow, currCol] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{currRow}, {currCol + 1}]!");
                    }
                }
                
            }
            if (command == "End")
            {
                holeCount++;
                Console.WriteLine($"Vanko managed to make {holeCount} hole(s) and he hit only {hitRot} rod(s).");
            }
            PrintMatrix(wall);
            
        }
        private static void FillMatrix(char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = rowData[j];
                }
            }
        }

        private static void PrintMatrix(char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {

                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}", maze[i, j]));
                }
                Console.WriteLine();
            }
        }
        public static bool ValidateIndexes(char[,] squareMatrix, int row, int col)
        {
            return row >= 0 && row < squareMatrix.GetLength(0) && col >= 0 && col < squareMatrix.GetLength(1);
        }
    }
    
}
