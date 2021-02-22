using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkPickingUpItem : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkPickingUpItem(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkPickingUpItemSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public Direction Action() => Direction.None;
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.PickingUpItem, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingDown());
        }
    }
}
