using System.Diagnostics;

namespace SpaceInvaders
{
    public class BirdColumn : Composite
    {
        public BirdColumn(GameObject.Name name, float posX = 0, float posY = 0)
        : base( name)
        {
            this.x = posX;
            this.y = posY;
            this.pCollosionObject.pCollsionBoxSprite.SetLineColor(0, 0, 1);
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
