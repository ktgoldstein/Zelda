using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class TunnelFaceUp : IDoor
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
        private ISprite sprite;
        private readonly int height;
        private readonly int width;

        public TunnelFaceUp(GameStateMachine game, Vector2 location)
        {
            this.game = game;
            sprite = ObjectSpriteFactory.Instance.CreateTunnelFaceUp();
            Location = location;
            height = 16;
            width = 32;
            BlockHeight = ObjectHeight.CanWalkOver;
            IsBombable = false;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        public void ChangeRoom()
        {
            if (game.NextRoom == null)
            {
                game.NextRoom = game.CurrentRoom.RoomUp;
                foreach (IObject block in game.NextRoom.Blocks)
                {
                    if (block is BombableWallDown)
                    {
                        game.NextRoom.Blocks.Remove(block);
                        break;
                    }
                }
                game.NextRoom.LoadRoom();
                game.Camera.CameraTransition(Direction.Up);
            }
        }
        public void Die() { }
    }
}