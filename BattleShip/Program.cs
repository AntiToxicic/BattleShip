using BattleShip;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Draw draw = new Draw();
TheBattle theBattle = new TheBattle();

draw.Game_Name();
Console.WriteLine("Do you wanna random set ship, or handle?\tr - Random, h - handle\nr/h?");
while (true)
{
    char key = Console.ReadKey().KeyChar;
    if (key == 'r') { theBattle.PlayerGen.setShipsRdm(); break; }
    if (key == 'h') { theBattle.PlayerGen.setShips(); break; }
}


theBattle.BotGen.setShipsRdm();

theBattle.Game();

draw.Battlefield(theBattle.PlayerGen.battleField, theBattle.BotGen.battleField);

Console.ReadLine();
Thread.Sleep(5000);