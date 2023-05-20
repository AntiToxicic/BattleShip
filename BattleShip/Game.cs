namespace BattleShip;

class Game{

Constructor constructor = new();
Client player = new();
Client bot = new();

public void start(){
    
}

     



public void CreateFleet(List<Ship> ShipsList, bool IsRandom){
        
        for(int i = 0; i < 10; i++)
        {
        

        constructor.DefineShip(TypeShip.Single, OrientationShip.Horizontal, x,y,ShipsList);

        }
    }
}