using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BombermanAdventure.Models.GameModels.Players
{
    abstract class AbstractPlayer : AbstractGameModel
    {
        protected int possibleBombsCount;
        protected int bombsCount;
        protected int bombRange;
        protected int life;
        protected int armor;

        public int Life
        {
            get { return life; }
        }

        public int BombRange
        {
            get { return bombRange; }
        }

        public AbstractPlayer(Game game, int x, int y) : base(game) 
        {
            base.modelPosition = new Vector3(x * 20, 10, y * 20);
        }
    }
}
