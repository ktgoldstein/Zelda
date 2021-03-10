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
        private Texture2D tiles;
        private Texture2D background;
        //private Texture2D backgroundFix;

        private List<List<int>> data;
        private String fileLocation;
        private List<IObject> objects;
        private List<IEnemy> enemies;
        public Room(String fileLocation)
        {
            
            this.fileLocation = fileLocation;
            tiles = RoomTextureFactory.Instance.tiles;
            background = RoomTextureFactory.Instance.background;
            objects = new List<IObject>(); 
            enemies = new List<IEnemy>();
            //backgroundFix = RoomTextureFactory.Instance.backgroundFix;


        }
        public void LoadRoom()
        {
            data = new List<List<int>>();
            var lines = File.ReadLines(fileLocation);
            foreach (var line in lines)
            {
                var splitLine = line.Split(",");
                var row = Array.ConvertAll(splitLine, s => int.Parse(s));
                data.Add(new List<int>((row)));
            }
        }
        public List<IObject> GetObjectCollisionList()
        {
            return objects;
        }
        public List<IEnemy> GetEnemiesCollisionList()
        {
            return enemies;
        }
        public void RenderRoom(SpriteBatch spritebatch)
        {

            Rectangle sourceRectangle = new Rectangle(522, 11, 256, 176);
            Rectangle destinationRectangle = new Rectangle(0, 192, 256 *3, 176 * 3);

            if (!fileLocation.Equals("Content\\LevelLoading\\SecretRoom.csv"))
            {
                //spritebatch.Draw(backgroundFix, destinationRectangle, sourceRectangle, Color.White);
                spritebatch.Draw(background, destinationRectangle, sourceRectangle, Color.White);
            }
            sourceRectangle = new Rectangle(2, 192, 192, 112);
            destinationRectangle = new Rectangle(96, 288, 192 * 3, 112 * 3);

            spritebatch.Draw(tiles, destinationRectangle, sourceRectangle, Color.White);

            

            for (int row = 0; row < data.Count; row++)
            {
                for (int column = 0; column < data[row].Count; column++)
                {
                    
                    int width = 16;
                    int height = 16;
                    Vector2 tileLocation = new Vector2((width * column + 16) * 3, (height * row + 80) * 3);
                    if (fileLocation.Equals("Content\\LevelLoading\\SecretRoom.csv"))
                    {
                        tileLocation = new Vector2((width * column) * 3, (height * row + 80) * 3);

                    }
                        
                    Vector2 smallItemLocation = new Vector2((width * column + 20) * 3, (height * row + 80) * 3);
                    Vector2 doorLocationUp = new Vector2((width * column + 16) * 3, (height * row + 64) * 3);
                    Vector2 doorLocationDown = new Vector2((width * column + 16) * 3, (height * row + 80) * 3);
                    Vector2 doorLocationRight = new Vector2((width * column + 16) * 3, (height * row + 88) * 3);
                    Vector2 doorLocationLeft = new Vector2((width * column) * 3, 408);   

                    int source = data[row][column];

                    switch (source)
                    {
                        case 1:
                            IObject raisedBlock = new RaisedBlock(tileLocation);
                            raisedBlock.Draw(spritebatch);
                            objects.Add(raisedBlock);
                            break;
                        case 2:
                            IObject blueGargoyle = new BlueGargoyleStatue(tileLocation);
                            blueGargoyle.Draw(spritebatch);
                            objects.Add(blueGargoyle);
                            break;
                        case 3:
                            IObject blueDragon = new BlueDragonStatue(tileLocation);
                            blueDragon.Draw(spritebatch);
                            objects.Add(blueDragon);
                            break;
                        case 4:
                            IObject blackTile = new DarkBlock(tileLocation);
                            blackTile.Draw(spritebatch);
                            objects.Add(blackTile);
                            break;
                        case 5:
                            IObject dottedBlock = new DottedBlock(tileLocation);
                            dottedBlock.Draw(spritebatch);
                            objects.Add(dottedBlock);
                            break;
                        case 6:
                            IObject water = new Water(tileLocation);
                            water.Draw(spritebatch);
                            objects.Add(water);
                            break;
                        case 7:
                            IObject gargoyle = new GargoyleStatue(tileLocation);
                            gargoyle.Draw(spritebatch);
                            objects.Add(gargoyle);
                            break;
                        case 8:
                            IObject stone = new StoneWall(tileLocation);
                            stone.Draw(spritebatch);
                            objects.Add(stone);
                            break;
                        case 9:
                            IObject ladder = new Ladder(tileLocation);
                            ladder.Draw(spritebatch);
                            objects.Add(ladder);
                            break;
                        case 10:
                            IObject keyDoorUp = new KeyDoorUp(doorLocationUp);
                            keyDoorUp.Draw(spritebatch);
                            objects.Add(keyDoorUp);
                            break;
                        case 11:
                            IObject keyDoorDown = new KeyDoorDown(doorLocationDown);
                            keyDoorDown.Draw(spritebatch);
                            objects.Add(keyDoorDown);
                            break;
                        case 13:
                            IObject keyDoorRight = new KeyDoorRight(doorLocationRight);
                            keyDoorRight.Draw(spritebatch);
                            objects.Add(keyDoorRight);
                            break;
                        case 14:
                            IObject keyDoorLeft = new KeyDoorLeft(doorLocationLeft);
                            keyDoorLeft.Draw(spritebatch);
                            objects.Add(keyDoorLeft);
                            break;
                        case 15:
                            IObject openDoorUp = new OpenDoorUp(doorLocationUp);
                            openDoorUp.Draw(spritebatch);
                            objects.Add(openDoorUp);
                            break;
                        case 16:
                            IObject openDoorDown = new OpenDoorDown(doorLocationDown);
                            openDoorDown.Draw(spritebatch);
                            objects.Add(openDoorDown);
                            break;
                        case 17:
                            IObject openDoorRight = new OpenDoorRight(doorLocationRight);
                            openDoorRight.Draw(spritebatch);
                            objects.Add(openDoorRight);
                            break;
                        case 18:
                            IObject openDoorLeft = new OpenDoorLeft(doorLocationLeft);
                            openDoorLeft.Draw(spritebatch);
                            objects.Add(openDoorLeft);
                            break;
                        case 20:
                            IObject lockedDoorLeft = new LockedDoorLeft(doorLocationLeft);
                            lockedDoorLeft.Draw(spritebatch);
                            objects.Add(lockedDoorLeft);
                            break;
                        case 21:
                            IObject lockedDoorRight = new LockedDoorRight(doorLocationRight);
                            lockedDoorRight.Draw(spritebatch);
                            objects.Add(lockedDoorRight);
                            break;
                        case 23:
                            IObject wallFaceUp = new WallUp(doorLocationUp);
                            wallFaceUp.Draw(spritebatch);
                            objects.Add(wallFaceUp);
                            break;
                        case 24:
                            IObject wallFaceDown = new WallDown(doorLocationDown);
                            wallFaceDown.Draw(spritebatch);
                            objects.Add(wallFaceDown);
                            break;
                        case 25:
                            IObject wallFaceLeft = new WallLeft(doorLocationLeft);
                            wallFaceLeft.Draw(spritebatch);
                            objects.Add(wallFaceLeft);
                            break;
                        case 26:
                            IObject wallFaceRight = new WallRight(doorLocationRight);
                            wallFaceRight.Draw(spritebatch);
                            objects.Add(wallFaceRight);
                            break;
                        case 27:
                            IObject tunnelFaceUp = new TunnelFaceUp(doorLocationUp);
                            tunnelFaceUp.Draw(spritebatch);
                            objects.Add(tunnelFaceUp);
                            break;
                        case 28:
                            IObject tunnelFaceDown = new TunnelFaceDown(doorLocationDown);
                            tunnelFaceDown.Draw(spritebatch);
                            objects.Add(tunnelFaceDown);
                            break;
                        case 29:
                            IEnemy keese = new Keese(tileLocation);
                            keese.Draw(spritebatch);
                            enemies.Add(keese);
                            break;
                        case 30:
                            IEnemy stalfos = new Stalfos(tileLocation);
                            stalfos.Draw(spritebatch);
                            enemies.Add(stalfos);
                            break;
                        case 31:
                            IEnemy wallMaster = new Wallmaster(tileLocation);
                            wallMaster.Draw(spritebatch);
                            enemies.Add(wallMaster);
                            break;
                        case 32:
                            IEnemy goriya = new Goriya(tileLocation);
                            goriya.Draw(spritebatch);
                            enemies.Add(goriya);
                            break;
                        case 33:
                            IEnemy gel = new Gel(tileLocation);
                            gel.Draw(spritebatch);
                            enemies.Add(gel);
                            break;
                        case 34:
                            IEnemy aquamentus = new Aquamentus(tileLocation);
                            aquamentus.Draw(spritebatch);
                            enemies.Add(aquamentus);
                            break;
                        case 35:
                            IEnemy bladeTrap = new BladeTrap(tileLocation);
                            bladeTrap.Draw(spritebatch);
                            enemies.Add(bladeTrap);
                            break;
                        //case 39:
                        //    IItem key = new Key(smallItemLocation);
                        //    key.Draw(spritebatch);
                        //    break;
                        //case 40:
                        //    IItem compass = new Compass(smallItemLocation);
                        //    compass.Draw(spritebatch);
                        //    break;
                        //case 41:
                        //    IItem boomerang = new Boomerang(smallItemLocation);
                        //    boomerang.Draw(spritebatch);
                        //    break;
                        //case 42:
                        //    IItem map = new Map(smallItemLocation);
                        //    map.Draw(spritebatch);
                        //    break;
                        case 43:
                            IObject dragon = new DragonStatue(tileLocation);
                            dragon.Draw(spritebatch);
                            objects.Add(dragon);
                            break;
                        case 44:
                            IObject stairs = new Stairs(tileLocation);
                            stairs.Draw(spritebatch);
                            objects.Add(stairs);
                            break;
                        default:
                            break;
                    }
                  
                }
            }
        }
    }
}
