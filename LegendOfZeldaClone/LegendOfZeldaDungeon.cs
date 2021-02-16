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

        private IController controller;
        public List<IEnemy> enemyList;

        public Texture2D LinkTextures;

        public int switchEnemyNum;
        public IEnemy SpriteEnemy;
        public IPlayer Link;

        public List<ISprite> objList;
        public ISprite currentObject;

        public Texture2D ItemTextures;
        public ISprite[] Items;
        public ISprite CurrItem;
        public int itemIndex;
        public Vector2 itemVector;
        public int xDirection;
        public int yDirection;
        public ISprite fairy;

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
            _graphics.PreferredBackBufferWidth = LoZHelpers.GameWidth;
            _graphics.PreferredBackBufferHeight = LoZHelpers.GameHeight;
            _graphics.ApplyChanges();

            ICommand quitGame = new QuitGame(this);
            ICommand moveDown = new MoveDown(this);
            ICommand moveUp = new MoveUp(this);
            ICommand moveLeft = new MoveLeft(this);
            ICommand moveRight = new MoveRight(this);
            ICommand actionA = new ActionA(this);
            ICommand actionB = new ActionB(this);
            ICommand pickUpBlueRing = new PickUpBlueRing(this);
            ICommand resetLink = new ResetLink(this);
            
            ICommand setSpriteEnemy = new SetSpriteEnemy(this);
            ICommand nextItem = new NextItem(this);
            ICommand prevItem = new PreviousItem(this);
            ICommand nextObject = new NextObject(this);
            ICommand previousObject = new PreviousObject(this);

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
            keyboardController.RegisterCommand(Keys.D6, pickUpBlueRing);
            keyboardController.RegisterCommand(Keys.NumPad6, pickUpBlueRing);
            keyboardController.RegisterCommand(Keys.R, resetLink);
            
            keyboardController.RegisterCommand(Keys.I, nextItem);
            keyboardController.RegisterCommand(Keys.U, prevItem);
            keyboardController.RegisterCommand(Keys.P, setSpriteEnemy);
            keyboardController.RegisterCommand(Keys.O, setSpriteEnemy);
            keyboardController.RegisterCommand(Keys.Y, nextObject);
            keyboardController.RegisterCommand(Keys.T, previousObject);

            controller = keyboardController;

            switchEnemyNum = 0;
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

            itemIndex = 0;
            Items = new ISprite[24];
            itemVector = new Vector2(LoZHelpers.GameWidth / 2 + 32, LoZHelpers.GameHeight / 2);
            xDirection = 1;
            yDirection = 1;

            objList = new List<ISprite>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            LinkSpriteFactory.Instance.LoadAllTextures(Content);

            Link = new LinkPlayer(this, LoZHelpers.LinkStartingLocation);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            SpriteEnemy = new Stalfos();

            ObjectSpriteFactory.Instance.LoadAllTextures(Content);
            currentObject = ObjectSpriteFactory.Instance.CreatedefaultFlatBlock();
            objList.Add(ObjectSpriteFactory.Instance.CreateflatBlock());
            objList.Add(ObjectSpriteFactory.Instance.CreateraisedBlock());
            objList.Add(ObjectSpriteFactory.Instance.CreateraisedBlock());
            objList.Add(ObjectSpriteFactory.Instance.Createstatue());
            objList.Add(ObjectSpriteFactory.Instance.Createstatue2());
            objList.Add(ObjectSpriteFactory.Instance.CreateblueStatue());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreateblueStatue2());
            //spriteObject.Add(ObjectSpriteFactory.Instance.Createsand());
            //spriteObject.Add(ObjectSpriteFactory.Instance.Createstairs());
            //spriteObject.Add(ObjectSpriteFactory.Instance.Createwater());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreatekeyDoorUp());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreatekeyDoorDown());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreatekeyDoorLeft());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreatekeyDoorRight());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreatelockedDoorUp());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreatelockedDoorDown());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreatelockedDoorLeft());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreatelockedDoorRight());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreateopenDoorUp());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreateopenDoorDown());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreateopenDoorLeft());
            //spriteObject.Add(ObjectSpriteFactory.Instance.CreateopenDoorRight());

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            Items[0] = ItemSpriteFactory.Instance.CreateCompass();
            Items[1] = ItemSpriteFactory.Instance.CreateKey();
            Items[2] = ItemSpriteFactory.Instance.CreateBoomerang();
            Items[3] = ItemSpriteFactory.Instance.CreateBow();
            Items[4] = ItemSpriteFactory.Instance.CreateHeart();
            Items[5] = ItemSpriteFactory.Instance.CreateFlashingRupee();
            Items[6] = ItemSpriteFactory.Instance.CreateArrow();
            Items[7] = ItemSpriteFactory.Instance.CreateBomb();
            Items[8] = ItemSpriteFactory.Instance.CreateFairy();
            Items[9] = ItemSpriteFactory.Instance.CreateClock();
            Items[10] = ItemSpriteFactory.Instance.CreateTriforcePiece();
            Items[11] = ItemSpriteFactory.Instance.CreateHeartContainer();
            Items[12] = ItemSpriteFactory.Instance.CreateMap();
            Items[13] = ItemSpriteFactory.Instance.CreateSword();
            Items[14] = ItemSpriteFactory.Instance.CreateMagicalKey();
            Items[15] = ItemSpriteFactory.Instance.CreateFullHealthHeart();
            Items[16] = ItemSpriteFactory.Instance.CreateHalfHealthHeart();
            Items[17] = ItemSpriteFactory.Instance.CreateNoHealthHeart();
            Items[18] = ItemSpriteFactory.Instance.CreateGoldRupee();
            Items[19] = ItemSpriteFactory.Instance.CreateBlueRupee();
            Items[20] = ItemSpriteFactory.Instance.CreateSilverArrow();
            Items[21] = ItemSpriteFactory.Instance.CreateLifePotion();
            Items[22] = ItemSpriteFactory.Instance.CreateBlueCandle();
            Items[23] = ItemSpriteFactory.Instance.CreateBlueRing();
            CurrItem = Items[0];
            fairy = Items[8];
        }

        protected override void Update(GameTime gameTime)
        {
            controller.Update();
            
            Link.Update();
            
            SpriteEnemy.Update();

            if (CurrItem == fairy)
            {
                itemVector.Y += 2 * yDirection;
                itemVector.X += 2 * xDirection;
                if (itemVector.Y > (LoZHelpers.GameHeight / 2 + 30))
                {
                    yDirection = -1;
                }
                if (itemVector.Y < (LoZHelpers.GameHeight / 2 - 30))
                {
                    yDirection = 1;
                }
                if (itemVector.X > (LoZHelpers.GameWidth / 2 + 50))
                {
                    xDirection = -1;
                }
                if (itemVector.X < (LoZHelpers.GameWidth / 2 - 50))
                {
                    xDirection = 1;
                }
            }
            CurrItem.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            Link.Draw(_spriteBatch);
            SpriteEnemy.Draw(_spriteBatch);
            CurrItem.Draw(_spriteBatch, itemVector);

            currentObject.Draw(_spriteBatch, new Vector2(LoZHelpers.GameWidth / 2 + 50, LoZHelpers.GameHeight * 2 / 6));

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
