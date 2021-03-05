using LegendOfZeldaClone.Enemy;
using LegendOfZeldaClone.Objects;
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
        public List<IEnemy> enemyList;
        public List<IEnemyProjectile> EnemyProjectilesQueue;
        public List<IEnemyProjectile> EnemyProjectiles;

        public IPlayer Link;
        public List<IPlayerProjectile> LinkProjectilesQueue;
        public List<IPlayerProjectile> LinkProjectiles;

        public List<IObject> Objects;
        public IObject CurrentObject;
        public int ObjectIndex;

        public Texture2D ItemTextures;
        public List<IItem> Items;
        public int itemIndex;
        public Vector2 itemVector;

        public int SwitchEnemyDelay;
        public int SwitchObjectDelay;
        public int SwitchItemDelay;
        public int SwitchDelayLength = 5;

        public LegendOfZeldaDungeon()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = true;
            TargetElapsedTime = System.TimeSpan.FromSeconds(1d / 20d);

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
            Items = new List<IItem>();
            itemVector = new Vector2(LoZHelpers.GameWidth / 2 + 32, LoZHelpers.GameHeight / 2);

            ObjectIndex = 0;
            Objects = new List<IObject>();

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

            EnemyProjectilesQueue = new List<IEnemyProjectile>();
            EnemyProjectiles = new List<IEnemyProjectile>();
            enemyList = new List<IEnemy>()
            {
               new Aquamentus(this, LoZHelpers.EnemyStartingLocation),
               new Goriya(this, LoZHelpers.EnemyStartingLocation),
               new Stalfos(LoZHelpers.EnemyStartingLocation),
               new BladeTrap(LoZHelpers.EnemyStartingLocation),
               new Gel(LoZHelpers.EnemyStartingLocation),
               new Keese(LoZHelpers.EnemyStartingLocation),
               new Wallmaster(LoZHelpers.EnemyStartingLocation)
            };

            ObjectSpriteFactory.Instance.LoadAllTextures(Content);

            Objects.Add(new FlatBlock(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new RaisedBlock(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new DragonStatue(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new GargoyleStatue(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new BlueDragonStatue(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new BlueGargoyleStatue(LoZHelpers.ObjectStartingLocation)); 
            Objects.Add(new DottedBlock(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new Stairs(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new DarkBlock(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new Water(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new TunnelFaceUp(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new TunnelFaceDown(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new KeyDoorUp(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new KeyDoorDown(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new KeyDoorRight(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new KeyDoorLeft(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new LockedDoorUp(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new LockedDoorDown(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new LockedDoorRight(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new LockedDoorLeft(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new OpenDoorUp(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new OpenDoorDown(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new OpenDoorRight(LoZHelpers.ObjectStartingLocation));
            Objects.Add(new OpenDoorLeft(LoZHelpers.ObjectStartingLocation));

            CurrentObject = Objects[0];

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            Items.Add(new Compass(itemVector));
            Items.Add(new Key(itemVector));
            Items.Add(new Boomerang(itemVector));
            Items.Add(new Bow(itemVector));
            Items.Add(new Heart(itemVector));
            Items.Add(new FlashingRupee(itemVector));
            Items.Add(new Arrow(itemVector));
            Items.Add(new Bomb(itemVector));
            Items.Add(new Fairy(itemVector));
            Items.Add(new Clock(itemVector));
            Items.Add(new TriForcePiece(itemVector));
            Items.Add(new HeartContainer(itemVector));
            Items.Add(new Map(itemVector));
            Items.Add(new Sword(itemVector));
            Items.Add(new MagicalKey(itemVector));
            Items.Add(new FullHealthHeart(itemVector));
            Items.Add(new HalfHealthHeart(itemVector));
            Items.Add(new NoHealthHeart(itemVector));
            Items.Add(new GoldRupee(itemVector));
            Items.Add(new BlueRupee(itemVector));
            Items.Add(new SilverArrow(itemVector));
            Items.Add(new LifePotion(itemVector));
            Items.Add(new BlueCandle(itemVector));
            Items.Add(new BlueRing(itemVector));
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

            List<IPlayerProjectile> deadLinkProjectiles = new List<IPlayerProjectile>();
            LinkProjectiles.AddRange(LinkProjectilesQueue);
            LinkProjectilesQueue.Clear();
            foreach (IPlayerProjectile projectile in LinkProjectiles)
            {
                projectile.Update();
                if (!projectile.Alive)
                    deadLinkProjectiles.Add(projectile);
            }
            LinkProjectiles = LinkProjectiles.Except(deadLinkProjectiles).ToList();

            enemyList[currentEnemyIndex].Update();

            List<IEnemyProjectile> deadEnemyProjectiles = new List<IEnemyProjectile>();
            EnemyProjectiles.AddRange(EnemyProjectilesQueue);
            EnemyProjectilesQueue.Clear();
            foreach (IEnemyProjectile projectile in EnemyProjectiles)
            {
                projectile.Update();
                if (!projectile.Alive)
                    deadEnemyProjectiles.Add(projectile);
            }
            EnemyProjectiles = EnemyProjectiles.Except(deadEnemyProjectiles).ToList();

            List<IItem> deadItems = new List<IItem>();
            foreach(IItem item in Items)
            {
                item.Update();
                if (!item.Alive)
                {
                    deadItems.Add(item);
                }
            }
            Items = Items.Except(deadItems).ToList();

            Direction collisionDirection = Collisions.CollisionDetection.DetectCollisionDirection(Link.HurtBoxLocation, Link.Width, Link.Height, 
                enemyList[currentEnemyIndex].Location, enemyList[currentEnemyIndex].Width, enemyList[currentEnemyIndex].Height);
            Link.Location += collisionDirection switch
            {
                Direction.Down => new Vector2(0, -Link.Speed * 20),
                Direction.Up => new Vector2(0, Link.Speed * 20),
                Direction.Left => new Vector2(Link.Speed * 20, 0),
                Direction.Right => new Vector2(-Link.Speed * 20, 0),
                _ => new Vector2()
            };

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

            foreach (IEnemyProjectile projectile in EnemyProjectiles)
                projectile.Draw(_spriteBatch);

            foreach (IItem item in Items)
            {
                item.Draw(_spriteBatch);
            }

            CurrentObject.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}