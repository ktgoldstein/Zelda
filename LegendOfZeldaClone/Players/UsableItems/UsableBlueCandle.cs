using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBlueCandle : IUsableItem
    {
        private readonly LegendOfZeldaDungeon game;

        public UsableBlueCandle(LegendOfZeldaDungeon game) => this.game = game;

        public void Use(Vector2 location, Direction direction)
        {
            game.LinkProjectilesQueue.Add(new FireProjectile(location, direction));
        }
    }
}
