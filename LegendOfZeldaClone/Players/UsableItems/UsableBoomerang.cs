using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBoomerang : IUsableItem
    {
        private readonly LegendOfZeldaDungeon game;
        private readonly BoomerangSkinType skinType;

        public UsableBoomerang(LegendOfZeldaDungeon game, BoomerangSkinType skinType)
        {
            this.game = game;
            this.skinType = skinType;
        }

        public void Use(Vector2 location, Direction direction)
        {
            game.PlayerProjectilesQueue.Add(new BoomerangProjectile(location, direction, skinType, game, game.Player));
        }
    }
}
