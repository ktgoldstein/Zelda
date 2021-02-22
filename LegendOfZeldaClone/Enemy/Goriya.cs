﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    public class Goriya : IEnemy
    {
      
        private ISprite goriyaSprite;
        private Vector2 location;
        private float speed = 6;
        private Vector2 direction = new Vector2(0, 1);
        private int timer = 0;
        private Boomerang boomerang;

        public Goriya(Vector2 location)
        {
            goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
            this.location = location;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            goriyaSprite.Draw(spritebatch, location);
            if (boomerang != null)
            {
                boomerang.Draw(spritebatch);
            }
        }

        public void Update()
        {
            goriyaSprite.Update();
            if(boomerang != null)
            {
                boomerang.Update();
            }

            location.Y += speed * direction.Y;
            location.X += speed * direction.X;
            if(timer % 20 == 0)
            {
                ThrowBoomerang(direction);
            }
            if (timer == 0)
            {
                direction = Vector2.UnitY;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();

            }
            else if (timer == 20)
            {
                direction = -Vector2.UnitX;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite();
            }
            else if (timer == 40)
            {
                direction = -Vector2.UnitY;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite();
            }
            else if (timer == 60)
            {
                direction = Vector2.UnitX;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
            }
            timer++;
            if (timer > 79)
            {
                timer = 0;
            }
        }

        private void ThrowBoomerang(Vector2 direction)
        {
            if(boomerang == null)
            {
                boomerang = new Boomerang(this.location, direction, this);
            }
        }

        public Vector2 GetGoriyaLocation()
        {
            return location;
        }

        public void CatchBoomerang()
        {
            boomerang = null;
        }
    }
}
