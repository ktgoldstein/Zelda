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
        public void Action();
        public int Damage(int amount);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
        public void Update(Vector2 location);
    }

    public class LinkNormalStandingDown : ILinkState
    {
        public LinkNormalStandingDown(IPlayer Link)
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }


    }

    public class LinkNormalStandingUp : ILinkState
    {
        public LinkNormalStandingUp(IPlayer Link)
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalStandingLeft : ILinkState
    {

        public LinkNormalStandingLeft(IPlayer Link)
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalStandingRight : ILinkState
    {
        public LinkNormalStandingRight(IPlayer Link)
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalWalkingDown : ILinkState
    {
        public LinkNormalWalkingDown(IPlayer Link)
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalWalkingUp : ILinkState
    {
        public LinkNormalWalkingUp(IPlayer Link)
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    public class LinkNormalWalkingLeft : ILinkState
    {
        public LinkNormalWalkingLeft(IPlayer Link)
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }
    public class LinkNormalWalkingRight : ILinkState
    {
        public LinkNormalWalkingRight(IPlayer Link)
        {

        }
        public void MoveUp()
        {

        }
        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Action()
        {

        }
        public int Damage(int amount)
        {


            return 0;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

        }
        public void Update(Vector2 location)
        {

        }
    }

    // Simon edit after this comment

}
