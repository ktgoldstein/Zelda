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

        public Texture2D ItemTextures;
        public ItemInterface CurrItem;

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
            ICommand setSpriteNonMovingNonAnimated = new SetSpriteNonMovingNonAnimated(this);
            ICommand setSpriteNonMovingAnimated = new SetSpriteNonMovingAnimated(this);
            ICommand setSpriteMovingNonAnimated = new SetSpriteMovingNonAnimated(this);
            ICommand setSpriteMovingAnimated = new SetSpriteMovingAnimated(this);

            KeyboardController keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.D0, quitGame);
            keyboardController.RegisterCommand(Keys.D1, setSpriteNonMovingNonAnimated);
            keyboardController.RegisterCommand(Keys.D2, setSpriteNonMovingAnimated);
            keyboardController.RegisterCommand(Keys.D3, setSpriteMovingNonAnimated);
            keyboardController.RegisterCommand(Keys.D4, setSpriteMovingAnimated);
            keyboardController.RegisterCommand(Keys.NumPad0, quitGame);
            keyboardController.RegisterCommand(Keys.NumPad1, setSpriteNonMovingNonAnimated);
            keyboardController.RegisterCommand(Keys.NumPad2, setSpriteNonMovingAnimated);
            keyboardController.RegisterCommand(Keys.NumPad3, setSpriteMovingNonAnimated);
            keyboardController.RegisterCommand(Keys.NumPad4, setSpriteMovingAnimated);

            MouseController mouseController = new MouseController(this);
            mouseController.RegisterCommand("rightClick", quitGame);
            mouseController.RegisterCommand("leftClick topLeft", setSpriteNonMovingNonAnimated);
            mouseController.RegisterCommand("leftClick topRight", setSpriteNonMovingAnimated);
            mouseController.RegisterCommand("leftClick bottomLeft", setSpriteMovingNonAnimated);
            mouseController.RegisterCommand("leftClick bottomRight", setSpriteMovingAnimated);

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

            // TODO: load/initialize text sprite
            LinkTextures = Content.Load<Texture2D>("ZoLSpriteSheet");
            SpriteLink = new NonMovingNonAnimatedSprite(LinkTextures);

            SpriteFont font = Content.Load<SpriteFont>("DefaultFont");
            string credits = "Credits\nProgram Made By: Simon Kirksey\nSprites from: spriters-resource.com/nes/legendofzelda/";
            SpriteCredits = new TextSprite(font, credits);

            /* Not currently working, fix later
             * ItemTextures = Content.Load<Texture2D>("ItemsSpriteSheet");
             * CurrItem = new Compass(ItemTextures);
            */
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

            SpriteCredits.Draw(_spriteBatch, new Vector2(GameWidth /10, GameHeight *2 /3));
            SpriteLink.Draw(_spriteBatch, new Vector2(GameWidth /2 -16, GameHeight /2 -16));

            /* Undo comment once texture load is working
             * CurrItem.Draw(_spriteBatch, new Vector2(GameWidth / 2, GameHeight / 2));
            */

            base.Draw(gameTime);
        }
    }
}
