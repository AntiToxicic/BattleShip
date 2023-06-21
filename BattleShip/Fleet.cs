namespace BattleShip;

public class Fleet
{
    public List<Ship> ShipsList = new();

    public bool AliveFleet()
    {
        for(int i = 0; i < ShipsList.Count; i ++)
        {
            if(ShipsList[i].AliveShip) return true;
        }

        return false;
    }

    public int GetCountShips
    {
        get
        {
            return ShipsList.Count();
        }
    }

}