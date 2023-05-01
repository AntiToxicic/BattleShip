namespace BattleShip;

public class TheBattle
{
    private Draw _draw = new Draw();
    public PlayerGen PlayerGen = new PlayerGen();
    public BotGen BotGen = new BotGen();
    private bool _isGame;

    private char[,] hiddenField = new char[10,10];
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
                _draw.Battlefield(PlayerGen.battleField, hiddenField);
               // _draw.Battlefield(BotGen.battleField);
               _draw.rules2();

               pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (x > 0) {delDot(x--, y, value); value = hiddenField[x, y];setDot(x, y);}
                        break;
                    case ConsoleKey.DownArrow:
                        if (x < 9) {delDot(x++, y, value); value = hiddenField[x, y];setDot(x, y);}
                        break;
                    case ConsoleKey.RightArrow:
                        if (y < 9) {delDot(x, y++, value); value = hiddenField[x, y];setDot(x, y);}
                        break;
                    case ConsoleKey.LeftArrow:
                        if (y > 0) {delDot(x, y--, value); value = hiddenField[x, y];setDot(x, y);}
                        break;
                    case ConsoleKey.Enter:
                        if (value == _nullPlace)
                        {
                            badField = true;
                            checkFieldbot(x, y, out explosionField);
                            hit(x, y, explosionField,hiddenField);
                            copyField();
                        }
                        break;
                }
            }
            
            if(explosionField == '?')botShot();
        }
    }

    private void hit(int x,int y,char explosionField, char[,] battleField) => battleField[x, y] = explosionField;
    
    private void setDot(int x, int y) => hiddenField[x, y] = _dot;
    
    private void delDot(int x, int y,char value) => hiddenField[x, y] = value;

    private void checkFieldbot(int x, int y, out char explosionField)
    {
        if (BotGen.battleField[x, y] == _shipPlace)
        {
            explosionField = 'x';
            
            BotGen.bot.singleShip1.CheckFieldShip(ref BotGen.battleField, x,y);
            BotGen.bot.singleShip2.CheckFieldShip(ref BotGen.battleField, x,y);
            BotGen.bot.singleShip3.CheckFieldShip(ref BotGen.battleField, x,y);
            BotGen.bot.singleShip4.CheckFieldShip(ref BotGen.battleField, x,y);
            
            BotGen.bot.doubleShip1.CheckFieldShip(ref BotGen.battleField, x,y);
            BotGen.bot.doubleShip2.CheckFieldShip(ref BotGen.battleField, x,y);
            BotGen.bot.doubleShip3.CheckFieldShip(ref BotGen.battleField, x,y);
            
            BotGen.bot.tripleShip1.CheckFieldShip(ref BotGen.battleField, x,y);
            BotGen.bot.tripleShip2.CheckFieldShip(ref BotGen.battleField, x,y);
            
            BotGen.bot.quadroShip.CheckFieldShip(ref BotGen.battleField, x,y);
            
            FleetAlive();
        }
        else
        {
            explosionField = '?'; 
        }
    }
    
    private void checkFieldPlayer(int x, int y, out char explosionField)
    {
        
        if (PlayerGen.battleField[x, y] == _shipPlace)
        {
            explosionField = 'x';
            
            PlayerGen.player.singleShip1.CheckFieldShip(ref PlayerGen.battleField, x,y);
            PlayerGen.player.singleShip2.CheckFieldShip(ref PlayerGen.battleField, x,y);
            PlayerGen.player.singleShip3.CheckFieldShip(ref PlayerGen.battleField, x,y);
            PlayerGen.player.singleShip4.CheckFieldShip(ref PlayerGen.battleField, x,y);
            
            PlayerGen.player.doubleShip1.CheckFieldShip(ref PlayerGen.battleField, x,y);
            PlayerGen.player.doubleShip2.CheckFieldShip(ref PlayerGen.battleField, x,y);
            PlayerGen.player.doubleShip3.CheckFieldShip(ref PlayerGen.battleField, x,y);
            
            PlayerGen.player.tripleShip1.CheckFieldShip(ref PlayerGen.battleField, x,y);
            PlayerGen.player.tripleShip2.CheckFieldShip(ref PlayerGen.battleField, x,y);
            
            PlayerGen.player.quadroShip.CheckFieldShip(ref PlayerGen.battleField, x,y);
            
            FleetAlive();
        }
        else
        {
            explosionField = '?';
            hit(x, y, explosionField,PlayerGen.battleField);
        }
    }
    
    private void copyField()
    {
        for (int i = 0; i < BotGen.battleField.GetLength(0); i++)
        {
            for (int j = 0; j < BotGen.battleField.GetLength(1); j++)
            {
                if (BotGen.battleField[i, j] == '#') hiddenField[i, j] = '#';
                if (BotGen.battleField[i, j] == '?') hiddenField[i, j] = '?';
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

            if (PlayerGen.battleField[x,y] == _nullPlace ||
                PlayerGen.battleField[x,y] == _shipPlace) break;
        }
        Thread.Sleep(400);
        checkFieldPlayer(x, y, out explosionField);

        if(explosionField == 'x') botShot();
    }

    private void FleetAlive()
    {
        if (PlayerGen.player.fleetShips() == 0)
        {
            Console.Clear();
            Console.WriteLine("Bot is Winning!");
            _isGame = false;
        }
        
        if (BotGen.bot.fleetShips() == 0)
        {
            Console.Clear();
            Console.WriteLine("Player is Winning!");
            _isGame = false;
        }
        
    }
}