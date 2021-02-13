﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IPlayer
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void ActionA();
        public void ActionB();
        public void Damage(int amount);
        public void Heal(int amount);
        public void SetAItem(IUsableItem item);
        public void SetBItem(IUsableItem item);
        public void SetMaxHealth(int amount);
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }

    public class LinkPlayer : IPlayer
    {
        public IUsableItem Sword { get; set; }
        public IUsableItem HeldItem { get; set; }

        private LegendOfZeldaDungeon game;
        private Vector2 location;
        private int health;
        private int maxHealth;
        private ILinkState linkState;

        public LinkPlayer(LegendOfZeldaDungeon game, IUsableItem sword, IUsableItem heldItem, Vector2 location, int maxHealth, int health)
        {
            Sword = sword;
            HeldItem = heldItem;

            SpriteFactory = new LinkSpriteFactory();

            this.game = game;
            this.location = location;            
            this.health = health;
            this.maxHealth = maxHealth;

            linkState = new LinkNormalStandingDown(this);
        }

        public void MoveUp()
        {
            linkState.MoveUp();
        }

        public void MoveDown()
        {
            linkState.MoveDown();
        }

        public void MoveLeft()
        {
            linkState.MoveLeft();
        }

        public void MoveRight()
        {
            linkState.MoveRight();
        }

        public void ActionA()
        {
            Sword.Use();
            linkState.Action();
        }

        public void ActionB()
        {
            HeldItem.Use();
            linkState.Action();
        }

        public void Damage(int amount)
        {
            health -= linkState.Damage(amount);
            if (health < 0)
                health = 0;
            // TODO: Handle the grief of Link dying
        }

        public void Heal(int amount)
        {
            health += amount;
            if (health > maxHealth)
                health = maxHealth;
        }

        public void SetAItem(IUsableItem item)
        {
            Sword = item;
        }

        public void SetBItem(IUsableItem item)
        {
            HeldItem = item;
        }

        public void SetMaxHealth(int amount)
        {
            maxHealth = amount;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sword.Draw(spriteBatch, location);
            HeldItem.Draw(spriteBatch, location);
            linkState.Draw(spriteBatch, location);
        }

        public void Update()
        {
            Sword.Update();
            HeldItem.Update();
            linkState.Update(location);
        }
    }

    public class DamagedLinkPlayer : IPlayer
    {
        private LegendOfZeldaDungeon game;
    }
}
