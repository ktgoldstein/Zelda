﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ObjectSprite : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;
        private int sourcePosX;
        private int sourcePosY;
        public ObjectSprite(Texture2D texture, int height, int width, int sourcePosX, int sourcePosY)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
            this.sourcePosX = sourcePosX;
            this.sourcePosY = sourcePosY;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(sourcePosX, sourcePosY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 3, height * 3);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    
}