using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone.Display
{
    public class Camera
    {
        private Vector2 position;
        private Vector2 targetPosition;
        private int speed = LoZHelpers.Scale(8);

        public Camera(Viewport viewport) 
        {
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
                    targetPosition = position + new Vector2(-LoZHelpers.GameWidth, 0);
                    break;
                default:
                    break;
            }
            
        }

        public void Update()
        {
            if (targetPosition != position)
            {
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                position += direction * speed;
            }
        }

        public Matrix Translation()
        {
            return Matrix.CreateTranslation(position.X, position.Y, 0);
        }     
    }    
}
