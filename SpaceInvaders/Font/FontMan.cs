using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{

    class FontMan : Manager
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private FontMan(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
        }
        ~FontMan()
        {

        }

        //----------------------------------------------------------------------
        // Static Manager methods can be implemented with base methods 
        // Can implement/specialize more or less methods your choice
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pMan == null);

            // Do the initialization
            if (pMan == null)
            {
                pMan = new FontMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {

        }
        public static Font Add(Font.Name name, SpriteBatch.Name SB_Name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            FontMan pMan = FontMan.privGetInstance();

            Font pNode = (Font)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, pMessage, glyphName, xStart, yStart);

            // Add to sprite batch
            SpriteBatch pSB = SpriteBatchMan.Find(SB_Name);
            Debug.Assert(pSB != null);
            Debug.Assert(pNode.pFontSprite != null);
            pSB.Attach(pNode.pFontSprite);

            return pNode;
        }

        public static void AddXml(Glyph.Name glyphName, String assetName,Texture.Name textName)
        {
            GlyphMan.AddXml(glyphName, assetName, textName);
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            FontMan pMan = FontMan.privGetInstance();
            pMan.baseRemove(pNode);
            pNode.Wash();
        }
        public static Font Find(Font.Name name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((Font)ptr).GetName() == name)
                {
                    return (Font)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }


        public static void Dump()
        {
            FontMan pMan = FontMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.WriteLine("------ Font Manager ------");
            pMan.baseDump();
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------

        override protected DLink derivedCreate()
        {
            DLink pNode = new Font();
            Debug.Assert(pNode != null);
            return pNode;
        }

        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Font pNode = (Font)pLink;

            Debug.Assert(pNode != null);
            pNode.Dump();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static FontMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pMan != null);

            return pMan;
        }



        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static FontMan pMan = null;
    }
}
