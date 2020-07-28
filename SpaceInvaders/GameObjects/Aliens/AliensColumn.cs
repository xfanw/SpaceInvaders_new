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
            ForwardIterator pIt = new ForwardIterator(this);

            Component pNode = pIt.First();
            Debug.Assert(pNode != null);

            GameObject pGameObj = (GameObject)Iterator.GetChild(this);

            CollisionRect ColTotal = this.pCollosionObject.poCollisionRect;
            ColTotal.Set(pGameObj.GetCollisionObject().poCollisionRect);
            // Debug.WriteLine("\n");
            while (!pIt.IsDone())
            {
                pGameObj = (GameObject)pNode;
                //Debug.WriteLine("obj:{0} ", pGameObj.GetHashCode());

                ColTotal.Union(pGameObj.GetCollisionObject().poCollisionRect);
                pNode = pIt.Next();
            }

            //this.pColObj.pColRect.Set(201, 201, 201, 201);
            this.x = this.pCollosionObject.poCollisionRect.x;
            this.y = this.pCollosionObject.poCollisionRect.y;

            //  Debug.WriteLine("x:{0} y:{1} w:{2} h:{3}", ColTotal.x, ColTotal.y, ColTotal.width, ColTotal.height);

            base.Update();

        }


        // Data

    }
}
