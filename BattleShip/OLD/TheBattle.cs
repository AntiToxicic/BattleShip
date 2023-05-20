// namespace BattleShip;

// public class TheBattle
// {
//     public Client bot = new Client();
//     public Client player = new Client();



//     private OutPut output = new OutPut();
//     public PlayerBattleField playerBattleField = new PlayerBattleField();
//     public BotBattleField botBattleField = new BotBattleField();
//     private bool _isGame;

//     private char[,] hiddenField = new char[10, 10];
//     private char _dot = '+';
//     private char _shipPlace = 'Z';
//     private char _nullPlace = '∙';

//     public TheBattle()
//     {
//         for (int i = 0; i < hiddenField.GetLength(0); i++)
//         {
//             for (int j = 0; j < hiddenField.GetLength(1); j++)
//             {
//                 hiddenField[i, j] = _nullPlace;
//             }
//         }
//     }

//     public void Game()
//     {
//         char explosionField = '?';
//         _isGame = true;

//         while (_isGame)
//         {
//             ConsoleKeyInfo pressedKey;
//             int x = 4, y = 4;
//             char value;
//             bool badField = false;
//             value = hiddenField[x, y];
//             setDot(x, y);


//             while (badField == false)
//             {
//                 Console.Clear();
//                 output.Battlefield(playerBattleField.battleField, hiddenField);
//                 // output.Battlefield(botBattleField.battleField);
//                 output.rules2();

//                 pressedKey = Console.ReadKey();
//                 switch (pressedKey.Key)
//                 {
//                     case ConsoleKey.UpArrow:
//                         if (x > 0) { delDot(x--, y, value); value = hiddenField[x, y]; setDot(x, y); }
//                         break;
//                     case ConsoleKey.DownArrow:
//                         if (x < 9) { delDot(x++, y, value); value = hiddenField[x, y]; setDot(x, y); }
//                         break;
//                     case ConsoleKey.RightArrow:
//                         if (y < 9) { delDot(x, y++, value); value = hiddenField[x, y]; setDot(x, y); }
//                         break;
//                     case ConsoleKey.LeftArrow:
//                         if (y > 0) { delDot(x, y--, value); value = hiddenField[x, y]; setDot(x, y); }
//                         break;
//                     case ConsoleKey.Enter:
//                         if (value == _nullPlace)
//                         {
//                             badField = true;
//                             checkFieldbot(x, y, out explosionField);
//                             hit(x, y, explosionField, hiddenField);
//                             copyField();
//                         }
//                         break;
//                 }
//             }

//             if (explosionField == '?') botShot();
//         }
//     }

//     private void hit(int x, int y, char explosionField, char[,] battleField) => battleField[x, y] = explosionField;

//     private void setDot(int x, int y) => hiddenField[x, y] = _dot;

//     private void delDot(int x, int y, char value) => hiddenField[x, y] = value;

//     private void checkFieldbot(int x, int y, out char explosionField)
//     {
//         if (botBattleField.battleField[x, y] == _shipPlace)
//         {
//             explosionField = 'x';

//             botBattleField.bot.singleShip1.CheckFieldShip(ref botBattleField.battleField, x, y);
//             botBattleField.bot.singleShip2.CheckFieldShip(ref botBattleField.battleField, x, y);
//             botBattleField.bot.singleShip3.CheckFieldShip(ref botBattleField.battleField, x, y);
//             botBattleField.bot.singleShip4.CheckFieldShip(ref botBattleField.battleField, x, y);

//             botBattleField.bot.doubleShip1.CheckFieldShip(ref botBattleField.battleField, x, y);
//             botBattleField.bot.doubleShip2.CheckFieldShip(ref botBattleField.battleField, x, y);
//             botBattleField.bot.doubleShip3.CheckFieldShip(ref botBattleField.battleField, x, y);

//             botBattleField.bot.tripleShip1.CheckFieldShip(ref botBattleField.battleField, x, y);
//             botBattleField.bot.tripleShip2.CheckFieldShip(ref botBattleField.battleField, x, y);

//             botBattleField.bot.quadroShip.CheckFieldShip(ref botBattleField.battleField, x, y);

//             FleetAlive();
//         }
//         else 
//         {
//             explosionField = '?';
//         }
//     }

//     private void checkFieldPlayer(int x, int y, out char explosionField)
//     {

//         if (playerBattleField.battleField[x, y] == _shipPlace)
//         {
//             explosionField = 'x';

//             playerBattleField.player.singleShip1.CheckFieldShip(ref playerBattleField.battleField, x, y);
//             playerBattleField.player.singleShip2.CheckFieldShip(ref playerBattleField.battleField, x, y);
//             playerBattleField.player.singleShip3.CheckFieldShip(ref playerBattleField.battleField, x, y);
//             playerBattleField.player.singleShip4.CheckFieldShip(ref playerBattleField.battleField, x, y);

//             playerBattleField.player.doubleShip1.CheckFieldShip(ref playerBattleField.battleField, x, y);
//             playerBattleField.player.doubleShip2.CheckFieldShip(ref playerBattleField.battleField, x, y);
//             playerBattleField.player.doubleShip3.CheckFieldShip(ref playerBattleField.battleField, x, y);

//             playerBattleField.player.tripleShip1.CheckFieldShip(ref playerBattleField.battleField, x, y);
//             playerBattleField.player.tripleShip2.CheckFieldShip(ref playerBattleField.battleField, x, y);

//             playerBattleField.player.quadroShip.CheckFieldShip(ref playerBattleField.battleField, x, y);

//             FleetAlive();
//         }
//         else
//         {
//             explosionField = '?';
//             hit(x, y, explosionField, playerBattleField.battleField);
//         }
//     }

//     private void copyField()
//     {
//         for (int i = 0; i < botBattleField.battleField.GetLength(0); i++)
//         {
//             for (int j = 0; j < botBattleField.battleField.GetLength(1); j++)
//             {
//                 if (botBattleField.battleField[i, j] == '#') hiddenField[i, j] = '#';
//                 if (botBattleField.battleField[i, j] == '?') hiddenField[i, j] = '?';
//             }
//         }
//     }

//     private void botShot()
//     {
//         Random random = new Random();
//         int x, y;
//         char explosionField;

//         while (true)
//         {
//             x = random.Next(10);
//             y = random.Next(10);

//             if (playerBattleField.battleField[x, y] == _nullPlace ||
//                 playerBattleField.battleField[x, y] == _shipPlace) break;
//         }
//         Thread.Sleep(400);
//         checkFieldPlayer(x, y, out explosionField);

//         if (explosionField == 'x') botShot();
//     }

//     private void FleetAlive()
//     {
//         if (playerBattleField.player.GetFleetShips() == 0)
//         {
//             Console.Clear();
//             Console.WriteLine("Bot is Winning!");
//             _isGame = false;
//         }

//         if (botBattleField.bot.GetFleetShips() == 0)
//         {
//             Console.Clear();
//             Console.WriteLine("Player is Winning!");
//             _isGame = false;
//         }

//     }
// }