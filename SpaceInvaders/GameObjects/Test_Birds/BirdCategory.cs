
using System.Security.Cryptography.X509Certificates;

namespace SpaceInvaders
{
    abstract public class BirdCategory : Leaf
    {

        public enum Type
        {
            Red,
            Yellow,
            Green,
            White,

            Grid,
            Column
        }


        public BirdCategory(GameSprite.Name spriteName, GameObject.Name name)
            : base(spriteName, name)
        {

        }

        protected float speed = 0.0f;
    }
}