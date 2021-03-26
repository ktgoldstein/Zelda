using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class OpenDoorLeft : IDoor
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location + hurtBoxOffset; }
            set { Location = value; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsMovable { get; }
        public bool IsBombable { get; }
        public bool IsAlive { get; set; }
        public Direction DoorDirection { get; }
        public bool ActiveCamera { get; set; }

        private readonly LegendOfZeldaDungeon game;
        private ISprite sprite;
        private readonly int height;
        private readonly int width;
        private readonly Vector2 hurtBoxOffset;

        public OpenDoorLeft(LegendOfZeldaDungeon game, Vector2 location)
        {
            this.game = game;
            sprite = ObjectSpriteFactory.Instance.CreateOpenDoorLeft();
            Location = location;
            height = 32;
            width = 16;
            BlockHeight = ObjectHeight.CanWalkOver;
            hurtBoxOffset = new Vector2(LoZHelpers.Scale(-16), 0);
            IsMovable = false;
            IsBombable = false;
            IsAlive = true;
            DoorDirection = Direction.Left;
            ActiveCamera = false;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.NextRoom = game.CurrentRoom.RoomLeft;
                game.NextRoom.LoadRoom();
                game.Camera.CameraTransition(Direction.Left);
            }
        }
    }
}