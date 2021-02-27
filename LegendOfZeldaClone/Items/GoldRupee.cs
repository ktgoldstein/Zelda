using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class GoldRupee : IItem
    {
        private ISprite goldRupee;
        private Vector2 location;

        public GoldRupee(Vector2 location)
        {
            goldRupee = ItemSpriteFactory.Instance.CreateGoldRupee();
            this.location = location;
        }
    }
}
