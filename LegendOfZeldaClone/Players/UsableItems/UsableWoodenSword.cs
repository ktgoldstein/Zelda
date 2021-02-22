using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableWoodenSword : IUsableItem
    {
        private readonly LegendOfZeldaDungeon game;

        public UsableWoodenSword(LegendOfZeldaDungeon game) => this.game = game;

        public void Use(Vector2 location, Direction direction)
        {
            game.LinkProjectilesQueue.Add(new SwordProjectile(location, SwordSkinType.WoodenSword, direction, game));
        }
    }
}
