using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone
{
    public class LinkDyingSprite : ILinkSprite
    {
        public int CurrentFrame { get; set; }

        private readonly Texture2D linkTexture;
        private readonly Texture2D gameOverSparkleTexture;
        private readonly int totalFrames;
        //private readonly int xCoordStart;
        private readonly int yCoordStart;
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
            totalFrames = 150;
            //xCoordStart = x;
            yCoordStart = y;
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
            if (CurrentFrame <= 136) //link texture sprite sheet
            {
                if (CurrentFrame <= 80) //for frames 1->80
                {
                    switch (CurrentFrame / 4)
                    {
                        case 1:
                            sourceRectangle = new Rectangle(xCoordRight, yCoordStart, width, height); //standing right sprite
                            break;
                        case 2:
                            sourceRectangle = new Rectangle(xCoordUp, yCoordStart, width, height); //standing up sprite
                            break;
                        case 3:
                            sourceRectangle = new Rectangle(xCoordLeft, yCoordStart, width, height); //standing left sprite
                            break;
                        case 4:
                            sourceRectangle = new Rectangle(xCoordDown, yCoordStart, width, height); //standing down sprite
                            break;
                        default:
                            sourceRectangle = new Rectangle(0, 0, width, height);
                            break;
                    }
                }
                else if (CurrentFrame <= 112) //for frames 81->112
                {
                    sourceRectangle = new Rectangle(xCoordDown, yCoordStart, width, height); //standing down sprite
                }
                else //for frames 113->136
                {
                    sourceRectangle = new Rectangle(xCoordDown, yCoordStart, width, height); //WHITE standing down sprite
                }
                
                
                spriteBatch.Draw(linkTexture, destinationRectangle, sourceRectangle, Color.White);

            }
            else //gameover sparkle texture sprite sheet
            {
                 if (CurrentFrame <= 146)
                {
                    sourceRectangle = new Rectangle(xCoordDown, yCoordStart, width, height); //sparkle frame type one
                                                                                             //re-assign texture in here
                }
                else //the remainder of the frames up until 150
                {
                    sourceRectangle = new Rectangle(xCoordDown, yCoordStart, width, height); //sparkle frame type two
                                                                                             //re-assign texture in here
                }

                spriteBatch.Draw(gameOverSparkleTexture, destinationRectangle, sourceRectangle, Color.White);
            }
           
           /*will need a different texture for the enemy death sparkle thing*/
        }
    }
}
