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
    /// T��da MenuSession p�edstavuje t��du vykresluj�c� menu aplikace. D�d� ze t��dy DrawableGameComponent,
    /// tak�e v n� m��eme vykreslovat objekty, kter� ji budou n�le�et. Kl��ov� metody je pot�eba overridnout
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
        /// Dovoluje inicializovat v�ci pot�ebn� p�ed samotn�m spu�t�n�m.
        /// </summary>
        public override void Initialize()
        {
            // Va�i inicializa�n� logiku p�idejte zde

            // inicializece polozky New Game
            newGameItem = new MenuItem(Game, new Vector2(70, 260), "New Game");

            // inicializece polozky New Game
            creditsItem = new MenuItem(Game, new Vector2(70, 320), "Credits");

            // inicializece polozky Quit Game
            quitGameItem = new MenuItem(Game, new Vector2(70, 380), "Quit Game");

            base.Initialize();

            // Na�teme pot�ebn� v�ci pro menu
            LoadContent();
        }



        /// <summary>
        /// LoadContent je zavol�na jedou na za��tku - zde v metod� Initialize
        /// V�echen n� obsah nahrajeme pr�v� v t�to metod�
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
        /// Umo�uje d�ky neust�l�mu vol�n� aktualizovat hern� logiku, sv�t
        /// nebo t�eba detekci koliz�
        /// </summary>
        /// <param name="gameTime">�asov� instance (XNA si po��t� samo)</param>
        public override void Update(GameTime gameTime)
        {
            // updatujeme instance trid, ktere pou��v�me
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
        /// Vykreslovac� metoda. Stejn� jako Update() se neust�l� vol�,
        /// proto�e je sou��st� hern� smy�ky
        /// </summary>
        /// <param name="gameTime">�asov� instance (XNA si po��t� samo)</param>
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