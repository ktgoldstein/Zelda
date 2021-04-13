using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    class BlockFactory 
    {
        public static BlockFactory Instance { get; } = new BlockFactory();
        private BlockFactory() { }

        public IBlock CreateBlueDragonStatue(Vector2 location)
        {
            return new StaticBlock(location,
                BlockSpriteFactory.Instance.CreateBlueDragonStatue(),
                16,
                16,
                ObjectHeight.CanFlyOver,
                false);
        }
    }
}