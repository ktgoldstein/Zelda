using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ILinkState
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public bool Action();
        //public void Damage();
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }

    public class LinkStandingDown : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingDown(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingDownSprite(link.SkinType);
        }
        
        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());
        
        public bool Action()
        {
            link.SetState(link.GetStateUsingItemDown());
            return true;
        }

        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }

    public class LinkStandingUp : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingUp(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingUpSprite(link.SkinType);
        }

        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());
        
        public bool Action()
        {
            link.SetState(link.GetStateUsingItemUp());
            return true;
        }

        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }

    public class LinkStandingLeft : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingLeft(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingLeftSprite(link.SkinType);
        }

        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());

        public bool Action()
        {
            link.SetState(link.GetStateUsingItemLeft());
            return true;
        }

        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }

    public class LinkStandingRight : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkStandingRight(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkStandingRightSprite(link.SkinType);
        }

        public void MoveUp() => link.SetState(link.GetStateWalkingingUp());
        public void MoveDown() => link.SetState(link.GetStateWalkingingDown());
        public void MoveLeft() => link.SetState(link.GetStateWalkingingLeft());
        public void MoveRight() => link.SetState(link.GetStateWalkingingRight());

        public bool Action()
        {
            link.SetState(link.GetStateUsingItemRight());
            return true;
        }

        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);
        public void Update() => sprite.Update();
    }

    public class LinkWalkingDown : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingDown(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingDownSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public bool Action()
        {
            link.SetState(link.GetStateUsingItemDown());
            return true;
        }

        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location += new Vector2(0, LoZHelpers.LinkSpeed);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingDown());
        }
    }

    public class LinkWalkingUp : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingUp(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingUpSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public bool Action()
        {
            link.SetState(link.GetStateUsingItemUp());
            return true;
        }

        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location -= new Vector2(0, LoZHelpers.LinkSpeed);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingUp());
        }
    }

    public class LinkWalkingLeft : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingLeft(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingLeftSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public bool Action()
        {
            link.SetState(link.GetStateUsingItemLeft());
            return true;
        }

        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location -= new Vector2(LoZHelpers.LinkSpeed, 0);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingLeft());
        }
    }

    public class LinkWalkingRight : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkWalkingRight(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkWalkingRightSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }

        public bool Action()
        {
            link.SetState(link.GetStateUsingItemRight());
            return true;
        }

        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            link.Location += new Vector2(LoZHelpers.LinkSpeed, 0);
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingRight());
        }
    }

    public class LinkUsingItemDown : ILinkState
    {
        private readonly ILinkPlayer link;
        private readonly ILinkSprite sprite;

        public LinkUsingItemDown(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkUsingItemDownSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public bool Action() => false;
        //public void Damage();
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

        public LinkUsingItemUp(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkUsingItemUpSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public bool Action() => false;
        //public void Damage();
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

        public LinkUsingItemLeft(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkUsingItemLeftSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public bool Action() => false;
        //public void Damage();
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

        public LinkUsingItemRight(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkUsingItemRightSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public bool Action() => false;
        //public void Damage();
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

        public LinkPickingUpItem(ILinkPlayer link)
        {
            this.link = link;
            sprite = LinkSpriteFactory.Instance.CreateLinkPickingUpItemSprite(link.SkinType);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public bool Action() => false;
        //public void Damage();
        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, link.Location);

        public void Update()
        {
            sprite.Update();
            if (sprite.AnimationDone())
                link.SetState(link.GetStateStandingDown());
        }
    }
}
