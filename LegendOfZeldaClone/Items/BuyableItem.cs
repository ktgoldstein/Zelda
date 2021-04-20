using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BuyableItem : IItem
    {
        public IItem ItemForSale;
        public int Price { get; }
        public bool Alive { get; set; } = true;

        public Vector2 Location
        {
            get => ItemForSale.Location;
            set => ItemForSale.Location = value;
        }
        public Vector2 HurtBoxLocation
        {
            get => ItemForSale.HurtBoxLocation;
            set => ItemForSale.HurtBoxLocation = value;
        }
        public int Height => ItemForSale.Height;
        public int Width => ItemForSale.Width;

        private GameStateMachine game;

        public BuyableItem(GameStateMachine game, IItem item, int price)
        {
            this.game = game;
            ItemForSale = item;
            Price = price;
        }

        public void Draw(SpriteBatch spriteBatch) => ItemForSale.Draw(spriteBatch);
        public void Update() => ItemForSale.Update();

        public void Die()
        {
            if (!Alive) return;

            game.Items.Add(ItemForSale);
            Alive = false;
            foreach (IEnemy enemy in game.Enemies)
            {
                if (enemy is MerchantRoom) enemy.Die();
            }
            foreach (IItem item in game.Items)
            {
                if (item is BuyableItem) item.Die();
            }
        }
    }
}
