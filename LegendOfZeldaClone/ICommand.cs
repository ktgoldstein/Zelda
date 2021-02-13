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
                myGame.switchEnemyNum %= 3;

            }
            else
            {
                this.myGame.switchEnemyNum--;
                if (myGame.switchEnemyNum == -1)
                {
                    myGame.switchEnemyNum = 2;
                }
            }

            // Draw correct enemy
            if (myGame.switchEnemyNum == 1)
            {
                myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Aquamentus();

            }
            else if (myGame.switchEnemyNum == 2)
            {
                myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Goriya();
            }
            else
            {
                myGame.SpriteEnemy = new LegendOfZeldaClone.Enemy.Stalfos();
            }

        }

    }
}

