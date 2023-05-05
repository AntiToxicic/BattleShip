namespace BattleShip;

public class Draw
{
    public void Game_Name()                             //Отрисовка названия игры "SEA BATTLE"
    {
        Console.WriteLine(" ####     #####      ###          ####        ###       ##       ##      ##        #####");
        Console.WriteLine("##        ##       ##  ##         ##  ##    ##  ##      ##       ##      ##        ##   ");
        Console.WriteLine("  ##      #####    ##  ##         ####      ##  ##    ######   ######    ##        #####");
        Console.WriteLine("   ##     ##       ######         ##  ##    ######      ##       ##      ##        ##   ");
        Console.WriteLine("###       #####    ##  ##         #####     ##  ##      ####     ####    ######    #####");
        Console.WriteLine("\n");
    }

    public void Game_Menu(params string[] item_bar)     //Отрисвка пунктов меню   (для удобного взаимодействия)
    {
        for (int i = 0; i < item_bar.Length; i++)
        {
            Console.Write($"\t{i + 1}. [{item_bar[i]}]");
        }

        Console.Write("\n\n");
    }

    public void Battlefield(char[,] playerField, char[,] botField)     //Отрисовка полей с кораблями
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Write("\n");

            for (int j = 0; j < 10; j++)
            {
                Console.Write($"  {playerField[i, j]}");
            }

            Console.Write("\t\t");

            for (int j = 0; j < 10; j++)
            {
                if (botField[i, j] == '+')
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
    public void Battlefield(char[,] playerField)     //Отрисовка полей с кораблями
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Write("\n");

            for (int j = 0; j < 10; j++)
            {
                Console.Write($"  {playerField[i, j]}");
            }

        }

        Console.Write("\n");
    }

    public void rules()
    {
        Console.WriteLine("For set ship press \"Enter\"");
        Console.WriteLine("For change orientation press \"Spacebar\"");
        Console.WriteLine("Moving \"↑\" - move up");
        Console.WriteLine("       \"↓\" - move down");
        Console.WriteLine("       \"←\" - move left");
        Console.WriteLine("       \"→\" - move right");
    }

    public void rules2()
    {
        Console.WriteLine("For move cursor use\t\"←\" \"→\" \"↓\" \"↑\"");
        Console.WriteLine("For fire press \"Enter\"");
    }
}