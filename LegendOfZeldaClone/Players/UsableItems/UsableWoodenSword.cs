using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableWoodenSword : IUsableItem
    {
        private readonly GameStateMachine game;
        private readonly ILinkPlayer player;

        public UsableWoodenSword(GameStateMachine game, ILinkPlayer player)
        {
            this.game = game;
            this.player = player;
        }

        public void Use(Vector2 location, Direction direction, PlayerInventory playerInventory)
        {
            game.PlayerProjectilesQueue.Add(new SwordProjectile(location, SwordSkinType.WoodenSword, direction, game, player));
        }
    }
}
