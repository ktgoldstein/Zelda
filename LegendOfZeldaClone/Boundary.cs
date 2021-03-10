using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Boundary
    { 
        public Vector2 Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Boundary(Vector2 location, int width, int height)
        {
            Location = location;
            Width = width;
            Height = height;
        }
    }
}
