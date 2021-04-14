using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class OpenDoorLeft : DoorKernel
    {
        private readonly GameStateMachine game;

        public OpenDoorLeft(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
        }

        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.NextRoom = game.CurrentRoom.RoomLeft;
                foreach (IBlock block in game.NextRoom.Blocks)
                {
                    if (block is LockedDoor && (block as LockedDoor).Orientation == Direction.Right)
                    {
                        game.NextRoom.Blocks.Remove(block);
                        break;
                    }
                }
                game.NextRoom.LoadRoom();
                game.RoomCamera.CameraTransition(Direction.Left, GameState.ScreenTransition);
                game.HUDMap.UpdateLinkMapLocation(Direction.Left);
                game.PauseMap.MoveRooms(Direction.Left);
            }
        }
    }
}