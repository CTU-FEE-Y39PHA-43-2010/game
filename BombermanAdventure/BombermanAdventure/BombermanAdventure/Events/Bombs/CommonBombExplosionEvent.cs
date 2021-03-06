﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombermanAdventure.Models.GameModels.Bombs;
using BombermanAdventure.Models.GameModels.Players;

namespace BombermanAdventure.Events.Bombs
{
    class CommonBombExplosionEvent : AbstractBombExplosionEvent
    {
        public CommonBombExplosionEvent(AbstractBomb bomb, Player player) : base(bomb, player) { }
    }
}
