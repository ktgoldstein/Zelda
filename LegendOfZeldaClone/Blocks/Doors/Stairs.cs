using Microsoft.Xna.Framework;


namespace LegendOfZeldaClone
{
    public class Stairs : DoorKernel
    {
        private readonly GameStateMachine game;

        public Stairs(Vector2 location, ISprite sprite, int height, int width, GameStateMachine game)
            : base(location, sprite, height, width)
        {
            this.game = game;
        }

        public override void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.Player.Location = Location + new Vector2(LoZHelpers.Scale(-4 * 16), LoZHelpers.Scale(5 * 16));
                game.NextRoom = game.CurrentRoom.RoomDown;
                game.NextRoom.LoadRoom();
                game.RoomCamera.CameraTransition(Direction.Down, GameState.ScreenTransition);
                game.HUDMap.UpdateLinkMapLocation(Direction.Down);
                game.PauseMap.MoveRooms(Direction.Down);
            }
        }
    }
}
