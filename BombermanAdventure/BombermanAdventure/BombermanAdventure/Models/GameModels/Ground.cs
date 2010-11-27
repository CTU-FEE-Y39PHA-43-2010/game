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
        public Ground(Game game) : base(game) { }

        public override void Initialize() 
        {
            base.modelName = "Models/Ground1";
            base.modelScale = 0.1f;
            modelPosition = new Vector3(0, 0, 0);
            modelRotation = new Vector3();
            base.Initialize();
        }

        public override void OnEvent(Events.CommonEvent ieEvent)
        {
            //throw new NotImplementedException();
        }
    }
}
