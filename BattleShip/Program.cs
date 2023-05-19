using BattleShip;
Console.OutputEncoding = System.Text.Encoding.UTF8;


Client player = new Client();
Client bot = new Client();





OutPut OutPut = new OutPut();
TheBattle theBattle = new TheBattle();

OutPut.Game_Name();
Console.WriteLine("Do you wanna random set ship, or handle?\tr - Random, h - handle\nr/h?");
while (true)
{
    char key = Console.ReadKey().KeyChar;
    if (key == 'r') { theBattle.playerLayOut.setShipsRdm(); break; }
    if (key == 'h') { theBattle.playerLayOut.setShips(); break; }
}


theBattle.botLayOut.setShipsRdm();

theBattle.Game();

OutPut.Battlefield(theBattle.playerLayOut.battleField, theBattle.botLayOut.battleField);

Console.ReadLine();
Thread.Sleep(5000);