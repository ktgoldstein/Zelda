using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZeldaClone.Enemies;

namespace LegendOfZeldaClone
{
    class DeathAnimation : EnemyKernal
    {
        public override int AttackStat { get; }

        public override int Health { get; set; }
        public override Vector2 Direction { get; set; }
        public override bool Invincible { get; set; }
        public override bool Alive { get; set; }
        public override Vector2 Location { get; set; }
        public override Vector2 HurtBoxLocation { get; set; }
        private ISprite sprite;
        private readonly int width;
        private readonly int height;
        public override int Width { get { return LoZHelpers.Scale(width); } }
        public override int Height { get { return LoZHelpers.Scale(height); } }
        private readonly int maxLifeSpan;
        private int lifeSpan;

        public DeathAnimation(Vector2 location)
        {
            Location = location;
            width = 12;
            height = 12;
            Alive = true;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBombExplosionSprite(Color.Red);
            maxLifeSpan = 12;
            lifeSpan = maxLifeSpan;
            Health = 1;
        }
        public override void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public override void ChangeDirection(Direction direction = LegendOfZeldaClone.Direction.None) {}
        public override void DropItem() {}
        public override void Knockback(Vector2 direction) { }
        public override void Die() { }
        public override void TakeDamage(Vector2 direction) { }
        public override void Update()
        {
            if (lifeSpan == 0)
            {
                Alive = false;
                Health = 0;
            }
            else if (lifeSpan == (int)(maxLifeSpan * 2/3))
                sprite.Update();
            else if (lifeSpan == (int)(maxLifeSpan / 3.0))
                sprite.Update();
            lifeSpan--;
        }
    }
}
