namespace BattleShip;

class BattleShip
{
    static void Main(string[] args)
    {
        TheBattle theBattle = new();
        OutPut outPut = new();
        bool answer;
        
        while(true)
        {
            outPut.DrawGameName();
            Console.WriteLine($"Do you wanna fill Battlefield random?\tY/N?");
            
            char key = Console.ReadKey().KeyChar;

            if(key == 'y')
            {
                answer = true;
                break;
            }

            if(key == 'n')
            {
                answer = false;
                break;
            }
            
            Console.Clear();
        }
        
        theBattle.playersData.Generate(answer);
        theBattle.TurnTurn();
        
        outPut.DrawGameName();
        outPut.DrawBattleFields(theBattle.playersData.player.battleField.battleField,
            theBattle.playersData.bot.battleField.battleField);
    }
}



