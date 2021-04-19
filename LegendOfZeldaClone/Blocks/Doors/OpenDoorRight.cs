using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class OpenDoorRight : DoorKernel
    {
        public override Vector2 HurtBoxLocation
        {
            get { return Location + hurtBoxOffset; }
            set { Location = value - hurtBoxOffset; ; }
        }

        private readonly GameStateMachine game;
        private readonly Vector2 hurtBoxOffset;

        public OpenDoorRight(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
            hurtBoxOffset = new Vector2(LoZHelpers.Scale(32 - width), 0);
        }
        
        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                foreach (IBlock block in game.CurrentRoom.RoomRight.Blocks)
                {
                    if (block is LockedDoor && (block as LockedDoor).Orientation == Direction.Left)
                    {
                        game.CurrentRoom.RoomRight.Blocks.Remove(block);
                        break;
                    }
                }
                game.MoveRoom(Direction.Right);
            }
        }
    }
}