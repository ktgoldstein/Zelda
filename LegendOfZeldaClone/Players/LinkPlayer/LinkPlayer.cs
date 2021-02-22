using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkPlayer : ILinkPlayer
    {
        public float Speed { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public Vector2 Location { get; set; }
        public IUsableItem Sword { get; set; }
        public IUsableItem HeldItem { get; set; }
        public LinkSkinType SkinType { get; set; }

        private LegendOfZeldaDungeon game;
        private ILinkState linkState;

        public LinkPlayer(LegendOfZeldaDungeon game, Vector2 location, IUsableItem sword, IUsableItem heldItem = null)
        {
            Sword = sword;
            HeldItem = heldItem;
            SkinType = LinkSkinType.Normal;
            Location = location;

            this.game = game;
            Speed = LoZHelpers.Scale(3);
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
            Health -= amount;
            if (Health < 0)
                Health = 0;
            Tuple<LinkStateType, int> currentState = linkState.GetState();
            game.Link = new DamagedLinkPlayer(game, this, currentState.Item2, currentState.Item1);
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;
        }

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
