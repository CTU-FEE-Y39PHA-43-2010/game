using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BombermanAdventure.Cameras;
using BombermanAdventure.Events;

namespace BombermanAdventure.Models.GameModels
{
    abstract class AbstractGameModel : DrawableGameComponent
    {
        Model model;
        protected ModelList models;

        protected float modelScale;
        protected String modelName;
        protected Vector3 modelPosition;
        protected Vector3 modelRotation;

        Vector3 ModelPosition 
        {
            get { return modelPosition; }
        }

        public AbstractGameModel(Game game) : base(game) 
        {
            Initialize();
        }

        public override void Initialize() 
        {
            models = ModelList.GetInstance();
            LoadContent();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            model = Game.Content.Load<Model>(modelName);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Matrix world;
            world = Matrix.CreateScale(modelScale);
            world *= Matrix.CreateRotationX(MathHelper.ToRadians(modelRotation.X));
            world *= Matrix.CreateRotationY(MathHelper.ToRadians(modelRotation.Y));
            world *= Matrix.CreateRotationZ(MathHelper.ToRadians(modelRotation.Z));
            world *= Matrix.CreateTranslation(modelPosition);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = world;
                    effect.View = models.Camera.viewMatrix;
                    effect.Projection = models.Camera.projectionMatrix;
                }
                mesh.Draw();
            }
        }

        public abstract void OnEvent(CommonEvent ieEvent);
    }
}
