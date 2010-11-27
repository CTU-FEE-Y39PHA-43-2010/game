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
    /// Hlavní tøída GameClass dìdící od tøídy Game, která je základní stavební kámen XNA aplikace.
    /// </summary>
    public class GameClass : Microsoft.Xna.Framework.Game
    {

        // promìnné, se kterým budeme v této tøídì pracovat
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

            // nastavíme rozlišení naší aplikace pomocí instance graphics z GraphicsDeviceManager
            graphics.PreferredBackBufferWidth = screenWidth = 1000; //1440;
            graphics.PreferredBackBufferHeight = screenHeight = 800;// 900;

   //         graphics.IsFullScreen = true;
            // povolíme kurzor na obrazovce
            base.IsMouseVisible = true;

            this.Window.Title = "Bomberman Adventure";
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Dovoluje inicializovat vìci potøebné pøed samotným spuštìním.
        /// </summary>
        protected override void Initialize()
        {
            // Vaši inicializaèní logiku pøidejte zde

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
        /// LoadContent je zavolána jedou na zaèátku
        /// Všechen náš obsah nahrajeme právì v této metodì
        /// </summary>
        protected override void LoadContent()
        {
            // Vytvoøíme SpriteBatch, který nám umožní vykreslovat textury na obrazovku
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Vytvoøíme SpriteFont, který nám umožní vykreslovat text na obrazovku
            spriteFont = Content.Load<SpriteFont>("myFont");
        }

        /// <summary>
        /// Funkce se volá jednou za bìhu aplikace a má na starost odalokování
        /// naètených herním dat
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Umožuje díky neustálému volání aktualizovat herní logiku, svìt
        /// nebo tøeba detekci kolizí
        /// </summary>
        /// <param name="gameTime">Èasová instance (XNA si poèítá samo)</param>
        protected override void Update(GameTime gameTime)
        {

            //update kamery
            camera.Update();

            if (menuSession.InMenu)
            {
                // updatujeme potomky a instance trid, ktere používáme
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
        /// Vykreslovací metoda. Stejnì jako Update() se neustálé volá,
        /// protože je souèástí herní smyèky
        /// </summary>
        /// <param name="gameTime">Èasová instance (XNA si poèítá samo)</param>
        protected override void Draw(GameTime gameTime)
        {
            // vyèistíme depth buffer èernou barvou a poté v logickém
            // poøadí vykreslujeme objekty
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
