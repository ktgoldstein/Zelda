using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class BlueRupee : IItem
    {
        private ISprite blueRupee;
        private Vector2 location;

        public BlueRupee(Vector2 location)
        {
            blueRupee = ItemSpriteFactory.Instance.CreateBlueRupee();
            this.location = location;
        }
    }
}
