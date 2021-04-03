using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class Stairs : IDoor
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsBombable { get; }
        public bool Alive { get; set; }

        private readonly GameStateMachine game;
        private ISprite stairs;
        private readonly int height;
        private readonly int width;

        public Stairs(GameStateMachine game, Vector2 location)
        {
            this.game = game;
            stairs = ObjectSpriteFactory.Instance.CreateStairs();
            Location = location;
            height = 16;
            width = 16;
            BlockHeight = ObjectHeight.CanWalkOver;
            IsBombable = false;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => stairs.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.Player.Location = Location + new Vector2(LoZHelpers.Scale(-4 * 16), LoZHelpers.Scale(5 * 16));
                game.NextRoom = game.CurrentRoom.RoomDown;
                game.NextRoom.LoadRoom();
                game.RoomCamera.CameraTransition(Direction.Down);
                game.HUDMap.UpdateLinkMapLocation(Direction.Down);
                game.PauseMap.MoveRooms(Direction.Down);
            }
        }
        public void Die() { }
    }
}
