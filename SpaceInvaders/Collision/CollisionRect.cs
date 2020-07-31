using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionRect : Azul.Rect
    {

        public CollisionRect(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
        }
        public CollisionRect(Azul.Rect rect) : base(rect)
        {
        }
        public CollisionRect(CollisionRect pRect)
            : base(pRect)
        {
        }
        public CollisionRect()
            : base()
        {
        }
        static public bool Intersect(CollisionRect pA, CollisionRect pB)
        {
            if (pA.x + pA.width / 2 < pB.x - pB.width / 2 ||
                pB.x + pB.width / 2 < pA.x - pA.width / 2 ||
                pA.y + pA.height / 2 < pB.y - pB.height / 2 ||
                pB.y + pB.height / 2 < pA.y - pA.height / 2)
            {
                return false;
            }
            return true;
        }

        public void Union(CollisionRect pRect)
        {
            float minX;
            float minY;
            float maxX;
            float maxY;

            if (this.x - this.width / 2 < pRect.x - pRect.width / 2)
            {
                minX = this.x - this.width / 2;
            }
            else
            {
                minX = pRect.x - pRect.width / 2;
            }

            if ((this.x + this.width / 2) > (pRect.x + pRect.width / 2))
            {
                maxX = this.x + this.width / 2;
            }
            else
            {
                maxX = pRect.x + pRect.width / 2;
            }

            if (this.y + this.height / 2 > pRect.y + pRect.height / 2)
            {
                maxY = this.y + this.height / 2;
            }
            else
            {
                maxY = pRect.y + pRect.height / 2;
            }

            if ((this.y - this.height / 2) < (pRect.y - pRect.height / 2))
            {
                minY = this.y - this.height / 2;
            }
            else
            {
                minY = pRect.y - pRect.height / 2;
            }

            this.width = (maxX - minX);
            this.height = (maxY - minY);
            this.x = minX + this.width / 2;
            this.y = minY + this.height / 2;

        }


    }
}
