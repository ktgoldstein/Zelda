using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Players.LinkPlayer.LinkStates
{
    class LinkSpin : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ISprite linkSprite;
        private int timer = 0;
        private int direction;
        public Direction BlockingDirection { get; set; }
        public LinkSpin(ILinkPlayer player, int direction)
        {
            linkPlayer = player;
            linkSprite = EnemySpriteFactory.Instance.CreateLinkSpinSprite(direction);
            this.direction = direction;
            if (player is LegendOfZeldaClone.LinkPlayer)
            {
                ((LegendOfZeldaClone.LinkPlayer)player).GrowCollider();
            }
        }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight()  { }
        public void Action() { }
        public void PickUpItem(IItem item) { }
        public void PickUpTriforce(IItem triforce) { }
        public void Die() => linkPlayer.SetState(linkPlayer.GetStateDying());
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.Charge, 0);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);
        public void Update()
        {
            linkSprite.Update();
            timer++;
            if (timer > 12)
            {
                if (linkPlayer is LegendOfZeldaClone.LinkPlayer)
                {
                    ((LegendOfZeldaClone.LinkPlayer)linkPlayer).ShrinkCollider();
                }
                switch (direction)
                {
                    case 0:
                        linkPlayer.SetState(linkPlayer.GetStateStandingDown());
                        break;
                    case 1:
                        linkPlayer.SetState(linkPlayer.GetStateStandingRight());
                        break;
                    case 2:
                        linkPlayer.SetState(linkPlayer.GetStateStandingUp());
                        break;
                    case 3:
                        linkPlayer.SetState(linkPlayer.GetStateStandingLeft());
                        break;
                    default:
                        break;
                }
            }
        }
        public void Charge() { }
    }
}
