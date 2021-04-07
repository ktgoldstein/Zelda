using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    class BlueRingLinkPlayer : ILinkPlayer
    {
        public float Speed {
            get { return decoratedLinkPlayer.Speed; }
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
        public Direction BlockingDirection { get { return linkState.BlockingDirection; } }
        public PlayerInventory Inventory { get { return decoratedLinkPlayer.Inventory; } }
        public Vector2 Location
        {
            get { return decoratedLinkPlayer.Location; }
            set { decoratedLinkPlayer.Location = value; }
        }
        public Vector2 HurtBoxLocation
        {
            get { return decoratedLinkPlayer.HurtBoxLocation; }
            set { decoratedLinkPlayer.HurtBoxLocation = value; }
        }
        public int Width { get { return decoratedLinkPlayer.Width; } }
        public int Height { get { return decoratedLinkPlayer.Height; } }
        public IUsableItem Sword
        {
            get { return decoratedLinkPlayer.Sword; }
            set { decoratedLinkPlayer.Sword = value; }
        }
        public int SwordBeamLock
        {
            get { return decoratedLinkPlayer.SwordBeamLock; }
            set { decoratedLinkPlayer.SwordBeamLock = value; }
        }
        public IUsableItem HeldItem
        {
            get { return decoratedLinkPlayer.HeldItem; }
            set { decoratedLinkPlayer.HeldItem = value; }
        }
        public LinkSkinType SkinType { get; set; }
        public bool Alive
        {
            get { return decoratedLinkPlayer.Alive; }
            set { decoratedLinkPlayer.Alive = value; }
        }

        private readonly GameStateMachine game;
        private readonly ILinkPlayer decoratedLinkPlayer;
        private ILinkState linkState;

        public BlueRingLinkPlayer(GameStateMachine game, ILinkPlayer decoratedLinkPlayer)
        {
            SkinType = LinkSkinType.BlueRing;

            this.game = game;
            this.decoratedLinkPlayer = decoratedLinkPlayer;
            linkState = new LinkStandingDown(this);
        }

        public void MoveUp() => linkState.MoveUp();
        public void MoveDown() => linkState.MoveDown();
        public void MoveLeft() => linkState.MoveLeft();
        public void MoveRight() => linkState.MoveRight();

        public void ActionA()
        {
            Direction direction = linkState.BlockingDirection;
            linkState.Action();
            if (direction != Direction.None && Sword != null)
                Sword.Use(Location, direction, Inventory);
        }

        public void ActionB()
        {
            Direction direction = linkState.BlockingDirection;
            linkState.Action();
            if (direction != Direction.None && HeldItem != null)
                HeldItem.Use(Location, direction, Inventory);
        }

        public void Damage(int amount, Direction knockbackDirection)
        {
            Tuple<LinkStateType, int> currentState = linkState.GetState();
            if (currentState.Item1 == LinkStateType.PickingUpItem)
                return;
            Health -= amount / 2 + amount % 2;
            new LinkTakingDamageSoundEffect().Play();
            if (Health <= 0)
            {
                Die();
                return;
            }
            game.Player = new DamagedLinkPlayer(game, this, currentState.Item2, currentState.Item1, knockbackDirection);
        }

        public void Heal(int amount) => decoratedLinkPlayer.Heal(amount); 

        public void PickUpUsableItem(UsableItemTypes itemType, IItem item)
        {
            Inventory.AddItem(itemType, game);
            linkState.PickUpItem(item);
        }
        public void PickUpTriforce(IItem triforce)
        {
            linkState.PickUpTriforce(triforce);
            game.CurrentGameState = GameState.GameWon;
        }
            
        public void Equip(UsableItemTypes itemType) => decoratedLinkPlayer.Equip(itemType);
        public void Draw(SpriteBatch spriteBatch) => linkState.Draw(spriteBatch);

        public void Update()
        {
            linkState.Update();
            if (game.CurrentGameState == GameState.Play && Health < 3 && game.MusicTimingHelperInt % 7 == 0)
                new LowHealthBeepingSoundEffect().Play();
        }

        public void Die()
        {
            Health = 0;
            linkState.Die();
            new LinkDyingSoundEffect().Play();
            game.CurrentGameState = GameState.GameOver;
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
        public ILinkState GetStatePickingUpItem(IItem item) => new LinkPickingUpItem(this, item);
        public ILinkState GetStatePickingUpTriforce(IItem triforce) => new LinkPickingUpTriforce(this, triforce);
        public ILinkState GetStateDying() => new LinkDying(this);
    }
}
