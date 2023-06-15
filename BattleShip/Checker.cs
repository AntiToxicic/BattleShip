namespace BattleShip;

class Checker
{

    private char _shipPlace = 'Z';

    public bool IsFreePlace(LenghtShip lenghtShip ,TypeShip typeShip, int x, int y, List<Ship> ship)
    {
        int shipX, shipY;
        int checkX, checkY;

        for (int serialShip = 0; serialShip < ship.Count; serialShip++)
        {
            for (int lenShipList = 0; lenShipList < (int)ship[serialShip].lenghtShip; lenShipList ++)
            {
                for (int lenShipCheck = 0; lenShipCheck < (int)lenghtShip + 2; lenShipCheck++)
                {
                    
                    shipX = ship[serialShip].X;
                    shipY = ship[serialShip].Y;
                    checkX = x - 1;
                    checkY = y - 1;

                    if (ship[serialShip].typeShip == TypeShip.Horizontal)
                        shipY += lenShipList;
                    else
                        shipX += lenShipList;

                    for (int lenRow = 0; lenRow < 3; lenRow++)
                    {
                        if(typeShip == TypeShip.Horizontal)
                        {
                            if(ship[serialShip].typeShip == TypeShip.Horizontal)
                            {
                                if (shipX == checkX + lenRow && shipY + lenShipList == checkY + lenShipCheck)
                                    return false;
                            }
                            else
                            {
                                if (shipX + lenShipList == checkX + lenRow && shipY == checkY + lenShipCheck)
                                    return false;   
                            }
                        }
                        else
                        {
                            if(ship[serialShip].typeShip == TypeShip.Horizontal)
                            {
                                if (shipX == checkX + lenShipCheck && shipY + lenShipList == checkY + lenRow)
                                    return false;
                            }
                            else
                            {
                                if (shipX + lenShipList == checkX + lenShipCheck && shipY == checkY + lenRow)
                                    return false;
                            }
                        }   
                    }
                }
            }    
        }
        
        return true;
    }
}