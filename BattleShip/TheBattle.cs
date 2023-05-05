namespace BattleShip;

public class TheBattle
{
    private OutPut output = new OutPut();
    public PlayerLayOut playerLayOut = new PlayerLayOut();
    public BotLayOut botLayOut = new BotLayOut();
    private bool _isGame;

    private char[,] hiddenField = new char[10, 10];
    private char _dot = '+';
    private char _shipPlace = 'Z';
    private char _nullPlace = '∙';

    public TheBattle()
    {
        for (int i = 0; i < hiddenField.GetLength(0); i++)
        {
            for (int j = 0; j < hiddenField.GetLength(1); j++)
            {
                hiddenField[i, j] = _nullPlace;
            }
        }
    }

    public void Game()
    {
        char explosionField = '?';
        _isGame = true;

        while (_isGame)
        {
            ConsoleKeyInfo pressedKey;
            int x = 4, y = 4;
            char value;
            bool badField = false;
            value = hiddenField[x, y];
            setDot(x, y);


            while (badField == false)
            {
                Console.Clear();
                output.Battlefield(playerLayOut.battleField, hiddenField);
                // output.Battlefield(botLayOut.battleField);
                output.rules2();

                pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (x > 0) { delDot(x--, y, value); value = hiddenField[x, y]; setDot(x, y); }
                        break;
                    case ConsoleKey.DownArrow:
                        if (x < 9) { delDot(x++, y, value); value = hiddenField[x, y]; setDot(x, y); }
                        break;
                    case ConsoleKey.RightArrow:
                        if (y < 9) { delDot(x, y++, value); value = hiddenField[x, y]; setDot(x, y); }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (y > 0) { delDot(x, y--, value); value = hiddenField[x, y]; setDot(x, y); }
                        break;
                    case ConsoleKey.Enter:
                        if (value == _nullPlace)
                        {
                            badField = true;
                            checkFieldbot(x, y, out explosionField);
                            hit(x, y, explosionField, hiddenField);
                            copyField();
                        }
                        break;
                }
            }

            if (explosionField == '?') botShot();
        }
    }

    private void hit(int x, int y, char explosionField, char[,] battleField) => battleField[x, y] = explosionField;

    private void setDot(int x, int y) => hiddenField[x, y] = _dot;

    private void delDot(int x, int y, char value) => hiddenField[x, y] = value;

    private void checkFieldbot(int x, int y, out char explosionField)
    {
        if (botLayOut.battleField[x, y] == _shipPlace)
        {
            explosionField = 'x';

            botLayOut.bot.singleShip1.CheckFieldShip(ref botLayOut.battleField, x, y);
            botLayOut.bot.singleShip2.CheckFieldShip(ref botLayOut.battleField, x, y);
            botLayOut.bot.singleShip3.CheckFieldShip(ref botLayOut.battleField, x, y);
            botLayOut.bot.singleShip4.CheckFieldShip(ref botLayOut.battleField, x, y);

            botLayOut.bot.doubleShip1.CheckFieldShip(ref botLayOut.battleField, x, y);
            botLayOut.bot.doubleShip2.CheckFieldShip(ref botLayOut.battleField, x, y);
            botLayOut.bot.doubleShip3.CheckFieldShip(ref botLayOut.battleField, x, y);

            botLayOut.bot.tripleShip1.CheckFieldShip(ref botLayOut.battleField, x, y);
            botLayOut.bot.tripleShip2.CheckFieldShip(ref botLayOut.battleField, x, y);

            botLayOut.bot.quadroShip.CheckFieldShip(ref botLayOut.battleField, x, y);

            FleetAlive();
        }
        else 
        {
            explosionField = '?';
        }
    }

    private void checkFieldPlayer(int x, int y, out char explosionField)
    {

        if (playerLayOut.battleField[x, y] == _shipPlace)
        {
            explosionField = 'x';

            playerLayOut.player.singleShip1.CheckFieldShip(ref playerLayOut.battleField, x, y);
            playerLayOut.player.singleShip2.CheckFieldShip(ref playerLayOut.battleField, x, y);
            playerLayOut.player.singleShip3.CheckFieldShip(ref playerLayOut.battleField, x, y);
            playerLayOut.player.singleShip4.CheckFieldShip(ref playerLayOut.battleField, x, y);

            playerLayOut.player.doubleShip1.CheckFieldShip(ref playerLayOut.battleField, x, y);
            playerLayOut.player.doubleShip2.CheckFieldShip(ref playerLayOut.battleField, x, y);
            playerLayOut.player.doubleShip3.CheckFieldShip(ref playerLayOut.battleField, x, y);

            playerLayOut.player.tripleShip1.CheckFieldShip(ref playerLayOut.battleField, x, y);
            playerLayOut.player.tripleShip2.CheckFieldShip(ref playerLayOut.battleField, x, y);

            playerLayOut.player.quadroShip.CheckFieldShip(ref playerLayOut.battleField, x, y);

            FleetAlive();
        }
        else
        {
            explosionField = '?';
            hit(x, y, explosionField, playerLayOut.battleField);
        }
    }

    private void copyField()
    {
        for (int i = 0; i < botLayOut.battleField.GetLength(0); i++)
        {
            for (int j = 0; j < botLayOut.battleField.GetLength(1); j++)
            {
                if (botLayOut.battleField[i, j] == '#') hiddenField[i, j] = '#';
                if (botLayOut.battleField[i, j] == '?') hiddenField[i, j] = '?';
            }
        }
    }

    private void botShot()
    {
        Random random = new Random();
        int x, y;
        char explosionField;

        while (true)
        {
            x = random.Next(10);
            y = random.Next(10);

            if (playerLayOut.battleField[x, y] == _nullPlace ||
                playerLayOut.battleField[x, y] == _shipPlace) break;
        }
        Thread.Sleep(400);
        checkFieldPlayer(x, y, out explosionField);

        if (explosionField == 'x') botShot();
    }

    private void FleetAlive()
    {
        if (playerLayOut.player.GetFleetShips() == 0)
        {
            Console.Clear();
            Console.WriteLine("Bot is Winning!");
            _isGame = false;
        }

        if (botLayOut.bot.GetFleetShips() == 0)
        {
            Console.Clear();
            Console.WriteLine("Player is Winning!");
            _isGame = false;
        }

    }
}