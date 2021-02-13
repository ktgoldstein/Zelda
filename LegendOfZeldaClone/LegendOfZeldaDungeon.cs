using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZeldaClone
{

    public class LegendOfZeldaDungeon : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<IController> controllerList;

        public Texture2D LinkTextures;
        public ISprite SpriteLink;
        public ISprite SpriteCredits;
        public int GameWidth;
        public int GameHeight;

        public LegendOfZeldaDungeon()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = System.TimeSpan.FromSeconds(1d / 20d);

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameWidth = 512;
            GameHeight = 256;

            _graphics.PreferredBackBufferWidth = GameWidth;
            _graphics.PreferredBackBufferHeight = GameHeight;
            _graphics.ApplyChanges();

            ICommand quitGame = new QuitGame(this);

            KeyboardController keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.D0, quitGame);
            keyboardController.RegisterCommand(Keys.NumPad0, quitGame);

            MouseController mouseController = new MouseController(this);
            mouseController.RegisterCommand("rightClick", quitGame);

            controllerList = new List<IController>
            {
                keyboardController,
                mouseController
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            LinkTextures = Content.Load<Texture2D>("ZoLSpriteSheet");
    }

        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update();
            }

            SpriteLink.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            SpriteLink.Draw(_spriteBatch, new Vector2(GameWidth /2 -16, GameHeight /2 -16));

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
