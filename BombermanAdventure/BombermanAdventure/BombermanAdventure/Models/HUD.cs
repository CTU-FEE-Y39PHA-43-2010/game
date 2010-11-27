using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class HUD : DrawableGameComponent
    {
        ModelList models;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Texture2D texture;

        public HUD(Game game) :base(game) {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            LoadContent();
        }

        protected override void LoadContent()
        {
            models = ModelList.GetInstance();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Game.Content.Load<Texture2D>("bomberHUD");
            spriteFont = Game.Content.Load<SpriteFont>("myFont");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // vykreslime texturu
            spriteBatch.Draw(texture, new Rectangle(0,0,100,100), Color.Green);
            // vzkreslime text
            spriteBatch.DrawString(spriteFont, models.Player.Life + "%", new Vector2(20, 50), Color.White);
            spriteBatch.End();
        }
    }
}
