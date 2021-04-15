using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkPickingUpTriforce : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;
        private readonly IItem triforce;

        public Direction BlockingDirection { get { return Direction.None; } }

        public LinkPickingUpTriforce(ILinkPlayer link, IItem triforce, int frame = 0)
        {
            linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpTriforceSprite(link.SkinType, frame);
            this.triforce = triforce;

            this.triforce.Location = new Vector2(link.Location.X + (link.Width - this.triforce.Width + LoZHelpers.Scale(2)) / 2, link.Location.Y - this.triforce.Height);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void Action() { }
        public void PickUpItem(IItem item) { }
        public void PickUpTriforce(IItem triforce) { }
        public void Die() { }
        public void Charge() { }
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.PickingUpTriforce, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, linkPlayer.Location);
            triforce.Draw(spriteBatch);
        }

        public void Update()
        {
            linkSprite.Update();
            triforce.Update();
            if (linkSprite.AnimationDone())
                linkPlayer.SetState(linkPlayer.GetStateStandingDown());
        }
    }
}
