namespace BattleShip;

public class Fleet
{
    private int _ships;
    LayOut _layOut = new 

    public Ship singleShip1 = new Ship(TypeShip.Single, OrientationShip.Horizontal);
    public Ship singleShip2 = new Ship(TypeShip.Single, OrientationShip.Horizontal);
    public Ship singleShip3 = new Ship(TypeShip.Single, OrientationShip.Horizontal);
    public Ship singleShip4 = new Ship(TypeShip.Single, OrientationShip.Horizontal);

    public Ship doubleShip1 = new Ship(TypeShip.Double, OrientationShip.Horizontal);
    public Ship doubleShip2 = new Ship(TypeShip.Double, OrientationShip.Horizontal);
    public Ship doubleShip3 = new Ship(TypeShip.Double, OrientationShip.Horizontal);

    public Ship tripleShip1 = new Ship(TypeShip.Triple, OrientationShip.Horizontal);
    public Ship tripleShip2 = new Ship(TypeShip.Triple, OrientationShip.Horizontal);
 
    public Ship quadroShip = new Ship(TypeShip.Quadro, OrientationShip.Horizontal);
    public Fleet()
    {
        for (int i = 1; i <= 10; i++)
        {
            
        }
    }

    public int GetFleetShips()
    {
        _ships = 0;

        if (singleShip1.lifes() > 0) _ships++;
        if (singleShip2.lifes() > 0) _ships++;
        if (singleShip3.lifes() > 0) _ships++;
        if (singleShip4.lifes() > 0) _ships++;

        if (doubleShip1.lifes() > 0) _ships++;
        if (doubleShip2.lifes() > 0) _ships++;
        if (doubleShip3.lifes() > 0) _ships++;

        if (tripleShip1.lifes() > 0) _ships++;
        if (tripleShip2.lifes() > 0) _ships++;

        if (quadroShip.lifes() > 0) _ships++;

        return _ships;
    }

}