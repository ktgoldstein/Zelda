﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.LevelLoading
{

    public class MapSprite : ISprite
    {
        private int columns;
        private int rows;
        private int currentFrame = 0;
        private int totalFrames;
        private Texture2D texture;
        private int frameDelay = 0;
        private float animationSpeed;


        public MapSprite(Texture2D texture, int columns, int rows, int totalFrames, float animationSpeed = 5)
        {
            this.texture = texture;
            this.columns = columns;
            this.rows = rows;
            this.totalFrames = totalFrames;
            this.animationSpeed = animationSpeed;

        }
        public void Update()
        {

            frameDelay++;
            if (frameDelay == animationSpeed)
            {
                frameDelay = 0;
                currentFrame++;
                if (currentFrame >= totalFrames)
                {
                    currentFrame = 0;
                }
            }
        }
        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 5, height * 5);

            spritebatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

}
