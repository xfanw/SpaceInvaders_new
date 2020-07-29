using System.Diagnostics;

namespace SpaceInvaders
{
    public class AliensColumn : Composite
    {
        public AliensColumn(GameObject.Name name, float posX = 0, float posY = 0)
        : base(name)
        {
            this.x = posX;
            this.y = posY;
            this.pCollosionObject.pCollsionBoxSprite.SetLineColor(0, 0, 1);
        }

        public override void Update()
        {
            baseUpdateBoundingBox();

            base.Update();

        }

        // Visitor + Collision
        public override void Accept(CollisionVisitor other)
        {
            other.VisitAlienColumn(this);
        }
        public override void VisitMissileGroup(MissileGrid g)
        {
            // AliensColumn vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());

            // Alien vs Missile
            ColPair.Collide((GameObject)g.GetFirstChild(), (GameObject)this.GetFirstChild());
        }

        public override void VisitMissile(Missile m)
        {
            // AliensColumn vs Missile
            Debug.WriteLine("         collide:  {0} <-> {1}", m.GetName(), this.GetName());

            // Alien vs Missile 
            ColPair.Collide(m, (GameObject)this.GetFirstChild());
        }


    }
}
