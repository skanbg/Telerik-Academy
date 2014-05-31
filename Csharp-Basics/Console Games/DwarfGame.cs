using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class FallingRocks
{
    static int gameLevel = 1;
    static int symbolsOnLevel = 1;
    static int livesCounter = 10;
    static string dwarfSymbols = "(0)";
    static int dwarfWidth = dwarfSymbols.Length;
    static int dwarfPositionX = (Console.WindowWidth / 2) - (dwarfWidth / 2);
    static int dwarfPositionY = Console.WindowHeight - 1;
    static List<int> rockX = new List<int>();
    static List<int> rockY = new List<int>();
    static List<char> rockSymbol = new List<char>();
    static List<ConsoleColor> rockColor = new List<ConsoleColor>();
    static char[] symbolsContainer = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
    static Random random = new Random();
    static int experienceContainer = 0;
    static int isExpChanged = 0;

    static void ShowResult()
    {
        if (experienceContainer >= 100)
        {
            experienceContainer = 0;
            gameLevel += 1;
        }
        Console.SetCursorPosition(1, 0);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Level: {0}  |  Lives: {1}", gameLevel, livesCounter);

        Console.SetCursorPosition(40, 0);
        Console.Write("Exp: {0}%", experienceContainer);

        isExpChanged--;
    }

    static void MoveRocks()
    {
        for (int i = 0; i < rockX.Count; i++)
        {
            if (rockY[i] < (Console.WindowHeight - 1))
            {
                rockY[i]++;
            }
            else if (rockY[i] == (Console.WindowHeight - 1))
            {
                rockY.RemoveAt(i);
                rockX.RemoveAt(i);
                rockColor.RemoveAt(i);
                rockSymbol.RemoveAt(i);

                if (rockY[i] == dwarfPositionY && (rockX[i] >= dwarfPositionX && rockX[i] <= (dwarfPositionX + 2)))
                {
                    if (livesCounter > 0)
                    {
                        livesCounter--;
                    }
                }

                if (isExpChanged < 1)
                {
                    experienceContainer += gameLevel + 1;
                    isExpChanged += (gameLevel * symbolsOnLevel);
                }

            }
        }
    }

    static void RockAdder()
    {
        for (int i = 1; i <= (gameLevel / 10 + symbolsOnLevel); i++)
        {
            int randomX = random.Next(0, 79);
            int randomSymbol = random.Next(0, 10);
            int randomColor = random.Next(2, 16);
            if (!rockX.Contains(randomX))
            {
                rockY.Add(1);
                rockX.Add(randomX);
                rockSymbol.Add(symbolsContainer[randomSymbol]);
                rockColor.Add((ConsoleColor)randomColor);
                //rockX.RemoveAt();
            }
        }
    }

    static string[] rocksSymbols = { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";" };

    static void ChangeLevelHardnesUp()
    {
        if (gameLevel < 20)
        {
            gameLevel++;
        }
    }

    static void ChangeLevelHardnesDown()
    {
        if (gameLevel > 1)
        {
            gameLevel--;
        }
    }

    static void MoveDwarfLeft()
    {
        if (dwarfPositionX > 1)
        {
            dwarfPositionX--;
        }
    }

    static void MoveDwarfRight()
    {
        if (dwarfPositionX < (Console.WindowWidth - dwarfWidth - 1))
        {
            dwarfPositionX++;
        }
    }

    static void Settings()
    {
        //Set fixed console width and height
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    static void DrawDwarf()
    {
        Console.SetCursorPosition(dwarfPositionX, dwarfPositionY);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(dwarfSymbols);
    }

    static void DrawRocks()
    {
        for (int i = 0; i < rockX.Count; i++)
        {
            Console.SetCursorPosition(rockX[i], rockY[i]);
            Console.ResetColor();
            Console.ForegroundColor = rockColor[i];
            Console.Write(rockSymbol[i]);
        }
    }

    static void Main()
    {
        Settings();


        while (true)
        {
            if (livesCounter == 0)
            {
                Console.Clear();
                Console.WriteLine("You lost! Do you want to restart (yes/no)");
                string restartQuestion = Console.ReadLine();
                if (restartQuestion == "yes")
                {
                    gameLevel = 1;
                    symbolsOnLevel = 1;
                    rockX.Clear();
                    rockY.Clear();
                    rockSymbol.Clear();
                    rockColor.Clear();
                    experienceContainer = 0;
                    isExpChanged = 0;
                    livesCounter = 10;
                }
            }
            else
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        MoveDwarfLeft();
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        MoveDwarfRight();
                    }
                }
                Console.Clear();
                MoveRocks();
                RockAdder();
                DrawRocks();
                DrawDwarf();
                ShowResult();
                Thread.Sleep(150);
            }
        }
    }
}