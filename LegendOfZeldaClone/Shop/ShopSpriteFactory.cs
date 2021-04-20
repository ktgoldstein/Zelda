using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
	public class ShopSpriteFactory
	{
		public static ShopSpriteFactory Instance { get; } = new ShopSpriteFactory();

		private Texture2D shopKeeper;
		private Texture2D fire;
		private SpriteFont font;
		private ShopSpriteFactory() { }

		public void LoadAllTextures(ContentManager content)
		{
			shopKeeper = content.Load<Texture2D>("NPCSheet");
			fire = content.Load<Texture2D>("EnemySprites\\WizardFire");
			font = content.Load<SpriteFont>("Font");
		}

		public ISprite CreateShopKeeper() => new EnemySprite(shopKeeper, 2, 1, 1, 2);
		public ISprite CreateShopFire() => new EnemySprite(fire, 2, 1, 2, 2);
		public SpriteFont CreateFont() => font;
	}
}
