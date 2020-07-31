using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class TextureMan : Manager
    {
        // private Constructor
        private TextureMan(int init = 2, int delta = 3) : base(init, delta)
        {
        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new TextureMan(init, delta);
            }


            TextureMan.Add(Texture.Name.NullObjectTexture, "HotPink.tga");
        }

        public static void Destroy()
        {
            Debug.Assert(pMan != null);
            pMan.baseDestroy();

            // invalidate the singleton
            pMan = null;
        }
        public static Texture Add(Texture.Name name, string path)
        {
            Debug.Assert(pMan != null);
            Texture pTexture = (Texture)pMan.baseAdd();
            Debug.Assert(pTexture != null);

            pTexture.SetTexture(name, path);
            return pTexture;
        }

        public static void Remove(Texture pTexture)
        {
            Debug.Assert(pMan != null);
            Debug.Assert(pTexture != null);

            pMan.baseRemove(pTexture);
            pTexture.Wash();
        }
        public static void LoadTexture()
        {
            Debug.WriteLine("...LoadingTexture...");

            TextureMan.Add(Texture.Name.Consolas, "Consolas36pt.tga");
            TextureMan.Add(Texture.Name.Invader_3, "Invaders_3.tga");
            TextureMan.Add(Texture.Name.Invader_4, "Invaders_4.tga");

            Debug.WriteLine("Done!");
        }
        public static void Dump()
        {
            Debug.Assert(pMan != null);
            pMan.baseDump();
        }

        public static Texture Find(Texture.Name name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((Texture)ptr).GetName() == name)
                {
                    return (Texture)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }



        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Texture pData = (Texture)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new Texture(Texture.Name.uninitialized, "HotPink.tga");
        }


        // Data: ----------
        private static TextureMan pMan;

    }
}
