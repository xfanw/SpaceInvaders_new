using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class ImageLink : DLink
    {
        public ImageLink() : base()
        {

        }
    }
    public class Image : ImageLink
    {
        public enum Name
        {
            Img_Squid_Open,
            Img_Squid_Close,
            Img_Octopus_Open,
            Img_Octopus_Close,
            Img_Crab_Open,
            Img_Crab_Close,
            
            Img_ShipBullet,
            Img_Ship,
            
            Img_BombT,
            Img_BombZigZag,
            Img_BombCross,
            
            Img_Brick,
            Img_BrickLeft_Top0,
            Img_BrickLeft_Top1,
            Img_BrickLeft_Bottom,
            Img_BrickRight_Top0,
            Img_BrickRight_Top1,
            Img_BrickRight_Bottom,
            
            Img_ShipDie1,
            Img_ShipDie2,
            Img_AlienDie1,
            Img_AlienDie2,
            Img_UFO,
            Img_UFODie,

            Img_NullObject,
            // test
            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,
            BlueBird,
            RedGhost,
            PinkGhost,
            BlueGhost,
            OrangeGhost,
            MsPacMan,
            PowerUpGhost,
            Prezel,
            // test

            Img_uninitialized
        }

        public Image(Image.Name name, Texture pTex, Azul.Rect pSubRect)
        {
            Debug.Assert(pTex != null);

            // Do the create and load
            this.pTex = pTex;
            this.poRect = new Azul.Rect(pSubRect);

            this.name = name;
        }

        public Image()  : base()   
        {
            this.poRect = new Azul.Rect();
            Debug.Assert(this.poRect != null);

            // this.Clear();
        }
        public void SetImage(Name name, Texture pTex, int x, int y, int w, int h)
        {
            
            
            Debug.Assert(pTex != null);
            this.pTex = pTex;

            this.poRect.Set(x, y, w, h);

            this.name = name;
        }

        public void SetImageName(Name name)
        {
            this.name = name;
        }

        public Image.Name GetName()
        {
            return this.name;
        }

        public Texture GetTexture()
        {
            return this.pTex;
        }

        public Azul.Rect GetRect()
        {
            return this.poRect;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.pTex.GetAzulTexture();
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
                Image pTmp = (Image)this.pPrev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            // Next Node
            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                Image pTmp = (Image)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

        }
        // Data: ----------
        private Image.Name name;
        private Texture pTex;
        private Azul.Rect poRect;


    }
}
