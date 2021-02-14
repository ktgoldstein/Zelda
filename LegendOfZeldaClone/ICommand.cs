using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZeldaClone
{
    public interface ICommand
    {
        void Execute();
    }

    public class QuitGame : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public QuitGame(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }

    public class SetSpriteNonMovingNonAnimated : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public SetSpriteNonMovingNonAnimated(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.SpriteLink = new NonMovingNonAnimatedSprite(myGame.LinkTextures);
        }
    }

    public class SetSpriteNonMovingAnimated : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public SetSpriteNonMovingAnimated(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.SpriteLink = new NonMovingAnimatedSprite(myGame.LinkTextures);
        }
    }

    public class SetSpriteMovingNonAnimated : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public SetSpriteMovingNonAnimated(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.SpriteLink = new MovingNonAnimatedSprite(myGame.LinkTextures);
        }
    }

    public class SetSpriteMovingAnimated : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public SetSpriteMovingAnimated(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.SpriteLink = new MovingAnimatedSprite(myGame.LinkTextures, myGame.GameWidth);
        }
    }

    public class SetSpriteEnemy : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public SetSpriteEnemy(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            // Cycle counter
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                myGame.switchEnemyNum++;
                myGame.switchEnemyNum %= 7;

            }
            else
            {
                this.myGame.switchEnemyNum--;
                if (myGame.switchEnemyNum == -1)
                {
                    myGame.switchEnemyNum = 6;
                }
            }

            int pickSprite = myGame.switchEnemyNum;
            switch (pickSprite)
            {
                case 1:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Aquamentus();
                        break;
                    }
                case 2:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Goriya();
                        break;
                    }
                case 3:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.BladeTrap();
                        break;
                    }
                case 4:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Keese();
                        break;
                    }
                case 5:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Gel();
                        break;
                    }
                case 6:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Wallmaster();
                        break;
                    }
                default:
                    {
                        myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Stalfos();
                        break;
                    }
            }

        }

    }
}

