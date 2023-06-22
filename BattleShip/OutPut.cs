namespace BattleShip;

public class OutPut
{
    private BattleField _battleField = new();
    public void DrawGameName()
    {
        Console.WriteLine(" ####    ###     #      #    #      #####   ####  #   #  #  ####   ");
        Console.WriteLine(" #   #  #   #    #      #    #      #      #      #   #  #  #   #  ");
        Console.WriteLine(" ####   #   #  #####  #####  #      #####   ###   #####  #  ####   ");
        Console.WriteLine(" #   #  #####    #      #    #      #          #  #   #  #  #      ");
        Console.WriteLine(" ####   #   #    ###    ###  #####  #####  ####   #   #  #  #      version 3.0");
        Console.WriteLine("\n");
    }

    public void DrawBattleFields(char[,] playerField, char[,] botField)
    {
        for (int i = 0; i < _battleField.mapSize; i++)
        {
            Console.Write("\n");

            for (int j = 0; j < _battleField.mapSize; j++)
            {
                Console.Write($"  {playerField[i, j]}");
            }

            Console.Write("\t\t");

            for (int j = 0; j < _battleField.mapSize; j++)
            {
                if (botField[i, j] == (char)Markers.Aim)
                {
                    Console.Write("  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"{botField[i, j]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"  {botField[i, j]}");
                }
            }
        }

        Console.Write("\n");
    }
    public void DrawPlayerField(char[,] playerField)
    {
        for (int i = 0; i < _battleField.mapSize; i++)
        {
            Console.Write("\n");

            for (int j = 0; j < _battleField.mapSize; j++)
            {
                Console.Write($"  {playerField[i, j]}");
            }
        }

        Console.Write("\n");
    }

    public void DrawAimAndBattleFields(int x, int y, char[,] playerField, char[,] botField)
    {
        for (int i = 0; i < _battleField.mapSize; i++)
        {
            Console.Write("\n");

            for (int j = 0; j < _battleField.mapSize; j++)
            {
                    Console.Write($"  {playerField[i, j]}");
            }

            Console.Write("\t\t");

            for (int j = 0; j < _battleField.mapSize; j++)
            {
                if (i == x && j == y)
                {
                    Console.Write("  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"{(char)Markers.Aim}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"  {botField[i, j]}");
                }
            }
        }

        Console.Write("\n");
    } 

    public void DrawRules()
    {
        Console.WriteLine("For set ship press \"Enter\"");
        Console.WriteLine("For change orientation press \"Spacebar\"");
        Console.WriteLine("Moving \"↑\" - move up");
        Console.WriteLine("       \"↓\" - move down");
        Console.WriteLine("       \"←\" - move left");
        Console.WriteLine("       \"→\" - move right");
    }

    public void DrawRules2()
    {
        Console.WriteLine("For move cursor use\t\"←\" \"→\" \"↓\" \"↑\"");
        Console.WriteLine("For fire press \"Enter\"");
    }
}