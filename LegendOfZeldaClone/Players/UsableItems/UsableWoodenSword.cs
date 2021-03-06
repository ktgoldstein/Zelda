using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class UsableWoodenSword : IUsableItem
    {
        private readonly GameStateMachine game;

        public UsableWoodenSword(GameStateMachine game)
        {
            this.game = game;
        }

        public void Use(Vector2 location, Direction direction, PlayerInventory playerInventory)
        {
            game.PlayerProjectilesQueue.Add(new SwordProjectile(location, SwordSkinType.WoodenSword, direction, game, (game.Player as ILinkPlayer)));
            new SwordSlashSoundEffect().Play();
        }
    }
}
