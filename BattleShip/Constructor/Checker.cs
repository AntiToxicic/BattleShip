namespace BattleShip;

class Checker
{
    public bool IsFreePlace(LenghtShip lenghtShip ,TypeShip typeShip, int x, int y, List<Ship> ShipList)
    {
        int shipList_X;
        int shipList_Y;

        int shipCheck_X = x - 1;
        int shipCheck_Y = y - 1;

        for (int shipList_Count = 0; shipList_Count < ShipList.Count; shipList_Count++)
        {
            shipList_X = ShipList[shipList_Count].X;
            shipList_Y = ShipList[shipList_Count].Y;

            for (int shipList_Lenght = 0; shipList_Lenght < (int)ShipList[shipList_Count].lenghtShip; shipList_Lenght ++)
            {
                for (int shipCheck_Lenght = 0; shipCheck_Lenght < (int)lenghtShip + 2; shipCheck_Lenght++)
                {
                    for (int lenRow = 0; lenRow < 3; lenRow++)
                    {
                        if(typeShip == TypeShip.Horizontal)
                        {
                            if(ShipList[shipList_Count].typeShip == TypeShip.Horizontal)
                            {
                                if (shipList_X == shipCheck_X + lenRow && shipList_Y + shipList_Lenght == shipCheck_Y + shipCheck_Lenght)
                                    return false;
                            }
                            else
                            {
                                if (shipList_X + shipList_Lenght == shipCheck_X + lenRow && shipList_Y == shipCheck_Y + shipCheck_Lenght)
                                    return false;
                            }
                        }
                        else
                        {
                            if(ShipList[shipList_Count].typeShip == TypeShip.Horizontal)
                            {
                                if (shipList_X == shipCheck_X + shipCheck_Lenght && shipList_Y + shipList_Lenght == shipCheck_Y + lenRow)
                                    return false;
                            }
                            else
                            {
                                if (shipList_X + shipList_Lenght == shipCheck_X + shipCheck_Lenght && shipList_Y == shipCheck_Y + lenRow)
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