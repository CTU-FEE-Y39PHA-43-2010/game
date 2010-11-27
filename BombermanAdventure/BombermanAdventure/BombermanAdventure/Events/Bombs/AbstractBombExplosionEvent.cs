using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombermanAdventure.Models.GameModels.Bombs;
using BombermanAdventure.Models.GameModels.Players;

namespace BombermanAdventure.Events.Bombs
{
    abstract class AbstractBombExplosionEvent : CommonEvent, IDestructible
    {
        Player player;
        public Player Player 
        {
            get { return player; }
        }

        public AbstractBombExplosionEvent(AbstractBomb model, Player player) : base(model) 
        {
            this.player = player;
        }
    }
}
