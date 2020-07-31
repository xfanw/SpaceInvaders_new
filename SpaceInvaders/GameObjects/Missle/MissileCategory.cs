
using System.Security.Cryptography.X509Certificates;

namespace SpaceInvaders
{
    abstract public class MissileCategory : Leaf
    {

        public enum Type
        {
            Missile,
            Missile_Grid
        }


        public MissileCategory(GameSprite.Name spriteName, GameObject.Name name)
            : base(spriteName, name)
        {

        }
    }
}