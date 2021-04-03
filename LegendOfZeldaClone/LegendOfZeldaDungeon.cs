using LegendOfZeldaClone.Enemy;
using LegendOfZeldaClone.LevelLoading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LegendOfZeldaClone
{
    public class LegendOfZeldaDungeon : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IController controllerKeyboard;

        private GameStateMachine gameStateMachine;

        public IGameSound GameBackgroundMusic;
        public int MusicTimingHelperInt; //here for debugging purposes only; usually in gameStateMachine
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

            KeyboardController keyboardController = new KeyboardController();

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
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            ObjectSpriteFactory.Instance.LoadAllTextures(Content);
            GameSoundFactory.Instance.LoadAllSounds(Content);

            PlayerProjectileSpriteFactory.Instance.LoadAllTextures(Content);
            RoomTextureFactory.Instance.LoadAllTextures(Content);
            HUDTextureFactory.Instance.LoadAllTextures(Content);

            gameStateMachine.ResetPlayer();
            gameStateMachine.InitializeRooms();
            gameStateMachine.InitializeHUD();
            gameStateMachine.InitializeMusic();
           // GameBackgroundMusic = new DungeonThemeMusic();
          //  GameBackgroundMusic.Play();
            MusicTimingHelperInt = 0;
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
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

            gameStateMachine.Draw(_spriteBatch);                                   

            _spriteBatch.End();

            base.Draw(gameTime);
        }               
    }
}
