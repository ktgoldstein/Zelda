using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class EnemySpriteFactory
    {
		private Texture2D aquamentusSprite, fireballSprite;
		private Texture2D goriyaDownSprite, goriyaUpSprite, goriyaRightSprite, goriyaLeftSprite;
		private Texture2D boomerangSprite, stalfosSprite;

		private static EnemySpriteFactory instance = new EnemySpriteFactory();

		public static EnemySpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private EnemySpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			aquamentusSprite = content.Load<Texture2D>("EnemySprites\\Aquamentus");
			fireballSprite = content.Load<Texture2D>("EnemySprites\\fireball");
			goriyaDownSprite = content.Load<Texture2D>("EnemySprites\\Goriya\\GoriyaDown");
			goriyaUpSprite = content.Load<Texture2D>("EnemySprites\\Goriya\\GoriyaUp");
			goriyaRightSprite = content.Load<Texture2D>("EnemySprites\\Goriya\\GoriyaRight");
			goriyaLeftSprite = content.Load<Texture2D>("EnemySprites\\Goriya\\GoriyaLeft");
			boomerangSprite = content.Load<Texture2D>("EnemySprites\\Boomerang2");
			stalfosSprite = content.Load<Texture2D>("EnemySprites\\Stalfos");


		}

		public ISprite CreateAquamentusSprite()
        {
			return new EnemySprite(aquamentusSprite, 4, 1, 4);
        }

		public ISprite CreateFireballSprite()
        {
			return new EnemySprite(fireballSprite, 4, 1, 4);
        }

		public ISprite CreateGoriyaDownSprite()
        {
			return new EnemySprite(goriyaDownSprite, 2, 1, 2);
        }
		
		public ISprite CreateGoriyaUpSprite()
        {
			return new EnemySprite(goriyaUpSprite, 2, 1, 2);
        }

		public ISprite CreateGoriyaRightSprite()
        {
			return new EnemySprite(goriyaRightSprite, 2, 1, 2);
        }

		public ISprite CreateGoriyaLeftSprite()
        {
			return new EnemySprite(goriyaLeftSprite, 2, 1, 2);
		}

		public ISprite createBoomerangSprite()
        {
			return new EnemySprite(boomerangSprite, 8, 1, 8, 1);
        }

		public ISprite CreateStalfosSprite()
        {
			return new EnemySprite(stalfosSprite, 2, 1, 2);
        }
	}
}
