namespace BattleShip;

class BattleShip
{
    static void Main(string[] args)
    {
        Game game = new();
        OutPut outPut = new();

        game.start(true);

        outPut.Game_Name();
        outPut.Battlefield(game.player.battleField.battleField ,game.bot.battleField.battleField);

        
    }
}



