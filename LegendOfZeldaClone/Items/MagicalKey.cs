using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class MagicalKey : IItem
    {
        private ISprite magicKey;
        private Vector2 location;

        public MagicalKey(Vector2 location)
        {
            magicKey = ItemSpriteFactory.Instance.CreateMagicalKey();
            this.location = location;
        }
    }
}
