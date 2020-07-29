using System.Diagnostics;

namespace SpaceInvaders
{
    public class AliensGrid : Composite
    {
        public AliensGrid(AlienCategory.Name name, int posX = 0, int posY = 0)
        : base(name)
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
            other.VisitAlienGrid(this);
        }

        public override void VisitMissileGroup(MissileGrid g)
        {
            // AliensGrid vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());

            // AliensCol vs Missile 
            ColPair.Collide((GameObject)g.GetFirstChild(), (GameObject)this.GetFirstChild());
        }

        public override void VisitMissile(Missile m)
        {
            // AliensGrid vs Missile
            Debug.WriteLine("         collide:  {0} <-> {1}", m.GetName(), this.GetName());

            // AliensCol vs Missile
            ColPair.Collide(m, (GameObject)this.GetFirstChild());
        }

    }
}
