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
                game.NextRoom = game.CurrentRoom.RoomRight;
                foreach (IBlock block in game.NextRoom.Blocks)
                {
                    if (block is LockedDoor && (block as LockedDoor).Orientation == Direction.Left)
                    {
                        game.NextRoom.Blocks.Remove(block);
                        break;
                    }
                }
                game.NextRoom.LoadRoom();
                game.RoomCamera.CameraTransition(Direction.Right, GameState.ScreenTransition);
                game.HUDMap.UpdateLinkMapLocation(Direction.Right);
                game.PauseMap.MoveRooms(Direction.Right);
            }
        }
    }
}