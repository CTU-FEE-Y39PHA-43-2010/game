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
using BombermanAdventure.Cameras;
using BombermanAdventure.Models.GameModels;
using BombermanAdventure.Models.GameModels.Players;
using BombermanAdventure.Generators;

namespace BombermanAdventure.Models
{
    class LevelBase : DrawableGameComponent
    {
        ModelList models;

        public LevelBase(Game game) : base(game) 
        {
            Initialize(game);
        }

        public void Initialize(Game game)
        {
            models = (new LevelGenerator()).GenerateLevel(game);
            models.Hud = new HUD(game);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            models.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.Black, 1.0f, 0);
            //GraphicsDevice.BlendState = BlendState.AlphaBlend;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            models.DrawLabyrinth(gameTime);
            models.DrawWalls(gameTime);
            models.DrawBombs(gameTime);
            models.Player.Draw(gameTime);

            GraphicsDevice.DepthStencilState = DepthStencilState.None;
            models.Hud.Draw(gameTime);
        }

    }
}
