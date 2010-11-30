using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BombermanAdventure.Models.GameModels
{
    class Ground : AbstractGameModel
    {
        int BLOCK_SIZE = 20;

        int indestructibleBlocksCountOnX;
        int indestructibleBlocksCountOnY;

        int mapWidth;
        int mapHeight;

        List<GroundUnit> floor;
        List<IndestructibleBlock> blocks;

        public Ground(Game game, int x, int y) : base(game) 
        {
            this.indestructibleBlocksCountOnX = x;
            this.indestructibleBlocksCountOnY = y;

            this.Initialize();
        }

        protected override void LoadContent()
        {
            floor = this.GenerateFloor(mapWidth, mapHeight);
            blocks = this.GenerateBlocks(mapWidth, mapHeight);
        }

        public override void Initialize() 
        {
            mapWidth = (2 * indestructibleBlocksCountOnX) + 1;
            mapHeight = (2 * indestructibleBlocksCountOnY) + 1;

            //base.modelName = "Models/Ground1";
            //base.modelScale = 0.1f;
            //modelPosition = new Vector3(0, 0, 0);
            //modelRotation = new Vector3();
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GroundUnit unit in floor) 
            {
                unit.Draw(gameTime);
            }
            foreach (IndestructibleBlock block in blocks)
            {
                block.Draw(gameTime);
            }
        }

        private List<GroundUnit> GenerateFloor(int x, int y) 
        {
            int xx = (x / 2 + 1) * BLOCK_SIZE;
            int yy = (y / 2 + 1) * BLOCK_SIZE;

            int xxx = xx;
            //int yyy = yy;

            List<GroundUnit> floor = new List<GroundUnit>();

            for (int i = 0; i != (y + 2); i++) 
            {
                for (int j = 0; j != (x + 2); j++) 
                {
                    GroundUnit unit = new GroundUnit(Game, new Vector3(xx, 0, yy));
                    floor.Add(unit);
                    xx -= BLOCK_SIZE;
                }
                yy -= BLOCK_SIZE;
                xx = xxx;
            }

            return floor;
        }

        private List<IndestructibleBlock> GenerateBlocks(int x, int y)
        {
            int xx = (x / 2 + 1) * BLOCK_SIZE;
            int yy = (y / 2 + 1) * BLOCK_SIZE;

            int xxx = xx;
            //int yyy = yy;
            xx -= BLOCK_SIZE;
            List<IndestructibleBlock> blocks = new List<IndestructibleBlock>();

            for (int i = 0; i != x; i++) 
            {
                IndestructibleBlock block = new IndestructibleBlock(Game, new Vector3(xx, 0, yy));
                blocks.Add(block);
                block = new IndestructibleBlock(Game, new Vector3(xx, 0, -yy));
                blocks.Add(block);
                xx -= BLOCK_SIZE;
            }
            xx = xxx;

            for (int i = 0; i != (y + 2); i++)
            {
                IndestructibleBlock block = new IndestructibleBlock(Game, new Vector3(xx, 0, yy));
                blocks.Add(block);
                block = new IndestructibleBlock(Game, new Vector3(-xx, 0, yy));
                blocks.Add(block);
                yy -= BLOCK_SIZE;
            }

            xx = (x / 2 - 1) * BLOCK_SIZE;
            yy = (y / 2 - 1) * BLOCK_SIZE;
            xxx = xx;

            for (int i = 0; i < y - 1; i += 2)
            {
                for (int j = 0; j < x - 1; j += 2)
                {
                    IndestructibleBlock block = new IndestructibleBlock(Game, new Vector3(xx, 0, yy));
                    blocks.Add(block);
                    xx -= 2 * BLOCK_SIZE;
                }
                yy -= 2 * BLOCK_SIZE;
                xx = xxx;
            }

            return blocks;
        }

        public override void OnEvent(Events.CommonEvent ieEvent) { }
    }

    class GroundUnit : AbstractGameModel 
    {
        public GroundUnit(Game game, Vector3 position) : base(game) 
        {
            base.modelPosition = position;
        }

        public override void Initialize()
        {
            base.modelName = "Models/GroundUnit";
            base.modelScale = 1f;
            base.modelRotation = new Vector3();
            base.Initialize();
        }

        public override void OnEvent(Events.CommonEvent ieEvent) { }

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
                    //effect.EnableDefaultLighting();
                    effect.World = world;
                    effect.View = models.Camera.viewMatrix;
                    effect.Projection = models.Camera.projectionMatrix;
                }
                mesh.Draw();
            }
        }
    }

    class IndestructibleBlock : AbstractGameModel
    {
        public IndestructibleBlock(Game game, Vector3 position) : base(game)
        {
            base.modelPosition = position;
        }

        public override void Initialize()
        {
            base.modelName = "Models/IndestructibleBlock";
            base.modelScale = 1f;
            base.modelRotation = new Vector3();
            base.Initialize();
        }

        public override void OnEvent(Events.CommonEvent ieEvent) { }

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
    }
}
