using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class BoxSpriteMan : Manager
    {
        // private Constructor
        private BoxSpriteMan(int init = 2, int delta = 3) : base(init, delta)
        {
        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new BoxSpriteMan(init, delta);
            }

        }

        public static void Destroy()
        {

            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            pMan.baseDestroy();
            // invalidate the singleton

            pMan = null;
        }

        public static BoxSprite Add( float x, float y, float w, float h, Azul.Color pColor = null)
        {
            Debug.Assert(pMan != null);

            BoxSprite pSprite = (BoxSprite)pMan.baseAdd();
            Debug.Assert(pSprite != null);

            
            if (pColor == null)
            {
                pColor = new Azul.Color(1,1,1);
            }

            pSprite.Set( x, y, w, h, pColor);
            return pSprite;
        }

        public static void Remove(BoxSprite pSprite)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pSprite != null);

            pMan.baseRemove(pSprite);
            pSprite.Wash();
        }

        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }


        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            BoxSprite pData = (BoxSprite)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new BoxSprite();
        }


        // Data: ----------
        private static BoxSpriteMan pMan;

    }
}
