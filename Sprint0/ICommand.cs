using Microsoft.Xna.Framework;

namespace Sprint0
{
    public interface ICommand
    {
        void Execute();
    }

    public class QuitGame : ICommand
    {
        private LegendOfZeldaClone myGame;

        public QuitGame(LegendOfZeldaClone game)
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
        private LegendOfZeldaClone myGame;

        public SetSpriteNonMovingNonAnimated(LegendOfZeldaClone game)
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
        private LegendOfZeldaClone myGame;

        public SetSpriteNonMovingAnimated(LegendOfZeldaClone game)
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
        private LegendOfZeldaClone myGame;

        public SetSpriteMovingNonAnimated(LegendOfZeldaClone game)
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
        private LegendOfZeldaClone myGame;

        public SetSpriteMovingAnimated(LegendOfZeldaClone game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.SpriteLink = new MovingAnimatedSprite(myGame.LinkTextures, myGame.GameWidth);
        }
    }
}
