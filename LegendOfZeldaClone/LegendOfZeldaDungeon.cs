using LegendOfZeldaClone.Enemy;
using LegendOfZeldaClone.LevelLoading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LegendOfZeldaClone
{
    public class LegendOfZeldaDungeon : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _SpriteBatch;

        private IController controllerKeyboard;

        private GameStateMachine gameStateMachine;

        public IGameSound GameBackgroundMusic;

        private Texture2D blackBackground;

        public LegendOfZeldaDungeon()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 20d);

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = LoZHelpers.GameWidth;
            _graphics.PreferredBackBufferHeight = LoZHelpers.GameHeight;
            
            _graphics.ApplyChanges();

            gameStateMachine = new GameStateMachine();

            ICommand quitGame = new QuitGame(this);
            ICommand moveDown = new MoveDown(gameStateMachine);
            ICommand moveUp = new MoveUp(gameStateMachine);
            ICommand moveLeft = new MoveLeft(gameStateMachine);
            ICommand moveRight = new MoveRight(gameStateMachine);
            ICommand actionA = new ActionA(gameStateMachine);
            ICommand actionB = new ActionB(gameStateMachine);
            ICommand damageLink = new DamageLink(gameStateMachine);

            ICommand resetGame = new ResetGame(gameStateMachine);

            ICommand moveRoomDown = new MoveRoomDown(gameStateMachine);
            ICommand moveRoomUp = new MoveRoomUp(gameStateMachine);
            ICommand moveRoomLeft = new MoveRoomLeft(gameStateMachine);
            ICommand moveRoomRight = new MoveRoomRight(gameStateMachine);
            ICommand pauseGame = new PauseGame(gameStateMachine);
            ICommand selectItem = new SelectItem(gameStateMachine);

            KeyboardController keyboardController = new KeyboardController(gameStateMachine);

            keyboardController.RegisterCommand(Keys.Q, quitGame);
            keyboardController.RegisterCommand(Keys.S, moveDown);
            keyboardController.RegisterCommand(Keys.W, moveUp);
            keyboardController.RegisterCommand(Keys.A, moveLeft);
            keyboardController.RegisterCommand(Keys.D, moveRight);
            keyboardController.RegisterCommand(Keys.Down, moveDown);
            keyboardController.RegisterCommand(Keys.Up, moveUp);
            keyboardController.RegisterCommand(Keys.Left, moveLeft);
            keyboardController.RegisterCommand(Keys.Right, moveRight);
            keyboardController.RegisterCommand(Keys.Z, actionA);
            keyboardController.RegisterCommand(Keys.N, actionA);
            keyboardController.RegisterCommand(Keys.X, actionB);
            keyboardController.RegisterCommand(Keys.M, actionB);
            keyboardController.RegisterCommand(Keys.E, damageLink);

            keyboardController.RegisterCommand(Keys.R, resetGame);

            keyboardController.RegisterCommand(Keys.K, moveRoomDown);
            keyboardController.RegisterCommand(Keys.I, moveRoomUp);
            keyboardController.RegisterCommand(Keys.J, moveRoomLeft);
            keyboardController.RegisterCommand(Keys.L, moveRoomRight);
            keyboardController.RegisterCommand(Keys.P, pauseGame);
            keyboardController.RegisterCommand(Keys.Enter, selectItem);

            controllerKeyboard = keyboardController;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _SpriteBatch = new SpriteBatch(_graphics.GraphicsDevice);

            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            GameSoundFactory.Instance.LoadAllSounds(Content);

            PlayerProjectileSpriteFactory.Instance.LoadAllTextures(Content);
            RoomTextureFactory.Instance.LoadAllTextures(Content);
            ShopSpriteFactory.Instance.LoadAllTextures(Content);
            HUDTextureFactory.Instance.LoadAllTextures(Content);

            blackBackground = Content.Load<Texture2D>("BackgroundFix");

            gameStateMachine.ResetPlayer();
            gameStateMachine.InitializeRooms();
            gameStateMachine.InitializeHUD();
            gameStateMachine.InitializeMusic();
            gameStateMachine.GameOverTexture = Content.Load<Texture2D>("gameScreenFilter");
        }

        protected override void Update(GameTime gameTime)
        {        
            controllerKeyboard.Update();

            gameStateMachine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Viewport startingViewport = _graphics.GraphicsDevice.Viewport;
            Viewport bottomViewport = startingViewport;

            bottomViewport.Y = LoZHelpers.HUDHeight;
            _graphics.GraphicsDevice.Viewport = bottomViewport;

            _SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                null, null, null, null, gameStateMachine.RoomCamera.Translation());
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

            gameStateMachine.RoomDraw(_SpriteBatch);
            _SpriteBatch.End();

            _graphics.GraphicsDevice.Viewport = startingViewport;

            _SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                null, null, null, null, gameStateMachine.MenuCamera.Translation());
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

            _SpriteBatch.Draw(blackBackground, new Rectangle(0, LoZHelpers.HUDHeight - LoZHelpers.GameHeight, LoZHelpers.GameWidth, LoZHelpers.GameHeight), Color.White);

            gameStateMachine.HUDDraw(_SpriteBatch);
            _SpriteBatch.End();

            base.Draw(gameTime);
        }               
    }
}
