using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IEnemy
    {
        public Vector2 Location { get; set; }
        public int Width { get; }
        public int Height { get; }
        public int Health { get; set; }
        public void Update();
        public void Draw(SpriteBatch spritebatch);
    }
}
