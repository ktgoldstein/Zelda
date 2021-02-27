using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class HeartContainer : IItem
    {
        private ISprite heartContainer;
        private Vector2 location;

        public HeartContainer(Vector2 location)
        {
            heartContainer = ItemSpriteFactory.Instance.CreateHeartContainer();
            this.location = location;
        }
    }
}
