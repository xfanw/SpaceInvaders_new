
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

            BoxSpriteMan.Add( 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            BoxSpriteMan.Add( 550.0f, 100.0f, 50.0f, 100.0f);

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

 
            SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.Name.AngryBirds);
            SpriteBatch pSB_Alieans = SpriteBatchMan.Add(SpriteBatch.Name.Aliens);
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
            GameObject pGameObj;

            // create the factory 

            BirdFactory BF = new BirdFactory(SpriteBatch.Name.AngryBirds);
            BirdGrid pGrid = (BirdGrid)BF.Create(GameObject.Name.BirdGrid, BirdCategory.Type.Grid);

            // Create Column 0
            GameObject pCol0 = BF.Create(GameObject.Name.BirdColumn_0, BirdCategory.Type.Column);
            pGrid.Add(pCol0);

            pGameObj = BF.Create(GameObject.Name.RedBird, BirdCategory.Type.Red, 250.0f + 50.0f, 400.0f);
            pCol0.Add(pGameObj);

            pGameObj = BF.Create(GameObject.Name.YellowBird, BirdCategory.Type.Yellow, 250.0f + 50.0f, 250.0f);
            pCol0.Add(pGameObj);

            GameObject pCol1 = BF.Create(GameObject.Name.BirdColumn_1, BirdCategory.Type.Column);
            pGrid.Add(pCol1);

            pGameObj = BF.Create(GameObject.Name.GreenBird, BirdCategory.Type.Green, 250.0f + 50.0f, 300.0f);
            pCol1.Add(pGameObj);

            pGameObj = BF.Create(GameObject.Name.WhiteBird, BirdCategory.Type.White, 250.0f + 50.0f, 300.0f);
            pCol1.Add(pGameObj);

            pGrid.Print();


            Debug.WriteLine("\n");
            Debug.WriteLine("Iterator...\n");
            ForwardIterator pIt = new ForwardIterator(pGrid);

            Component pNode = pIt.First();
            while (!pIt.IsDone())
            {
                pNode.Dump();
                pNode = pIt.Next();
            }



 
            AliensFactory af = new AliensFactory(SpriteBatch.Name.Aliens);
            AliensGrid pAGrid = (AliensGrid)af.Create(GameObject.Name.Aliens_Grid, AlienCategory.Type.Grid);
            GameObject pC0 = af.Create(GameObject.Name.C0, AlienCategory.Type.Column);
            pAGrid.Add(pC0);
            GameObject pC1 = af.Create(GameObject.Name.C1, AlienCategory.Type.Column);
            pAGrid.Add(pC1);
            GameObject pC2 = af.Create(GameObject.Name.C2, AlienCategory.Type.Column);
            pAGrid.Add(pC2);
            //GameObject pC3 = af.Create(GameObject.Name.C3, AlienCategory.Type.Column);
            //pAGrid.Add(pC3);
            //GameObject pC4 = af.Create(GameObject.Name.C4, AlienCategory.Type.Column);
            //pAGrid.Add(pC4);
            //GameObject pC5 = af.Create(GameObject.Name.C5, AlienCategory.Type.Column);
            //pAGrid.Add(pC5);
            //GameObject pC6 = af.Create(GameObject.Name.C6, AlienCategory.Type.Column);
            //pAGrid.Add(pC6);
            //GameObject pC7 = af.Create(GameObject.Name.C7, AlienCategory.Type.Column);
            //pAGrid.Add(pC7);
            //GameObject pC8 = af.Create(GameObject.Name.C8, AlienCategory.Type.Column);
            //pAGrid.Add(pC8);
            //GameObject pC9 = af.Create(GameObject.Name.C9, AlienCategory.Type.Column);
            //pAGrid.Add(pC9);
            //GameObject pC10 = af.Create(GameObject.Name.C10, AlienCategory.Type.Column);
            //pAGrid.Add(pC10);

            pGameObj = af.Create(GameObject.Name.R0C0, AlienCategory.Type.Squid, 60.0f + 40.0f * 0, 500.0f - 30.0f * 0);
            pC0.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R1C0, AlienCategory.Type.Squid, 60f + 40.0f * 0, 500.0f - 30.0f * 1);
            pC0.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R2C0, AlienCategory.Type.Crab, 60.0f + 40.0f * 0, 500.0f - 30.0f * 2);
            pC0.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R3C0, AlienCategory.Type.Crab, 60.0f + 40.0f * 0, 500.0f - 30.0f * 3);
            pC0.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R4C0, AlienCategory.Type.Octopus, 60.0f + 40.0f * 0, 500.0f - 30.0f * 4);
            pC0.Add(pGameObj);

            pGameObj = af.Create(GameObject.Name.R0C1, AlienCategory.Type.Squid, 60.0f + 40.0f * 1, 500.0f - 30.0f * 0);
            pC1.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R1C1, AlienCategory.Type.Squid, 60.0f + 40.0f * 1, 500.0f - 30.0f * 1);
            pC1.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R2C1, AlienCategory.Type.Crab, 60.0f + 40.0f * 1, 500.0f - 30.0f * 2);
            pC1.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R3C1, AlienCategory.Type.Crab, 60.0f + 40.0f * 1, 500.0f - 30.0f * 3);
            pC1.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R4C1, AlienCategory.Type.Octopus, 60.0f + 40.0f * 1, 500.0f - 30.0f * 4);
            pC1.Add(pGameObj);


            pGameObj = af.Create(GameObject.Name.R0C2, AlienCategory.Type.Squid, 60.0f + 40.0f * 2, 500.0f - 30.0f * 0);
            pC2.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R1C2, AlienCategory.Type.Squid, 60.0f + 40.0f * 2, 500.0f - 30.0f * 1);
            pC2.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R2C2, AlienCategory.Type.Crab, 60.0f + 40.0f * 2, 500.0f - 30.0f * 2);
            pC2.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R3C2, AlienCategory.Type.Crab, 60.0f + 40.0f * 2, 500.0f - 30.0f * 3);
            pC2.Add(pGameObj);
            pGameObj = af.Create(GameObject.Name.R4C2, AlienCategory.Type.Octopus, 60.0f + 40.0f * 2, 500.0f - 30.0f * 4);
            pC2.Add(pGameObj);
            pAGrid.Print();

            Debug.WriteLine("\n");
            Debug.WriteLine("Iterator...\n");
             pIt = new ForwardIterator(pAGrid);

             pNode = pIt.First();
            while (!pIt.IsDone())
            {
                pNode.Dump();
                pNode = pIt.Next();
            }


            //---------------------------------------------------------------------------------------------------------
            // Create Missile
            //---------------------------------------------------------------------------------------------------------

            MissileGrid pMissileGrid = new MissileGrid( GameObject.Name.Missile_Grid);
            pMissileGrid.ActivateGameSprite(pSB_Birds);
            pMissileGrid.ActivateCollisionSprite(pSB_Birds);

            Missile pMissile = new Missile(GameSprite.Name.BlueBird, GameObject.Name.Missile, 405, 100);
            pMissile.ActivateGameSprite(pSB_Birds);
            pMissile.ActivateCollisionSprite(pSB_Birds);

            pMissileGrid.Add(pMissile);
            GameObjectMan.Attach(pMissile);
            GameObjectMan.Attach(pMissileGrid);

            Debug.WriteLine("-------------------");


            //---------------------------------------------------------------------------------------------------------
            // ColPair 
            //---------------------------------------------------------------------------------------------------------

            // associate in a collision pair
            ColPairMan.Add(pMissileGrid, pAGrid);


        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            // Add your update below this line: ----------------------------

            // Fire off the timer events
            TimerMan.Update(this.GetTime());
            
            GameObjectMan.Update();

            Debug.WriteLine("\n------------------------------------");
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

