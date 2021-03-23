using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone.Display
{
    public class Camera
    {
        private Vector2 position;

        private Viewport viewport;
        public Camera(Viewport viewport) 
        {
            this.viewport = viewport;
            position.X = 0;
            position.Y = 0;
        }
        public void CameraTransition(Direction direction)
        {
            switch (direction)
            {
                //case Direction.Up:
                //    while (posY != 720)
                //        viewport.X += 8;
                //    break;
                //case Direction.Down:
                //    while (posY != -720)
                //        viewport.X -= 8;
                //    break;
                //case Direction.Right:
                //    while (posX != 768)
                //        viewport.X += 8;
                //    break;
                case Direction.Left:
                    viewport.X -= 8;
                    Console.WriteLine("HERE 2");
                    break;
                default:
                    break;
            }
            
        }
        public Matrix Translation()
        {
            return Matrix.CreateTranslation(position.X, position.Y, 0);
        } 
            

    }
    
}
