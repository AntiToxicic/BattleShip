namespace BattleShip;

public class BattleManager
{

    public void CheckShot(int x, int y, List<Ship> ShipList, ref char[,] battleField) 
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

                        if(ShipList[i].AliveShip)
                            Hit(x,y, ref battleField);
                        else
                            Explode(ShipList[i], ref battleField);

                        return;
                    }
                }  
                else
                {
                    if(ShipList[i].X + j == x && ShipList[i].Y == y)
                    {
                        ShipList[i].Damage();

                        if(ShipList[i].AliveShip)
                            Hit(x,y, ref battleField);
                        else
                            Explode(ShipList[i], ref battleField);
                            
                        return;
                    } 
                } 
            }
        }

        Miss(x,y, ref battleField);
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

        for(int i = 0; i < (int)ship.lenghtShip; i ++)
        {
            for(int j = 0; j < 3; j++)
            {
                if(ship.typeShip == TypeShip.Horizontal)
                {
                    if((x > 0 && x < 9) && (y > 0 && y < 9))
                        battleField[x + j, y + i] = (char)Markers.Explode;
                }  
                else
                {
                    if((x > 0 && x < 9) && (y > 0 && y < 9))
                        battleField[x + i, y + j] = (char)Markers.Explode;
                }  
            }
        }
    }
}