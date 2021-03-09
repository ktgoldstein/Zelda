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
        public Vector2 Direction { get; set; }
        public bool Invincible { get; set; }
        public bool Alive { get; set; }
        public void Update();
        public void Draw(SpriteBatch spritebatch);
        public void Knockback(Vector2 direction);
    }
}
