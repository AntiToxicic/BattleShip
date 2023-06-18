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
        for(int i = 0; i < _constructor.shipCollection.Length; i++)
        {
            if (IsRandom)
                 _constructor.RandomPlace(_constructor.shipCollection[i], ShipsList);
            else
                 _constructor.findPlace(_constructor.shipCollection[i], ShipsList);
            
            _constructor.AddShip(ShipsList);
            _constructor.SetShip(ref battleField, ShipsList[i].X, ShipsList[i].Y, ShipsList[i].typeShip, ShipsList[i].lenghtShip);
        }
    }
}
