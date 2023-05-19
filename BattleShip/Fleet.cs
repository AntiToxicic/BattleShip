namespace BattleShip;

public class Fleet
{
    public List<Ship> ShipsList = new List<Ship>();

    public int GetCountShips
    {
        get { return ShipsList.Count(); }
    }

}