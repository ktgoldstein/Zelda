using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Objects
{
    public class PressurePlate : IObject
    {
        public ObjectHeight BlockHeight => ObjectHeight.CanWalkOver;
        public bool IsMovable => false;
        public bool IsBombable => false;
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get => Location; set => Location = value; }
        public int Width => LoZHelpers.Scale(width);
        public int Height => LoZHelpers.Scale(height);
        public bool Alive { get; set; } = true;

        private readonly GameStateMachine game;
        private readonly int oversize = 3;
        private readonly int height = 16;
        private readonly int width = 16;

        public PressurePlate(Vector2 location, GameStateMachine game)
        {
            this.game = game;
            Location = location - LoZHelpers.Scale(oversize) * Vector2.One;
            height += oversize * 2;
            width += oversize * 2;
        }

        public void Die() { }
        public void Draw(SpriteBatch spriteBatch) { }
        public void Update() { }
        public void CloseDoors()
        {
            game.CurrentRoom.CloseDoors();
        }
    }
}
