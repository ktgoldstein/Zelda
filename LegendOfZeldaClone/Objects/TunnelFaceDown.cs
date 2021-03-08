using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class TunnelFaceDown: IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }

        private ISprite tunnel;
        private readonly int height;
        private readonly int width;

        public TunnelFaceDown(Vector2 location)
        {
            tunnel = ObjectSpriteFactory.Instance.CreateTunnelFaceDown();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            tunnel.Draw(spriteBatch, Location);
        }
    }
}