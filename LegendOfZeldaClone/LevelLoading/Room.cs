using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Objects;
using LegendOfZeldaClone.Enemy;

namespace LegendOfZeldaClone.LevelLoading
{
    public class Room
    {
        public Room RoomUp;
        public Room RoomDown;
        public Room RoomLeft;
        public Room RoomRight;

        private readonly ISprite tiles;
        private readonly ISprite walls;
        private int backgroundType;
        private int wallType;
        private readonly LegendOfZeldaDungeon game;
        private readonly string fileLocation;

        public Room(string fileLocation, LegendOfZeldaDungeon game)
        {
            this.game = game;
            this.fileLocation = fileLocation;
            tiles = RoomTextureFactory.Instance.CreateTiles();
            walls = RoomTextureFactory.Instance.CreateWalls();
            backgroundType = -1;
            wallType = -1;
        }

        public void LoadRoom()
        {
            game.ResetLists();

            List<List<int>> data = ProcessCSV();

            for (int row = 0; row < data.Count; row++)
            {
                for (int column = 0; column < data[row].Count; column++)
                {
                    ProcessEntry(data[row][column], column, row);
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (wallType == 1)
                walls.Draw(spritebatch, new Vector2(0, LoZHelpers.HUDHeight));

            if (backgroundType == 1)
                tiles.Draw(spritebatch, new Vector2(LoZHelpers.TileSize * 2, LoZHelpers.HUDHeight + LoZHelpers.TileSize * 2));
        }

        public void AddNeighbors(Room roomUp, Room roomDown, Room roomLeft, Room roomRight)
        {
            RoomUp = roomUp;
            RoomDown = roomDown;
            RoomLeft = roomLeft;
            RoomRight = roomRight;
        }

        private List<List<int>> ProcessCSV()
        {
            List<List<int>> data = new List<List<int>>();
            var lines = File.ReadLines(fileLocation);
            bool readBackgroundType = false;
            bool readWallType = false;
            foreach (var line in lines)
            {                
                if(!readBackgroundType)
                {
                    backgroundType = int.Parse(line);
                    readBackgroundType = true;
                }
                else if (!readWallType)
                {
                    wallType = int.Parse(line);
                    readWallType = true;
                }
                else
                {
                    var splitLine = line.Split(",");
                    var row = Array.ConvertAll(splitLine, s => int.Parse(s));
                    data.Add(new List<int>((row)));
                }
            }
            return data;
        }

        private void ProcessEntry(int gameObjectID, int column, int row)
        {
            Vector2 tileLocation = new Vector2(LoZHelpers.TileSize * (column + 1), LoZHelpers.TileSize * (row + 1) + LoZHelpers.HUDHeight);
            if (fileLocation.Equals("Content\\LevelLoading\\SecretRoom.csv"))
                tileLocation = new Vector2(LoZHelpers.TileSize * column, LoZHelpers.TileSize * (row + 1) + LoZHelpers.HUDHeight);

            Vector2 smallItemLocation = tileLocation + new Vector2(LoZHelpers.TileSize / 4, 0);
            Vector2 doorLocationUp = tileLocation - new Vector2(0, LoZHelpers.TileSize);
            Vector2 doorLocationDown = tileLocation;
            Vector2 doorLocationRight = tileLocation - new Vector2(0, LoZHelpers.TileSize / 2);
            Vector2 doorLocationLeft = tileLocation - new Vector2(LoZHelpers.TileSize, LoZHelpers.TileSize / 2);

            switch (gameObjectID)
            {
                case -3:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.Left));
                    break;
                case -2:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.Right));
                    break;
                case -1:
                    AddIObject(new InvisibleBlock(tileLocation, Direction.None));
                    break;
                case 1:
                    AddIObject(new RaisedBlock(tileLocation));
                    break;
                case 2:
                    AddIObject(new BlueGargoyleStatue(tileLocation));
                    break;
                case 3:
                    AddIObject(new BlueDragonStatue(tileLocation));
                    break;
                case 4:
                    AddIObject(new DarkBlock(tileLocation));
                    break;
                case 5:
                    AddIObject(new DottedBlock(tileLocation));
                    break;
                case 6:
                    AddIObject(new Water(tileLocation));
                    break;
                case 7:
                    AddIObject(new GargoyleStatue(tileLocation));
                    break;
                case 8:
                    AddIObject(new StoneWall(tileLocation));
                    break;
                case 9:
                    AddIObject(new Ladder(tileLocation));
                    break;
                case 10:
                    AddIObject(new OpenDoorUp(game, doorLocationUp));
                    AddIObject(new LockedDoorUp(doorLocationUp));
                    break;
                case 11:
                    AddIObject(new OpenDoorDown(game, doorLocationDown));
                    AddIObject(new LockedDoorDown(doorLocationDown));
                    break;
                case 13:
                    AddIObject(new OpenDoorRight(game, doorLocationRight));
                    AddIObject(new LockedDoorRight(doorLocationRight));
                    break;
                case 14:
                    AddIObject(new OpenDoorLeft(game, doorLocationLeft));
                    AddIObject(new LockedDoorLeft(doorLocationLeft));
                    break;
                case 15:
                    AddIObject(new OpenDoorUp(game, doorLocationUp));
                    break;
                case 16:
                    AddIObject(new OpenDoorDown(game, doorLocationDown));
                    break;
                case 17:
                    AddIObject(new OpenDoorRight(game, doorLocationRight));
                    break;
                case 18:
                    AddIObject(new OpenDoorLeft(game, doorLocationLeft));
                    break;
                case 20:
                    AddIObject(new OpenDoorLeft(game, doorLocationLeft));
                    AddIObject(new ClosedDoorLeft(doorLocationLeft));
                    break;
                case 21:
                    AddIObject(new OpenDoorRight(game, doorLocationRight));
                    AddIObject(new ClosedDoorRight(doorLocationRight));
                    break;
                case 23:
                    AddIObject(new WallUp(doorLocationUp));
                    break;
                case 24:
                    AddIObject(new WallDown(doorLocationDown));
                    break;
                case 25:
                    AddIObject(new WallLeft(doorLocationLeft));
                    break;
                case 26:
                    AddIObject(new WallRight(doorLocationRight));
                    break;
                case 27:
                    AddIObject(new TunnelFaceUp(game, doorLocationUp));
                    AddIObject(new BombableWallUp(doorLocationUp));
                    break;
                case 28:
                    AddIObject(new TunnelFaceDown(game, doorLocationDown));
                    AddIObject(new BombableWallDown(doorLocationDown));
                    break;
                case 29:
                    AddIEnemy(new Keese(tileLocation));
                    break;
                case 30:
                    AddIEnemy(new Stalfos(tileLocation));
                    break;
                case 31:
                    AddIEnemy(new Wallmaster(tileLocation));
                    break;
                case 32:
                    AddIEnemy(new Goriya(game, tileLocation));
                    break;
                case 33:
                    AddIEnemy(new Gel(tileLocation));
                    break;
                case 34:
                    AddIEnemy(new Aquamentus(game, tileLocation));
                    break;
                case 35:
                    AddIEnemy(new BladeTrap(tileLocation));
                    break;
                case 39:
                    AddIItem(new Key(smallItemLocation));
                    break;
                case 40:
                    AddIItem(new Compass(smallItemLocation));
                    break;
                case 41:
                    AddIItem(new Boomerang(smallItemLocation));
                    break;
                case 42:
                    AddIItem(new Map(smallItemLocation));
                    break;
                case 43:
                    AddIObject(new DragonStatue(tileLocation));
                    break;
                case 44:
                    AddIObject(new Stairs(game, tileLocation));
                    break;
                case 45:
                    AddIObject(new MovableRaisedBlock(tileLocation));
                    break;
                case 46:
                    AddIEnemy(new Wizard(game, tileLocation));
                    break;
                case 47:
                    AddIItem(new BlueRing(smallItemLocation));
                    break;
                case 48:
                    AddIItem(new Bomb(smallItemLocation));
                    break;
                case 49:
                    AddIItem(new Bow(smallItemLocation));
                    break;
                case 50:
                    AddIItem(new Clock(smallItemLocation));
                    break;
                case 51:
                    AddIItem(new Fairy(smallItemLocation));
                    break;
                case 52:
                    AddIItem(new Heart(smallItemLocation));
                    break;
                case 53:
                    AddIItem(new HeartContainer(smallItemLocation));
                    break;
                case 54:
                    AddIItem(new LifePotion(smallItemLocation));
                    break;
                case 55:
                    AddIItem(new NoHealthHeart(smallItemLocation));
                    break;
                case 56:
                    AddIItem(new Sword(smallItemLocation));
                    break;
                case 57:
                    AddIItem(new TriForcePiece(smallItemLocation));
                    break;
                case 58:
                    AddIItem(new BlueCandle(smallItemLocation));
                    break;
                case 59:
                    AddIItem(new BlueRupee(smallItemLocation));
                    break;
                case 60:
                    AddIItem(new FlashingRupee(smallItemLocation));
                    break;
                case 61:
                    AddIItem(new HalfHealthHeart(smallItemLocation));
                    break;
                case 62:
                    AddIItem(new HalfHealthHeart(smallItemLocation));
                    break;
                case 63:
                    AddIItem(new LifePotion(smallItemLocation));
                    break;
                case 64:
                    AddIObject(new LadderDoor(game, tileLocation));
                    break;
                default:
                    break;
            }
        }

        private void AddIEnemy(IEnemy enemy) => game.Enemies.Add(enemy);
        private void AddIItem(IItem item) => game.Items.Add(item);
        private void AddIObject(IObject block) => game.Objects.Add(block);
    }
}
