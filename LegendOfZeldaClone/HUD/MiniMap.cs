using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class MiniMap : ISprite
    {
        private ISprite sprite;
        private Vector2 location;

        public MiniMap(Vector2 location)
        {
            sprite = HUDTextureFactory.Instance.CreateMiniMap();
            this.location = location;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => sprite.Draw(spriteBatch, location);
    }
}
