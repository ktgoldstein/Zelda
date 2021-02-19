using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public interface ILinkState
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public Direction Action();
        public Tuple<LinkStateType, int> GetState();
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }

    public class LinkStandingDown : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingDown(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingDownSprite(link.SkinType, frame);
        }
        
        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());
        
        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemDown());
            return Direction.Down;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.StandingDown, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }

    public class LinkStandingUp : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingUp(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingUpSprite(link.SkinType, frame);
        }

        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());
        
        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemUp());
            return Direction.Up;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.StandingUp, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }

    public class LinkStandingLeft : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingLeft(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingLeftSprite(link.SkinType, frame);
        }

        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemLeft());
            return Direction.Left;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.StandingLeft, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }

    public class LinkStandingRight : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingRight(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingRightSprite(link.SkinType, frame);
        }

        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemRight());
            return Direction.Right;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.StandingRight, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }

    public class LinkWalkingDown : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingDown(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingDownSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemDown());
            return Direction.Down;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingDown, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location += new Vector2(0, link.Speed);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingDown());
        }
    }

    public class LinkWalkingUp : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingUp(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingUpSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemUp());
            return Direction.Up;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingUp, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location -= new Vector2(0, link.Speed);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingUp());
        }
    }

    public class LinkWalkingLeft : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingLeft(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeftSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemLeft());
            return Direction.Left;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingLeft, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location -= new Vector2(link.Speed, 0);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingLeft());
        }
    }

    public class LinkWalkingRight : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingRight(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingRightSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public Direction Action()
        {
            link.SetState(link.GetStateUsingItemRight());
            return Direction.Right;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingRight, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location += new Vector2(link.Speed, 0);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingRight());
        }
    }

    public class LinkUsingItemDown : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkUsingItemDown(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkUsingItemDownSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public Direction Action() => Direction.None;
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.UsingItemDown, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingDown());
        }
    }

    public class LinkUsingItemUp : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkUsingItemUp(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkUsingItemUpSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public Direction Action() => Direction.None;
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.UsingItemUp, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingUp());
        }
    }

    public class LinkUsingItemLeft : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkUsingItemLeft(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkUsingItemLeftSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public Direction Action() => Direction.None;
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.UsingItemLeft, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingLeft());
        }
    }

    public class LinkUsingItemRight : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkUsingItemRight(ILinkPlayer link, int frame = 0)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkUsingItemRightSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public Direction Action() => Direction.None;
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.UsingItemRight, sprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingRight());
        }
    }

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
