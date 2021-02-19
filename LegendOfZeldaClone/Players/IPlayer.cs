using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public interface IPlayer
    {
        public float Speed { get; set; }
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

        public void Draw(SpriteBatch spriteBatch)
        {
            linkState.Draw(spriteBatch);
        }

        public void Update()
        {
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

        public void Draw(SpriteBatch spriteBatch)
        {
            linkState.Draw(spriteBatch);
        }

        public void Update()
        {
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

    class DamagedLinkPlayer : ILinkPlayer
    {
        public float Speed
        {
            get { return decoratedLink.Speed / linkStates.Length; }
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
        public LinkSkinType SkinType 
        {
            get { return skinTypes[skinTypesIndex]; }
            set { }
        }

        private LegendOfZeldaDungeon game;
        private ILinkPlayer decoratedLink;
        private ILinkState[] linkStates;
        private int timer; //link stays damaged for 24 frames
        private LinkSkinType[] skinTypes;
        private int skinTypesIndex;

        public DamagedLinkPlayer(LegendOfZeldaDungeon game, ILinkPlayer decoratedLink, int currentFrame, LinkStateType linkState)
        {
            this.game = game;
            this.decoratedLink = decoratedLink;

            skinTypes = new LinkSkinType[] { LinkSkinType.DamagedOne, LinkSkinType.DamagedTwo, LinkSkinType.DamagedThreeDungeonOne, this.decoratedLink.SkinType };
            skinTypesIndex = 0;
            linkStates = new ILinkState[skinTypes.Length];

            for (int i = 0; i < skinTypes.Length; i++)
            {
                linkStates[i] = GetSpecificState(this, linkState, currentFrame);
                NextSkinIndex();
            }

            timer = LoZHelpers.LinkInvincibilityFrames;
        }

        public void MoveUp()
        {
            foreach (ILinkState linkState in linkStates)
                linkState.MoveUp();
        }

        public void MoveDown()
        {
            foreach (ILinkState linkState in linkStates)
                linkState.MoveDown();
        }

        public void MoveLeft()
        {
            foreach (ILinkState linkState in linkStates)
                linkState.MoveLeft();
        }

        public void MoveRight()
        {
            foreach (ILinkState linkState in linkStates)
                linkState.MoveRight();
        }

        public void ActionA()
        {
            Direction direction = Direction.None;
            foreach (ILinkState linkState in linkStates) 
                direction = linkState.Action();
            if (direction != Direction.None)
                Sword.Use(Location, direction);
        }

        public void ActionB()
        {
            Direction direction = Direction.None;
            foreach (ILinkState linkState in linkStates)
                direction = linkState.Action();
            if (direction != Direction.None)
                HeldItem.Use(Location, direction);
        }

        public void Damage(int amount) { /* Invinvibility Frames */ }
        public void Heal(int amount) => decoratedLink.Heal(amount);

        public void Draw(SpriteBatch spriteBatch)
        {
            int damageFrameType = timer % linkStates.Length;
            linkStates[damageFrameType].Draw(spriteBatch);
        }

        public void Update()
        {            
            timer--;
            foreach (ILinkState linkState in linkStates)
                linkState.Update();
            if (timer == 0)
            {
                Tuple<LinkStateType, int> currentState = linkStates[0].GetState();
                decoratedLink.SetState(GetSpecificState(decoratedLink, currentState.Item1, currentState.Item2));
                game.Link = decoratedLink;
            }
        }

        public void SetState(ILinkState linkState)
        {
            linkStates[skinTypesIndex] = linkState;
            NextSkinIndex();
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

        private void NextSkinIndex() => skinTypesIndex = (skinTypesIndex + 1) % skinTypes.Length;
        private ILinkState GetSpecificState(ILinkPlayer player, LinkStateType linkState, int currentFrame)
        {
            return linkState switch
            {
                LinkStateType.StandingDown => new LinkStandingDown(player, currentFrame),
                LinkStateType.StandingUp => new LinkStandingUp(player, currentFrame),
                LinkStateType.StandingLeft => new LinkStandingLeft(player, currentFrame),
                LinkStateType.StandingRight => new LinkStandingRight(player, currentFrame),
                LinkStateType.WalkingDown => new LinkWalkingDown(player, currentFrame),
                LinkStateType.WalkingUp => new LinkWalkingUp(player, currentFrame),
                LinkStateType.WalkingLeft => new LinkWalkingLeft(player, currentFrame),
                LinkStateType.WalkingRight => new LinkWalkingRight(player, currentFrame),
                LinkStateType.UsingItemDown => new LinkUsingItemDown(player, currentFrame),
                LinkStateType.UsingItemUp => new LinkUsingItemUp(player, currentFrame),
                LinkStateType.UsingItemLeft => new LinkUsingItemLeft(player, currentFrame),
                LinkStateType.UsingItemRight => new LinkUsingItemRight(player, currentFrame),
                LinkStateType.PickingUpItem => new LinkPickingUpItem(player, currentFrame),
                _ => new LinkStandingDown(player)
            };
        }
    }


}
