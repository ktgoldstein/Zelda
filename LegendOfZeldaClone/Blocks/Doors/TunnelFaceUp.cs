using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class TunnelFaceUp : DoorKernel
    {
        private readonly GameStateMachine game;

        public TunnelFaceUp(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
        }

        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                foreach (IBlock block in game.CurrentRoom.RoomUp.Blocks)
                {
                    if (block is BombableWall && (block as BombableWall).Orientation == Direction.Down)
                    {
                        game.CurrentRoom.RoomUp.Blocks.Remove(block);
                        break;
                    }
                }
                game.MoveRoom(Direction.Up);
            }
        }
    }
}