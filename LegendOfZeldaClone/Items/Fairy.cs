using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Fairy : IItem
    {
        private ISprite fairy;
        private Vector2 location;

        public Fairy(Vector2 location)
        {
            fairy = ItemSpriteFactory.Instance.CreateFairy();
            this.location = location;
        }
    }
}
