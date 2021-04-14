using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class OpenDoorDown : DoorKernel
    {
        public override Vector2 HurtBoxLocation
        {
            get { return Location + hurtBoxOffset; }
            set { Location = value - hurtBoxOffset; }
        }

        private readonly GameStateMachine game;
        private readonly Vector2 hurtBoxOffset;

        public OpenDoorDown(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
            hurtBoxOffset = new Vector2(0, LoZHelpers.Scale(32 - height));
        }

        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.NextRoom = game.CurrentRoom.RoomDown;
                foreach (IBlock block in game.NextRoom.Blocks)
                {
                    if (block is LockedDoor && (block as LockedDoor).Orientation == Direction.Up)
                    {
                        game.NextRoom.Blocks.Remove(block);
                        break;
                    }
                }
                game.NextRoom.LoadRoom();
                game.RoomCamera.CameraTransition(Direction.Down, GameState.ScreenTransition);
                game.HUDMap.UpdateLinkMapLocation(Direction.Down);
                game.PauseMap.MoveRooms(Direction.Down);
            }
        }
    }
}