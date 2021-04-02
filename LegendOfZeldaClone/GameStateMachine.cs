﻿using LegendOfZeldaClone.LevelLoading;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

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

        public Room CurrentRoom;
        public HUDMap HUDMap;
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
        public PauseMap PauseScreenMap;

        public int SwitchRoomDelay;
        public readonly int SwitchDelayLength;
        public GameState CurrentGameState = GameState.Play;

        public GameStateMachine()
        {
            Enemies = new List<IEnemy>();
            Items = new List<IItem>();
            Objects = new List<IObject>();

            PlayerProjectilesQueue = new List<IPlayerProjectile>();
            PlayerProjectiles = new List<IPlayerProjectile>();

            EnemyProjectilesQueue = new List<IEnemyProjectile>();
            EnemyProjectiles = new List<IEnemyProjectile>();

            SwitchRoomDelay = 0;
            SwitchDelayLength = 5;
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

                HUDHealthBar.Update();
                HUDMap.Update();
                PlayerRupeeCount.Update();
                PlayerBombCount.Update();
                PlayerKeyCount.Update();

                Collisions.CollisionHandling.HandleCollisions(this);
            }
            else if (CurrentGameState == GameState.Pause)
            {
                InventoryBox.Update(Direction.None);
                MapCompassHolder.Update();
            }
        }

        public void Draw(SpriteBatch sprintBatch) 
        {
            if (CurrentGameState == GameState.Play)
            {
                CurrentRoom.Draw(sprintBatch);

                foreach (IObject block in Objects)
                    block.Draw(sprintBatch);

                foreach (IItem item in Items)
                    item.Draw(sprintBatch);

                foreach (IEnemyProjectile projectile in EnemyProjectiles)
                    projectile.Draw(sprintBatch);

                foreach (IEnemy enemy in Enemies)
                    enemy.Draw(sprintBatch);

                foreach (IPlayerProjectile projectile in PlayerProjectiles)
                    projectile.Draw(sprintBatch);

                Player.Draw(sprintBatch);

                HUDMap.Draw(sprintBatch);
                DungeonLevelName.Draw(sprintBatch, LoZHelpers.LevelNameLocation);
                PlayerRupeeCount.Draw(sprintBatch, LoZHelpers.RupeeCountLocation);
                PlayerKeyCount.Draw(sprintBatch, LoZHelpers.KeyCountLocation);
                PlayerBombCount.Draw(sprintBatch, LoZHelpers.BombCountLocation);
                InventoryBoxB.Draw(sprintBatch, LoZHelpers.BBoxLocation);
                InventoryBoxA.Draw(sprintBatch, LoZHelpers.ABoxLocation);
                HUDLifeText.Draw(sprintBatch, LoZHelpers.LifeTextLocation);
                HUDHealthBar.Draw(sprintBatch, LoZHelpers.HealthLocation);
            }
            else if (CurrentGameState == GameState.Pause)
            {
                InventoryBox.Draw(sprintBatch);
                MapCompassHolder.Draw(sprintBatch);
                DungeonLevelName.Draw(sprintBatch, LoZHelpers.LevelNamePauseLocation);
                PlayerRupeeCount.Draw(sprintBatch, LoZHelpers.RupeeCountPauseLocation);
                PlayerKeyCount.Draw(sprintBatch, LoZHelpers.KeyCountPauseLocation);
                PlayerBombCount.Draw(sprintBatch, LoZHelpers.BombCountPauseLocation);
                InventoryBoxB.Draw(sprintBatch, LoZHelpers.BBoxPauseLocation);
                InventoryBoxA.Draw(sprintBatch, LoZHelpers.ABoxPauseLocation);
                HUDLifeText.Draw(sprintBatch, LoZHelpers.LifeTextPauseLocation);
                HUDHealthBar.Draw(sprintBatch, LoZHelpers.HealthPauseLocation);
            }
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
            ResetMiniMap();
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
        }

        public void ResetMiniMap()
        {
            HUDMap.Reset();
        }
    }
}
