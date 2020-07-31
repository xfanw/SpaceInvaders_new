﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    abstract public class Font_DLink : DLink
    {
    }
    public class Font: Font_DLink
    {
        public enum Name
        {
            TestMessage,
            TestOneOff,

            NullObject,
            Uninitialized
        };

        public Font()
            : base()
        {
            this.name = Name.Uninitialized;
            this.pFontSprite = new FontSprite();
        }

        ~Font()
        {

        }

        public void UpdateMessage(String pMessage)
        {
            Debug.Assert(pMessage != null);
            Debug.Assert(this.pFontSprite != null);
            this.pFontSprite.UpdateMessage(pMessage);
        }

        public void Set(Font.Name name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            Debug.Assert(pMessage != null);

            this.name = name;
            this.pFontSprite.Set(name, pMessage, glyphName, xStart, yStart);
        }

        public void Wash()
        {
            this.name = Name.Uninitialized;
            this.pFontSprite.Set(Font.Name.NullObject, pNullString, Glyph.Name.NullObject, 0.0f,0.0f);
        }

        public void Dump()
        {
        }

        public Name GetName()
        {
            return this.name;
        }

        // ----------------------------------------------------------------
        // Data 
        // ----------------------------------------------------------------
        private Name name;
        public FontSprite pFontSprite;
        static private String pNullString = "null";
    }
}
