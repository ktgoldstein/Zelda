using LegendOfZeldaClone.Enemy;
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
        public List<IEnemy> enemyList;

        public Texture2D LinkTextures;
        public ISprite SpriteLink;
        public ISprite SpriteCredits;

        public int switchEnemyNum;
        public IEnemy SpriteEnemy;

        

        public int GameWidth;
        public int GameHeight;

        public Texture2D ItemTextures;
        public ItemInterface[] Items;
        public ItemInterface CurrItem;
        public int ItemIndex;

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
            LoadContent();

            GameWidth = 512*2;
            GameHeight = 256*2;
            switchEnemyNum = 0;

            _graphics.PreferredBackBufferWidth = GameWidth;
            _graphics.PreferredBackBufferHeight = GameHeight;
            _graphics.ApplyChanges();

            ICommand quitGame = new QuitGame(this);
            ICommand setSpriteNonMovingNonAnimated = new SetSpriteNonMovingNonAnimated(this);
            ICommand setSpriteNonMovingAnimated = new SetSpriteNonMovingAnimated(this);
            ICommand setSpriteMovingNonAnimated = new SetSpriteMovingNonAnimated(this);
            ICommand setSpriteMovingAnimated = new SetSpriteMovingAnimated(this);
            ICommand setSpriteEnemy = new SetSpriteEnemy(this);
            ICommand nextItem = new NextItem(this);
            ICommand prevItem = new PreviousItem(this);


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
            keyboardController.RegisterCommand(Keys.I, nextItem);
            keyboardController.RegisterCommand(Keys.U, prevItem);
            keyboardController.RegisterCommand(Keys.P, setSpriteEnemy);
            keyboardController.RegisterCommand(Keys.O, setSpriteEnemy);

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

            enemyList = new List<IEnemy>
            {
                new Aquamentus(),
                new Goriya(),
                new Stalfos(),
                new BladeTrap(),
                new Gel(),
                new Keese(),
                new Wallmaster()
            };

            ItemIndex = 0;
            Items = new ItemInterface[20];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            LinkTextures = Content.Load<Texture2D>("ZoLSpriteSheet");
            SpriteLink = new NonMovingNonAnimatedSprite(LinkTextures);

            SpriteFont font = Content.Load<SpriteFont>("DefaultFont");
            string credits = "Credits\nProgram Made By: Simon Kirksey\nSprites from: spriters-resource.com/nes/legendofzelda/";
            SpriteCredits = new TextSprite(font, credits);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            SpriteEnemy = new Stalfos();

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            Items[0] = ItemSpriteFactory.Instance.CreateCompass();
            Items[1] = ItemSpriteFactory.Instance.CreateKey();
            Items[2] = ItemSpriteFactory.Instance.CreateBoomerang();
            Items[3] = ItemSpriteFactory.Instance.CreateBow();
            Items[4] = ItemSpriteFactory.Instance.CreateHeart();
            Items[5] = ItemSpriteFactory.Instance.CreateRupee();
            Items[6] = ItemSpriteFactory.Instance.CreateArrow();
            Items[7] = ItemSpriteFactory.Instance.CreateBomb();
            Items[8] = ItemSpriteFactory.Instance.CreateFairy();
            Items[9] = ItemSpriteFactory.Instance.CreateClock();
            Items[10] = ItemSpriteFactory.Instance.CreateTriforcePiece();
            Items[11] = ItemSpriteFactory.Instance.CreateHeartContainer();
            Items[12] = ItemSpriteFactory.Instance.CreateMap();
            Items[13] = ItemSpriteFactory.Instance.CreatePotion();
            Items[14] = ItemSpriteFactory.Instance.CreateSword();
            Items[15] = ItemSpriteFactory.Instance.CreateShield();
            Items[16] = ItemSpriteFactory.Instance.CreateCandle();
            Items[17] = ItemSpriteFactory.Instance.CreateRing();
            Items[18] = ItemSpriteFactory.Instance.CreateStaff();
            Items[19] = ItemSpriteFactory.Instance.CreateBook();
            CurrItem = Items[0];
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update();
            }

            SpriteLink.Update();
            SpriteEnemy.Update();

            CurrItem.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteCredits.Draw(_spriteBatch, new Vector2(GameWidth /10, GameHeight *2 /3));
            SpriteLink.Draw(_spriteBatch, new Vector2(GameWidth /2 -16, GameHeight /2 -16));
            SpriteEnemy.Draw(_spriteBatch);

    

            CurrItem.Draw(_spriteBatch, new Vector2(GameWidth / 2 + 32, GameHeight / 2));

            base.Draw(gameTime);
        }
    }
}
