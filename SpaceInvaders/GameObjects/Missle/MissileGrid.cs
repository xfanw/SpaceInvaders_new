using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileGrid : Composite
    {
        public MissileGrid(MissileCategory.Name name, float posX = 0.0f, float posY = 0.0f) : base(name)
        {
            this.x = posX;
            this.y = posY;
            this.pCollosionObject.pCollsionBoxSprite.SetLineColor(1, 0, 1);
        }


        public override void Update()
        {
            baseUpdateBoundingBox();
            base.Update();
        }

        // Visitor + Collision
        public override void Accept(CollisionVisitor other)
        {
            other.VisitMissileGroup(this);
        }


        // Aliens
        public override void VisitAlienGrid(AliensGrid g)
        {
            // MissileGroup vs AliensGrid 
            Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());

            // Missile vs AliensCol
            ColPair.Collide((GameObject)g.GetFirstChild(), (GameObject)this.GetFirstChild());
        }

        public override void VisitAlienColumn(AliensColumn c)
        {
            // AliensCol vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", c.GetName(), this.GetName());

            // Missile vs AliensCol
            ColPair.Collide((GameObject)this.GetFirstChild(), (GameObject)this.GetFirstChild());
        }
        public override void VisitAlien(Alien a)
        {
            // Aliens vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", a.GetName(), this.GetName());

            // Missile vs Alien
            ColPair.Collide((GameObject)this.GetFirstChild(), a);
        }

        // Wall
        public override void VisitWallGroup(WallGrid g)
        {
            // MissileGroup vs WallGrid 
           // Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());

            // Missile vs AliensCol
            ColPair.Collide((GameObject)g.GetFirstChild(), this);
        }

        public override void VisitTopWall(WallTop g)
        {
            // MissileGroup vs Top Wall
            Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());

            // Missile vs AliensCol
           // ColPair.Collide((GameObject)g.GetFirstChild(), this);
           
        }

    }
}
