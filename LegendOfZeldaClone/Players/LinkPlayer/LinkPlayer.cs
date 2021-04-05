using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkPlayer : ILinkPlayer
    {
        public float Speed { get; set; }
        public int MaxHealth { get; set; }
        public int Health
        {
            get => health; 
            set => health = value > MaxHealth ? MaxHealth : value;
        }
        public Direction BlockingDirection { get { return linkState.BlockingDirection; } }
        public PlayerInventory Inventory { get; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation 
        { 
            get { return Location + hurtBoxOffset; }
            set { Location = value - hurtBoxOffset; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public IUsableItem Sword { get; set; }
        public int SwordBeamLock { get; set; } = 0;
        public IUsableItem HeldItem { get; set; }
        public LinkSkinType SkinType { get; set; }
        public bool Alive
        {
            get { return Health > 0; }
            set { Health = value ? MaxHealth : 0; }
        }

        private readonly GameStateMachine game;
        public ILinkState linkState;
        private readonly int width;
        private readonly int height;
        private readonly Vector2 hurtBoxOffset;

        private int health;

        public LinkPlayer(GameStateMachine game, Vector2 location, IUsableItem sword = null, IUsableItem heldItem = null)
        {
            Sword = sword;
            HeldItem = heldItem;
            SkinType = LinkSkinType.Normal;
            Location = location;
            width = 14;
            height = 14;
            hurtBoxOffset = new Vector2(LoZHelpers.Scale(1), LoZHelpers.Scale(2));

            this.game = game;
            Speed = LoZHelpers.Scale(2);
            MaxHealth = 6;
            Health = MaxHealth;
            Inventory = new PlayerInventory(0, 0, 0, false, false);
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
            Health -= amount;            
            new LinkTakingDamageSoundEffect().Play();
            if (Health <= 0)
                Die();
            Tuple<LinkStateType, int> currentState = linkState.GetState();
            if (currentState.Item1 != LinkStateType.PickingUpItem)
                game.Player = new DamagedLinkPlayer(game, this, currentState.Item2, currentState.Item1, knockbackDirection);
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;
                new HeartsRefillingSoundEffect().Play(); //this will likely need to be changed later to loop
        }

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
            
            

        public void Equip(UsableItemTypes itemType)
        {
            if (itemType == UsableItemTypes.BlueRing)
                Inventory.GetItem(itemType).Use(Location, Direction.None, Inventory);
            else
                HeldItem = Inventory.GetItem(itemType);
        }

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
            Alive = false;
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
