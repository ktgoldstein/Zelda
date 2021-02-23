using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace LegendOfZeldaClone
{
    public class LegendOfZeldaDungeon : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IController controller;

        public Texture2D LinkTextures;

        public int currentEnemyIndex;
        public IEnemy SpriteEnemy;
        public List<IEnemy> enemyList;

        public IPlayer Link;
        public List<IPlayerProjectile> LinkProjectilesQueue;
        public List<IPlayerProjectile> LinkProjectiles;

        public List<ISprite> Objects;
        public ISprite CurrentObject;
        public int ObjectIndex;

        public Texture2D ItemTextures;
        public ISprite[] Items;
        public ISprite CurrItem;
        public int itemIndex;
        public Vector2 itemVector;
        public int xDirection;
        public int yDirection;
        public ISprite fairy;

        public int SwitchEnemyDelay;
        public int SwitchObjectDelay;
        public int SwitchItemDelay;
        public int SwitchDelayLength = 5;

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
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            _graphics.PreferredBackBufferWidth = LoZHelpers.GameWidth;
            _graphics.PreferredBackBufferHeight = LoZHelpers.GameHeight;
            _graphics.ApplyChanges();

            ICommand quitGame = new QuitGame(this);
            ICommand moveDown = new MoveDown(this);
            ICommand moveUp = new MoveUp(this);
            ICommand moveLeft = new MoveLeft(this);
            ICommand moveRight = new MoveRight(this);
            ICommand actionA = new ActionA(this);
            ICommand damageLink = new DamageLink(this);
            ICommand useBow = new UseBow(this, ArrowSkinType.Wooden);
            ICommand useSilverBow = new UseBow(this, ArrowSkinType.Silver);
            ICommand useBoomerang = new UseBoomerang(this, BoomerangSkinType.Normal);
            ICommand useMagicalBoomerang = new UseBoomerang(this, BoomerangSkinType.Magical);
            ICommand useBomb = new UseBomb(this);
            ICommand useBlueCandle = new UseBlueCandle(this);
            ICommand pickUpBlueRing = new PickUpBlueRing(this);
            
            ICommand resetGame = new ResetGame(this);

            ICommand nextItem = new NextItem(this);
            ICommand prevItem = new PreviousItem(this);
            ICommand nextObject = new NextObject(this);
            ICommand previousObject = new PreviousObject(this);

            ICommand previousEnemy = new PreviousEnemy(this);
            ICommand nextEnemy = new NextEnemy(this);

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
            keyboardController.RegisterCommand(Keys.E, damageLink);
            keyboardController.RegisterCommand(Keys.D1, useBow);
            keyboardController.RegisterCommand(Keys.D2, useSilverBow);
            keyboardController.RegisterCommand(Keys.D3, useBoomerang);
            keyboardController.RegisterCommand(Keys.D4, useMagicalBoomerang);
            keyboardController.RegisterCommand(Keys.D5, useBomb);
            keyboardController.RegisterCommand(Keys.D6, useBlueCandle);
            keyboardController.RegisterCommand(Keys.D7, pickUpBlueRing);
            keyboardController.RegisterCommand(Keys.NumPad1, useBow);
            keyboardController.RegisterCommand(Keys.NumPad2, useSilverBow);
            keyboardController.RegisterCommand(Keys.NumPad3, useBoomerang);
            keyboardController.RegisterCommand(Keys.NumPad4, useMagicalBoomerang);
            keyboardController.RegisterCommand(Keys.NumPad5, useBomb);
            keyboardController.RegisterCommand(Keys.NumPad6, useBlueCandle);
            keyboardController.RegisterCommand(Keys.NumPad7, pickUpBlueRing);

            keyboardController.RegisterCommand(Keys.R, resetGame);

            keyboardController.RegisterCommand(Keys.I, nextItem);
            keyboardController.RegisterCommand(Keys.U, prevItem);

            keyboardController.RegisterCommand(Keys.P, nextEnemy);
            keyboardController.RegisterCommand(Keys.O, previousEnemy);

            keyboardController.RegisterCommand(Keys.Y, nextObject);
            keyboardController.RegisterCommand(Keys.T, previousObject);

            controller = keyboardController;

            currentEnemyIndex = 0;
            enemyList = new List<IEnemy>();

            itemIndex = 0;
            Items = new ISprite[24];
            itemVector = new Vector2(LoZHelpers.GameWidth / 2 + 32, LoZHelpers.GameHeight / 2);
            xDirection = 1;
            yDirection = 1;

            ObjectIndex = 0;
            Objects = new List<ISprite>();

            SwitchEnemyDelay = 0;
            SwitchItemDelay = 0;
            SwitchObjectDelay = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            PlayerProjectileSpriteFactory.Instance.LoadAllTextures(Content);

            LinkProjectilesQueue = new List<IPlayerProjectile>();
            LinkProjectiles = new List<IPlayerProjectile>();
            IUsableItem woodenSword = new UsableWoodenSword(this);
            Link = new LinkPlayer(this, LoZHelpers.LinkStartingLocation, woodenSword);

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            enemyList = new List<IEnemy>()
            {
               new Aquamentus(LoZHelpers.EnemyStartingLocation),
               new Goriya(LoZHelpers.EnemyStartingLocation),
               new Stalfos(LoZHelpers.EnemyStartingLocation),
               new BladeTrap(LoZHelpers.EnemyStartingLocation),
               new Gel(LoZHelpers.EnemyStartingLocation),
               new Keese(LoZHelpers.EnemyStartingLocation),
               new Wallmaster(LoZHelpers.EnemyStartingLocation)
            };

            ObjectSpriteFactory.Instance.LoadAllTextures(Content);

            Objects.Add(ObjectSpriteFactory.Instance.CreateFlatBlock());
            Objects.Add(ObjectSpriteFactory.Instance.CreateRaisedBlock());
            Objects.Add(ObjectSpriteFactory.Instance.CreateRaisedBlock());
            Objects.Add(ObjectSpriteFactory.Instance.CreateDragonStatue());
            Objects.Add(ObjectSpriteFactory.Instance.CreateGargoyleStatue());
            Objects.Add(ObjectSpriteFactory.Instance.CreateDragonStatueBlue());
            Objects.Add(ObjectSpriteFactory.Instance.CreateGargoyleStatueBlue());
            Objects.Add(ObjectSpriteFactory.Instance.CreateDottedBlock());
            Objects.Add(ObjectSpriteFactory.Instance.CreateStairs());
            Objects.Add(ObjectSpriteFactory.Instance.CreateDarkBlock());
            Objects.Add(ObjectSpriteFactory.Instance.CreateWater());
            Objects.Add(ObjectSpriteFactory.Instance.CreateTunnelOpeningUp());
            Objects.Add(ObjectSpriteFactory.Instance.CreateTunnelOpeningDown());
            Objects.Add(ObjectSpriteFactory.Instance.CreateKeyDoorUp());
            Objects.Add(ObjectSpriteFactory.Instance.CreateKeyDoorDown());
            Objects.Add(ObjectSpriteFactory.Instance.CreatekeyDoorRight());
            Objects.Add(ObjectSpriteFactory.Instance.CreatekeyDoorLeft());
            Objects.Add(ObjectSpriteFactory.Instance.CreatelockedDoorUp());
            Objects.Add(ObjectSpriteFactory.Instance.CreatelockedDoorDown());
            Objects.Add(ObjectSpriteFactory.Instance.CreatelockedDoorRight());
            Objects.Add(ObjectSpriteFactory.Instance.CreatelockedDoorLeft());
            Objects.Add(ObjectSpriteFactory.Instance.CreateOpenDoorUp());
            Objects.Add(ObjectSpriteFactory.Instance.CreateOpenDoorDown());
            Objects.Add(ObjectSpriteFactory.Instance.CreateOpenDoorRight());
            Objects.Add(ObjectSpriteFactory.Instance.CreateOpenDoorLeft());

            CurrentObject = Objects[0];

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
            if (SwitchObjectDelay > 0)
                SwitchObjectDelay--;
            if (SwitchItemDelay > 0)
                SwitchItemDelay--;
            if (SwitchEnemyDelay > 0)
                SwitchEnemyDelay--;

            controller.Update();

            Link.Update();

            List<IPlayerProjectile> deadProjectiles = new List<IPlayerProjectile>();
            LinkProjectiles.AddRange(LinkProjectilesQueue);
            LinkProjectilesQueue.Clear();
            foreach (IPlayerProjectile projectile in LinkProjectiles)
            {
                if (projectile.Update())
                    deadProjectiles.Add(projectile);
            }
            LinkProjectiles = LinkProjectiles.Except(deadProjectiles).ToList();

            enemyList[currentEnemyIndex].Update();

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
            else
            {
                itemVector = new Vector2(LoZHelpers.GameWidth / 2 + 32, LoZHelpers.GameHeight / 2);
            }
            CurrItem.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (IPlayerProjectile projectile in LinkProjectiles)
                projectile.Draw(_spriteBatch);

            Link.Draw(_spriteBatch);

            enemyList[currentEnemyIndex].Draw(_spriteBatch);
            CurrItem.Draw(_spriteBatch, itemVector);

            CurrentObject.Draw(_spriteBatch, new Vector2(LoZHelpers.GameWidth / 2 + 50, LoZHelpers.GameHeight * 2 / 6));

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}