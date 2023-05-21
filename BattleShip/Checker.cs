namespace BattleShip;

class Checker
{

    private char _shipPlace = 'Z';

    public bool IsFreePlace(LenghtShip lenghtShip ,TypeShip typeShip, int x, int y, List<Ship> ship)
    {
        int ShipX, ShipY;
        Console.WriteLine(ship.Count);
        for (int i = 0; i < ship.Count; i++)
        {
            ShipX = ship[i].X;
            ShipY = ship[i].Y;

            ShipX--;
            ShipY--;

            for(int row = 0; row < 3; row++)
            {
                if(typeShip == TypeShip.Horizontal)
                {
                    for(int j = ShipX; j < ShipX + (int)lenghtShip + 1; j++)
                    {
                        if(j == x && ShipY + row == y) return false;
                    }
                }
                else
                {
                    for(int j = ShipY; j < ShipY + (int)lenghtShip + 1; j++)
                    {
                        if(j == y && ShipX + row == y) return false;
                    }
                }
            }
        }

          return true;
    }
}