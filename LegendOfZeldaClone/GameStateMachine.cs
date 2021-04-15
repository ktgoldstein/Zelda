using LegendOfZeldaClone.LevelLoading;
using LegendOfZeldaClone.Display;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Enemy;

namespace LegendOfZeldaClone
{
    public class GameStateMachine
    {
        public IPlayer Player;

        public List<IEnemy> EnemiesQueue;
        public List<IEnemy> Enemies;

        public List<IItem> Items;
        public List<IBlock> Blocks;
        private List<IBlock> stashedBlocks;

        public List<IPlayerProjectile> PlayerProjectilesQueue;
        public List<IPlayerProjectile> PlayerProjectiles;

        public List<IEnemyProjectile> EnemyProjectilesQueue;
        public List<IEnemyProjectile> EnemyProjectiles;

        public Room CurrentRoom;
        public Room NextRoom;
        private Room firstRoom;

        public HUDMap HUDMap;
        public PauseMap PauseMap;
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
        public SelectionBoxItem SelectionBox;

        public int SwitchRoomDelay = 0;
        public int SwitchCursorDelay = 0;
        public readonly int SwitchDelayLength = 5;

        public int KillCounter
        {
            get { return killCounter; }
            set { killCounter = value % 9; }
        }
        private int killCounter = 0;

        public Camera RoomCamera;
        public Camera MenuCamera;
        public GameState CurrentGameState
        {
            get { return currentGameState; }
            set
            {
                PreviousGameState = currentGameState;
                currentGameState = value;
            }
        }
        public GameState PreviousGameState;
        private GameState currentGameState = GameState.Play;

        public DungeonThemeMusic GameBackgroundMusic;
        public GameOverThemeMusic GameOverTheme;
        public int MusicTimingHelperInt;
        public int EndScreenMusicTimingHelperInt;
        
        public Texture2D GameOverTexture;

        public GameStateMachine()
        {
            RoomCamera = new Camera(this);
            MenuCamera = new Camera(this);

            EnemiesQueue = new List<IEnemy>();
            Enemies = new List<IEnemy>();

            Items = new List<IItem>();
            Blocks = new List<IBlock>();

            PlayerProjectilesQueue = new List<IPlayerProjectile>();
            PlayerProjectiles = new List<IPlayerProjectile>();

            EnemyProjectilesQueue = new List<IEnemyProjectile>();
            EnemyProjectiles = new List<IEnemyProjectile>();

            EndScreenMusicTimingHelperInt = 0;
            MusicTimingHelperInt = 0;
        }

        public void Update()
        {
            RoomCamera.Update();
            MenuCamera.Update();

            if (SwitchRoomDelay > 0)
                SwitchRoomDelay--;
            if (SwitchCursorDelay > 0)
                SwitchCursorDelay--;

            if (CurrentGameState == GameState.Play)
            {
                Player.Update();

                PlayerProjectiles.AddRange(PlayerProjectilesQueue);
                PlayerProjectilesQueue.Clear();
                PlayerProjectiles = PlayerProjectiles.Except(UpdateGameObjectEnumerable(PlayerProjectiles)).ToList();

                Enemies.AddRange(EnemiesQueue);
                EnemiesQueue.Clear();
                Enemies = Enemies.Except(UpdateGameObjectEnumerable(Enemies)).ToList();

                EnemyProjectiles.AddRange(EnemyProjectilesQueue);
                EnemyProjectilesQueue.Clear();
                EnemyProjectiles = EnemyProjectiles.Except(UpdateGameObjectEnumerable(EnemyProjectiles)).ToList();

                Items = Items.Except(UpdateGameObjectEnumerable(Items)).ToList();

                Blocks = Blocks.Except(UpdateGameObjectEnumerable(Blocks)).ToList();

                Collisions.CollisionHandling.HandleCollisions(this);

                if (Enemies.Count == 0)
                {
                    bool blocksInPlace = true;
                    foreach (IBlock block in Blocks)
                    {
                        if (block is MovableBlock)
                            blocksInPlace &= (block as MovableBlock).Moved;
                    }
                    if (blocksInPlace)
                        CurrentRoom.OpenDoors();
                }

                HUDMap.Update();
                HUDHealthBar.Update();
                PlayerRupeeCount.Update();
                PlayerBombCount.Update();
                PlayerKeyCount.Update();

                MusicTimingHelperInt++;
                bool aquamentusNearby = false;
                foreach (Room room in new Room[]{ CurrentRoom.RoomUp, CurrentRoom.RoomDown, CurrentRoom.RoomLeft, CurrentRoom.RoomRight })
                {
                    foreach (IEnemy enemy in (room == null ? new List<IEnemy>() : room.Enemies))
                    {
                        if (enemy is Aquamentus && enemy.Alive)
                        {
                            aquamentusNearby = true;
                            break;
                        }
                    }
                    if (aquamentusNearby) break;
                }
                if (aquamentusNearby && MusicTimingHelperInt % 60 == 0)
                    new AquamentusScreamingSoundEffect().Play();
            }
            else if (CurrentGameState == GameState.Pause)
            {
                InventoryBox.Update(Direction.None);
                MapCompassHolder.Update();
                HUDMap.Update();
                HUDHealthBar.Update();
            }
            else if (CurrentGameState == GameState.GameOver)
            {
                GameBackgroundMusic.StopPlaying();
                EndScreenMusicTimingHelperInt++;
                if (EndScreenMusicTimingHelperInt > LoZHelpers.FramesBeforeGameOverMessageAppears)
                    GameOverTheme.Play();
                Player.Update();
            }
            else if (CurrentGameState == GameState.GameWon)
            {
                GameBackgroundMusic.StopPlaying();
                EndScreenMusicTimingHelperInt++;
                if (EndScreenMusicTimingHelperInt <= LoZHelpers.FramesBeforeBlackFadeOutEndsGameWon)
                    Player.Update();
            }
        }

        public void RoomDraw(SpriteBatch spriteBatch)
        {
            if (CurrentGameState == GameState.Play)
            {
                CurrentRoom.Draw(spriteBatch);
                NextRoom?.Draw(spriteBatch);

                foreach (IBlock block in Blocks)
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
            }
            else if (CurrentGameState == GameState.ScreenTransition || CurrentGameState == GameState.PauseTransition)
            {
                Vector2? nextRoomOffset = CurrentRoom.Offset;
                if (NextRoom == null)
                    nextRoomOffset = null;
                else if (NextRoom == CurrentRoom.RoomDown)
                    nextRoomOffset += Vector2.UnitY * (LoZHelpers.GameHeight - LoZHelpers.HUDHeight);
                else if (NextRoom == CurrentRoom.RoomLeft)
                    nextRoomOffset -= Vector2.UnitX * LoZHelpers.GameWidth;
                else if (NextRoom == CurrentRoom.RoomRight)
                    nextRoomOffset += Vector2.UnitX * LoZHelpers.GameWidth;
                else if (NextRoom == CurrentRoom.RoomUp)
                    nextRoomOffset -= Vector2.UnitY * (LoZHelpers.GameHeight - LoZHelpers.HUDHeight);

                CurrentRoom.Draw(spriteBatch);
                NextRoom?.DrawAt(spriteBatch, (Vector2)nextRoomOffset);

                foreach (IBlock block in Blocks)
                {                    
                    if (nextRoomOffset == null)
                    {
                        block.Draw(spriteBatch);
                    }                        
                    else
                    {
                        Vector2 relativeLocation = LoZHelpers.GetLocationInRoom(block.Location);
                        block.DrawAt(spriteBatch, relativeLocation + (Vector2)nextRoomOffset);
                    }
                }

                foreach (IBlock block in stashedBlocks)
                    block.Draw(spriteBatch);
            }
            else if (CurrentGameState == GameState.GameOver)
            {
                if (EndScreenMusicTimingHelperInt >= LoZHelpers.FramesBeforeGameOverMessageAppears)
                {
                    SpriteFont font = EnemySpriteFactory.Instance.CreateFont();
                    string gameOverMessage = "GAME OVER";
                    string resetGameMessage = "\nPress 'R' to reset your game.";
                    spriteBatch.DrawString(font, gameOverMessage, new Vector2(LoZHelpers.GameWidth / 3, LoZHelpers.GameHeight / 2) - RoomCamera.Position, Color.White);
                    spriteBatch.DrawString(font, resetGameMessage, new Vector2(LoZHelpers.GameWidth / 6, LoZHelpers.GameHeight / 2) - RoomCamera.Position, Color.White);
                }
                else if (EndScreenMusicTimingHelperInt < LoZHelpers.FramesBeforeBlackScreenGameOver)
                {
                    CurrentRoom.Draw(spriteBatch);
                    NextRoom?.Draw(spriteBatch);

                    foreach (IBlock block in Blocks)
                        block.Draw(spriteBatch);

                    foreach (IItem item in Items)
                        item.Draw(spriteBatch);

                    foreach (IEnemyProjectile projectile in EnemyProjectiles)
                        projectile.Draw(spriteBatch);

                    foreach (IEnemy enemy in Enemies)
                        enemy.Draw(spriteBatch);

                    foreach (IPlayerProjectile projectile in PlayerProjectiles)
                        projectile.Draw(spriteBatch);

                    Rectangle sourceRectangle = new Rectangle(0, 0, 1, 1);
                    Rectangle destinationRectangle = new Rectangle((int)-RoomCamera.Position.X, (int)-RoomCamera.Position.Y, LoZHelpers.GameWidth, LoZHelpers.GameHeight);
                    spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.DarkRed, 0.7f));
                }
                Player.Draw(spriteBatch);
            }
            else if (CurrentGameState == GameState.GameWon)
            {
                if (EndScreenMusicTimingHelperInt < LoZHelpers.FramesBeforeBlackFadeOutEndsGameWon)
                {
                    CurrentRoom.Draw(spriteBatch);

                    foreach (IBlock block in Blocks)
                        block.Draw(spriteBatch);

                    foreach (IItem item in Items)
                        item.Draw(spriteBatch);

                    foreach (IEnemyProjectile projectile in EnemyProjectiles)
                        projectile.Draw(spriteBatch);

                    foreach (IEnemy enemy in Enemies)
                        enemy.Draw(spriteBatch);

                    foreach (IPlayerProjectile projectile in PlayerProjectiles)
                        projectile.Draw(spriteBatch);

                    //screen flashes:
                    Rectangle sourceRectangle = new Rectangle(0, 0, 1, 1);
                    Rectangle destinationRectangle = new Rectangle((int)-RoomCamera.Position.X, (int)-RoomCamera.Position.Y, LoZHelpers.GameWidth, LoZHelpers.GameHeight);
                    if (EndScreenMusicTimingHelperInt > 12 && EndScreenMusicTimingHelperInt < 24 && EndScreenMusicTimingHelperInt % 2 == 1)
                        spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, Color.White * 0.7f);

                    //screen fade to black:
                    if (EndScreenMusicTimingHelperInt > LoZHelpers.FramesBeforeBlackFadeOutBeginsGameWon)
                    {
                        float floatFadeOpacityModifier = (EndScreenMusicTimingHelperInt - LoZHelpers.FramesBeforeBlackFadeOutBeginsGameWon);
                        if (floatFadeOpacityModifier < 32)
                            floatFadeOpacityModifier = ((int)floatFadeOpacityModifier / 2 + 1) * 0.06f;
                        else
                            floatFadeOpacityModifier = 1f;
                        spriteBatch.Draw(GameOverTexture, destinationRectangle, sourceRectangle, new Color(Color.Black, floatFadeOpacityModifier));
                    }
                }
                else if (EndScreenMusicTimingHelperInt >= LoZHelpers.FramesBeforeGameWonMessageAppears)
                {
                    SpriteFont font = Enemy.EnemySpriteFactory.Instance.CreateFont();
                    string gameWonMessage = "YOU WON!";
                    string resetGameMessage = "\nPress 'R' to reset your game.";
                    spriteBatch.DrawString(font, gameWonMessage, new Vector2(LoZHelpers.GameWidth / 3, LoZHelpers.GameHeight / 2) - RoomCamera.Position, Color.White);
                    spriteBatch.DrawString(font, resetGameMessage, new Vector2(LoZHelpers.GameWidth / 6, LoZHelpers.GameHeight / 2) - RoomCamera.Position, Color.White);
                }
                Player.Draw(spriteBatch);
            }
        }

        public void HUDDraw(SpriteBatch spriteBatch)
        {
            HUDMap.Draw(spriteBatch);
            DungeonLevelName.Draw(spriteBatch, LoZHelpers.LevelNameLocation);
            PlayerRupeeCount.Draw(spriteBatch, LoZHelpers.RupeeCountLocation);
            PlayerKeyCount.Draw(spriteBatch, LoZHelpers.KeyCountLocation);
            PlayerBombCount.Draw(spriteBatch, LoZHelpers.BombCountLocation);
            InventoryBoxB.Draw(spriteBatch, LoZHelpers.BBoxLocation);
            InventoryBoxA.Draw(spriteBatch, LoZHelpers.ABoxLocation);
            HUDLifeText.Draw(spriteBatch, LoZHelpers.LifeTextLocation);
            HUDHealthBar.Draw(spriteBatch, LoZHelpers.HealthLocation); 
            
            PauseMap.Draw(spriteBatch);
            SelectionBox.Draw(spriteBatch);
            InventoryBox.Draw(spriteBatch);
            MapCompassHolder.Draw(spriteBatch);
        }

        public void InitializeRooms()
        {
            List<Room> RoomList = new List<Room>()
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
                new Room("Content\\LevelLoading\\roomMaze00.csv", this),
                new Room("Content\\LevelLoading\\roomMaze01.csv", this),
                new Room("Content\\LevelLoading\\roomMaze02.csv", this),
                new Room("Content\\LevelLoading\\roomMaze03.csv", this),
                new Room("Content\\LevelLoading\\roomMaze04.csv", this),
                new Room("Content\\LevelLoading\\roomMaze05.csv", this),
                new Room("Content\\LevelLoading\\roomMaze06.csv", this),
                new Room("Content\\LevelLoading\\roomMaze07.csv", this),
                new Room("Content\\LevelLoading\\roomMaze08.csv", this),
                new Room("Content\\LevelLoading\\SecretRoom.csv", this),
            };

            RoomList[0].AddNeighbors(RoomList[3], RoomList[17], RoomList[1], RoomList[2]);
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
            RoomList[17].AddNeighbors(RoomList[0], null, RoomList[18], null);
            RoomList[18].AddNeighbors(null, RoomList[19], null, RoomList[17]);
            RoomList[19].AddNeighbors(RoomList[18], RoomList[20], null, null);
            RoomList[20].AddNeighbors(RoomList[19], null, RoomList[21], null);
            RoomList[21].AddNeighbors(null, RoomList[22], null, RoomList[20]);
            RoomList[22].AddNeighbors(RoomList[21], null, RoomList[23], null);
            RoomList[23].AddNeighbors(null, RoomList[24], null, RoomList[22]);
            RoomList[24].AddNeighbors(RoomList[23], null, RoomList[25], null);
            RoomList[25].AddNeighbors(null, RoomList[24], null, null);
            RoomList[26].AddNeighbors(RoomList[16], null, null, null);

            firstRoom = RoomList[0];
            CurrentRoom = RoomList[0];
            CurrentRoom.LoadRoom();
        }

        public void GoToTheStart()
        {
            ResetLists();
            CurrentRoom = firstRoom;
            CurrentRoom.LoadRoom();
            Player.Location = LoZHelpers.LinkStartingLocation;
            RoomCamera.Reset();
            PauseMap.GoToStart();
            HUDMap.Reset();
        }

        public void InitializeHUD()
        {
            HUDMap = new HUDMap(this);
            PauseMap = new PauseMap(this);
            DungeonLevelName = new LevelName();
            PlayerRupeeCount = new RupeeCount(this);
            PlayerKeyCount = new KeyCount(this);
            PlayerBombCount = new BombCount(this);
            InventoryBox = new InventoryScreen(this);
            InventoryBoxB = new BBox(this);
            InventoryBoxA = new ABox();
            HUDLifeText = new LifeText();
            HUDHealthBar = new HealthBar(this);
            MapCompassHolder = new MapCompassHolder(this);
            SelectionBox = new SelectionBoxItem(this);
        }

        public void InitializeMusic()
        {
            if (GameBackgroundMusic != null)
                GameBackgroundMusic.StopPlaying();
            GameBackgroundMusic = new DungeonThemeMusic();
            GameBackgroundMusic.Play();
            GameOverTheme = new GameOverThemeMusic();
            MusicTimingHelperInt = 0;
            EndScreenMusicTimingHelperInt = 0;
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

        public void ShiftLink(Direction direction)
        {
            int horizontalDisplacement = LoZHelpers.Scale(16);
            int verticalDisplacement = LoZHelpers.Scale(32);
            switch (direction)
            {
                case Direction.Up:
                    Player.Location -= new Vector2(0, verticalDisplacement + Player.Height);
                    break;
                case Direction.Down:
                    Player.Location += new Vector2(0, verticalDisplacement + Player.Height);
                    break;
                case Direction.Left:
                    Player.Location -= new Vector2(horizontalDisplacement + Player.Width, 0);
                    break;
                case Direction.Right:
                    Player.Location += new Vector2(horizontalDisplacement + Player.Width, 0);
                    break;
                case Direction.None:
                    break;
            }
        }
        public void Reset()
        {
            CurrentGameState = GameState.Play;
            if (GameOverTheme != null)
                GameOverTheme.StopPlaying();
            ResetPlayer();
            ResetLists();
            InitializeRooms();            
            RoomCamera = new Camera(this);
            MenuCamera = new Camera(this);
            InitializeMusic();
            InitializeHUD();
        }

        public void ResetPlayer()
        {
            Player = new LinkPlayer(this, LoZHelpers.LinkStartingLocation, new UsableWoodenSword(this));
        }

        public void ResetLists()
        {
            Blocks.Clear();
            ResetRoomSpecificLists();
        }

        public void ResetRoomSpecificLists()
        {
            Enemies.Clear();
            EnemiesQueue.Clear();

            Items.Clear();

            while (PlayerProjectilesQueue.Count > 0 || PlayerProjectiles.Count > 0)
            {
                PlayerProjectiles.AddRange(PlayerProjectilesQueue);
                PlayerProjectilesQueue.Clear();
                foreach (IPlayerProjectile playerProjectile in PlayerProjectiles)
                    playerProjectile.Die();
                PlayerProjectiles.Clear();
            }

            while (EnemyProjectilesQueue.Count > 0 || EnemyProjectiles.Count > 0)
            {
                EnemyProjectiles.AddRange(EnemyProjectilesQueue);
                EnemyProjectilesQueue.Clear();
                foreach (IEnemyProjectile enemyProjectile in EnemyProjectiles)
                    enemyProjectile.Die();
                EnemyProjectiles.Clear();
            }
        }

        public void StashBlocks()
        {
            stashedBlocks = Blocks;
            Blocks = new List<IBlock>();
        }
    }
}
