using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class FlashingRupee: IItem
    {
        private ISprite rupee;
        private Vector2 location;

        public FlashingRupee(Vector2 location)
        {
            rupee = ItemSpriteFactory.Instance.CreateFlashingRupee();
            this.location = location;
        }
    }
}
