using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class PauseMap : ISprite
    {
        private ISprite sprite;
        private Vector2 location;

        public PauseMap(Vector2 location)
        {
            sprite = HUDTextureFactory.Instance.CreatePauseMap();
            this.location = location;
        }

        public void Update() {

            // Check to see what room Link's in
            // If we've never been in this room, draw it on the map
            // For drawing, either create a lot of different sprites with different combos or ask about .csv files
            // Also track location with white dot
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => sprite.Draw(spriteBatch, location);
    }
}
