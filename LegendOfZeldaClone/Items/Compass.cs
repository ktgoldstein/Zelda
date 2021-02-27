using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Compass : IItem
    {
        private ISprite compass;
        private Vector2 location;

        public Compass(Vector2 location)
        {
            compass = ItemSpriteFactory.Instance.CreateCompass();
            this.location = location;
        }
    }
}
