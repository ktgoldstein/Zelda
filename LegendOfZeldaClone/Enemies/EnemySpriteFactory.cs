using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class EnemySpriteFactory
    {
		public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

		private Texture2D aquamentusSprite, fireballSprite;
		private Texture2D goriyaDownSprite, goriyaUpSprite, goriyaRightSprite, goriyaLeftSprite;
		private Texture2D boomerangSprite;
		private Texture2D stalfosSprite;
		private Texture2D bladeTrapSprite;
		private Texture2D gelSprite;
		private Texture2D keeseSprite;
		private Texture2D wallmasterSprite;
		private Texture2D wizardSprite, wizardFireSprite;
		private Texture2D dodongoSprite;
		private Texture2D linkCharge, linkSpin;
		private Texture2D greenDodongoSprite, blueDodongoSprite, redDodongoSprite;
		private Texture2D greenDodongoDamagedSprite, blueDodongoDamagedSprite, redDodongoDamagedSprite;
		private Texture2D hpBackground, bossHP;
		private SpriteFont normalGameTextFont;
		private SpriteFont endScreensTextFont;

		private EnemySpriteFactory() { }

		public void LoadAllTextures(ContentManager content)
		{
			aquamentusSprite = content.Load<Texture2D>("EnemySprites\\Aquamentus");
			fireballSprite = content.Load<Texture2D>("EnemySprites\\Fireball");
			goriyaDownSprite = content.Load<Texture2D>("EnemySprites\\Goriya\\GoriyaDown");
			goriyaUpSprite = content.Load<Texture2D>("EnemySprites\\Goriya\\GoriyaUp");
			goriyaRightSprite = content.Load<Texture2D>("EnemySprites\\Goriya\\GoriyaRight");
			goriyaLeftSprite = content.Load<Texture2D>("EnemySprites\\Goriya\\GoriyaLeft");
			boomerangSprite = content.Load<Texture2D>("EnemySprites\\Boomerang");
			stalfosSprite = content.Load<Texture2D>("EnemySprites\\Stalfos");
			bladeTrapSprite = content.Load<Texture2D>("EnemySprites\\BladeTrap");
			gelSprite = content.Load<Texture2D>("EnemySprites\\Gel");
			keeseSprite = content.Load<Texture2D>("EnemySprites\\Keese");
			wallmasterSprite = content.Load<Texture2D>("EnemySprites\\Wallmaster");
			wizardSprite = content.Load<Texture2D>("EnemySprites\\Wizard");
			wizardFireSprite = content.Load<Texture2D>("EnemySprites\\WizardFire");
			dodongoSprite = content.Load<Texture2D>("EnemySprites\\GreenDodongo");
			linkCharge = content.Load<Texture2D>("EnemySprites\\LinkCharge");
			linkSpin = content.Load<Texture2D>("EnemySprites\\LinkSpin");
			greenDodongoSprite = content.Load<Texture2D>("EnemySprites\\GreenDodongo");
			blueDodongoSprite = content.Load<Texture2D>("EnemySprites\\BlueDodongo");
			redDodongoSprite = content.Load<Texture2D>("EnemySprites\\RedDodongo");
			hpBackground = content.Load<Texture2D>("EnemySprites\\BossHPBackground");
			bossHP = content.Load<Texture2D>("EnemySprites\\BossHP");
			greenDodongoDamagedSprite = content.Load<Texture2D>("EnemySprites\\GreenDodongoDamaged");
			blueDodongoDamagedSprite = content.Load<Texture2D>("EnemySprites\\BlueDodongoDamaged");
			redDodongoDamagedSprite = content.Load<Texture2D>("EnemySprites\\RedDodongoDamaged");
			normalGameTextFont = content.Load<SpriteFont>("Font");
			endScreensTextFont = content.Load<SpriteFont>("EndScreensFont");
		}

		public ISprite CreateAquamentusSprite() => new EnemySprite(aquamentusSprite, 4, 1, 2, 4);
		public ISprite CreateDamagedAquamentusSprite() => new EnemySprite(aquamentusSprite, 4, 1, 2, 4, color: Color.OrangeRed);
		public ISprite CreateFireballSprite(Color color) => new EnemySprite(fireballSprite, 4, 1, 2, 4, 5, color);
		public ISprite CreateGoriyaDownSprite() => new EnemySprite(goriyaDownSprite, 2, 1, 2, 2);
		public ISprite CreateGoriyaUpSprite() => new EnemySprite(goriyaUpSprite, 2, 1, 2, 2);
		public ISprite CreateGoriyaRightSprite() => new EnemySprite(goriyaRightSprite, 2, 1, 2, 2);
		public ISprite CreateGoriyaLeftSprite() => new EnemySprite(goriyaLeftSprite, 2, 1, 2, 2);
		public ISprite CreateBoomerangSprite() => new EnemySprite(boomerangSprite, 8, 1, 2, 8, 1);
		public ISprite CreateStalfosSprite() => new EnemySprite(stalfosSprite, 2, 1, 2, 2);
		public ISprite CreateBladeTrapSprite() => new EnemySprite(bladeTrapSprite, 1, 1, 0, 1);
		public ISprite CreateGelSprite() => new EnemySprite(gelSprite, 2, 1, 2, 2);
		public ISprite CreateKeeseSprite() => new EnemySprite(keeseSprite, 2, 1, 2, 2);
		public ISprite CreateWallmasterSprite() => new EnemySprite(wallmasterSprite, 2, 1, 2, 2);
		public ISprite CreateWizardSprite() => new EnemySprite(wizardSprite, 1, 1, 0, 1);
		public ISprite CreateWizardFireSprite() => new EnemySprite(wizardFireSprite, 2, 1, 2, 2);
		public ISprite CreateDodongoSprite() => new EnemySprite(dodongoSprite, 2, 1, 2, 2);
		public ISprite CreateLinkChargeSprite(int direction) => new EnemySprite(4, 1, 2, 1, direction, linkCharge);
		public ISprite CreateLinkSpinSprite(int direction) => new EnemySprite(4, 1, 2, 4, linkSpin, direction, 1);
		public ISprite CreateDodongoPhaseOneSprite() => new EnemySprite(greenDodongoSprite, 2, 1, 2, 2);
		public ISprite CreateDodongoPhaseTwoSprite() => new EnemySprite(blueDodongoSprite, 2, 1, 2, 2, 2);
		public ISprite CreateDodongoPhaseThreeSprite() => new EnemySprite(redDodongoSprite, 2, 1, 2, 2, 2);
		public ISprite CreateBossHPBackground() => new EnemySprite(hpBackground, 1, 1, 0, 1);
		public ISprite CreateBossHP() => new EnemySprite(bossHP, 1, 1, 0, 1);
		public ISprite CreateGreenDodongoDamaged() => new EnemySprite(greenDodongoDamagedSprite, 1, 1, 2, 1);
		public ISprite CreateBlueDodongoDamaged() => new EnemySprite(blueDodongoDamagedSprite, 1, 1, 2, 1);
		public ISprite CreateRedDodongoDamaged() => new EnemySprite(redDodongoDamagedSprite, 1, 1, 2, 1);
		public SpriteFont CreateFont() => normalGameTextFont;
		public SpriteFont CreateEndScreensFont() => endScreensTextFont;
	}
}
