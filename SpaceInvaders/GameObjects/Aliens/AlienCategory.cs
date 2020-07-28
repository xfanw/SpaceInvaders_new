
using System.Security.Cryptography.X509Certificates;

namespace SpaceInvaders
{
    abstract public class AlienCategory : Leaf
    {

        public enum Type
        {
            // temporary location --> move this

            Crab,
            Squid,
            Octopus,

            Column,
            Grid            
        }


        public AlienCategory(GameSprite.Name spriteName, GameObject.Name name)
            : base(spriteName, name)
        {

        }
    }
}