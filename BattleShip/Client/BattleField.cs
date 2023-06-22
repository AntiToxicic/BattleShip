namespace BattleShip;

public class BattleField{
    
    private static int _mapSize = 10;
    public char[,] battleField = new char[_mapSize, _mapSize];
    
    public BattleField()
    {
        for (int i = 0; i < _mapSize; i++)
        {
            for (int j = 0; j < _mapSize; j++)
            {
                battleField[i, j] = (char)Markers.Empty;
            }
        }
    }

    public int mapSize
    {
        get
        {
            return _mapSize;
        }
    }

}