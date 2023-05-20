namespace BattleShip;

class Checker
{

    private char _shipPlace = 'Z';

    public bool IsFreePlace(OrientationShip orientationShip, TypeShip typeShip, int x, int y, char[,] battleField)
    {
        for(int i = 0; (int)typeShip < i; i++)
        {
        
            if (battleField[x, y] == _shipPlace) return false;
            if (x < 9) { if (battleField[x + 1, y] == _shipPlace) return false; }
            if (x > 0) { if (battleField[x - 1, y] == _shipPlace) return false; }
            if (y < 9) { if (battleField[x, y + 1] == _shipPlace) return false; }
            if (y > 0) { if (battleField[x, y - 1] == _shipPlace) return false; }

            if (x < 9 && y < 9) { if (battleField[x + 1, y + 1] == _shipPlace) return false; }
            if (x > 0 && y > 0) { if (battleField[x - 1, y - 1] == _shipPlace) return false; }
            if (x < 9 && y > 0) { if (battleField[x + 1, y - 1] == _shipPlace) return false; }
            if (x > 0 && y < 9) { if (battleField[x - 1, y + 1] == _shipPlace) return false; }

            if (orientationShip == OrientationShip.Horizontal)
            {
                y++;
            }
            else
            {
                x++;
            }

        } 

        return true;
    }



}