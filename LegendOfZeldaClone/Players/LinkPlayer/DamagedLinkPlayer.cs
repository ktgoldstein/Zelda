using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    class DamagedLinkPlayer : ILinkPlayer
    {
        public float Speed
        {
            get { return decoratedLinkPlayer.Speed / linkStates.Length; }
            set { decoratedLinkPlayer.Speed = value; }
        }
        public int MaxHealth
        {
            get { return decoratedLinkPlayer.MaxHealth; }
            set { decoratedLinkPlayer.MaxHealth = value; }
        }
        public int Health
        {
            get { return decoratedLinkPlayer.Health; }
            set { decoratedLinkPlayer.Health = value; }
        }
        public Vector2 Location
        {
            get { return decoratedLinkPlayer.Location; }
            set { decoratedLinkPlayer.Location = value; }
        }
        public IUsableItem Sword
        {
            get { return decoratedLinkPlayer.Sword; }
            set { decoratedLinkPlayer.Sword = value; }
        }
        public IUsableItem HeldItem
        {
            get { return decoratedLinkPlayer.HeldItem; }
            set { decoratedLinkPlayer.HeldItem = value; }
        }
        public LinkSkinType SkinType 
        {
            get { return skinTypes[skinTypesIndex]; }
            set { skinTypes[skinTypesIndex] = value; }
        }

        private readonly LegendOfZeldaDungeon game;
        private readonly ILinkPlayer decoratedLinkPlayer;
        private LinkSkinType[] skinTypes;
        private int skinTypesIndex;
        private ILinkState[] linkStates;
        private int timer;

        public DamagedLinkPlayer(LegendOfZeldaDungeon game, ILinkPlayer decoratedLinkPlayer, int currentFrame, LinkStateType linkState)
        {
            this.game = game;
            this.decoratedLinkPlayer = decoratedLinkPlayer;

            skinTypes = new LinkSkinType[] { LinkSkinType.DamagedOne, LinkSkinType.DamagedTwo, LinkSkinType.DamagedThreeDungeonOne, this.decoratedLinkPlayer.SkinType };
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
        public void Heal(int amount) => decoratedLinkPlayer.Heal(amount);

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
                decoratedLinkPlayer.SetState(GetSpecificState(decoratedLinkPlayer, currentState.Item1, currentState.Item2));
                game.Link = decoratedLinkPlayer;
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
