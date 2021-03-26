using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableBow : IUsableItem
    {
        private readonly GameStateMachine game;
        private readonly ArrowSkinType skinType;

        public UsableBow(GameStateMachine game, ArrowSkinType skinType)
        {
            this.game = game;
            this.skinType = skinType;
        }

        public void Use(Vector2 location, Direction direction)
        {
            game.PlayerProjectilesQueue.Add(new ArrowProjectile(location, direction, skinType, game));
        }
    }
}
