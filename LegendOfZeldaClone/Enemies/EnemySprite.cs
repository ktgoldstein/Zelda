using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone.Enemy
{
    public class EnemySprite : ISprite
    {
        private Texture2D texture;
        private readonly int columns;
        private readonly int rows;
        private readonly int atlasGap;
        private readonly int totalFrames;
        private int currentFrame;
        private int frameDelay;
        private readonly int animationSpeed;
        private Color color;
        Random random = new Random();

        public EnemySprite(Texture2D texture, int columns, int rows, int atlasGap, int totalFrames, int animationSpeed = 5, Color? color = null)
        {
            this.texture = texture;
            this.columns = columns;
            this.rows = rows;
            this.atlasGap = atlasGap;
            this.totalFrames = totalFrames;
            this.animationSpeed = animationSpeed + random.Next() % 2;
            this.color = color ?? Color.White;

            currentFrame = 0;
            frameDelay = 0;
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
            int width = texture.Width / columns - atlasGap;
            int height = texture.Height / rows - atlasGap;
            int row = currentFrame / columns;
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle((width + atlasGap) * column, (height + atlasGap) * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spritebatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
