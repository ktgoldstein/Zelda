using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class SwordProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }
        public Vector2 Location
        {
            get { return player.Location + locationOffset; }
            set { locationOffset = value - player.Location; }
        }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }


        public readonly ILinkPlayer player;

        private readonly GameStateMachine game;
        private readonly SwordSkinType skinType;
        private readonly Direction direction;
        private ISprite sprite;
        private Vector2 locationOffset = Vector2.Zero;
        private int width;
        private int height;
        private int lifeSpan;

        public SwordProjectile(Vector2 startingLocation, SwordSkinType skinType, Direction direction, GameStateMachine game, ILinkPlayer player)
        {
            Alive = true;

            this.game = game;
            this.player = player;
            this.direction = direction;
            this.skinType = skinType;

            Location = startingLocation;
            lifeSpan = 8;
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            if (lifeSpan == 0)
                Die();
            switch (lifeSpan)
            {
                case 8:
                    locationOffset += DirectedMovement() * LoZHelpers.Scale(2);
                    break;
                case 7:
                    locationOffset += DirectedMovement() * LoZHelpers.Scale(9);
                    break;
                case 6:
                case 5:
                    break;
                case 4:
                    locationOffset -= DirectedMovement() * LoZHelpers.Scale(4);
                    SpawnSwordBeam();
                    break;
                case 3:
                    break;
                case 2:
                    locationOffset -= DirectedMovement() * LoZHelpers.Scale(4);
                    break;
                case 1:
                    break;
            }
            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordDownSprite(skinType);
                    locationOffset += new Vector2(LoZHelpers.Scale(5), 0);
                    width = 7;
                    height = 16;
                    break;
                case Direction.Up:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordUpSprite(skinType);
                    locationOffset += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    width = 7;
                    height = 16;
                    break;
                case Direction.Left:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordLeftSprite(skinType);
                    locationOffset += new Vector2(0, LoZHelpers.Scale(7));
                    width = 16;
                    height = 7;
                    break;
                case Direction.Right:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordRightSprite(skinType);
                    locationOffset += new Vector2(0, LoZHelpers.Scale(7));
                    width = 16;
                    height = 7;
                    break;
            }
        }

        private Vector2 DirectedMovement()
        {
            return direction switch
            {
                Direction.Down => new Vector2(0, 1),
                Direction.Up => new Vector2(0, -1),
                Direction.Left => new Vector2(-1, 0),
                Direction.Right => new Vector2(1, 0),
                _ => new Vector2(0, 0)
            };
        }

        private void SpawnSwordBeam()
        {
            if (player.Health == player.MaxHealth && player.SwordBeamLock == 0)
            {
                player.SwordBeamLock++;
                game.PlayerProjectilesQueue.Add(new SwordBeamProjectile(Location, direction, game, player));
                new SwordBeamSoundEffect().Play();
            }
        }

        public void Die() => Alive = false;
    }
}
