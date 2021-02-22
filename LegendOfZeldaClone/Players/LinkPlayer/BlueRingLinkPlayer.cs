using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    class BlueRingLinkPlayer : ILinkPlayer
    {
        public float Speed {
            get { return decoratedLink.Speed; }
            set { decoratedLink.Speed = value; }
        }
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

        private readonly LegendOfZeldaDungeon game;
        private readonly ILinkPlayer decoratedLink;
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
            Direction direction = linkState.Action();
            if (direction != Direction.None)
                Sword.Use(Location, direction);
        }

        public void ActionB()
        {
            Direction direction = linkState.Action();
            if (direction != Direction.None)
                HeldItem.Use(Location, direction);
        }

        public void Damage(int amount)
        {
            Health -= amount / 2;
            if (Health < 0)
                Health = 0;
            Tuple<LinkStateType, int> currentState = linkState.GetState();
            game.Link = new DamagedLinkPlayer(game, this, currentState.Item2, currentState.Item1);
        }

        public void Heal(int amount) => decoratedLink.Heal(amount);
        public void Draw(SpriteBatch spriteBatch) => linkState.Draw(spriteBatch);
        public void Update() => linkState.Update();
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
