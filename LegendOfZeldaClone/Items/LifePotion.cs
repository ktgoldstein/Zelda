using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class LifePotion : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite lifePotion;
        private readonly int height;
        private readonly int width;
        GameStateMachine game;

        public LifePotion(Vector2 location, GameStateMachine game)
        {
            lifePotion = ItemSpriteFactory.Instance.CreateLifePotion();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
            this.game = game;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => lifePotion.Draw(spriteBatch, Location);
        public void Die()
        {
            Alive = false;
            new NewImportantItemAcquiredFanfareSoundEffect().Play();
            new InventoryItemPickupSoundEffect().Play();
        }

    }
}
