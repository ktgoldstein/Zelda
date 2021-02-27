using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Key : IItem
    {
        private ISprite key;
        private Vector2 location;

        public Key(Vector2 location)
        {
            key = ItemSpriteFactory.Instance.CreateKey();
            this.location = location;
        }
    }
}
