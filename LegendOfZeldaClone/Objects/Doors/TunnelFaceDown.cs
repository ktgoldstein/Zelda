using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class TunnelFaceDown: IDoor
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location + hurtBoxOffset; }
            set { Location = value - hurtBoxOffset; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsMovable { get; }
        public bool IsBombable { get; }
        public bool IsAlive { get; set; }

        private readonly LegendOfZeldaDungeon game;
        private ISprite sprite;
        private readonly int height;
        private readonly int width;
        private readonly Vector2 hurtBoxOffset;

        public TunnelFaceDown(LegendOfZeldaDungeon game, Vector2 location)
        {
            this.game = game;
            sprite = ObjectSpriteFactory.Instance.CreateTunnelFaceDown();
            Location = location;
            height = 16;
            width = 32;
            hurtBoxOffset = new Vector2(0, LoZHelpers.Scale(16));
            BlockHeight = ObjectHeight.CanWalkOver;
            IsMovable = false;
            IsBombable = false;
            IsAlive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            game.Camera.CameraTransition(Direction.Down);
            //game.CurrentRoom = game.CurrentRoom.RoomDown; 
        }
    }
}