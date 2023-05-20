namespace BattleShip;

class BattleField{

    public char[,] battleField = new char[10, 10];
    private char _shipPlace = 'Z';


    public BattleField()
    {
        for (int i = 0; i < battleField.GetLength(0); i++)
        {
            for (int j = 0; j < battleField.GetLength(1); j++)
            {
                battleField[i, j] = '∙';
            }
        }
    }

}