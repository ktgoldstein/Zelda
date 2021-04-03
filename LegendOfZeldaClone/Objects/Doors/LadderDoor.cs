using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class LadderDoor : IDoor
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
        public bool IsMovable { get; }
        public bool IsBombable { get; }
        public bool Alive { get; set; }
        public Vector2 SpawnLocation { get; }

        private readonly GameStateMachine game;
        private ISprite sprite;
        private readonly int height;
        private readonly int width;

        public LadderDoor(GameStateMachine game, Vector2 location)
        {
            this.game = game;
            sprite = ObjectSpriteFactory.Instance.CreateLadder();
            Location = location;
            height = 16;
            width = 16;
            SpawnLocation = LoZHelpers.SecretRoomSpawnLocationOut;
            BlockHeight = ObjectHeight.CanWalkOver;
            IsMovable = false;
            IsBombable = false;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            game.CurrentRoom = game.CurrentRoom.RoomUp;
            game.CurrentRoom.LoadRoom();
            game.HUDMap.UpdateLinkMapLocation(Direction.Up);
            game.PauseMap.UpdateLinkMapLocation(Direction.Up);
            game.PauseMap.PlaceRoomOnMap(Direction.Up);

        }
        public void Die() { }
    }
}