using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class MiniMap : ISprite
    {
        private ISprite sprite;
        private ISprite linkLocation;
        private Vector2 location;

        private bool hasMap { get; }

        public MiniMap(Vector2 location)
        {
            //draw dot initially (Do I use LocationTracking.Draw() method here?) 
            //linkLocation = HUDTextureFactory.Instance.CreateLocationTracker();
            sprite = HUDTextureFactory.Instance.CreateMiniMap();
            this.location = location;
        }

        public void Update() {

            // If map obtained, draw the map (Collision handeler?) (How do I get access to Inventory list?)

            // Whatever room link is in, draw the white dot (over the map if collected) (LevelLoading?) (Do I use LocationTracking.Update() method here?)

            // If compass is collected, flash Tri-Force room (over the map if collected) (Collision handeler?) (How do I get access to Inventory list?)

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => sprite.Draw(spriteBatch, location);
    }
}
