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

        protected float speed;
        public float Speed 
        {
            get { return speed; }
        }

        protected int armor;
        public int Armor 
        {
            get { return armor; }
            set { armor = value; }
        }

        protected int life;
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

        public abstract void GoLeft();
        public abstract void GoRight();
        public abstract void GoUp();
        public abstract void GoDown();

        public abstract void PutBomb(GameTime gameTime);
        public abstract void Fire();
    }
}
