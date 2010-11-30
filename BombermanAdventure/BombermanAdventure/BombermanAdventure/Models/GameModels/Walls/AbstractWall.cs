using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BombermanAdventure.Models.GameModels.Walls
{
    abstract class AbstractWall : AbstractGameModel
    {
        public AbstractWall(Game game, int x, int y) : base(game) 
        {
            base.modelPosition = new Vector3(x * 20, 0, y * 20);
        }
    }
}
