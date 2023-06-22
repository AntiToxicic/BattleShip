namespace BattleShip;

public class Ship
{
    private LenghtShip _lenghtShip;
    private TypeShip _typeShip;
    private int _lifeShip;
    private int _x;
    private int _y;

    public Ship(LenghtShip lenghtShip, TypeShip typeShip, int x, int y)
    {
        _lenghtShip = lenghtShip;
        _typeShip = typeShip;
        _lifeShip = (int)lenghtShip;
        _x = x;
        _y = y;
    }

    public void Damage() => _lifeShip--;

    public bool IsAliveShip() => (_lifeShip > 0);

    public int X
    {
        get
        {
            return _x;
        }
    }

    public int Y
    {
        get
        {
            return _y;
        }
    }

    public LenghtShip lenghtShip
    {
        get
        {
            return _lenghtShip;
        }
    }

    public TypeShip typeShip
    {
        get 
        {
            return _typeShip;
        }
    }
}