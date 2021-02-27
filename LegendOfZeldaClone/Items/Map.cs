using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Map : IItem
    {
        private ISprite map;
        private Vector2 location;

        public Map(Vector2 location)
        {
            map = ItemSpriteFactory.Instance.CreateMap();
            this.location = location;
        }
    }
}
