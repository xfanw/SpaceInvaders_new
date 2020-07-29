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

        public override void Accept(CollisionVisitor other)
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            baseUpdateBoundingBox();

            base.Update();

        }


        // Data

    }
}
