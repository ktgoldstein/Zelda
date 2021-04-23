using LegendOfZeldaClone.Enemies;
using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Merchant : EnemyKernal
    {
        public override int AttackStat { get; }
        public override int Health { get; set; } = LoZHelpers.WizardHP;
        public int MaxHealth { get; } = LoZHelpers.WizardHP;
        public Vector2 direction;
        public override Vector2 Direction { get { return direction; } set { direction = value; } }
        public override bool Invincible { get; set; }
        public override bool Alive { get; set; }
        public override Vector2 Location { get; set; }
        public override Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }

        public override int Width { get { return LoZHelpers.Scale(width); } }
        public override int Height { get { return LoZHelpers.Scale(height); } }

        private readonly ISprite merchantSprite;
        private readonly ISprite rupeeSprite;
        private readonly ISprite xSprite;
        private readonly int width;
        private readonly int height;
        private readonly SpriteFont font;
        private readonly string merchantMsg = "Come spend your rupees!";
        private readonly string priceOne = "20";
        private readonly string priceTwo = "50";
        private int current = 0;
        private int timer = 3;

        public Merchant(GameStateMachine game, Vector2 location)
        {
            merchantSprite = ShopSpriteFactory.Instance.CreateShopKeeper();
            font = ShopSpriteFactory.Instance.CreateFont();
            xSprite = HUDTextureFactory.Instance.CreateX();
            rupeeSprite = ItemSpriteFactory.Instance.CreateFlashingRupee();
            base.game = game;
            Location = location;

            width = 16;
            height = 16;
            Direction = new Vector2(0, 0);
            Invincible = false;
            Alive = true;
            AttackStat = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Alive)
            {
                //Put locations in LoZ Helpers
                merchantSprite.Draw(spriteBatch, Location - LoZHelpers.merchantOffset);
                rupeeSprite.Draw(spriteBatch, Location + LoZHelpers.shopRupeePos);
                xSprite.Draw(spriteBatch, Location + LoZHelpers.shopXPos);
                spriteBatch.DrawString(font, merchantMsg.Substring(0, current), Location - LoZHelpers.merchantMsgPos, Color.White);
                spriteBatch.DrawString(font, priceOne, Location + LoZHelpers.priceOnePos, Color.White);
                spriteBatch.DrawString(font, priceTwo, Location + LoZHelpers.priceTwoPos, Color.White);
            }           
        }

        public override void Knockback(Vector2 direction) { }

        public override void Update()
        {
            merchantSprite.Update();
            rupeeSprite.Update();

            timer--;
            if (timer == 0)
            {
                timer = 3;
                if (current < merchantMsg.Length)
                {
                    current++;
                    new TextAppearingSlowlySoundEffect().Play();
                }
            }
        }
        public override void DropItem() { }
        public override void ChangeDirection(Direction direction = LegendOfZeldaClone.Direction.None) { }
        public override void TakeDamage(Vector2 direction) { }
        public override void Die() { Alive = false; }
    }
}
