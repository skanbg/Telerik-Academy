using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//THIS SCRIPT IS UNFINISHED - needs optimization

namespace DepthSearch
{
    class MazeGeneration
    {
        static int width;
        static int height;
        // 1 is wall; 0 is path; 2 is Player
        static byte[,] gameField;
        static int pathEndX;
        static int pathEndY;

        static void Main()
        {
            GameSettings();
            GenerateField();
            DrawGameField();
            Console.ReadLine();
            Console.WriteLine();
            int smil = 9787;
            char smiley = (char)9787;
            Console.WriteLine(smiley);
        }

        private static void GameSettings()
        {
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            width = (int)(Console.WindowWidth * 0.6);
            height = (int)(Console.WindowHeight * 0.9);
            gameField = new byte[height, width];
        }

        private static void DrawGameField()
        {
		//Used only to show the final result on the console - better than debugging
            for (int loopRow = 0; loopRow < height; loopRow++)
            {
                for (int loopCol = 0; loopCol < width; loopCol++)
                {
                    Console.SetCursorPosition(loopCol, loopRow);
                    Console.ResetColor();
                    if (gameField[loopRow, loopCol] == 0)
                    {
                        if (loopRow == pathEndY && loopCol == pathEndX)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                    }
                    Console.Write(" ");
                }
            }
        }

        private static void GenerateField()
        {
            bool[,] visitedGameField = new bool[height, width];
            Random randomPicker = new Random();

            Stack<int> rowStack = new Stack<int>();
            Stack<int> colStack = new Stack<int>();

            //step 1 (i wan the script to start from (0,0) cel
            int currentCelRow = 0;
            int currentCelCol = 0;
            int countVisits = 1;

            //Step 2
            while (countVisits > 0)
            {

                if (!visitedGameField[currentCelRow, currentCelCol])
                {
                    visitedGameField[currentCelRow, currentCelCol] = true;
                }
                List<int[]> neighbours = GetNeighbours(currentCelRow, currentCelCol, visitedGameField);
                //Step 2.1
                if (neighbours.Count > 0)
                {
                    //Step 2.1.1 - Random cell choosed
                    int[] randomCell = neighbours[randomPicker.Next(0, neighbours.Count)];
                    //Step 2.1.2
                    rowStack.Push(randomCell[0]);
                    colStack.Push(randomCell[1]);
                    //Step 2.1.4
                    currentCelCol = randomCell[1];
                    currentCelRow = randomCell[0];
                    //Instead removing walls at step 2.1.3 we add walls if there are enough neighbours
                    List<int[]> neighboursToMakeUnavailable = GetNeighbours(currentCelRow, currentCelCol, visitedGameField);
                    if (neighboursToMakeUnavailable.Count > 1)
                    {
                        int[] randomtoUnavailable = neighboursToMakeUnavailable[randomPicker.Next(0, neighboursToMakeUnavailable.Count)];
                        visitedGameField[randomtoUnavailable[0], randomtoUnavailable[1]] = true;
                        gameField[randomtoUnavailable[0], randomtoUnavailable[1]] = 1;
                    }
                    if (currentCelCol > (width / 4) && currentCelRow > (height / 4))
                    {
                        pathEndX = currentCelCol;
                        pathEndY = currentCelRow;
                    }
                }
                //Step 2.2
                else if (rowStack.Count > 0)
                {
                    //Step 2.2.1 and 2.2.2 merged
                    currentCelCol = colStack.Pop();
                    currentCelRow = rowStack.Pop();
                }
                //Step 2.3
                else
                {
                    countVisits = 0;
                }
            }
        }

        private static List<int[]> GetNeighbours(int currentCelRow, int currentCelCol, bool[,] visitedGameField)
        {
            int[][] possibilities = new int[4][] { new int[2] { 0, -1 }, new int[2] { -1, 0 }, new int[2] { 0, 1 }, new int[2] { 1, 0 } };

            List<int[]> neighbours = new List<int[]>();

            foreach (var cell in possibilities)
            {
                if ((currentCelCol + cell[1]) >= 0 && (currentCelCol + cell[1]) < width && (currentCelRow + cell[0]) >= 0 && (currentCelRow + cell[0]) < height && !visitedGameField[currentCelRow + cell[0], currentCelCol + cell[1]])
                {
                    neighbours.Add(new int[] { currentCelRow + cell[0], currentCelCol + cell[1] });
                }
            }

            return neighbours;
        }
    }
}
