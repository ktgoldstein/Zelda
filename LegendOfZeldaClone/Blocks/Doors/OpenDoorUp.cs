using Microsoft.Xna.Framework;


namespace LegendOfZeldaClone
{
    public class OpenDoorUp : DoorKernel
    {
        private readonly GameStateMachine game;

        public OpenDoorUp(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
        }

        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.NextRoom = game.CurrentRoom.RoomUp;
                foreach (IBlock block in game.NextRoom.Blocks)
                {
                    if (block is LockedDoor && (block as LockedDoor).Orientation == Direction.Down)
                    {
                        game.NextRoom.Blocks.Remove(block);
                        break;
                    }
                }
                game.NextRoom.LoadRoom();
                game.RoomCamera.CameraTransition(Direction.Up, GameState.ScreenTransition);
                game.HUDMap.UpdateLinkMapLocation(Direction.Up);
                game.PauseMap.MoveRooms(Direction.Up);
            }
        }
    }
}