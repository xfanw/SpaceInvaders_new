using System.Diagnostics;
using System.Dynamic;

namespace SpaceInvaders
{
    public class GameSpriteMan : Manager
    {
        // private Constructor
        private GameSpriteMan(int init = 2, int delta = 3) : base(init, delta)
        {
        }

        // public 
        public static void Create(int init = 2, int delta = 2)
        {
            if (pMan == null)
            {
                pMan = new GameSpriteMan(init, delta);
            }

            GameSpriteMan.Add(GameSprite.Name.Sprite_NullObject, Image.Name.Img_NullObject, 0, 0, 0, 0);
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

        public static GameSprite Add(GameSprite.Name name, Image.Name pImgName, int x, int y, int w, int h)
        {
            Debug.Assert(pMan != null);

            GameSprite pSprite = (GameSprite)pMan.baseAdd();
            Debug.Assert(pSprite != null);

            Image pImg = ImageMan.Find(pImgName);
            Debug.Assert(pImg != null);

            pSprite.SetSprite(name, pImg, x, y, w, h);
            return pSprite;
        }

        public static void Remove(GameSprite pSprite)
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

        public static GameSprite Find(GameSprite.Name name)
        {
            DLink ptr = pMan.poActive;
            while (ptr != null)
            {
                if (((GameSprite)ptr).GetName() == name)
                {
                    return (GameSprite)ptr;
                }

                ptr = ptr.pNext;
            }

            return null;
        }



        override protected void derivedDump(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameSprite pData = (GameSprite)pLink;
            pData.Dump();
        }



        protected override DLink derivedCreate()
        {
            return new GameSprite();
        }

        public static void LoadGameSprite()
        {
            Debug.WriteLine("...Loading Sprite...");
            GameSprite colorSprite;
            Add(GameSprite.Name.Sprite_Squid, Image.Name.Img_Squid_Open, 100, 500, 20, 20);

            Add(GameSprite.Name.Sprite_Crab, Image.Name.Img_Crab_Open, 100, 450, 25, 20);

            Add(GameSprite.Name.Sprite_Octopus, Image.Name.Img_Octopus_Open, 100, 350, 30, 20);

            Add(GameSprite.Name.Sprite_Missle, Image.Name.Img_ShipBullet, 350, 100, 4, 10);
            // Ships 1 movable, 2 unmovable
            Add(GameSprite.Name.Sprite_Ship, Image.Name.Img_Ship, 400, 100, 35, 25);
            Add(GameSprite.Name.Sprite_Ship1, Image.Name.Img_Ship, 70, 25, 35, 25);
            Add(GameSprite.Name.Sprite_Ship2, Image.Name.Img_Ship, 120, 25, 35, 25);

            //  Bricks
            Add(GameSprite.Name.Sprite_Brick, Image.Name.Img_Brick, 300, 200, 10, 5);
            Add(GameSprite.Name.Sprite_Brick_LT0, Image.Name.Img_BrickLeft_Top0, 285, 200, 10, 5);
            Add(GameSprite.Name.Sprite_Brick_LT1, Image.Name.Img_BrickLeft_Top1, 285, 195, 10, 5);
            Add(GameSprite.Name.Sprite_Brick_RT0, Image.Name.Img_BrickRight_Top0, 315, 200, 10, 5);
            Add(GameSprite.Name.Sprite_Brick_RT1, Image.Name.Img_BrickRight_Top1, 315, 195, 10, 5);
            Add(GameSprite.Name.Sprite_Brick_LB, Image.Name.Img_BrickLeft_Bottom, 285, 165, 10, 5);
            Add(GameSprite.Name.Sprite_Brick_RB, Image.Name.Img_BrickRight_Bottom, 315, 165, 10, 5);

            colorSprite = Add(GameSprite.Name.Sprite_UFO, Image.Name.Img_UFO, 400, 550, 40, 20);
            colorSprite.SwapColor(0.8f, 0, 0);
            // Bombs
            Add(GameSprite.Name.Sprite_BombT, Image.Name.Img_BombT, 350, 200, 8, 10);
            Add(GameSprite.Name.Sprite_BombZ, Image.Name.Img_BombZigZag, 360, 200, 8, 10);
            Add(GameSprite.Name.Sprite_BombC, Image.Name.Img_BombCross, 370, 200, 8, 10);

            // Death Images
            Add(GameSprite.Name.Sprite_AlienDeath, Image.Name.Img_AlienDie2, 100, 100, 25, 20);
            Add(GameSprite.Name.Sprite_UFODeath, Image.Name.Img_UFODie, 100, 100, 40, 20);
            Add(GameSprite.Name.Sprite_ShipDeath, Image.Name.Img_ShipDie1, 100, 100, 35, 25);
            Debug.WriteLine("Done!");

        }
        // Data: ----------
        private static GameSpriteMan pMan;

    }
}
