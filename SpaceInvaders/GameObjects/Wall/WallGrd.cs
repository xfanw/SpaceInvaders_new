using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallGrid : Composite
    {
        public WallGrid(MissileCategory.Name name, int posX = 0, int posY = 0) : base(name)
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
            other.VisitWallGroup(this);
        }

        public override void VisitAlienGrid(AliensGrid g)
        {
            // MissileGroup vs AliensGrid 
            Debug.WriteLine("         collide:  {0} <-> {1}", g.GetName(), this.GetName());

            // Missile vs AliensCol
            ColPair.Collide(g, (GameObject)this.GetFirstChild());
        }

    }
}
