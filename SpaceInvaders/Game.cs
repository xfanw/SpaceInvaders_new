
using Azul;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    class SpaceInvaders : Azul.Game
    {
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Sprites");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.4f, 0.4f, 0.8f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Setup Managers
            //---------------------------------------------------------------------------------------------------------

            TextureMan.Create(1, 1);
            ImageMan.Create(5, 2);
            GameSpriteMan.Create(4, 2);
            BoxSpriteMan.Create(3, 1);
            SpriteBatchMan.Create(3, 1);
            TimerMan.Create(3, 1);
            ProxyMan.Create(10, 1);
            GameObjectMan.Create(10, 5);
            ColPairMan.Create(3, 1);
            GlyphMan.Create(3, 1);
            FontMan.Create(1, 1);
            //---------------------------------------------------------------------------------------------------------
            // Sound Experiment
            //---------------------------------------------------------------------------------------------------------
            SoundMan.Create(5, 3);
            SoundMan.LoadAll();
            // play a sound file
            SoundMan.PlayMusic(Sound.Name.Snd_Theme);
            SoundMan.Find(Sound.Name.Snd_Theme).SetVolume(0.2f);

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            TextureMan.Add(Texture.Name.Birds, "Birds.tga");
            TextureMan.Add(Texture.Name.PacMan, "PacMan.tga");

            TextureMan.Add(Texture.Name.Consolas, "Consolas20pt.tga");
            TextureMan.Add(Texture.Name.Invader_3, "Invaders_3.tga");
            TextureMan.Add(Texture.Name.Invader_4, "Invaders_4.tga");
            TextureMan.LoadTexture();

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------

            // --- angry birds ---

            ImageMan.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);
            ImageMan.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);
            ImageMan.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);
            ImageMan.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);
            ImageMan.Add(Image.Name.BlueBird, Texture.Name.Birds, 301, 49, 33, 33);
            // --- Pacman Ghosts ---

            ImageMan.Add(Image.Name.RedGhost, Texture.Name.PacMan, 616, 148, 33, 33);
            ImageMan.Add(Image.Name.PinkGhost, Texture.Name.PacMan, 663, 148, 33, 33);
            ImageMan.Add(Image.Name.BlueGhost, Texture.Name.PacMan, 710, 148, 33, 33);
            ImageMan.Add(Image.Name.OrangeGhost, Texture.Name.PacMan, 757, 148, 33, 33);

            // --- Alians ---
            ImageMan.LoadImage();

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            // --- BoxSprites ---

            BoxSpriteMan.Add(550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            BoxSpriteMan.Add(550.0f, 100.0f, 50.0f, 100.0f);

            GameSpriteMan.Add(GameSprite.Name.RedBird, Image.Name.RedBird, 50, 500, 50, 50);
            GameSpriteMan.Add(GameSprite.Name.YellowBird, Image.Name.YellowBird, 300, 400, 50, 50);
            GameSpriteMan.Add(GameSprite.Name.GreenBird, Image.Name.GreenBird, 400, 200, 50, 50);
            GameSpriteMan.Add(GameSprite.Name.WhiteBird, Image.Name.WhiteBird, 600, 200, 100, 100);
            GameSpriteMan.Add(GameSprite.Name.BlueBird, Image.Name.BlueBird, 50, 50, 50, 50);

            GameSpriteMan.Add(GameSprite.Name.RedGhost, Image.Name.RedGhost, 100, 300, 100, 100);
            GameSpriteMan.Add(GameSprite.Name.PinkGhost, Image.Name.PinkGhost, 300, 300, 100, 100);
            GameSpriteMan.Add(GameSprite.Name.BlueGhost, Image.Name.BlueGhost, 500, 300, 100, 100);
            GameSpriteMan.Add(GameSprite.Name.OrangeGhost, Image.Name.OrangeGhost, 700, 300, 100, 100);

            GameSpriteMan.LoadGameSprite();
            // Create SpriteBatch
            //---------------------------------------------------------------------------------------------------------

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Batch_Texts);
            SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.Name.Batch_AngryBirds);
            SpriteBatch pSB_Alieans = SpriteBatchMan.Add(SpriteBatch.Name.Batch_Aliens);
            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Batch_Boxes);
            //---------------------------------------------------------------------------------------------------------
            // Attach to Sprite Batch
            //---------------------------------------------------------------------------------------------------------


            pSB_Birds.Attach(GameSprite.Name.RedBird);
            pSB_Birds.Attach(GameSprite.Name.YellowBird);
            pSB_Birds.Attach(GameSprite.Name.GreenBird);
            pSB_Birds.Attach(GameSprite.Name.WhiteBird);


            //---------------------------------------------------------------------------------------------------------
            // Proxy
            //---------------------------------------------------------------------------------------------------------

            // create 10 proxies
            for (int i = 0; i < 10; i++)
            {
                ProxySprite pProxy = ProxyMan.Add(GameSprite.Name.YellowBird);
                pProxy.x = 50.0f + 70 * i;
                pProxy.y = 100.0f;
                pSB_Birds.Attach(pProxy);
            }
            //---------------------------------------------------------------------------------------------------------
            // Game Object
            //---------------------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------------------
            // Create Birds
            //---------------------------------------------------------------------------------------------------------
            
            // create the factory 

            BirdFactory BF = new BirdFactory(SpriteBatch.Name.Batch_AngryBirds);
            BirdGrid pGrid = (BirdGrid)BF.Create(GameObject.Name.BirdGrid, BirdCategory.Type.Grid);
            GameObjectMan.Attach(pGrid);
            BF.LoadAll(pGrid);


            AliensFactory af = new AliensFactory(SpriteBatch.Name.Batch_Aliens);
            GameObject pAlienGrid = af.Create(GameObject.Name.Aliens_Grid, AlienCategory.Type.Grid);            
            GameObjectMan.Attach(pAlienGrid);
            af.LoadAll(pAlienGrid);

            //pAlienGrid.Print();

            //---------------------------------------------------------------------------------------------------------
            // Create Walls
            //---------------------------------------------------------------------------------------------------------

            // Wall Root
            WallFactory WF = new WallFactory();
            WallGrid pWallGrid = (WallGrid)WF.Create(GameObject.Name.Wall_Grid, WallCategory.Type.Wall_Grid, 0.0f, 0.0f);
            GameObjectMan.Attach(pWallGrid);

            WallLeft pWallLeft = (WallLeft)WF.Create(GameObject.Name.Wall_Left, WallCategory.Type.Wall_Left, 20, 280, 20, 500);
            WallRight pWallRight = (WallRight)WF.Create(GameObject.Name.Wall_Right, WallCategory.Type.Wall_Right, 780, 280, 20, 500);
            WallTop pWallTop = (WallTop)WF.Create(GameObject.Name.Wall_Top, WallCategory.Type.Wall_Top, 400, 530, 700, 20);
            WallBottom pWallBottom = (WallBottom)WF.Create(GameObject.Name.Wall_Bottom, WallCategory.Type.Wall_Bottom, 400, 20, 700, 20);

            // Add to the composite the children
            pWallGrid.Add(pWallRight);
            pWallGrid.Add(pWallLeft);
            pWallGrid.Add(pWallTop);
            pWallGrid.Add(pWallBottom);


            //---------------------------------------------------------------------------------------------------------
            // Create Missile
            //---------------------------------------------------------------------------------------------------------
            MissileFactory MF = new MissileFactory(SpriteBatch.Name.Batch_Aliens);
            MissileGrid pMissileGrid = (MissileGrid)MF.Create(GameObject.Name.Missile_Grid, MissileCategory.Type.Missile_Grid);
            GameObjectMan.Attach(pMissileGrid);

            Missile pMissile = (Missile)MF.Create(GameObject.Name.Missile, MissileCategory.Type.Missile, 405, 100);            
            pMissileGrid.Add(pMissile);
            Debug.WriteLine("-------------------");


            //---------------------------------------------------------------------------------------------------------
            // ColPair 
            //---------------------------------------------------------------------------------------------------------

            // associate in a collision pair
            ColPair pair = ColPairMan.Add(pMissileGrid, pAlienGrid);
            pair.Attach(new MissileHitAlienAnim());
            pair.Attach(new MissileHitAlienSnd());
            ColPairMan.Add(pWallGrid, pAlienGrid);
            ColPairMan.Add(pWallGrid, pMissileGrid);
            //---------------------------------------------------------------------------------------------------------
            // Font Experiment
            //---------------------------------------------------------------------------------------------------------
            GlyphMan.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas);

            FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Batch_Texts, "ABC", Glyph.Name.Consolas36pt, 500, 500);
            FontMan.Add(Font.Name.TestOneOff, SpriteBatch.Name.Batch_Texts, "XYZ1234!#=+ZYX", Glyph.Name.Consolas36pt, 200, 200);
        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------

        public float vol_delta = 0.005f;
        public int count = 0;
        public int missileCount = 0;
        public override void Update()
        {
            // Add your update below this line: ----------------------------

            //-----------------------------------------------------------
            // Sound Update - place here:
            //-----------------------------------------------------------

            //---------------------------------------------------------------------------------------------------------
            // Font Experiment
            //---------------------------------------------------------------------------------------------------------
            Font pTestMessage = FontMan.Find(Font.Name.TestMessage);
            Debug.Assert(pTestMessage != null);
            pTestMessage.UpdateMessage("dog " + count++);

            // walk through all objects and push to proxy
            GameObjectMan.Update();

            // Do the collision checks
            ColPairMan.Process();

            //-----------------------------------------------------------
            // Sound Experiments
            //-----------------------------------------------------------

            // Adjust music theme volume
            Sound tmpSnd = SoundMan.Find(Sound.Name.Snd_Theme);
            float vol = tmpSnd.GetVolume();
            if (vol > 0.30f)
            {
                vol_delta = -0.002f;
            }
            else if (vol < 0.00f)
            {
                vol_delta = 0.002f;
            }
            tmpSnd.SetVolume(vol + vol_delta);

            InputMan.Update();
            // Load by file
            missileCount++;
            if (missileCount == 200)
            {
                missileCount = 0;
                // play one by file, not by load 
                SoundMan.Play(Sound.Name.Snd_Shoot);
            }

            //// Trigger already loaded sounds
            //if (pMissile.y > 500.0f || pMissile.y < 100.0f)
            //{
            //    pMissile.speed *= -1.0f;

            //    switch (count%4)
            //    {
            //        case 0:
            //            SoundMan.Play(Sound.Name.Snd_HitWall);
            //            break;
            //        case 1:
            //            SoundMan.Play(Sound.Name.Snd_Explosion);
            //            break;
            //        case 2:
            //            SoundMan.Play(Sound.Name.Snd_UFO1);
            //            break;
            //        case 3:
            //            SoundMan.Play(Sound.Name.Snd_UFO2);
            //            break;
            //        default:
            //            Debug.Assert(false);
            //            break;
            //    }

            //}
            // Fire off the timer events
            TimerMan.Update(this.GetTime());

            GameObjectMan.Update();

            //Debug.WriteLine("\n------------------------------------");
            ColPairMan.Process();

        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}

