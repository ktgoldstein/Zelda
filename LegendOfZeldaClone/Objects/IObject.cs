using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.Objects
{
    public interface IObject
    {
        public int Width { get;}
        public int Height { get;}
        public Vector2 Location { get; set; }
        public void Update();
        public void Draw(SpriteBatch spritebatch);

    }
}
