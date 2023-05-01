namespace BattleShip;

public class Ship
{
    private TypeShip _typeShip;
    private OrientationShip _orientationShip;
    private int _lifeShip;
    private int _xcoordinate;
    private int _ycoordinate;
    
    public Ship(TypeShip typeShip,OrientationShip orientationShip)
    {
        this._typeShip = typeShip;
        this._orientationShip = orientationShip;
        this._lifeShip = (int) typeShip;                                       //Конструктор
        _xcoordinate = 4;
        _ycoordinate = 4;
    }

    public void setUpShip(OrientationShip orientationShip,int x, int y)    //Установка координат и ориентации корабля
    {
        this._orientationShip = orientationShip;                            //изменения данных корабля
        this._xcoordinate = x;
        this._ycoordinate = y;
    }
    
    public void AddShip(ref char[,] battlefield)                       //Добавление корабля на поле боя
    {
        if (_orientationShip == OrientationShip.Horizontal)
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xcoordinate, _ycoordinate + i] = 'Z';
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xcoordinate + i, _ycoordinate] = 'Z';
            }
        }
    }     
    
    public void DeleteShip(ref char[,] battlefield)                       //удаление корабля на поле боя
    {
        if (_orientationShip == OrientationShip.Horizontal)
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xcoordinate, _ycoordinate + i] = '∙';
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xcoordinate + i, _ycoordinate] = '∙';
            }
        }
    }       

    private void ExpShip(ref char[,] battlefield)                       //Взрыв корабля на поле боя
    {
        if (_orientationShip == OrientationShip.Horizontal)
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xcoordinate, _ycoordinate + i] = '#';

                if (_ycoordinate > 0 && i == 0) battlefield[_xcoordinate, _ycoordinate + i - 1] = '?';
                if (_ycoordinate + i < 9) battlefield[_xcoordinate, _ycoordinate + i + 1] = '?';
                if (_xcoordinate > 0) battlefield[_xcoordinate - 1, _ycoordinate + i] = '?';
                if (_xcoordinate < 9) battlefield[_xcoordinate + 1, _ycoordinate + i] = '?';
                if (_xcoordinate > 0 && _ycoordinate > 0) battlefield[_xcoordinate - 1, _ycoordinate + i - 1] = '?';
                if (_xcoordinate < 9 && _ycoordinate + i < 9) battlefield[_xcoordinate + 1, _ycoordinate + i  + 1] = '?';
                if (_xcoordinate < 9 && _ycoordinate > 0) battlefield[_xcoordinate + 1, _ycoordinate + i - 1] = '?'; 
                if (_xcoordinate > 0 && _ycoordinate + i < 9) battlefield[_xcoordinate - 1, _ycoordinate + i + 1] = '?';
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                battlefield[_xcoordinate + i, _ycoordinate] = '#';

                if (_ycoordinate > 0) battlefield[_xcoordinate + i, _ycoordinate - 1] = '?';
                if (_ycoordinate < 9) battlefield[_xcoordinate + i, _ycoordinate + 1] = '?';
                if (_xcoordinate > 0 && i == 0) battlefield[_xcoordinate + i - 1, _ycoordinate] = '?';
                if (_xcoordinate + i < 9) battlefield[_xcoordinate + i + 1, _ycoordinate] = '?';
                if (_xcoordinate > 0 && _ycoordinate > 0) battlefield[_xcoordinate + i - 1, _ycoordinate - 1] = '?';
                if (_xcoordinate + i < 9 && _ycoordinate < 9) battlefield[_xcoordinate + i + 1, _ycoordinate + 1] = '?';
                if (_xcoordinate + i < 9 && _ycoordinate > 0) battlefield[_xcoordinate + i + 1, _ycoordinate - 1] = '?'; 
                if (_xcoordinate > 0 && _ycoordinate < 9) battlefield[_xcoordinate + i - 1, _ycoordinate + 1] = '?';
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
                if (_xcoordinate == x && _ycoordinate + i == y)
                {
                    HitShip(ref battlefield,x,y);
                }
            }
        }
        else
        {
            for (int i = 0; i < (int)_typeShip; i++)
            {
                if (_xcoordinate + i == x && _ycoordinate == y)
                {
                    HitShip(ref battlefield,x,y);
                }
            }
        }
    }
    
    private void HitShip(ref char[,] battlefield, int x, int y)        //Попадание по кораблю
    {
        battlefield[x, y] = 'x';
        _lifeShip--;
        if (!AliveShip()) {ExpShip(ref battlefield);}
    }
    
    public int lifes()                                                  //возвращает количество жизней корабля
    {
        return _lifeShip;
    }
}