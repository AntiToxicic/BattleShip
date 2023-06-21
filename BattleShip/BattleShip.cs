namespace BattleShip;

class BattleShip
{
    static void Main(string[] args)
    {
        TheBattle theBattle = new();
        OutPut outPut = new();

        theBattle.playersData.Generate(true);
        
        outPut.Game_Name();
        outPut.Battlefield(theBattle.playersData.player.battleField.battleField,
            theBattle.playersData.bot.battleField.battleField);
        
    }
}



