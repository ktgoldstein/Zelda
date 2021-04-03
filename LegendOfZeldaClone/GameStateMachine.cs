using LegendOfZeldaClone.LevelLoading;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZeldaClone
{
    public class GameStateMachine 
    {
        public IPlayer Player;
        public List<IEnemy> Enemies;
        public List<IItem> Items;
        public List<IObject> Objects;

        public List<IPlayerProjectile> PlayerProjectilesQueue;
        public List<IPlayerProjectile> PlayerProjectiles;

        public List<IEnemyProjectile> EnemyProjectilesQueue;
        public List<IEnemyProjectile> EnemyProjectiles;

        public List<PauseMapRoom> MapRooms;

        public Room CurrentRoom;
        public HUDMap HUDMap;
        public PauseScreenMap PauseMap;
        public LevelName DungeonLevelName;
        public RupeeCount PlayerRupeeCount;
        public KeyCount PlayerKeyCount;
        public BombCount PlayerBombCount;
        public BBox InventoryBoxB;
        public ABox InventoryBoxA;
        public LifeText HUDLifeText;
        public HealthBar HUDHealthBar;
        public InventoryScreen InventoryBox;
        public MapCompassHolder MapCompassHolder;
        public PauseScreenMap PauseScreenMap;
        public SelectionBoxItem SelectionBox;

        public int SwitchRoomDelay;
        public readonly int SwitchDelayLength;
        public GameState CurrentGameState = GameState.Play;

        public IGameSound GameBackgroundMusic;
        public GameOverThemeMusic GameOverTheme;
        public int MusicTimingHelperInt;
        public int EndScreenMusicTimingHelperInt;
        public int NumberOfLinkDyingFrames;
        public int NumberOfFramesBeforeBlackScreenGameOver;
        public int NumberOfFramesBeforeGameOverMessageAppears;
        public int NumberOfLinkPickingUpTriforceFrames;
        public int NumberOfFramesBeforeBlackFadeOutBeginsGameWon;
        public int NumberOfFramesBeforeBlackFadeOutEndsGameWon;
        public Texture2D GameOverTexture; //refactor this out probably

        List<Room> RoomList;

        public GameStateMachine()
        {
            Enemies = new List<IEnemy>();
            Items = new List<IItem>();
            Objects = new List<IObject>();

            PlayerProjectilesQueue = new List<IPlayerProjectile>();
            PlayerProjectiles = new List<IPlayerProjectile>();

            EnemyProjectilesQueue = new List<IEnemyProjectile>();
            EnemyProjectiles = new List<IEnemyProjectile>();

            MapRooms = new List<PauseMapRoom>();

            SwitchRoomDelay = 0;
            SwitchDelayLength = 5;

            EndScreenMusicTimingHelperInt = 0;
            MusicTimingHelperInt = 0;
            NumberOfLinkDyingFrames = 55;
            NumberOfFramesBeforeBlackScreenGameOver = NumberOfLinkDyingFrames - 16;
            NumberOfFramesBeforeGameOverMessageAppears = NumberOfLinkDyingFrames + 20;
            NumberOfLinkPickingUpTriforceFrames = 180;
            NumberOfFramesBeforeBlackFadeOutEndsGameWon = NumberOfLinkPickingUpTriforceFrames - 60;
            NumberOfFramesBeforeBlackFadeOutBeginsGameWon = NumberOfFramesBeforeBlackFadeOutEndsGameWon - 40;

        }

        public void Update()
        {
            if (CurrentGameState == GameState.Play)
            {
                if (SwitchRoomDelay > 0)
                    SwitchRoomDelay--;

                Player.Update();

                PlayerProjectiles.AddRange(PlayerProjectilesQueue);
                PlayerProjectilesQueue.Clear();
                PlayerProjectiles = PlayerProjectiles.Except(UpdateGameObjectEnumerable(PlayerProjectiles)).ToList();

                Enemies = Enemies.Except(UpdateGameObjectEnumerable(Enemies)).ToList();

                EnemyProjectiles.AddRange(EnemyProjectilesQueue);
                EnemyProjectilesQueue.Clear();
                EnemyProjectiles = EnemyProjectiles.Except(UpdateGameObjectEnumerable(EnemyProjectiles)).ToList();

                Items = Items.Except(UpdateGameObjectEnumerable(Items)).ToList();

                Objects = Objects.Except(UpdateGameObjectEnumerable(Objects)).ToList();

                HUDMap.Update();
                HUDHealthBar.Update();
                PlayerRupeeCount.Update();
                PlayerBombCount.Update();
                PlayerKeyCount.Update();

                Collisions.CollisionHandling.HandleCollisions(this);

                //for sound effect testing
                if (MusicTimingHelperInt > 120)
                {
                    GameBackgroundMusic.StopPlaying();
                }
                MusicTimingHelperInt++;
                  if (CurrentRoom == RoomList[7] || CurrentRoom == RoomList[13])
                 {
                   if (MusicTimingHelperInt % 60 == 0)
                      new AquamentusScreamingSoundEffect().Play();
                 }

            }
            else if (CurrentGameState == GameState.Pause)
            {
                InventoryBox.Update(Direction.None);
                MapCompassHolder.Update();
                HUDMap.Update();
                PauseMap.Update();
            }
            else if (CurrentGameState == GameState.GameOver)
            {
                GameBackgroundMusic.StopPlaying();
                EndScreenMusicTimingHelperInt++;
                if (EndScreenMusicTimingHelperInt > NumberOfFramesBeforeGameOverMessageAppears)
                {
                    GameOverTheme.ConditionalPlay();
                }
                Player.Update();
            }
            else if (CurrentGameState == GameState.GameWon)
            {
                GameBackgroundMusic.StopPlaying();
                EndScreenMusicTimingHelperInt++;
                if (EndScreenMusicTimingHelperInt < NumberOfFramesBeforeBlackFadeOutEndsGameWon)
                    Player.Update();
                //also update the triforce so that it continues to flash as link holds it
            }
            
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            if (CurrentGameState == GameState.Play)
            {
                CurrentRoom.Draw(spriteBatch);

                foreach (IObject block in Objects)
                    block.Draw(spriteBatch);

                foreach (IItem item in Items)
                    item.Draw(spriteBatch);

                foreach (IEnemyProjectile projectile in EnemyProjectiles)
                    projectile.Draw(spriteBatch);

                foreach (IEnemy enemy in Enemies)
                    enemy.Draw(spriteBatch);

                foreach (IPlayerProjectile projectile in PlayerProjectiles)
                    projectile.Draw(spriteBatch);

                Player.Draw(spriteBatch);
                HUDMap.Draw(spriteBatch);
                DungeonLevelName.Draw(spriteBatch, LoZHelpers.LevelNameLocation);
                PlayerRupeeCount.Draw(spriteBatch, LoZHelpers.RupeeCountLocation);
                PlayerKeyCount.Draw(spriteBatch, LoZHelpers.KeyCountLocation);
                PlayerBombCount.Draw(spriteBatch, LoZHelpers.BombCountLocation);
                InventoryBoxB.Draw(spriteBatch, LoZHelpers.BBoxLocation);
                InventoryBoxA.Draw(spriteBatch, LoZHelpers.ABoxLocation);
                HUDLifeText.Draw(spriteBatch, LoZHelpers.LifeTextLocation);
                HUDHealthBar.Draw(spriteBatch, LoZHelpers.HealthLocation);

            }
            else if (CurrentGameState == GameState.Pause)
            {
                InventoryBox.Draw(spriteBatch);
                MapCompassHolder.Draw(spriteBatch);
                DungeonLevelName.Draw(spriteBatch, LoZHelpers.LevelNamePauseLocation);
                PlayerRupeeCount.Draw(spriteBatch, LoZHelpers.RupeeCountPauseLocation);
                PlayerKeyCount.Draw(spriteBatch, LoZHelpers.KeyCountPauseLocation);
                PlayerBombCount.Draw(spriteBatch, LoZHelpers.BombCountPauseLocation);
                InventoryBoxB.Draw(spriteBatch, LoZHelpers.BBoxPauseLocation);
                InventoryBoxA.Draw(spriteBatch, LoZHelpers.ABoxPauseLocation);
                HUDLifeText.Draw(spriteBatch, LoZHelpers.LifeTextPauseLocation);
                HUDHealthBar.Draw(spriteBatch, LoZHelpers.HealthPauseLocation);
                HUDMap.Draw(spriteBatch);
                PauseMap.Draw(spriteBatch);
                SelectionBox.Draw(spriteBatch);
            }
            else if (CurrentGameState == GameState.GameOver)
            {
                SpriteFont font = Enemy.EnemySpriteFactory.Instance.CreateFont();
                String gameOverMessage = "GAME OVER";
                String resetGameMessage = "\nPress 'R' to reset your game.";
                Rectangle sourceRectangle = new Rectangle(0, 0, 1, 1);
                Rectangle destinationRectangle = new Rectangle(0, LoZHelpers.HUDHeight, LoZHelpers.GameWidth, LoZHelpers.GameHeight);
                if (EndScreenMusicTimingHelperInt < NumberOfFramesBeforeBlackScreenGameOver)
                {
                    CurrentRoom.Draw(spriteBatch);

                    foreach (IObject block in Objects)
                        block.Draw(spriteBatch);

                    foreach (IItem item in Items)
                        item.Draw(spriteBatch);

                    foreach (IEnemyProjectile projectile in EnemyProjectiles)
                        projectile.Draw(spriteBatch);

                    foreach (IEnemy enemy in Enemies)
                        enemy.Draw(spriteBatch);

                    foreach (IPlayerProjectile projectile in PlayerProjectiles)
                        projectile.Draw(spriteBatch);
                    spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.DarkRed, 0.7f));

                    //screen fade to black:
                    if (EndScreenMusicTimingHelperInt > 32)
                        spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.Black, 0.3f));
                    if (EndScreenMusicTimingHelperInt > 35)
                        spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.Black, 0.5f));
                    if (EndScreenMusicTimingHelperInt > 38)
                        spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.Black, 0.8f));

                }
                else if (EndScreenMusicTimingHelperInt < NumberOfFramesBeforeGameOverMessageAppears) { }
                else
                {
                    spriteBatch.DrawString(font, gameOverMessage, new Vector2(LoZHelpers.GameWidth / 3, LoZHelpers.GameHeight / 2), Color.White);
                    spriteBatch.DrawString(font, resetGameMessage, new Vector2(LoZHelpers.GameWidth / 6, LoZHelpers.GameHeight / 2), Color.White);
                }
                HUDMap.Draw(spriteBatch);
                DungeonLevelName.Draw(spriteBatch, LoZHelpers.LevelNameLocation);
                PlayerRupeeCount.Draw(spriteBatch, LoZHelpers.RupeeCountLocation);
                PlayerKeyCount.Draw(spriteBatch, LoZHelpers.KeyCountLocation);
                PlayerBombCount.Draw(spriteBatch, LoZHelpers.BombCountLocation);
                InventoryBoxB.Draw(spriteBatch, LoZHelpers.BBoxLocation);
                HUDLifeText.Draw(spriteBatch, LoZHelpers.LifeTextLocation);
                HUDHealthBar.Draw(spriteBatch, LoZHelpers.HealthLocation);
                Player.Draw(spriteBatch);
            }



            else if (CurrentGameState == GameState.GameWon) /* **************GAME WON do NOT confuse these branches************************ */
            {
                SpriteFont font = Enemy.EnemySpriteFactory.Instance.CreateFont();
                String gameWonMessage = "YOU WON!";
                String resetGameMessage = "\nPress 'R' to reset your game.";
                Rectangle sourceRectangle = new Rectangle(0, 0, 1, 1);
                Rectangle destinationRectangle = new Rectangle(0, LoZHelpers.HUDHeight, LoZHelpers.GameWidth, LoZHelpers.GameHeight);
                if (EndScreenMusicTimingHelperInt < NumberOfFramesBeforeBlackScreenGameOver)
                {
                    CurrentRoom.Draw(spriteBatch);

                    foreach (IObject block in Objects)
                        block.Draw(spriteBatch);

                    foreach (IItem item in Items)
                        item.Draw(spriteBatch);

                    foreach (IEnemyProjectile projectile in EnemyProjectiles)
                        projectile.Draw(spriteBatch);

                    foreach (IEnemy enemy in Enemies)
                        enemy.Draw(spriteBatch);

                    foreach (IPlayerProjectile projectile in PlayerProjectiles)
                        projectile.Draw(spriteBatch);
                    //spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.White, 0.3f));

                    //screen fade to black:
                    if (EndScreenMusicTimingHelperInt > 32)
                        spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.Black, 0.3f));
                    if (EndScreenMusicTimingHelperInt > 35)
                        spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.Black, 0.5f));
                    if (EndScreenMusicTimingHelperInt > 38)
                        spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.Black, 0.8f));

                }
                else if (EndScreenMusicTimingHelperInt < NumberOfFramesBeforeGameOverMessageAppears) { }
                else
                {
                    spriteBatch.DrawString(font, gameWonMessage, new Vector2(LoZHelpers.GameWidth / 3, LoZHelpers.GameHeight / 2), Color.White);
                    spriteBatch.DrawString(font, resetGameMessage, new Vector2(LoZHelpers.GameWidth / 6, LoZHelpers.GameHeight / 2), Color.White);
                }
                HUDMap.Draw(spriteBatch);
                DungeonLevelName.Draw(spriteBatch, LoZHelpers.LevelNameLocation);
                PlayerRupeeCount.Draw(spriteBatch, LoZHelpers.RupeeCountLocation);
                PlayerKeyCount.Draw(spriteBatch, LoZHelpers.KeyCountLocation);
                PlayerBombCount.Draw(spriteBatch, LoZHelpers.BombCountLocation);
                InventoryBoxB.Draw(spriteBatch, LoZHelpers.BBoxLocation);
                HUDLifeText.Draw(spriteBatch, LoZHelpers.LifeTextLocation);
                HUDHealthBar.Draw(spriteBatch, LoZHelpers.HealthLocation);
                Player.Draw(spriteBatch);
            }
        }

        public void InitializeRooms()
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
            RoomList[6].AddNeighbors(RoomList[10], null, null, RoomList[4]);
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

            CurrentRoom = RoomList[0];
            CurrentRoom.LoadRoom();
        }

        public void InitializeHUD()
        {
            HUDMap = new HUDMap(this);
            PauseMap = new PauseScreenMap(this);
            DungeonLevelName = new LevelName();
            PlayerRupeeCount = new RupeeCount(this);
            PlayerKeyCount = new KeyCount(this);
            PlayerBombCount = new BombCount(this);
            InventoryBox = new InventoryScreen(this);
            InventoryBoxB = new BBox(this);
            InventoryBoxA = new ABox(this);
            HUDLifeText = new LifeText();
            HUDHealthBar = new HealthBar(this);
            MapCompassHolder = new MapCompassHolder(this);
            SelectionBox = new SelectionBoxItem(this);
        }

        public void InitializeMusic()
        {
            GameBackgroundMusic = new DungeonThemeMusic();
            GameBackgroundMusic.Play();
            GameOverTheme = new GameOverThemeMusic();

        }

        public List<T> UpdateGameObjectEnumerable<T>(List<T> gameObjects) where T : IGameObject
        {
            List<T> deadObjects = new List<T>();
            foreach (T gameObject in gameObjects)
            {
                gameObject.Update();
                if (!gameObject.Alive)
                    deadObjects.Add(gameObject);
            }
            return deadObjects;
        }

        public void Reset()
        {
            ResetPlayer();
            ResetLists();
            InitializeRooms();
            ResetMaps();
        }

        public void ResetPlayer()
        {
            Player = new LinkPlayer(this, LoZHelpers.LinkStartingLocation, new UsableWoodenSword(this));
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

            MapRooms.Clear();
        }

        public void ResetMaps()
        {
            HUDMap.Reset();
            PauseMap.Reset();
        }
    }
}
