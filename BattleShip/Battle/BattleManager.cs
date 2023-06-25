namespace BattleShip;

public class BattleManager
{
    private BattleField _battleField = new();
    public bool CheckShot(int x, int y, List<Ship> ShipList, ref char[,] battleField) 
    {
        for(int i = 0; i < ShipList.Count; i++)
        {
            for(int j = 0; j < (int)ShipList[i].lenghtShip; j ++)
            {
                if(ShipList[i].typeShip == TypeShip.Horizontal)
                {
                    if(ShipList[i].X == x && ShipList[i].Y + j == y)
                    {
                        ShipList[i].Damage();

                        if(ShipList[i].IsAliveShip())
                            Hit(x,y, ref battleField);
                        else
                            Explode(ShipList[i], ref battleField);

                        return true;
                    }
                }  
                else
                {
                    if(ShipList[i].X + j == x && ShipList[i].Y == y)
                    {
                        ShipList[i].Damage();

                        if(ShipList[i].IsAliveShip())
                            Hit(x,y, ref battleField);
                        else
                            Explode(ShipList[i], ref battleField);
                            
                        return true;
                    } 
                } 
            }
        }

        Miss(x,y, ref battleField);
        return false;
    }

    private void Hit(int x, int y, ref char[,] battleField)     
    {
        battleField[x, y] = (char)Markers.Hit;
    }

    private void Miss(int x, int y, ref char[,] battleField)
    {   
        battleField[x, y] = (char)Markers.Miss;
    }

    private void Explode(Ship ship, ref char[,] battleField)               
    {
        int x = ship.X - 1;
        int y = ship.Y - 1;

        for(int i = 0; i < (int)ship.lenghtShip + 2; i ++)
        {
            for(int j = 0; j < 3; j++)
            {
                if(ship.typeShip == TypeShip.Horizontal)
                {
                    if((x + j >= 0 && x + j < _battleField.mapSize) && (y + i >= 0 && y + i < _battleField.mapSize))
                        battleField[x + j, y + i] = (char)Markers.Explode; 
                }  
                else
                {
                    if((x + i >= 0 && x + i < _battleField.mapSize) && (y + j >= 0 && y + j < _battleField.mapSize))
                        battleField[x + i, y + j] = (char)Markers.Explode;
                }  
            }
        }
    }
}