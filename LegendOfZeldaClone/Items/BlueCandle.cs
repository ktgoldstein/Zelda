using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class BlueCandle : IItem
    {
        private ISprite blueCandle;
        private Vector2 location;

        public BlueCandle(Vector2 location)
        {
            blueCandle = ItemSpriteFactory.Instance.CreateBlueCandle();
            this.location = location;
        }
    }
}
