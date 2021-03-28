using LegendOfZeldaClone.Enemy;
using LegendOfZeldaClone.LevelLoading;
using LegendOfZeldaClone.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendOfZeldaClone
{
    public class LegendOfZeldaDungeon : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IController controllerKeyboard;
        private IController controllerMouse;

        public IPlayer Player;
        public List<IEnemy> Enemies;
        public List<IItem> Items;
        public List<IObject> Objects;

        public List<IPlayerProjectile> PlayerProjectilesQueue;
        public List<IPlayerProjectile> PlayerProjectiles;

        public List<IEnemyProjectile> EnemyProjectilesQueue;
        public List<IEnemyProjectile> EnemyProjectiles;
                
        public List<Room> RoomList;
        public int RoomListIndex = 0;
        public Room CurrentRoom;
        public MiniMap DungeonMiniMap;

        public int SwitchRoomDelay;
        public int SwitchDelayLength = 5;

        public IGameSound GameBackgroundMusic;
        public int MusicTimingHelperInt;

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

            ICommand previousRoom = new PreviousRoom(this);
            ICommand nextRoom = new NextRoom(this);

            KeyboardController keyboardController = new KeyboardController();
            MouseController mouseController = new MouseController(nextRoom, previousRoom);

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

            keyboardController.RegisterCommand(Keys.V, previousRoom);
            keyboardController.RegisterCommand(Keys.B, nextRoom);

            controllerKeyboard = keyboardController;
            controllerMouse = mouseController;

            Enemies = new List<IEnemy>();
            Items = new List<IItem>();
            Objects = new List<IObject>();

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

            PlayerProjectilesQueue = new List<IPlayerProjectile>();
            PlayerProjectiles = new List<IPlayerProjectile>();

            EnemyProjectilesQueue = new List<IEnemyProjectile>();
            EnemyProjectiles = new List<IEnemyProjectile>();

            IUsableItem woodenSword = new UsableWoodenSword(this);
            Player = new LinkPlayer(this, LoZHelpers.LinkStartingLocation, woodenSword);

            GameBackgroundMusic = new DungeonThemeMusic();
            GameBackgroundMusic.Play();
            MusicTimingHelperInt = 0;
            

            InitializeRooms();
            CurrentRoom = RoomList[RoomListIndex];
            CurrentRoom.LoadRoom();

            DungeonMiniMap = new MiniMap(LoZHelpers.MiniMapLocation);
        }

        protected override void Update(GameTime gameTime)
        {
            if (SwitchRoomDelay > 0)
                SwitchRoomDelay--;

            controllerKeyboard.Update();
            controllerMouse.Update();

            Player.Update();

            List<IPlayerProjectile> deadLinkProjectiles = new List<IPlayerProjectile>();
            PlayerProjectiles.AddRange(PlayerProjectilesQueue);
            PlayerProjectilesQueue.Clear();
            foreach (IPlayerProjectile projectile in PlayerProjectiles)
            {
                projectile.Update();
                if (!projectile.Alive)
                    deadLinkProjectiles.Add(projectile);
            }
            PlayerProjectiles = PlayerProjectiles.Except(deadLinkProjectiles).ToList();
            


            List<IEnemy> deadEnemies = new List<IEnemy>();
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update();
                if (enemy.Health <= 0)
                    deadEnemies.Add(enemy);
            }
            Enemies = Enemies.Except(deadEnemies).ToList();

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
            foreach (IItem item in Items)
            {
                item.Update();
                if (!item.Alive)
                    deadItems.Add(item);
            }
            Items = Items.Except(deadItems).ToList();

            List<IObject> deadObjects = new List<IObject>();
            foreach (IObject block in Objects)
            {
                block.Update();
                if (!block.IsAlive)
                    deadObjects.Add(block);
            }
            Objects = Objects.Except(deadObjects).ToList();

            Collisions.CollisionHandling.HandleCollisions(this);

            base.Update(gameTime);

            if (MusicTimingHelperInt > 120)
            {
                GameBackgroundMusic.StopPlaying();
            }
            MusicTimingHelperInt++;
            if (MusicTimingHelperInt % 10 ==0)
            {
               // new HeartPickupSoundEffect().Play();
            }
            if (CurrentRoom == RoomList[7] || CurrentRoom == RoomList[13])
            {
                if (MusicTimingHelperInt % 60 == 0)
                    new AquamentusScreamingSoundEffect().Play();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);            
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            
            CurrentRoom.Draw(_spriteBatch);
            DungeonMiniMap.Draw(_spriteBatch, LoZHelpers.MiniMapLocation);

            foreach (IObject block in Objects)
                block.Draw(_spriteBatch);

            foreach (IItem item in Items)
                item.Draw(_spriteBatch);

            foreach (IEnemyProjectile projectile in EnemyProjectiles)
                projectile.Draw(_spriteBatch);

            foreach (IEnemy enemy in Enemies)
                enemy.Draw(_spriteBatch);

            foreach (IPlayerProjectile projectile in PlayerProjectiles)
                projectile.Draw(_spriteBatch);

            Player.Draw(_spriteBatch);                       

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ResetLists()
        {
            Enemies.Clear();
            Items.Clear();
            Objects.Clear();

            PlayerProjectiles.Clear();
            PlayerProjectilesQueue.Clear();
            EnemyProjectiles.Clear();
            EnemyProjectilesQueue.Clear();
        }

        private void InitializeRooms()
        {
            RoomList = new List<Room>()
            {
                new Room("Content\\LevelLoading\\room00.csv", this),
                new Room("Content\\LevelLoading\\room01.csv", this),
                new Room("Content\\LevelLoading\\room02.csv", this),
                new Room("Content\\LevelLoading\\room03.csv", this),
                new Room("Content\\LevelLoading\\room04.csv", this),
                new Room("Content\\LevelLoading\\room05.csv", this),
                new Room("Content\\LevelLoading\\room06.csv", this),
                new Room("Content\\LevelLoading\\room07.csv", this),
                new Room("Content\\LevelLoading\\room08.csv", this),
                new Room("Content\\LevelLoading\\room09.csv", this),
                new Room("Content\\LevelLoading\\room10.csv", this),
                new Room("Content\\LevelLoading\\room11.csv", this),
                new Room("Content\\LevelLoading\\room12.csv", this),
                new Room("Content\\LevelLoading\\room13.csv", this),
                new Room("Content\\LevelLoading\\room14.csv", this),
                new Room("Content\\LevelLoading\\room15.csv", this),
                new Room("Content\\LevelLoading\\room16.csv", this),
                new Room("Content\\LevelLoading\\SecretRoom.csv", this)
            };

            RoomList[0].AddNeighbors(RoomList[3], RoomList[0], RoomList[1], RoomList[2]);
            RoomList[1].AddNeighbors(null, null, null, RoomList[0]);
            RoomList[2].AddNeighbors(null, null, RoomList[0], null);
            RoomList[3].AddNeighbors(RoomList[4], RoomList[0], null, null);
            RoomList[4].AddNeighbors(RoomList[9], RoomList[3], RoomList[6], RoomList[5]);
            RoomList[5].AddNeighbors(RoomList[8], null, RoomList[4], null);
            RoomList[6].AddNeighbors(RoomList[6], null, null, RoomList[4]);
            RoomList[7].AddNeighbors(RoomList[13], null, RoomList[8], null);
            RoomList[8].AddNeighbors(null, RoomList[5], RoomList[9], RoomList[7]);
            RoomList[9].AddNeighbors(RoomList[12], RoomList[4], RoomList[10], RoomList[8]);
            RoomList[10].AddNeighbors(null, RoomList[6], RoomList[11], RoomList[9]);
            RoomList[11].AddNeighbors(null, null, null, RoomList[10]);
            RoomList[12].AddNeighbors(RoomList[15], RoomList[9], null, null);
            RoomList[13].AddNeighbors(null, RoomList[7], null, RoomList[14]);
            RoomList[14].AddNeighbors(null, null, RoomList[13], null);
            RoomList[15].AddNeighbors(null, RoomList[12], RoomList[16], null);
            RoomList[16].AddNeighbors(null, RoomList[^1], null, RoomList[15]);
            RoomList[17].AddNeighbors(RoomList[16], null, null, null);
        }
    }
}
