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


namespace BombermanAdventure.Models
{
    /// <summary>
    /// Tøída MenuSession pøedstavuje tøídu vykreslující menu aplikace. Dìdí ze tøídy DrawableGameComponent,
    /// takže v ní mùžeme vykreslovat objekty, které ji budou náležet. Klíèové metody je potøeba overridnout
    /// </summary>
    public class MenuSession : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D txBackground;

        MenuItem newGameItem;
        MenuItem creditsItem;
        MenuItem quitGameItem;


        // indikuje, zda mame vykreslovat menu (nebo neco jineho)
        bool inMenu = true;
        public bool InMenu
        {
            get { return inMenu; }
            set { inMenu = value; }
        }

        public MenuSession(Game game) : base(game)
        {
            // Kontruktor children komponent v aplikaci
            Initialize();
        }


        /// <summary>
        /// Dovoluje inicializovat vìci potøebné pøed samotným spuštìním.
        /// </summary>
        public override void Initialize()
        {
            // Vaši inicializaèní logiku pøidejte zde

            // inicializece polozky New Game
            newGameItem = new MenuItem(Game, new Vector2(70, 260), "New Game");

            // inicializece polozky New Game
            creditsItem = new MenuItem(Game, new Vector2(70, 320), "Credits");

            // inicializece polozky Quit Game
            quitGameItem = new MenuItem(Game, new Vector2(70, 380), "Quit Game");

            base.Initialize();

            // Naèteme potøebné vìci pro menu
            LoadContent();
        }



        /// <summary>
        /// LoadContent je zavolána jedou na zaèátku - zde v metodì Initialize
        /// Všechen náš obsah nahrajeme právì v této metodì
        /// </summary>
        protected override void LoadContent()
        {
            // init SpriteBatche
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // nacteni textury pozadi menu
            txBackground = Game.Content.Load<Texture2D>("menuBackground");

            base.LoadContent();
        }

        /// <summary>
        /// Umožuje díky neustálému volání aktualizovat herní logiku, svìt
        /// nebo tøeba detekci kolizí
        /// </summary>
        /// <param name="gameTime">Èasová instance (XNA si poèítá samo)</param>
        public override void Update(GameTime gameTime)
        {
            // updatujeme instance trid, ktere používáme
            newGameItem.Update(gameTime);
            creditsItem.Update(gameTime);
            quitGameItem.Update(gameTime);

            // Zde bychom meli implementovat volani metod na zaklade kliknuti na tlaticko
            // Je na miste si pripomenout, ze kdyz budeme drzet leve tlacitko napriklad vterinu,
            // tak diky herni smycce se tento if segment provede treba 50 krat, takze je dobre si
            // nekde aktualizovat stav (pomoci boolean). Pri releasu tlacitka pak opet segment povolit.
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                // credits - kliknuti tlacitkem + zaroven mys ukazuje na specificke tlacitko
                if (newGameItem.IsIntersected)
                {
                    InMenu = false;
                }
                
                // credits - kliknuti tlacitkem + zaroven mys ukazuje na specificke tlacitko
                if (creditsItem.IsIntersected)
                {
                    //
                }

                // ukonceni hry - kliknuti tlacitkem + zaroven mys ukazuje na specificke tlacitko
                if (quitGameItem.IsIntersected)
                {
                    Game.Exit();
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Vykreslovací metoda. Stejnì jako Update() se neustálé volá,
        /// protože je souèástí herní smyèky
        /// </summary>
        /// <param name="gameTime">Èasová instance (XNA si poèítá samo)</param>
        public override void Draw(GameTime gameTime)
        {
            // nejdrive vykreslime pozadi menu
            spriteBatch.Begin();
            spriteBatch.Draw(txBackground, new Rectangle(0,0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.End();

            // pote vykreslime polozky menu
            newGameItem.Draw(gameTime);
            creditsItem.Draw(gameTime);
            quitGameItem.Draw(gameTime);


            base.Draw(gameTime);
        }

    }
}