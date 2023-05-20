namespace BattleShip;

public class Fleet
{
    public List<Ship> ShipsList = new();

    public int GetCountShips
    {
        get
        {
            return ShipsList.Count();
        }
    }

}