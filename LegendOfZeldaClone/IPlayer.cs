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
        public Vector2 Location { get; set; }
        public void SetState(ILinkState linkState);
        public ILinkState GetStateStandingDown();
        public ILinkState GetStateStandingUp();
        public ILinkState GetStateStandingLeft();
        public ILinkState GetStateStandingRight();
        public ILinkState GetStateWalkingingDown();
        public ILinkState GetStateWalkingingUp();
        public ILinkState GetStateWalkingingLeft();
        public ILinkState GetStateWalkingingRight();
        public ILinkState GetStateUsingItemDown();
        public ILinkState GetStateUsingItemUp();
        public ILinkState GetStateUsingItemLeft();
        public ILinkState GetStateUsingItemRight();
        public ILinkState GetStatePickingUpItem();
    }

    public class LinkPlayer : ILinkPlayer
    {
        public IUsableItem Sword { get; set; }
        public IUsableItem HeldItem { get; set; }
        public LinkSkinType SkinType { get; set; }
        public Vector2 Location { get; set; }

        private LegendOfZeldaDungeon game;
        private int health;
        private int maxHealth;
        private ILinkState linkState;

        //public LinkPlayer(LegendOfZeldaDungeon game, IUsableItem sword, IUsableItem heldItem, Vector2 location, int maxHealth, int health)
        public LinkPlayer(LegendOfZeldaDungeon game, Vector2 location, int maxHealth, int health)
        {
            //Sword = sword;
            //HeldItem = heldItem;

            this.game = game;
            this.Location = location;            
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
            linkState.Action();
            /*if (linkState.Action())
                Sword.Use();*/
        }

        public void ActionB()
        {
            if (linkState.Action())
                HeldItem.Use();
        }

        public void Damage(int amount)
        {
            //linkState.Damage();
            health -= amount;
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
            //Sword.Draw(spriteBatch);
            //HeldItem.Draw(spriteBatch);
            linkState.Draw(spriteBatch);
        }

        public void Update()
        {
            //Sword.Update();
            //HeldItem.Update();
            linkState.Update();
        }

        public void SetState(ILinkState linkState)
        {
            this.linkState = linkState;
        }

        public ILinkState GetStateStandingDown() => new LinkStandingDown(this);
        public ILinkState GetStateStandingUp() => new LinkStandingUp(this);
        public ILinkState GetStateStandingLeft() => new LinkStandingLeft(this);
        public ILinkState GetStateStandingRight() => new LinkStandingRight(this);
        public ILinkState GetStateWalkingingDown() => new LinkWalkingDown(this);
        public ILinkState GetStateWalkingingUp() => new LinkWalkingUp(this);
        public ILinkState GetStateWalkingingLeft() => new LinkWalkingLeft(this);
        public ILinkState GetStateWalkingingRight() => new LinkWalkingRight(this);
        public ILinkState GetStateUsingItemDown() => new LinkUsingItemDown(this);
        public ILinkState GetStateUsingItemUp() => new LinkUsingItemUp(this);
        public ILinkState GetStateUsingItemLeft() => new LinkUsingItemLeft(this);
        public ILinkState GetStateUsingItemRight() => new LinkUsingItemRight(this);
        public ILinkState GetStatePickingUpItem() => new LinkPickingUpItem(this);
    }
}
