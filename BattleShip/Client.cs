namespace BattleShip;

public class Client
{
    Fleet fleet = new Fleet();
    Constructor constructor = new Constructor();

    private void CreateFleet(){
        
        constructor.DefineShip(TypeShip.Single, OrientationShip.Horizontal, 5,5,fleet.ShipsList);
    }


}