using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Objects
{
    public class PressurePlate : IObject
    {
        public ObjectHeight BlockHeight => ObjectHeight.CanWalkOver;
        public bool IsBombable => false;
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get => Location; set => Location = value; }
        public int Width => LoZHelpers.Scale(width);
        public int Height => LoZHelpers.Scale(height);
        public bool Alive { get; set; } = true;

        private readonly GameStateMachine game;
        private readonly bool oversize;
        private readonly int oversizeScale = 3;
        private readonly int height = 16;
        private readonly int width = 16;
        private ISprite sprite;

        public PressurePlate(Vector2 location, GameStateMachine game, bool oversize)
        {
            sprite = ObjectSpriteFactory.Instance.CreateDarkBlock();
            this.game = game;
            this.oversize = oversize;
            Location = location - LoZHelpers.Scale(oversizeScale) * Vector2.One;
            if (oversize)
            {
                height += oversizeScale * 2;
                width += oversizeScale * 2;
            }
            else
            {
                Location = location;
                height -= oversizeScale * 5;
                width -= oversizeScale * 5;
            }
        }

        public void Die() { }
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Update() { }
        public void CloseDoors()
        {
            game.CurrentRoom.CloseDoors();
        }
    }
}
