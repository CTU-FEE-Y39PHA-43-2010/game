using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BombermanAdventure.Events;

namespace BombermanAdventure.Models.GameModels.Explosions
{
    class AbstractExplosion : AbstractGameModel
    {
        SpriteBatch spriteBatch;
 
        public AbstractExplosion(Game game) : base(game) { }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //spriteBatch.Draw(
        }

        public override void Draw(GameTime gameTime)
        {
            //spriteBatch.Draw(
        }


        public override void OnEvent(CommonEvent ieEvent)
        {
            throw new NotImplementedException();
        }
    }
}
