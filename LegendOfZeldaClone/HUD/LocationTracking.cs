using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{

    public class LocationTracking : ISprite
    {
        private ISprite sprite;
        private Vector2 location;

        private bool hasMap { get; }

        public LocationTracking(Vector2 location)
        {
            sprite = HUDTextureFactory.Instance.CreateLocationTracker();
            this.location = location;
        }

        public void Update() {

            /* 
                -Whatever room link is in, draw the white dot (over the map if collected) (LevelLoading?)
                -Maybe door collision handler? If he collides with up, left, right door move x/y position of dot
                -Indicator is a 3x3 square. Needs to go to middle of minimap room rectangle
                -y = +/- 4 (Up/Down)
                -x = +/- 8 (Left/Right)

            */

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector) => sprite.Draw(spriteBatch, location);
    }
}
