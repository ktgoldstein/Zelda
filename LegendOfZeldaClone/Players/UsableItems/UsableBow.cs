using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBow : IUsableItem
    {
        private readonly LegendOfZeldaDungeon game;
        private readonly ArrowSkinType skinType;

        public UsableBow(LegendOfZeldaDungeon game, ArrowSkinType skinType)
        {
            this.game = game;
            this.skinType = skinType;
        }

        public void Use(Vector2 location, Direction direction)
        {
            game.PlayerProjectilesQueue.Add(new ArrowProjectile(location, direction, skinType));
        }
    }
}
