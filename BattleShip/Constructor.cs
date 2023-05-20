namespace BattleShip;

public class Constructor
{   
    OutPut outPut = new();
    Checker checker = new();

    private TypeShip _typeShip;
    private OrientationShip _orientation;
    private int _x;
    private int _y;
    
    public void DefineShip(TypeShip typeShip ,OrientationShip orientation, int x, int y,List<Ship> ShipsList)
    {
        _x = x;
        _y = y;
        _orientation = orientation;
        _typeShip = typeShip;

        AddShip(ShipsList);
    }

    private void AddShip(List<Ship> ShipsList)
    {
        ShipsList.Add(new Ship(_typeShip, _orientation, _x, _y));
    }


    public void SetShip(ref char[,] battlefield, int x, int y)                       
    {
        char shipPlace = 'Z';

        if (_orientation == OrientationShip.Horizontal)
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[x, y + i] = shipPlace;
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[x + i, y] = shipPlace;
            }
        }
    }
    public void findPlace(char[,] battleField)
    {
        bool IsShipSet = false;

        int x = 5;
        int y = 5;
        OrientationShip orientationShip = OrientationShip.Horizontal;
        TypeShip typeShip = TypeShip.Single;
        
        ConsoleKeyInfo pressedKey;
        
        while (IsShipSet == false)
        {
            Console.Clear();
            outPut.Game_Name();
            outPut.Battlefield(battleField);
            outPut.rules();

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
                    IsShipSet = checker.IsFreePlace(orientationShip, typeShip, x, y, battleField);
                    break;
            }
           
        }
    }
}