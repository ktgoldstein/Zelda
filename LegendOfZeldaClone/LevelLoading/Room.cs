using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Objects;

namespace LegendOfZeldaClone.LevelLoading
{

    public class Room
    {
        public Texture2D tiles;
        public Texture2D exterior;
        //Why public -Yonace
        private Texture2D background;
        
        private List<List<int>> data;
        String fileLocation;
        private LegendOfZeldaDungeon game;
        public Room(String fileLocation, LegendOfZeldaDungeon game)
        {
            this.game = game;
            this.fileLocation = fileLocation;
            tiles = RoomTextureFactory.Instance.tiles;
            exterior = RoomTextureFactory.Instance.roomExterior;
            background = RoomTextureFactory.Instance.background;
            
            
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

        public void RenderRoom(SpriteBatch spritebatch)
        {

            //Rectangle sourceRectangle = new Rectangle(0, 0, 240, 160);
            //Rectangle destinationRectangle = new Rectangle(0, 0, 240*3, 160*3);
            Rectangle sourceRectangle = new Rectangle(522, 11, 256, 176);
            Rectangle destinationRectangle = new Rectangle(0, 192, 256 *3, 176 * 3);

            spritebatch.Draw(background, destinationRectangle, sourceRectangle, Color.White);

            sourceRectangle = new Rectangle(1, 192, 192, 112);
            destinationRectangle = new Rectangle(96, 288, 192 * 3, 112 * 3);

            //spritebatch.Draw(exterior, destinationRectangle, sourceRectangle, Color.White);
            spritebatch.Draw(tiles, destinationRectangle, sourceRectangle, Color.White);

            

            for (int row = 0; row < data.Count; row++)
            {
                for (int column = 0; column < data[row].Count; column++)
                {
                    
                    int width = 16;
                    int height = 16;
                    Vector2 tileLocation = new Vector2((width * column + 16) * 3 , (height * row + 80) * 3);
                    
                    Vector2 doorLocationUp = new Vector2((width * column + 16) * 3, (height * row + 64) * 3);
                    Vector2 doorLocationDown = new Vector2((width * column + 16) * 3, (height * row + 80) * 3);
                    Vector2 doorLocationRight = new Vector2((width * column + 16) * 3, (height * row + 88) * 3);
                    Vector2 doorLocationLeft = new Vector2((width * column) * 3, 408);
                    
                    //int sourceRow = data[row][column] / 4;
                    //int sourceCol = data[row][column] % 4;
                    //sourceRectangle = new Rectangle(width * sourceCol, height * sourceRow, width, height);

                    int source = data[row][column];

                    switch (source)
                    {
                        case 2:
                            IObject blueGargoyle = new BlueGargoyleStatue(tileLocation);
                            blueGargoyle.Draw(spritebatch);
                            break;
                        case 3:
                            IObject blueDragon = new BlueDragonStatue(tileLocation);
                            blueDragon.Draw(spritebatch);
                            break;
                        case 5:
                            IObject db = new DottedBlock(tileLocation);
                            db.Draw(spritebatch);
                            break;
                        case 20:
                            IObject odr = new OpenDoorRight(doorLocationRight);
                            odr.Draw(spritebatch);
                            break;
                        case 21:
                            IObject ldu = new LockedDoorUp(doorLocationUp);
                            ldu.Draw(spritebatch);
                            break;
                        case 22:
                            IObject odd = new OpenDoorDown(doorLocationDown);
                            odd.Draw(spritebatch);
                            break;
                        case 23:
                            IObject odl = new OpenDoorLeft(doorLocationLeft);
                            odl.Draw(spritebatch);
                            break;
                        default:
                            break;
                    }
                  
                }
            }
        }
    }
}
