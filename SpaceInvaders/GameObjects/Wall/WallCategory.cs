
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class WallCategory : Leaf
    {

        public enum Type
        {
            Wall_Left,
            Wall_Right,
            Wall_Top,
            Wall_Bottom,
            Wall_Grid
        }


        public WallCategory(GameSprite.Name spriteName, GameObject.Name name)
            : base(spriteName, name)
        {

        }
    }
}