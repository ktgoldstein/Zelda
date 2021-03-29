using LegendOfZeldaClone.LevelLoading;
using LegendOfZeldaClone.Display;
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
        public Room NextRoom;
        public MiniMap DungeonMiniMap;

        public int SwitchRoomDelay;
        public readonly int SwitchDelayLength;

        public Camera Camera;
        public GameState CurrentGameState = GameState.Play;

        public GameStateMachine()
        {
            Camera = new Camera(this);

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
            Camera.Update();

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

                Collisions.CollisionHandling.HandleCollisions(this);
            }
        }

        public void Draw(SpriteBatch sprintBatch) 
        {

            CurrentRoom.Draw(sprintBatch);
            NextRoom?.Draw(sprintBatch);

            foreach (IObject block in Objects)
                block.Draw(sprintBatch);

            if (CurrentGameState == GameState.Play)
            {
                foreach (IItem item in Items)
                    item.Draw(sprintBatch);

                foreach (IEnemyProjectile projectile in EnemyProjectiles)
                    projectile.Draw(sprintBatch);

                foreach (IEnemy enemy in Enemies)
                    enemy.Draw(sprintBatch);

                foreach (IPlayerProjectile projectile in PlayerProjectiles)
                    projectile.Draw(sprintBatch);

                Player.Draw(sprintBatch);
            }
            sprintBatch.End();
            sprintBatch.Begin();
            DungeonMiniMap.Draw(sprintBatch, LoZHelpers.MiniMapLocation);
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
            DungeonMiniMap = new MiniMap(LoZHelpers.MiniMapLocation);
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
            int displacement = LoZHelpers.Scale(16);
            switch (direction)
            {
                case Direction.Down:
                    Player.Location += new Vector2(0, displacement + Player.Height);
                    break;
                case Direction.Up:
                    Player.Location -= new Vector2(0, displacement + Player.Height);
                    break;
                case Direction.Left:
                    Player.Location -= new Vector2(displacement + Player.Width, 0);
                    break;
                case Direction.Right:
                    Player.Location += new Vector2(displacement + Player.Width, 0);
                    break;
                case Direction.None:
                    break;
            }
        }

        public void Reset()
        {
            ResetPlayer();
            ResetLists();
            InitializeRooms();
        }

        public void ResetPlayer()
        {
            IUsableItem woodenSword = new UsableWoodenSword(this);
            Player = new LinkPlayer(this, LoZHelpers.LinkStartingLocation, woodenSword);
        }

        public void ResetLists()
        {
            Objects.Clear();
            ResetRoomSpecificLists();
        }

        public void ResetRoomSpecificLists()
        {
            Enemies.Clear();
            Items.Clear();

            PlayerProjectiles.Clear();
            PlayerProjectilesQueue.Clear();
            EnemyProjectiles.Clear();
            EnemyProjectilesQueue.Clear();
        }
    }
}
