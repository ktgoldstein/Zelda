using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IPlayer
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public Vector2 Location { get; set; }
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void ActionA();
        public void ActionB();
        public void Damage(int amount);
        public void Heal(int amount);
        //public void PickUpItem(IUsableItem item);
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }

    public interface ILinkPlayer : IPlayer
    {
        public IUsableItem Sword { get; set; }
        public IUsableItem HeldItem { get; set; }
        public LinkSkinType SkinType { get; set; }
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
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public Vector2 Location { get; set; }
        public IUsableItem Sword { get; set; }
        public IUsableItem HeldItem { get; set; }
        public LinkSkinType SkinType { get; set; }

        private LegendOfZeldaDungeon game;
        private ILinkState linkState;

        //public LinkPlayer(LegendOfZeldaDungeon game, IUsableItem sword, IUsableItem heldItem, Vector2 location)
        public LinkPlayer(LegendOfZeldaDungeon game, Vector2 location)
        {
            //Sword = sword;
            //HeldItem = heldItem;
            SkinType = LinkSkinType.Normal;
            Location = location;

            this.game = game;          
            MaxHealth = 6;
            Health = MaxHealth;
            linkState = new LinkStandingDown(this);
        }

        public void MoveUp() => linkState.MoveUp();
        public void MoveDown() => linkState.MoveDown();
        public void MoveLeft() => linkState.MoveLeft();
        public void MoveRight() => linkState.MoveRight();

        public void ActionA()
        {
            linkState.Action();
            /*if (linkState.Action())
                Sword.Use();*/
        }

        public void ActionB()
        {
            linkState.Action();
            /*if (linkState.Action())
                HeldItem.Use();*/
        }

        public void Damage(int amount)
        {
            //linkState.Damage();
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;
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

        public void SetState(ILinkState linkState) => this.linkState = linkState;
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

    class BlueRingLinkPlayer : ILinkPlayer
    {
        public int MaxHealth
        {
            get { return decoratedLink.MaxHealth; }
            set { decoratedLink.MaxHealth = value; }
        }
        public int Health
        {
            get { return decoratedLink.Health; }
            set { decoratedLink.Health = value; }
        }
        public Vector2 Location
        {
            get { return decoratedLink.Location; }
            set { decoratedLink.Location = value; }
        }
        public IUsableItem Sword 
        {
            get { return decoratedLink.Sword; }
            set { decoratedLink.Sword = value; } 
        }
        public IUsableItem HeldItem
        {
            get { return decoratedLink.HeldItem; }
            set { decoratedLink.HeldItem = value; }
        }
        public LinkSkinType SkinType { get; set; }

        private LegendOfZeldaDungeon game;
        private ILinkPlayer decoratedLink;
        private ILinkState linkState;

        public BlueRingLinkPlayer(LegendOfZeldaDungeon game, ILinkPlayer decoratedLink)
        {
            SkinType = LinkSkinType.BlueRing;

            this.game = game;
            this.decoratedLink = decoratedLink;
            linkState = new LinkStandingDown(this);
        }

        public void MoveUp() => linkState.MoveUp();
        public void MoveDown() => linkState.MoveDown();
        public void MoveLeft() => linkState.MoveLeft();
        public void MoveRight() => linkState.MoveRight();

        public void ActionA()
        {
            linkState.Action();
            /*if (linkState.Action())
                Sword.Use();*/
        }

        public void ActionB() {
            linkState.Action();
            /*if (linkState.Action())
                HeldItem.Use();*/
        }

        public void Damage(int amount)
        {
            //linkState.Damage();
            Health -= amount / 2;
            if (Health < 0)
                Health = 0;
            // TODO: Handle the grief of Link dying
        }

        public void Heal(int amount) => decoratedLink.Heal(amount);

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

        public void SetState(ILinkState linkState) => this.linkState = linkState;
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



    //******NOTE: most of the below has not been implemented properly yet!!******
    class DamagedLinkPlayer : ILinkPlayer
    {
        public int MaxHealth
        {
            get { return decoratedLink.MaxHealth; }
            set { decoratedLink.MaxHealth = value; }
        }
        public int Health
        {
            get { return decoratedLink.Health; }
            set { decoratedLink.Health = value; }
        }
        public Vector2 Location
        {
            get { return decoratedLink.Location; }
            set { decoratedLink.Location = value; }
        }
        public IUsableItem Sword
        {
            get { return decoratedLink.Sword; }
            set { decoratedLink.Sword = value; }
        }
        public IUsableItem HeldItem
        {
            get { return decoratedLink.HeldItem; }
            set { decoratedLink.HeldItem = value; }
        }
        public LinkSkinType SkinType { get; set; }

        private LegendOfZeldaDungeon game;
        private ILinkPlayer decoratedLink;
        private ILinkState linkState;
        private int timer = 24; //link stays damaged for 24 frames

        public DamagedLinkPlayer(LegendOfZeldaDungeon game, ILinkPlayer decoratedLink)
        {
            SkinType = LinkSkinType.DamagedOne;

            this.game = game;
            this.decoratedLink = decoratedLink;
            linkState = new LinkStandingDown(this);
        }

        //he can still move while damaged
        public void MoveUp() => linkState.MoveUp();
        public void MoveDown() => linkState.MoveDown();
        public void MoveLeft() => linkState.MoveLeft();
        public void MoveRight() => linkState.MoveRight();

        public void ActionA()
        {
            linkState.Action();

        }

        public void ActionB()
        {
            linkState.Action();

        }

        public void Damage(int amount)
        {
            // Link is within his 24 invulnerability frames, no damage possible
        }

        public void Heal(int amount) => decoratedLink.Heal(amount);

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
            int damageFrameType = timer % 4;
            switch (damageFrameType)
            {
                case 0:
                    SkinType = LinkSkinType.DamagedOne;
                    break;
                case 1:
                    SkinType = LinkSkinType.DamagedTwo;
                    break;
                case 2:
                    SkinType = LinkSkinType.DamagedThreeDungeonOne;
                    break;
                default:
                    SkinType = decoratedLink.SkinType; //AKA case 3
                    break;

        }
            timer--;

            if (timer == 0)
                game.Link = decoratedLink; //removes decorator

            linkState.Update();
        }


        public void SetState(ILinkState linkState) => this.linkState = linkState;
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
