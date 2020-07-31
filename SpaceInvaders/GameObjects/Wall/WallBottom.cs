using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallBottom : WallCategory
    {
        public WallBottom(GameSprite.Name spriteName, GameObject.Name name, float posX, float posY, float width = 1, float height = 1) : base(spriteName, name)
        {
            this.pCollosionObject.poCollisionRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.pCollosionObject.pCollsionBoxSprite.SetLineColor(1, 1, 0);
        }

        ~WallBottom() { }



        // Visitor + Collision
        public override void Accept(CollisionVisitor other)
        {
            other.VisitBottomWall(this);
        }
        private void Hit()
        {
            Debug.WriteLine("Wall Hit by Missle");

        }
    }
}
