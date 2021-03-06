using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkWalkingLeft : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public Direction BlockingDirection { get { return Direction.Left; } }

        public LinkWalkingLeft(ILinkPlayer link, int frame = 0)
        {
            linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeftSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void Charge() { }
        public void Action() => linkPlayer.SetState(linkPlayer.GetStateUsingItemLeft());
        public void PickUpItem(IItem item) => linkPlayer.SetState(linkPlayer.GetStatePickingUpItem(item));
        public void PickUpTriforce(IItem triforce) => linkPlayer.SetState(linkPlayer.GetStatePickingUpTriforce(triforce));
        public void Die() => linkPlayer.SetState(linkPlayer.GetStateDying());
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingLeft, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);

        public void Update()
        {
            linkPlayer.Location -= new Vector2(linkPlayer.Speed, 0);
            linkSprite.Update();
            int linkAlignment = (int)linkPlayer.Location.X % LoZHelpers.Scale(8);
            if (linkSprite.AnimationDone() || linkAlignment == 0)
                linkPlayer.SetState(linkPlayer.GetStateStandingLeft());
            else if (linkAlignment % 2 == 1 || linkAlignment % 2 == -1)
                linkPlayer.Location -= new Vector2(LoZHelpers.Scale(1), 0);
        }
    }
}
