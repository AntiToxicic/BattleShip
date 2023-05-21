namespace BattleShip;

public class Constructor
{   
    OutPut outPut = new();
    Checker checker = new();

    public LenghtShip[] shipCollection = new LenghtShip[]
    {
        LenghtShip.Single,
        LenghtShip.Single,
        LenghtShip.Single,
        LenghtShip.Single,
        
        LenghtShip.Double,
        LenghtShip.Double,
        LenghtShip.Double,

        LenghtShip.Triple,
        LenghtShip.Triple,

        LenghtShip.Quadro
    };

    // temp battleField be like
    private char[,] _layOut = new char[10, 10]; 

    private LenghtShip _lenghtShip;
    private TypeShip _typeShip;
    private int _x;
    private int _y;
    
    public void DefineShip(LenghtShip lenghtShip ,TypeShip typeShip, int x, int y,List<Ship> ShipsList)
    {
        _x = x;
        _y = y;
        _typeShip = typeShip;
        _lenghtShip = lenghtShip;
    }

    public void AddShip(List<Ship> ShipsList)
    {
        ShipsList.Add(new Ship(_lenghtShip, _typeShip, _x, _y));
    }


    public void SetShip(ref char[,] battlefield, int x, int y)                       
    {
        char shipPlace = 'Z';

        if (_typeShip == TypeShip.Horizontal)
        {
            for (int i = 0; i < (int)_lenghtShip; i++)
            {
                battlefield[x, y + i] = shipPlace;
            }
        }
        else
        {
            for (int i = 0; i < (int)_lenghtShip; i++)
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
        TypeShip typeShipShip = TypeShip.Horizontal;
        LenghtShip lenghtShip = LenghtShip.Single;
        
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
                    if ((x < 9 && typeShipShip == TypeShip.Horizontal) ||
                        (x < 10 - (int)lenghtShip && typeShipShip == TypeShip.Vertical)) x++;
                    break;

                case ConsoleKey.LeftArrow:
                    if (y > 0) y--;
                    break;

                case ConsoleKey.RightArrow:
                    if ((y < 9 && typeShipShip == TypeShip.Vertical) ||
                        (y < 10 - (int)lenghtShip && typeShipShip == TypeShip.Horizontal)) y++;
                    break;

                case ConsoleKey.Spacebar:
                    if ((x <= (10 - (int)lenghtShip)) && y <= (10 - (int)lenghtShip))
                    {
                        if (typeShipShip == TypeShip.Horizontal)
                        {
                            typeShipShip = TypeShip.Vertical;
                        }
                        else
                        {
                            typeShipShip = TypeShip.Horizontal;
                        }
                    }
                    break;

                case ConsoleKey.Enter:
                   // IsShipSet = checker.IsFreePlace(lenghtShip, typeShipShip, x, y, battleField);
                    break;
            }
        }

    }

    public void RandomPlace(LenghtShip lenghtShip,  out TypeShip typeShip, out int x, out int y, char[,] battleField, List<Ship> listShip)
    {
        Random random = new();

    do
    {
        bool IsOverFlow = true;

        do
        {
            typeShip = (TypeShip)random.Next(2);
            x = random.Next(10);
            y = random.Next(10);

            if (typeShip == TypeShip.Horizontal)
            {
                if (y - 1 + (int)lenghtShip < battleField.GetLength(0)) IsOverFlow = false; 
            }
            else
            {
                if (x - 1 + (int)lenghtShip < battleField.GetLength(0)) IsOverFlow = false;
            }
            
        } while (IsOverFlow);
    }
    while (checker.IsFreePlace(lenghtShip, typeShip, x, y, listShip) == false);

    }

}