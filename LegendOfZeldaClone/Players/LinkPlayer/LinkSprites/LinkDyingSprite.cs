using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkDyingSprite : ILinkSprite
    {
        public int CurrentFrame { get; set; }

        private readonly Texture2D linkTexture;
        private readonly Texture2D gameOverSparkleTexture;
        private readonly int totalFrames;
        //private readonly int xCoordStart;
        private readonly int yCoordBaseColor;
        private readonly int yCoordDyingColor;
        private readonly int width;
        private readonly int height;
        private readonly int atlasGap;
        private readonly int xCoordRight;
        private readonly int xCoordUp;
        private readonly int xCoordLeft;
        private readonly int xCoordDown;

        public LinkDyingSprite(Texture2D linkSpriteSheet, Texture2D gameOverSparkleSpriteSheet, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap, int currentFrame = 0)
        {
            CurrentFrame = currentFrame;
            linkTexture = linkSpriteSheet;
            gameOverSparkleTexture = gameOverSparkleSpriteSheet;
            totalFrames = 55;
            yCoordBaseColor = y;
            yCoordDyingColor = (int)LinkSkinType.DyingLink * (width + atlasGap);
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;
            xCoordRight = x;
            xCoordUp = (int)LinkSpriteType.FacingUp * (width + atlasGap);
            xCoordLeft = (int)LinkSpriteType.FacingLeft * (width + atlasGap);
            xCoordDown = (int)LinkSpriteType.FacingDown * (width + atlasGap);

        }

        public bool AnimationDone() => CurrentFrame == totalFrames;
        public void Reset() => CurrentFrame = 0;
        public void Update() => CurrentFrame += CurrentFrame < totalFrames ? 1 : 0;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle sourceRectangle;
            Color tintColor = Color.White;
            if (CurrentFrame <= 50) //**link texture sprite sheet**
            {
                if (CurrentFrame <= 32) //for frames 1->32
                {
                    switch ((CurrentFrame / 2) % 4)
                    {
                        case 1:
                            sourceRectangle = new Rectangle(xCoordRight, yCoordBaseColor, width, height); //standing right sprite
                            break;
                        case 2:
                            sourceRectangle = new Rectangle(xCoordUp, yCoordBaseColor, width, height); //standing up sprite
                            break;
                        case 3:
                            sourceRectangle = new Rectangle(xCoordLeft, yCoordBaseColor, width, height); //standing left sprite
                            break;
                        case 4:
                            sourceRectangle = new Rectangle(xCoordDown, yCoordBaseColor, width, height); //standing down sprite
                            break;
                        default:
                            sourceRectangle = new Rectangle(xCoordDown, yCoordDyingColor, width, height);
                            break;
                    }
                }
                else if (CurrentFrame <= 36) //for frames 33->36
                 sourceRectangle = new Rectangle(xCoordDown, yCoordBaseColor, width, height); //standing down sprite

                else if (CurrentFrame <= 50) //for frames 36->50--RED standing down sprite
                {
                    sourceRectangle = new Rectangle(xCoordDown, yCoordBaseColor, width, height);
                    tintColor = Color.Red;
                }
                else
                    sourceRectangle = new Rectangle(0, 0, 0, 0);

                spriteBatch.Draw(linkTexture, destinationRectangle, sourceRectangle, tintColor);
            }
            else //**gameover sparkle texture sprite sheet**
            {
                if (CurrentFrame <= 52)
                    sourceRectangle = new Rectangle(0, 0, width, height); //sparkle frame type one

                else if (CurrentFrame <= 54) //the remainder of the frames up until 54
                    sourceRectangle = new Rectangle(width, 0, width, height); //sparkle frame type two
                else
                    sourceRectangle = new Rectangle(0, 0, 0, 0);
                spriteBatch.Draw(gameOverSparkleTexture, destinationRectangle, sourceRectangle, Color.White);
            }
        }
    }
}
