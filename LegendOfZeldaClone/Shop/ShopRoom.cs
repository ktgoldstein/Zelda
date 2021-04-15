using LegendOfZeldaClone.Enemy;
using LegendOfZeldaClone.LevelLoading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ShopRoom
    {
        private readonly ISprite shopKeeper;
        private readonly ISprite fireOne;
        private readonly ISprite fireTwo;
        private readonly ISprite itemOne;
        private readonly ISprite itemTwo;
        private readonly ISprite itemThree;
        private readonly ISprite walls;

        public ShopRoom()
        {
            lifeTextSprite = HUDTextureFactory.Instance.CreateLifeText();
            itemOne = ItemSpriteFactory.Instance.CreateLifePotion();
            itemTwo = ItemSpriteFactory.Instance.CreateBomb();
            itemThree = ItemSpriteFactory.Instance.CreateCompass();
            fireOne = EnemySpriteFactory.Instance.CreateWizardFireSprite();
            walls = RoomTextureFactory.Instance.CreateWalls();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            lifeTextSprite.Draw(spriteBatch, vector);
        }
    }
}
