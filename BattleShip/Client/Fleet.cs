namespace BattleShip;

public class Fleet
{
    public List<Ship> ShipsList = new();

    public bool IsAliveFleet()
    {
        for(int i = 0; i < ShipsList.Count; i ++)
        {
            if(ShipsList[i].IsAliveShip()) return true;
        }

        return false;
    }
}