using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BombermanAdventure.Models.GameModels.Walls
{
    class BrickWall : AbstractGameModel
    {
        public BrickWall(Game game, Vector3 modelPosition) : base(game) 
        {
            base.modelPosition = modelPosition;
        }

        public override void Initialize()
        {
            base.modelName = "Models/Walls/BrickWall";
            base.modelScale = 0.1f;
            modelRotation = new Vector3();
            base.Initialize();
        }

        public override void OnEvent(Events.CommonEvent ieEvent)
        {
            //throw new NotImplementedException();
        }
    }
}
