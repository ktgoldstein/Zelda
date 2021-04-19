using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class TunnelFaceDown: DoorKernel
    {
        public override Vector2 HurtBoxLocation
        {
            get { return Location + hurtBoxOffset; }
            set { Location = value - hurtBoxOffset; }
        }

        private readonly GameStateMachine game;
        private readonly Vector2 hurtBoxOffset;

        public TunnelFaceDown(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
            hurtBoxOffset = new Vector2(0, LoZHelpers.Scale(32 - height));
        }

        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                foreach (IBlock block in game.CurrentRoom.RoomDown.Blocks)
                {
                    if (block is BombableWall && (block as BombableWall).Orientation == Direction.Up)
                    {
                        game.CurrentRoom.RoomDown.Blocks.Remove(block);
                        break;
                    }
                }
                game.MoveRoom(Direction.Down);
            }
        }
    }
}
