using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone.Display
{
    public class Camera
    {
        private Vector2 Location;

        private Viewport viewport;
        private int x;
        public Camera(Viewport viewport) 
        {
            this.viewport = viewport;
            Location.X = 768;
            Location.Y = 720;
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
                    while (x!= -768)
                    {
                        Location.X = -8;
                        Console.WriteLine("HERE 2");
                        x -= 8;
                        
                    }
                    break;
                default:
                    break;
            }
            
        }
        public Matrix Translation()
        {
            return Matrix.CreateTranslation(Location.X, Location.Y, 0);
        } 
            

    }
    
}
