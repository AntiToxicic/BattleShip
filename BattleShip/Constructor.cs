namespace BattleShip;

public class Constructor
{   
    protected TypeShip _typeShip;
    protected OrientationShip _orientation;
    protected int _x;
    protected int _y;
    
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
}