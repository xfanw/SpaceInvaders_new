using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionObject
    {
        public CollisionObject(ProxySprite pProxy)
        {
            Debug.Assert(pProxy != null);

            this.poCollisionRect = new CollisionRect(pProxy.GetSpriteRect());

            this.pCollsionBoxSprite = BoxSpriteMan.Add(this.poCollisionRect.x, this.poCollisionRect.y, this.poCollisionRect.width, this.poCollisionRect.height);
            Debug.Assert(this.pCollsionBoxSprite != null);
            this.pCollsionBoxSprite.SetLineColor(1.0f, 1.0f, 0.0f);
        }

        public void UpdatePos(ProxySprite pProxy)
        {
            this.poCollisionRect.x = pProxy.x;
            this.poCollisionRect.y = pProxy.y;

            this.pCollsionBoxSprite.SetScreenRect(
                                this.poCollisionRect.x,
                this.poCollisionRect.y, this.poCollisionRect.width, this.poCollisionRect.height);

            this.pCollsionBoxSprite.Update();
        }
        // Data : ----------
        public BoxSprite pCollsionBoxSprite;
        public CollisionRect poCollisionRect;
    }
}
