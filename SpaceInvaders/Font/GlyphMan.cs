﻿using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GlyphMan : Manager
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private GlyphMan(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
        }
        ~GlyphMan()
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
                pMan = new GlyphMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy()
        {

        }
        public static Glyph Add(Glyph.Name name, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            GlyphMan pMan = GlyphMan.privGetInstance();

            Glyph pNode = (Glyph)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, key, textName, x, y, width, height);
            return pNode;
        }

        public static void AddXml(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            System.Xml.XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            // I'm sure there is a better way to do this... but this works for now
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element 
                        if (reader.Name == "character")
                        {
                            // have all the data... so now create a glyph
                            //Debug.WriteLine("key:{0} x:{1} y:{2} w:{3} h:{4}", key, x, y, width, height);
                            GlyphMan.Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }

         // Debug.Write("\n");
        }

        public static void Remove(Glyph pGlyph)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pGlyph != null);

            pMan.baseRemove(pGlyph);
            pGlyph.Wash();
        }
        public static Glyph Find(Glyph.Name name, int key)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((Glyph)ptr).GetKey() == key)
                {
                    return (Glyph)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }

        public static void Dump()
        {
            GlyphMan pMan = GlyphMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.WriteLine("------ Glyph Manager ------");
            pMan.baseDump();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GlyphMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pMan != null);

            return pMan;
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------

        protected override void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Glyph pNode = (Glyph)pLink;

            Debug.Assert(pNode != null);
            pNode.Dump();
        }

        protected override DLink derivedCreate()
        {
            return new Glyph();
        }

        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static GlyphMan pMan = null;
    }
}
