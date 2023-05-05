namespace BattleShip;

public class Ship
{
    private TypeShip _typeShip;
    private OrientationShip _orientationShip;
    private int _lifeShip;
    private int _xСoordinate;
    private int _yCoordinate;

    public Ship(TypeShip typeShip, OrientationShip orientationShip)
    {
        this._typeShip = typeShip;
        this._orientationShip = orientationShip;
        this._lifeShip = (int)typeShip;                                       //Конструктор
        _xСoordinate = 4;
        _yCoordinate = 4;
    }

    public void setUpShip(OrientationShip orientationShip, int x, int y)    //Установка координат и ориентации корабля
    {
        this._orientationShip = orientationShip;                            //изменения данных корабля
        this._xСoordinate = x;
        this._yCoordinate = y;
    }

    public void AddShip(ref char[,] battlefield)                       //Добавление корабля на поле боя
    {
        if (_orientationShip == OrientationShip.Horizontal)
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xСoordinate, _yCoordinate + i] = 'Z';
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xСoordinate + i, _yCoordinate] = 'Z';
            }
        }
    }

    public void DeleteShip(ref char[,] battlefield)                       //удаление корабля на поле боя
    {
        if (_orientationShip == OrientationShip.Horizontal)
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xСoordinate, _yCoordinate + i] = '∙';
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xСoordinate + i, _yCoordinate] = '∙';
            }
        }
    }

    private void ExpShip(ref char[,] battlefield)                       //Взрыв корабля на поле боя
    {
        if (_orientationShip == OrientationShip.Horizontal)
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xСoordinate, _yCoordinate + i] = '#';

                if (_yCoordinate > 0 && i == 0) battlefield[_xСoordinate, _yCoordinate + i - 1] = '?';
                if (_yCoordinate + i < 9) battlefield[_xСoordinate, _yCoordinate + i + 1] = '?';
                if (_xСoordinate > 0) battlefield[_xСoordinate - 1, _yCoordinate + i] = '?';
                if (_xСoordinate < 9) battlefield[_xСoordinate + 1, _yCoordinate + i] = '?';
                if (_xСoordinate > 0 && _yCoordinate > 0) battlefield[_xСoordinate - 1, _yCoordinate + i - 1] = '?';
                if (_xСoordinate < 9 && _yCoordinate + i < 9) battlefield[_xСoordinate + 1, _yCoordinate + i + 1] = '?';
                if (_xСoordinate < 9 && _yCoordinate > 0) battlefield[_xСoordinate + 1, _yCoordinate + i - 1] = '?';
                if (_xСoordinate > 0 && _yCoordinate + i < 9) battlefield[_xСoordinate - 1, _yCoordinate + i + 1] = '?';
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xСoordinate + i, _yCoordinate] = '#';

                if (_yCoordinate > 0) battlefield[_xСoordinate + i, _yCoordinate - 1] = '?';
                if (_yCoordinate < 9) battlefield[_xСoordinate + i, _yCoordinate + 1] = '?';
                if (_xСoordinate > 0 && i == 0) battlefield[_xСoordinate + i - 1, _yCoordinate] = '?';
                if (_xСoordinate + i < 9) battlefield[_xСoordinate + i + 1, _yCoordinate] = '?';
                if (_xСoordinate > 0 && _yCoordinate > 0) battlefield[_xСoordinate + i - 1, _yCoordinate - 1] = '?';
                if (_xСoordinate + i < 9 && _yCoordinate < 9) battlefield[_xСoordinate + i + 1, _yCoordinate + 1] = '?';
                if (_xСoordinate + i < 9 && _yCoordinate > 0) battlefield[_xСoordinate + i + 1, _yCoordinate - 1] = '?';
                if (_xСoordinate > 0 && _yCoordinate < 9) battlefield[_xСoordinate + i - 1, _yCoordinate + 1] = '?';
            }
        }
    }

    public bool AliveShip()                                            //Проверка жизни корабля
    {
        return (_lifeShip > 0);
    }

    public void CheckFieldShip(ref char[,] battlefield, int x, int y)  //Проверка какому короблю принадлежит поле
    {
        if (_orientationShip == OrientationShip.Horizontal)
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                if (_xСoordinate == x && _yCoordinate + i == y)
                {
                    HitShip(ref battlefield, x, y);
                }
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                if (_xСoordinate + i == x && _yCoordinate == y)
                {
                    HitShip(ref battlefield, x, y);
                }
            }
        }
    }

    private void HitShip(ref char[,] battlefield, int x, int y)        //Попадание по кораблю
    {
        battlefield[x, y] = 'x';
        _lifeShip--;
        if (!AliveShip()) { ExpShip(ref battlefield); }
    }

    public int lifes()                                                  //возвращает количество жизней корабля
    {
        return _lifeShip;
    }
}