namespace BattleShip;

public class Constructor
{   
    OutPut _outPut = new();
    Checker _checker = new();
    BattleField _battleField = new();

    public LenghtShip[] shipCollection = new LenghtShip[]
    {
        LenghtShip.Quadro,

        LenghtShip.Triple,
        LenghtShip.Triple,

        LenghtShip.Double,
        LenghtShip.Double,
        LenghtShip.Double,

        LenghtShip.Single,
        LenghtShip.Single,
        LenghtShip.Single,
        LenghtShip.Single
    };
    
    private char[,] _layOut = new char[10, 10]; 

    private LenghtShip _lenghtShip;
    private TypeShip _typeShip;
    private int _x;
    private int _y;

    public void AddShip(List<Ship> ShipsList)
    {
        ShipsList.Add(new Ship(_lenghtShip, _typeShip, _x, _y));
    }


    public void SetShip(ref char[,] battlefield, int x, int y, TypeShip typeShip, LenghtShip lenghtShip)                       
    {
        char shipPlace = 'Z';
        
        for (int i = 0; i < (int)lenghtShip; i++)
        {
            if (typeShip == TypeShip.Horizontal)
            {
                battlefield[x, y + i] = shipPlace;
            }
            else
            {
                battlefield[x + i, y] = shipPlace;
            }
        }
    }
    public void findPlace(LenghtShip lenghtShip, List<Ship> ShipsList)
    {
        bool IsShipSet = false;

        _x = 5;
        _y = 5;
        _typeShip = TypeShip.Horizontal;
        _lenghtShip = lenghtShip;
        
        ConsoleKeyInfo pressedKey;
        
        while (IsShipSet == false)
        {
            
            SetShip(ref _battleField.battleField, _x, _y, _typeShip, _lenghtShip);
            
            Console.Clear();
            _outPut.Game_Name();
            _outPut.Battlefield(_battleField.battleField);
            _outPut.rules();

            
            
            pressedKey = Console.ReadKey();  

            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (_x > 0) _x--;
                    break;

                case ConsoleKey.DownArrow:
                    if ((_x < 9 && _typeShip == TypeShip.Horizontal) ||
                        (_x < 10 - (int)lenghtShip && _typeShip == TypeShip.Vertical)) _x++;
                    break;

                case ConsoleKey.LeftArrow:
                    if (_y > 0) _y--;
                    break;

                case ConsoleKey.RightArrow:
                    if ((_y < 9 && _typeShip == TypeShip.Vertical) ||
                        (_y < 10 - (int)lenghtShip && _typeShip == TypeShip.Horizontal)) _y++;
                    break;

                case ConsoleKey.Spacebar:
                    if ((_x <= (10 - (int)lenghtShip)) && _y <= (10 - (int)lenghtShip))
                    {
                        if (_typeShip == TypeShip.Horizontal)
                            _typeShip = TypeShip.Vertical;
                        else
                            _typeShip = TypeShip.Horizontal;
                    }
                    break;

                case ConsoleKey.Enter:
                    IsShipSet = _checker.IsFreePlace(lenghtShip, _typeShip, _x, _y, ShipsList);
                    break;
            }
            
            for (int i = 0; i < _battleField.mapSize; i++)
                for (int j = 0; j < _battleField.mapSize; j++)
                    _battleField.battleField[i, j] = '∙';

            for (int i = 0; i < ShipsList.Count; i++)
                SetShip(ref _battleField.battleField, ShipsList[i].X, ShipsList[i].Y, ShipsList[i].typeShip, ShipsList[i].lenghtShip);

            SetShip(ref _battleField.battleField, _x, _y, _typeShip, _lenghtShip);

        }
    }

    public void RandomPlace(LenghtShip lenghtShip, List<Ship> listShip)
    {
        Random random = new();

        do
        {
            bool IsOverFlow = true;
    
            do
            {
                _typeShip = (TypeShip)random.Next(2);
                _lenghtShip = lenghtShip;
                _x = random.Next(_battleField.mapSize);
                _y = random.Next(_battleField.mapSize);
                
                if (_typeShip == TypeShip.Horizontal)
                {
                    if (_y - 1 + (int)lenghtShip < _battleField.mapSize) IsOverFlow = false; 
                }
                else
                {
                    if (_x - 1 + (int)lenghtShip < _battleField.mapSize) IsOverFlow = false;
                }
            }
            while (IsOverFlow);
        }
        while (_checker.IsFreePlace(lenghtShip, _typeShip, _x, _y, listShip) == false);

    }

}