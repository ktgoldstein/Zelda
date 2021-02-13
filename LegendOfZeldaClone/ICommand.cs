using Microsoft.Xna.Framework;

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

    public class PreviousItem : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public PreviousItem(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.index == 0)
            {
                myGame.CurrItem = myGame.Items[myGame.Items.Length - 1];
            }
            else
            {
                myGame.CurrItem = myGame.Items[myGame.index - 1];
            }
        }
    }

    public class NextItem : ICommand
    {
        private LegendOfZeldaDungeon myGame;

        public NextItem(LegendOfZeldaDungeon game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.index == myGame.Items.Length - 1)
            {
                myGame.CurrItem = myGame.Items[0];
            }
            else
            {
                myGame.CurrItem = myGame.Items[myGame.index + 1];
            }
        }
    }
}
