using System;
using System.Diagnostics;


namespace SpaceInvaders
{

    abstract public class CollisionVisitor : DLink
    {

        public virtual void VisitBirdGroup(BirdGrid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BirdGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBirdColumn(BirdColumn b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BirdColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitRedBird(RedBird b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by RedBird not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitYellowBird(YellowBird b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by YellowBird not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitGreenBird(GreenBird b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }


        public virtual void VisitWhiteBird(WhiteBird b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissile(Missile m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitAlien(Alien a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Aliens not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitAlienGrid(AliensGrid g)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Aliens not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitAlienColumn(AliensColumn c)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Aliens not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitMissileGroup(MissileGrid m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallGroup(WallGrid g)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitLeftWall(WallLeft w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by LeftWall not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitRightWall(WallRight w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by RightWall not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitTopWall(WallTop w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by TopWall not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBottomWall(WallBottom w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BottomWall not implemented");
            Debug.Assert(false);
        }



        public virtual void VisitNullGameObject(NullGameObjs n)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by NullGameObject not implemented");
            Debug.Assert(false);
        }

        abstract public void Accept(CollisionVisitor other);
    }

}