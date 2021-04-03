using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkWalkingDown : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public Direction BlockingDirection { get { return Direction.Down; } }

        public LinkWalkingDown(ILinkPlayer link, int frame = 0)
        {
            linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingDownSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void Action() => linkPlayer.SetState(linkPlayer.GetStateUsingItemDown());
        public void PickUpItem(IItem item) => linkPlayer.SetState(linkPlayer.GetStatePickingUpItem(item));
        public void PickUpTriforce(IItem triforce) => linkPlayer.SetState(linkPlayer.GetStatePickingUpTriforce(triforce));
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingDown, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);

        public void Update()
        {
            linkPlayer.Location += new Vector2(0, linkPlayer.Speed);
            linkSprite.Update();
            bool linkIsAligned = (linkPlayer.Location.Y - LoZHelpers.HUDHeight) % LoZHelpers.Scale(8) == 0;
            if (linkSprite.AnimationDone() || linkIsAligned)
                linkPlayer.SetState(linkPlayer.GetStateStandingDown());
        }
    }
}
