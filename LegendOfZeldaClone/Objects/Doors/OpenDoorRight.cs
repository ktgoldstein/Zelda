using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class OpenDoorRight : IDoor
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
        public bool Alive { get; set; }
        public Vector2 SpawnLocation { get; }

        private readonly GameStateMachine game;
        private ISprite openDoorRight;
        private readonly int height;
        private readonly int width;
        private readonly Vector2 hurtBoxOffset;

        public OpenDoorRight(GameStateMachine game, Vector2 location)
        {
            this.game = game;
            SpawnLocation = LoZHelpers.LeftSpawnLocation;
            openDoorRight = ObjectSpriteFactory.Instance.CreateOpenDoorRight();
            Location = location;
            height = 32;
            width = 16;
            hurtBoxOffset = new Vector2(LoZHelpers.Scale(16), 0);
            BlockHeight = ObjectHeight.CanWalkOver;
            IsMovable = false;
            IsBombable = false;
            Alive = true;
        }
        
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => openDoorRight.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            game.CurrentRoom = game.CurrentRoom.RoomRight;
            game.CurrentRoom.LoadRoom();
            game.HUDMap.link.moveLinkOnMiniMap(Direction.Right);
        }
        public void Die() { }
    }
}