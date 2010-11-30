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
        //List<AbstractGameModel> models;
        //TODO: predelat na tridu player
        //Player player;

        public LevelBase(Game game) : base(game) 
        {
            Initialize(game);
        }

        public void Initialize(Game game)
        {
            models = (new LevelGenerator()).GenerateLevel(game);

            models.Hud = new HUD(game);
            //player = new Player(game);
            base.Initialize();
            //GraphicsDevice.BlendState.AlphaBlendFunction = BlendFunction.Add;
            //BlendState.AlphaBlend.AlphaBlendFunction = BlendFunction.Add;
            //GraphicsDevice.RasterizerState.CullMode = CullMode.CullClockwiseFace;
        }

        public override void Update(GameTime gameTime)
        {
            models = ModelList.GetInstance();
            List<AbstractGameModel> modelsList = new List<AbstractGameModel>();
            foreach (AbstractGameModel model in models.Models)
            {
                modelsList.Add(model);
            }

            foreach (AbstractGameModel model in modelsList) 
            {
                model.Update(gameTime);
            }
            models.Player.Update(gameTime);
            models.Hud.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (AbstractGameModel model in models.Models) 
            {
                model.Draw(gameTime);
            }
            models.Player.Draw(gameTime);
            models.Hud.Draw(gameTime);
        }

    }
}
