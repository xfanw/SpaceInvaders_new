using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class ImageMan : Manager
    {
        // private Constructor
        private ImageMan(int init = 2, int delta = 3) : base(init, delta)
        {

        }


        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new ImageMan(init, delta);
            }
            ImageMan.Add(Image.Name.Img_NullObject, Texture.Name.NullObjectTexture, 0, 0, 128, 128);
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

        public static Image Add(Image.Name name, Texture.Name pTexName, int x, int y, int w, int h)
        {
            Debug.Assert(pMan != null);

            Image pImage = (Image)pMan.baseAdd();
            Debug.Assert(pImage != null);


            Texture pTex = TextureMan.Find(pTexName);
            Debug.Assert(pTex != null);

            pImage.SetImage(name, pTex, x, y, w, h);
            return pImage;
        }

        public static void Remove(Image pImage)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pImage != null);

            pMan.baseRemove(pImage);
        }

        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }

        public static Image Find(Image.Name name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((Image)ptr).GetName() == name)
                {
                    return (Image)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }


        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Image pData = (Image)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new Image();
        }

        public static void LoadImage()
        {
            Debug.WriteLine("...Loading Image...");
            // --- Ship --- 
            Add(Image.Name.Img_Ship, Texture.Name.Invader_4, 158, 186, 73, 52);

            Add(Image.Name.Img_ShipDie1, Texture.Name.Invader_3, 247, 1020, 226, 120);
            Add(Image.Name.Img_ShipDie2, Texture.Name.Invader_3, 488, 1020, 226, 120);

            // --- Bullet ---
            Add(Image.Name.Img_ShipBullet, Texture.Name.Invader_4, 240, 280, 4, 32);

            // --- Alien ---

            // Squid
            Add(Image.Name.Img_Squid_Open, Texture.Name.Invader_4, 280, 2, 80, 80);
            Add(Image.Name.Img_Squid_Close, Texture.Name.Invader_4, 408, 2, 80, 80);

            // Octopus
            Add(Image.Name.Img_Octopus_Open, Texture.Name.Invader_4, 132, 93, 120, 80);
            Add(Image.Name.Img_Octopus_Close, Texture.Name.Invader_4, 4, 92, 120, 80);

            // Crab
            Add(Image.Name.Img_Crab_Open, Texture.Name.Invader_4, 137, 2, 110, 80);
            Add(Image.Name.Img_Crab_Close, Texture.Name.Invader_4, 9, 2, 110, 80);

            // Die 
            Add(Image.Name.Img_AlienDie1, Texture.Name.Invader_3, 517, 1252, 165, 135);
            Add(Image.Name.Img_AlienDie2, Texture.Name.Invader_3, 262, 1252, 195, 135);

            // --- Bomb ---
            Add(Image.Name.Img_BombT, Texture.Name.Invader_3, 567, 1507, 47, 105);
            Add(Image.Name.Img_BombZigZag, Texture.Name.Invader_3, 337, 1748, 47, 105);
            Add(Image.Name.Img_BombCross, Texture.Name.Invader_3, 337, 1507, 47, 105);

            // --- UFO ---
            Add(Image.Name.Img_UFO, Texture.Name.Invader_3, 120, 788, 240, 105);
            Add(Image.Name.Img_UFODie, Texture.Name.Invader_3, 563, 788, 305, 105);

            // Bick
            Add(Image.Name.Img_Brick, Texture.Name.Invader_3, 130, 2700, 75, 30);

            // Brick - left corners
            Add(Image.Name.Img_BrickLeft_Top0, Texture.Name.Invader_3, 0, 2655, 75, 30);
            Add(Image.Name.Img_BrickLeft_Top1, Texture.Name.Invader_3, 0, 2685, 75, 30);
            Add(Image.Name.Img_BrickLeft_Bottom, Texture.Name.Invader_3, 70, 2805, 75, 30);

            // Brick - right corners
            Add(Image.Name.Img_BrickRight_Top0, Texture.Name.Invader_3, 256, 2655, 75, 30);
            Add(Image.Name.Img_BrickRight_Top1, Texture.Name.Invader_3, 256, 2685, 75, 30);
            Add(Image.Name.Img_BrickRight_Bottom, Texture.Name.Invader_3, 180, 2805, 75, 30);
            Debug.WriteLine("Done!");
        }

        // Data: ----------
        private static ImageMan pMan;
    }
}
