namespace BattleShip;

public class TheBattle
{
    public PlayersData playersData = new();
    private BattleField _battleField = new();
    BattleManager battleManager = new();
    OutPut output = new();
    
    public void TurnTurn()
    {
        while(true)
        {
            PlayerTurn();
            if(!playersData.bot.fleet.IsAliveFleet()) break;

            BotTurn();
            if(!playersData.player.fleet.IsAliveFleet()) break;
        }
    }

    private void PlayerTurn()
    {
        int x = 4;
        int y = 4;
        ConsoleKeyInfo pressedKey;

        while(true)
        {
            Console.Clear();
            output.DrawAimAndBattleFields(x, y, playersData.player.battleField.battleField, playersData.bot.battleField.battleField);
            output.DrawRules2();


            pressedKey = Console.ReadKey();

            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (x > 0) x--; break;

                case ConsoleKey.DownArrow:
                    if (x < _battleField.mapSize - 1) x++; break;

                case ConsoleKey.RightArrow:
                    if (y < _battleField.mapSize - 1) y++; break;

                case ConsoleKey.LeftArrow:
                    if (y > 0) y--; break;

                 case ConsoleKey.Enter:

                 if(playersData.bot.battleField.battleField[x,y] == (char)Markers.Empty)
                 {
                    battleManager.CheckShot(x, y, playersData.bot.fleet.ShipsList, ref playersData.bot.battleField.battleField);
                    return;
                 }

                 break;
            }
        }
    }

    private void BotTurn()
    {
        int x, y;
        Random random = new Random();
    
        while (true)
        {
            x = random.Next(_battleField.mapSize);
            y = random.Next(_battleField.mapSize);

            if(playersData.player.battleField.battleField[x,y] == (char)Markers.CellShip
            || playersData.player.battleField.battleField[x,y] == (char)Markers.Empty) 
                break;
        }

        battleManager.CheckShot(x, y, playersData.player.fleet.ShipsList, ref playersData.player.battleField.battleField);
    }
}