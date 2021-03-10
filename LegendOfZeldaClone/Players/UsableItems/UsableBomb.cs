using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBomb : IUsableItem
    {
        private readonly LegendOfZeldaDungeon game;

        public UsableBomb(LegendOfZeldaDungeon game) => this.game = game;

        public void Use(Vector2 location, Direction direction)
        {
            game.PlayerProjectilesQueue.Add(new BombProjectile(game, location, direction));
        }
    }
}
