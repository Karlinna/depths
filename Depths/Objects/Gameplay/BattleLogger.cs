using Depths.Objects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects.Gameplay
{
    class BattleLogger
    {
        private GameWindow gw = GameWindow.GetGameWindow;


        public void DamageLog(ITalk who, ITalk whom, int value)
        {
            gw.WriteText(String.Format("{0} damaged {1} for {2}.",
                who.Name, whom.Name, value));
        }

        public void StateLog(ITalk player, ITalk enemy)
        {
            Player.Player p = (Player.Player)player;
            gw.ChangeValue(p.GetHealthPercentage());
            gw.WriteText(String.Format("Player has {0} health remaining...", p.Health));
            Enemy e = (Enemy)enemy;
            gw.WriteText(String.Format("{0} has {1} health remaining...",e.Name, e.Health));

        }

    }
}
