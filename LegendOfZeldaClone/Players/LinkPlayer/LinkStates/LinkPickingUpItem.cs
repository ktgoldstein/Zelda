﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkPickingUpItem : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;
        private readonly IItem heldItem;

        public LinkPickingUpItem(ILinkPlayer link, IItem item, int frame = 0)
        {
            linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkPickingUpItemSprite(link.SkinType, frame);
            heldItem = item;

            heldItem.Location = new Vector2(link.Location.X + (link.Width - heldItem.Width) / 2, link.Location.Y - heldItem.Height);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public Direction Action() => Direction.None;
        public void PickUpItem(IItem item) { }
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.PickingUpItem, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, linkPlayer.Location);
            heldItem.Draw(spriteBatch);
        }

        public void Update()
        {
            linkSprite.Update();
            if (linkSprite.AnimationDone())
                linkPlayer.SetState(linkPlayer.GetStateStandingDown());
        }
    }
}
