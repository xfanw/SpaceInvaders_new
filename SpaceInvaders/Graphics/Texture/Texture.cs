using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class TextureLink : DLink
    {
        public TextureLink() : base()
        {

        }
    }
    public class Texture: TextureLink
    {
        public enum Name
        {
            Consolas,
            Invader_3,
            Invader_4,

            NullObjectTexture,
            
            //test
            Birds,
            PacMan,
            //test

            uninitialized

        }

        public Texture(Texture.Name name, string pTextureName)
        {
            Debug.Assert(pTextureName != null);

            // Do the create and load
            this.pAzulTex = new Azul.Texture(pTextureName);
            Debug.Assert(this.pAzulTex != null);

            this.name = name;
        }

        public void SetTexture(Name name, string path)
        {
            Debug.Assert(path != null);

            // Do the create and load
            this.pAzulTex = new Azul.Texture(path);
            Debug.Assert(this.pAzulTex != null);

            this.name = name;
        }

        public void SetTextureName(Name name)
        {
            this.name = name;
        }

        public Texture.Name GetName()
        {
            return this.name;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.pAzulTex;
        }

        public void Wash()
        {
            this.name = Name.uninitialized;
        }
        public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Prev Node
            if (this.pPrev == null)
            {
                Debug.WriteLine("      prev: null");
            }
            else
            {
                Texture pTmp = (Texture)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            // Next Node
            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                Texture pTmp = (Texture)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

        }
        // Data: ----------
        private Texture.Name name;
        private Azul.Texture pAzulTex;


    }
}
