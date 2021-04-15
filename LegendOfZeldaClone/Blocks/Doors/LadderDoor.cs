using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class LadderDoor : DoorKernel
    {
        private readonly GameStateMachine game;

        public LadderDoor(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
        }

        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.Player.Location = Location + new Vector2(LoZHelpers.Scale(2 * 16), LoZHelpers.Scale(-2 * 16));
                game.MoveRoom(Direction.Up);
            }
        }
    }
}