using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class BlueGargoyleStatue : IObject
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

        private ISprite blueGargoyleStatue;
        private readonly int height;
        private readonly int width;

        public BlueGargoyleStatue(Vector2 location)
        {
            blueGargoyleStatue = ObjectSpriteFactory.Instance.CreateBlueGargoyleStatue();
            Location = location;
            height = 16;
            width = 16;
            BlockHeight = ObjectHeight.CanFlyOver;
            IsMovable = false;
            IsBombable = false;
        }  
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            blueGargoyleStatue.Draw(spriteBatch, Location);
        }
    }
}