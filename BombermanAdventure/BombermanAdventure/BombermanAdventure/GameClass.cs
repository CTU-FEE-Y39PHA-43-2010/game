using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using BombermanAdventure.Cameras;
using BombermanAdventure.Models;


namespace BombermanAdventure
{
    /// <summary>
    /// Hlavn� t��da GameClass d�d�c� od t��dy Game, kter� je z�kladn� stavebn� k�men XNA aplikace.
    /// </summary>
    public class GameClass : Microsoft.Xna.Framework.Game
    {

        // prom�nn�, se kter�m budeme v t�to t��d� pracovat
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        // property pro sirku okna
        private static int screenWidth;
        public static int ScreenWidth
        {
            get { return screenWidth; }
        }

        // property pro vysku okna
        private static int screenHeight;
        public static int ScreenHeight
        {
            get { return screenHeight; }
        }

        MenuSession menuSession;
        LevelBase worldSession;
        Camera camera;
        ModelList models;

        public GameClass()
        {
            graphics = new GraphicsDeviceManager(this);

            // nastav�me rozli�en� na�� aplikace pomoc� instance graphics z GraphicsDeviceManager
            graphics.PreferredBackBufferWidth = screenWidth = 1000; //1440;
            graphics.PreferredBackBufferHeight = screenHeight = 800;// 900;

   //         graphics.IsFullScreen = true;
            // povol�me kurzor na obrazovce
            base.IsMouseVisible = true;

            this.Window.Title = "Bomberman Adventure";
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Dovoluje inicializovat v�ci pot�ebn� p�ed samotn�m spu�t�n�m.
        /// </summary>
        protected override void Initialize()
        {
            // Va�i inicializa�n� logiku p�idejte zde

            menuSession = new MenuSession(this);

            worldSession = new LevelBase(this);            

            float aspectRatio = graphics.GraphicsDevice.Viewport.Width /
                (float)graphics.GraphicsDevice.Viewport.Height;
            
            // inicializace kamery a urceni pocatecni pozice
            camera = new Camera(aspectRatio);
            camera.CameraPosition = new Vector3(0, 100, 100);

            models = ModelList.GetInstance();
            models.Camera = camera;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent je zavol�na jedou na za��tku
        /// V�echen n� obsah nahrajeme pr�v� v t�to metod�
        /// </summary>
        protected override void LoadContent()
        {
            // Vytvo��me SpriteBatch, kter� n�m umo�n� vykreslovat textury na obrazovku
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Vytvo��me SpriteFont, kter� n�m umo�n� vykreslovat text na obrazovku
            spriteFont = Content.Load<SpriteFont>("myFont");
        }

        /// <summary>
        /// Funkce se vol� jednou za b�hu aplikace a m� na starost odalokov�n�
        /// na�ten�ch hern�m dat
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Umo�uje d�ky neust�l�mu vol�n� aktualizovat hern� logiku, sv�t
        /// nebo t�eba detekci koliz�
        /// </summary>
        /// <param name="gameTime">�asov� instance (XNA si po��t� samo)</param>
        protected override void Update(GameTime gameTime)
        {

            //update kamery
            camera.Update();

            if (menuSession.InMenu)
            {
                // updatujeme potomky a instance trid, ktere pou��v�me
                menuSession.Update(gameTime);
            }
            else
            {
                //update sveta
                worldSession.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Vykreslovac� metoda. Stejn� jako Update() se neust�l� vol�,
        /// proto�e je sou��st� hern� smy�ky
        /// </summary>
        /// <param name="gameTime">�asov� instance (XNA si po��t� samo)</param>
        protected override void Draw(GameTime gameTime)
        {
            // vy�ist�me depth buffer �ernou barvou a pot� v logick�m
            // po�ad� vykreslujeme objekty
            GraphicsDevice.Clear(Color.Black);

            // zde mame situaci jednoduchou, but vykreslujeme menu nebo primo uz hru
            if (menuSession.InMenu)
            {
                menuSession.Draw(gameTime);
            }
            else // jdeme kreslit hru
            {
                worldSession.Draw(gameTime);
                //spriteBatch.Begin();
                //spriteBatch.DrawString(spriteFont, "// TODO: Imagine your game here :)", new Vector2(250, 240), Color.White);
                //spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
