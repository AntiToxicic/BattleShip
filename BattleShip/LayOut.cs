namespace BattleShip;

public class LayOut
{
    public char[,] battleField = new char[10, 10];
    public char[,] tempBattleField = new char[10, 10];
    private char _shipPlace = 'Z';

    public LayOut()
    {
        for (int i = 0; i < battleField.GetLength(0); i++)
        {
            for (int j = 0; j < battleField.GetLength(1); j++)
            {
                battleField[i, j] = '∙';
            }
        }
        tempBattleField = battleField.Clone() as char[,];
    }

    protected bool IsFreePlace(OrientationShip orientationShip, TypeShip typeShip, int x, int y)
    {
        var i = 0;

        do
        {
            if (tempBattleField[x, y] == _shipPlace) return false;
            if (x < 9) { if (tempBattleField[x + 1, y] == _shipPlace) return false; }
            if (x > 0) { if (tempBattleField[x - 1, y] == _shipPlace) return false; }
            if (y < 9) { if (tempBattleField[x, y + 1] == _shipPlace) return false; }
            if (y > 0) { if (tempBattleField[x, y - 1] == _shipPlace) return false; }

            if (x < 9 && y < 9) { if (tempBattleField[x + 1, y + 1] == _shipPlace) return false; }
            if (x > 0 && y > 0) { if (tempBattleField[x - 1, y - 1] == _shipPlace) return false; }
            if (x < 9 && y > 0) { if (tempBattleField[x + 1, y - 1] == _shipPlace) return false; }
            if (x > 0 && y < 9) { if (tempBattleField[x - 1, y + 1] == _shipPlace) return false; }

            if (orientationShip == OrientationShip.Horizontal)
            {
                y++;
            }
            else
            {
                x++;
            }

        } while (++i != (int)typeShip);

        tempBattleField = battleField.Clone() as char[,];
        return true;
    }

}

public class PlayerLayOut : LayOut
{
    private OutPut output = new OutPut();
    public Fleet player = new Fleet();


    public void setShips()
    {
        var count = 0;
        int x, y;
        OrientationShip orientationShip;
        TypeShip typeShip = TypeShip.Single;
        
        ConsoleKeyInfo pressedKey;
        bool IsShipSet = false;

            while (IsShipSet == false)
            {
                Console.Clear();
                output.Game_Name();
                output.Battlefield(battleField);
                output.rules();
                pressedKey = Console.ReadKey();  

                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (x > 0) x--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((x < 9 && orientationShip == OrientationShip.Horizontal) ||
                            (x < 10 - (int)typeShip && orientationShip == OrientationShip.Vertical)) x++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (y > 0) y--;
                        break;
                    case ConsoleKey.RightArrow:
                        if ((y < 9 && orientationShip == OrientationShip.Vertical) ||
                            (y < 10 - (int)typeShip && orientationShip == OrientationShip.Horizontal)) y++;
                        break;
                    case ConsoleKey.Spacebar:
                        if ((x <= (10 - (int)typeShip)) && y <= (10 - (int)typeShip))
                        {
                            if (orientationShip == OrientationShip.Horizontal)
                            {

                                orientationShip = OrientationShip.Vertical;
                            }
                            else
                            {
                                orientationShip = OrientationShip.Horizontal;
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        IsShipSet = IsFreePlace(orientationShip, typeShip, x, y);
                        break;
                }
               
            }
    }
    public void setShipsRdm()
    {
        Random random = new Random();
        var count = 0;
        int x = random.Next(10);
        int y = random.Next(10);

        OrientationShip orientationShip = OrientationShip.Horizontal;
        TypeShip typeShip = TypeShip.Single;
        bool IsOverFlow = true;

        while (++count <= 10)
        {
            tempBattleField = battleField.Clone() as char[,];

            do
            {
                IsOverFlow = true;

                while (IsOverFlow)
                {
                    orientationShip = (OrientationShip)random.Next(2);
                    x = random.Next(10);
                    y = random.Next(10);

                    if (orientationShip == OrientationShip.Horizontal)
                    {
                        if (y - 1 + (int)typeShip < battleField.GetLength(0))
                        {
                            IsOverFlow = false;
                        }
                    }
                    else
                    {
                        if (x - 1 + (int)typeShip < battleField.GetLength(0))
                        {
                            IsOverFlow = false;
                        }
                        
                    }
                }
            } while (IsFreePlace(orientationShip, typeShip, x, y) == false);

            Console.Clear();
            output.Game_Name();
            output.Battlefield(battleField);
            Thread.Sleep(400);

        }
    }
}

public class BotLayOut : LayOut
{
    public Fleet bot = new Fleet();

    public void setShipsRdm()
    {
        Random random = new Random();
        var count = 0;
        int x = random.Next(10);
        int y = random.Next(10);

        OrientationShip orientationShip = OrientationShip.Horizontal;
        TypeShip typeShip = TypeShip.Single;
        bool IsOverFlow = true;

        while (++count <= 10)
        {
            tempBattleField = battleField.Clone() as char[,];
            bool IsShipSet = false;
            do
            {
                IsOverFlow = true;

                while (IsOverFlow)
                {
                    orientationShip = (OrientationShip)random.Next(2);
                    x = random.Next(10);
                    y = random.Next(10);

                    if (orientationShip == OrientationShip.Horizontal)
                    {
                        if (y - 1 + (int)typeShip < battleField.GetLength(0))
                        {
                            IsOverFlow = false;
                        }
                    }
                    else
                    {
                        if (x - 1 + (int)typeShip < battleField.GetLength(0))
                        {
                            IsOverFlow = false;
                        }
                    }
                }


            } while (IsFreePlace(orientationShip, typeShip, x, y) == false);



            switch (count)
            {
                case 1:
                    bot.singleShip1.setUpShip(orientationShip, x, y);
                    bot.singleShip1.AddShip(ref battleField);
                    typeShip = TypeShip.Single;
                    break;
                case 2:
                    bot.singleShip2.setUpShip(orientationShip, x, y);
                    bot.singleShip2.AddShip(ref battleField);
                    typeShip = TypeShip.Single;
                    break;
                case 3:
                    bot.singleShip3.setUpShip(orientationShip, x, y);
                    bot.singleShip3.AddShip(ref battleField);
                    typeShip = TypeShip.Single;
                    break;
                case 4:
                    bot.singleShip4.setUpShip(orientationShip, x, y);
                    bot.singleShip4.AddShip(ref battleField);
                    typeShip = TypeShip.Double;
                    break;
                case 5:
                    bot.doubleShip1.setUpShip(orientationShip, x, y);
                    bot.doubleShip1.AddShip(ref battleField);
                    typeShip = TypeShip.Double;
                    break;
                case 6:
                    bot.doubleShip2.setUpShip(orientationShip, x, y);
                    bot.doubleShip2.AddShip(ref battleField);
                    typeShip = TypeShip.Double;
                    break;
                case 7:
                    bot.doubleShip3.setUpShip(orientationShip, x, y);
                    bot.doubleShip3.AddShip(ref battleField);
                    typeShip = TypeShip.Triple;
                    break;
                case 8:
                    bot.tripleShip1.setUpShip(orientationShip, x, y);
                    bot.tripleShip1.AddShip(ref battleField);
                    typeShip = TypeShip.Triple;
                    break;
                case 9:
                    bot.tripleShip2.setUpShip(orientationShip, x, y);
                    bot.tripleShip2.AddShip(ref battleField);
                    typeShip = TypeShip.Quadro;
                    break;
                case 10:
                    bot.quadroShip.setUpShip(orientationShip, x, y);
                    bot.quadroShip.AddShip(ref battleField);
                    break;
            }
        }
    }

}
