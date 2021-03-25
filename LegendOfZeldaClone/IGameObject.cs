using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IGameObject 
    {
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get; set; }
        public int Width { get; }
        public int Height { get; }
        public bool Alive { get; set; }
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}