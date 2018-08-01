using Depths.Objects.Structs;
using Depths.Objects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Depths.Objects.Gameplay
{
    class Battle : ITalk
    {
        public string Name => "Battle";
        private BattleLogger battleLogger = new BattleLogger();

        public bool BattleOver = false;

        public Player.Player p { get; }
        public Enemy Attacker { get; }

        public Battle(Player.Player p, Enemy attacker)
        {
            this.p = p;
            Attacker = attacker;
        }

        public void PlayerAttacks()
        {            
            p.DamageOther(Attacker);
            battleLogger.DamageLog(p, Attacker, p.LastDamageDone);
            if (Attacker.isDead)
            {
                BattleOver = true;
                BattleWon();
            }
            else
            {
                battleLogger.StateLog(p, Attacker);                
                EnemyAttacks();
            }
        }
        public void EnemyAttacks()
        {            
            Attacker.DamageOther(p);
            battleLogger.DamageLog(Attacker, p, Attacker.LastDamageDone);
            if (p.isDead)
            {
                BattleOver = true;
                GameOver();
            }
            else
            {
                battleLogger.StateLog(p, Attacker);
            }
        }

        public void GameOver()
        {
            MessageBox.Show("Game Over!");
            GameWindow.GetGameWindow.Close();
        }
        public void BattleWon()
        {
            p.HealThis(500000);
            GameWindow.GetGameWindow.ChangeValue(100);
        }


    }
}
