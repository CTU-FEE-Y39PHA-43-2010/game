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
    /// 
    /// </summary>
    public class MenuItem : DrawableGameComponent
    {
        // promìnné, se kterým budeme v této tøídì pracovat
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Texture2D myTexture;

        Rectangle position;
        string itemTitle;
        int scaleItem = 1;

        // promenna a property, ktera bude slouzit jako indikace, 
        // zda jsme kurzorem najeli na tento objekt
        private bool isIntersected = false;
        public bool IsIntersected
        {
            get { return isIntersected; }
            set { isIntersected = value; }
        }


        /// <summary>
        /// Kontruktor tøídy MenuItem, která vykresluje jednu položku menu
        /// </summary>
        /// <param name="game">Game game</param>
        /// <param name="_position">Vector2 position</param>
        /// <param name="_itemTitle">string itemName</param>
        public MenuItem(Game game, Vector2 _position, string _itemTitle) : base(game)
        {
            this.position = new Rectangle((int)_position.X, (int)_position.Y, 0, 0);
            this.itemTitle = _itemTitle;

            // TODO: Construct any child components here

            Initialize();
        }

        /// <summary>
        /// Dovoluje inicializovat vìci potøebné pøed samotným spuštìním.
        /// </summary>
        public override void Initialize()
        {
            // Vaši inicializaèní logiku pøidejte zde

            base.Initialize();
            LoadContent();
        }

        /// <summary>
        /// LoadContent je zavolána jedou na zaèátku - zde v metodì Initialize
        /// Všechen náš obsah nahrajeme právì v této metodì
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Vytvoøíme SpriteFont, který nám umožní vykreslovat text na obrazovku
            spriteFont = Game.Content.Load<SpriteFont>("myFont");

            // naèteme texturu, která znározòuje položku v nìjakém menu
            myTexture = Game.Content.Load<Texture2D>("menuItem");
            
            // obalime do kvadru celou texturu
            position = new Rectangle(position.X, position.Y, myTexture.Width, myTexture.Height);

            base.LoadContent();
        }

        /// <summary>
        /// Umožuje díky neustálému volání aktualizovat herní logiku, svìt
        /// nebo tøeba detekci kolizí
        /// </summary>
        /// <param name="gameTime">Èasová instance (XNA si poèítá samo)</param>
        public override void Update(GameTime gameTime)
        {
            // updatujeme potomky a instance trid, ktere používáme


            // zjisime, zda kurzor koliduje s touto polozkou menu
            MouseState ms = Mouse.GetState();
            Rectangle rec = new Rectangle(ms.X, ms.Y, 0, 0);

            if (position.Intersects(rec))
            {
                IsIntersected = true;
            }
            else
            {
                IsIntersected = false;
            }


            if (IsIntersected)
            {
                if (scaleItem < 20) scaleItem += 1;
            }
            else
            {
                if (scaleItem > 0) scaleItem -= 1;
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
            Color col;
            if (IsIntersected) col = Color.Orange;
            else col = Color.White;

            // na zaklade medoty update zvetsujeme nebo zmensujeme policko v menu
            Rectangle rect = new Rectangle( position.X - scaleItem / 4, position.Y - scaleItem / 4,
                                            position.Width + 2 * scaleItem / 4, position.Height + 2 * scaleItem / 4);

            spriteBatch.Begin();
            // vykreslime texturu
            spriteBatch.Draw(myTexture, rect, col);
            // vzkreslime text
            spriteBatch.DrawString(spriteFont, itemTitle, new Vector2(position.X + 10, position.Y + 5), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}