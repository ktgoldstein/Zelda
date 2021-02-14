using Microsoft.Xna.Framework;
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

    public interface ILinkPlayer : IPlayer
    {
        public LinkSkinType SkinType { get; set; }
        public void SetState(LinkState linkState);
        public LinkState GetStateStandingDown();
        public LinkState GetStateStandingUp();
        public LinkState GetStateStandingLeft();
        public LinkState GetStateStandingRight();
        public LinkState GetStateWalkingingDown();
        public LinkState GetStateWalkingingUp();
        public LinkState GetStateWalkingingLeft();
        public LinkState GetStateWalkingingRight();
        public LinkState GetStateUsingItemDown();
        public LinkState GetStateUsingItemUp();
        public LinkState GetStateUsingItemLeft();
        public LinkState GetStateUsingItemRight();
        public LinkState GetStatePickingUpItem();
    }

    public class LinkPlayer : ILinkPlayer
    {
        public IUsableItem Sword { get; set; }
        public IUsableItem HeldItem { get; set; }
        public LinkSkinType SkinType { get; set; }

        private LegendOfZeldaDungeon game;
        private Vector2 location;
        private int health;
        private int maxHealth;
        private LinkState linkState;

        public LinkPlayer(LegendOfZeldaDungeon game, IUsableItem sword, IUsableItem heldItem, Vector2 location, int maxHealth, int health)
        {
            Sword = sword;
            HeldItem = heldItem;

            this.game = game;
            this.location = location;            
            this.health = health;
            this.maxHealth = maxHealth;

            linkState = new LinkStandingDown(this);
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

        public void SetState(LinkState linkState)
        {
            this.linkState = linkState;
        }

        public LinkState GetStateStandingDown() => new LinkStandingDown(this);
        public LinkState GetStateStandingUp() => new LinkStandingUp(this);
        public LinkState GetStateStandingLeft() => new LinkStandingLeft(this);
        public LinkState GetStateStandingRight() => new LinkStandingRight(this);
        public LinkState GetStateWalkingingDown() => new LinkWalkingDown(this);
        public LinkState GetStateWalkingingUp() => new LinkWalkingUp(this);
        public LinkState GetStateWalkingingLeft() => new LinkWalkingLeft(this);
        public LinkState GetStateWalkingingRight() => new LinkWalkingRight(this);
        public LinkState GetStateUsingItemDown() => new LinkUsingItemDown(this);
        public LinkState GetStateUsingItemUp() => new LinkUsingItemUp(this);
        public LinkState GetStateUsingItemLeft() => new LinkUsingItemLeft(this);
        public LinkState GetStateUsingItemRight() => new LinkUsingItemRight(this);
        public LinkState GetStatePickingUpItem() => new LinkPickingUpItem(this);
    }
}
