namespace BattleShip;

class Game{

private Constructor _constructor = new();
public Client player = new();
public Client bot = new();


    public void start(bool IsRandom)
    {
        CreateFleet(player.fleet.ShipsList, player.battleField.battleField, IsRandom);
        CreateFleet(bot.fleet.ShipsList, bot.battleField.battleField, true);
    }




    private void CreateFleet(List<Ship> ShipsList, char[,] battleField, bool IsRandom)
    {
        int x,y;
        TypeShip typeShip;

        for(int i = 0; i < 10; i++)
        {
            _constructor.RandomPlace(_constructor.shipCollection[i], out typeShip, out x, out y, battleField, ShipsList);
            _constructor.DefineShip(_constructor.shipCollection[i], typeShip, x,y,ShipsList);
            _constructor.AddShip(ShipsList);
            _constructor.SetShip(ref battleField, ShipsList[i].X, ShipsList[i].Y);
        }
    }
}