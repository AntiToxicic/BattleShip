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
        _x = x;
        _y = y;

    }

    public int X{
        get
        {
            return _x;
        }
    }

     public int Y{
        get
        {
            return _y;
        }
    }

    public LenghtShip lenghtShip{
        get
        {
            return _lenghtShip;
        }
    }

     public TypeShip typeShip{
        get 
        {
            return _typeShip;
        }
    }


    public void DeleteShip(ref char[,] battlefield)                     
    {
        if (_typeShip == TypeShip.Horizontal)
        {
            for (int i = 0; i < (int)_lenghtShip; i++)
            {
                battlefield[_x, _y + i] = '∙';
            }
        }
        else
        {
            for (int i = 0; i < (int)_lenghtShip; i++)
            {
                battlefield[_x + i, _y] = '∙';
            }
        }
    }

    private void ExpShip(ref char[,] battlefield)                  
    {
        if (_typeShip == TypeShip.Horizontal)
        {
            for (int i = 0; i < (int)_lenghtShip; i++)
            {
                battlefield[_x, _y + i] = '#';

                if (_y > 0 && i == 0) battlefield[_x, _y + i - 1] = '?';
                if (_y + i < 9) battlefield[_x, _y + i + 1] = '?';
                if (_x > 0) battlefield[_x - 1, _y + i] = '?';
                if (_x < 9) battlefield[_x + 1, _y + i] = '?';
                if (_x > 0 && _y > 0) battlefield[_x - 1, _y + i - 1] = '?';
                if (_x < 9 && _y + i < 9) battlefield[_x + 1, _y + i + 1] = '?';
                if (_x < 9 && _y > 0) battlefield[_x + 1, _y + i - 1] = '?';
                if (_x > 0 && _y + i < 9) battlefield[_x - 1, _y + i + 1] = '?';
            }
        }
        else
        {
            for (int i = 0; i < (int)_lenghtShip; i++)
            {
                battlefield[_x + i, _y] = '#';

                if (_y > 0) battlefield[_x + i, _y - 1] = '?';
                if (_y < 9) battlefield[_x + i, _y + 1] = '?';
                if (_x > 0 && i == 0) battlefield[_x + i - 1, _y] = '?';
                if (_x + i < 9) battlefield[_x + i + 1, _y] = '?';
                if (_x > 0 && _y > 0) battlefield[_x + i - 1, _y - 1] = '?';
                if (_x + i < 9 && _y < 9) battlefield[_x + i + 1, _y + 1] = '?';
                if (_x + i < 9 && _y > 0) battlefield[_x + i + 1, _y - 1] = '?';
                if (_x > 0 && _y < 9) battlefield[_x + i - 1, _y + 1] = '?';
            }
        }
    }

    public bool AliveShip()                                           
    {
        return (_lifeShip > 0);
    }

    public void CheckFieldShip(ref char[,] battlefield, int x, int y) 
    {
        if (_typeShip == TypeShip.Horizontal)
        {
            for (int i = 0; i < (int)_lenghtShip; i++)
            {
                if (_x == x && _y + i == y)
                {
                    HitShip(ref battlefield, x, y);
                }
            }
        }
        else
        {
            for (int i = 0; i < (int)_lenghtShip; i++)
            {
                if (_x + i == x && _y == y)
                {
                    HitShip(ref battlefield, x, y);
                }
            }
        }
    }

    private void HitShip(ref char[,] battlefield, int x, int y)     
    {
        battlefield[x, y] = 'x';
        _lifeShip--;
        if (!AliveShip()) { ExpShip(ref battlefield); }
    }

    public int lifes()                                               
    {
        return _lifeShip;
    }
}