namespace BattleShip;

public class Fleet
{
    private int _ships;
    private int _lifes;

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
    public Fleet(int ships = 10, int lifes = 20)
    {
        this._ships = ships;
        this._lifes = lifes;
    }

    public int fleetLifes()
    {
        _lifes = singleShip1.lifes() + singleShip2.lifes() + singleShip3.lifes() + singleShip4.lifes() +
                doubleShip1.lifes() + doubleShip2.lifes() + doubleShip3.lifes() +
                tripleShip1.lifes() + tripleShip2.lifes() +
                quadroShip.lifes();
        return _lifes;
    }

    public int fleetShips()
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