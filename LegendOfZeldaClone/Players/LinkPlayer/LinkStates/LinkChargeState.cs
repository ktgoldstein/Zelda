using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.Players.LinkPlayer.LinkStates
{
    class LinkChargeState : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ISprite linkSprite;
        private int timer = 0;
        private int direction;
        public Direction BlockingDirection { get; set; }
        public LinkChargeState(ILinkPlayer player, int direction)
        {
            linkPlayer = player;
            linkSprite = EnemySpriteFactory.Instance.CreateLinkChargeSprite(direction);
            this.direction = direction;
        }
       public void MoveUp()
        {
            Console.WriteLine("moving up");
            linkPlayer.Location += new Vector2(0, -linkPlayer.Speed/3);
        }
        public void MoveDown()
        {
            linkPlayer.Location += new Vector2(0, linkPlayer.Speed/3);

        }
        public void MoveLeft()
        {

            linkPlayer.Location += new Vector2(-linkPlayer.Speed/3, 0);
        }
        public void MoveRight()
        {
            linkPlayer.Location += new Vector2(linkPlayer.Speed/3, 0);
        }
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
            if(timer > 15)
            {
                linkPlayer.SetState(new LinkSpin(linkPlayer, direction));
            }
        }
        public void Charge() { }
    }
}
