using System.Diagnostics;

namespace SpaceInvaders
{
    public class BirdGrid : Composite
    {
        public BirdGrid(AlienCategory.Name name, float posX = 0.0f, float posY = 0.0f)
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
