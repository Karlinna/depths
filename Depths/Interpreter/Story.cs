using Depths.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Interpreter
{
    class Story
    {
        private Dialogue<ITalk, string> Storyboard = new Dialogue<ITalk, string>();
        private List<Enemy> enemies = new List<Enemy>();
        private List<NPC> npcs = new List<NPC>();
        private int state = 0;

        public void AddStoryBoard(ITalk i, string s)
        {
            Storyboard.Add(i, s);
        }
        public void AddEnemy(Enemy enemy)
        {
            if (!npcs.Exists(y => y.Name == enemy.Name))
                enemies.Add(enemy);
            //else: double defined ? exception
        }
        public void AddNPC(NPC n)
        {
            if(!npcs.Exists(y => y.Name == n.Name))
                npcs.Add(n);
            //else: Double Defined ? Exception ? 
        }

        public Enemy GetEnemy(int i)
        {
            return enemies[i];
        }
        public NPC GetNpcByName(string name)
        {
            return npcs.Find(n => n.Name == name);
        }
        public Enemy GetEnemyByName(string name)
        {
            return enemies.Find(n => n.Name == name);

        }
        public string GetNextStoryBoard()
        {
            string s = "";
            s = string.Format("{0} - '{1}'", Storyboard.GetKey(state).Name, Storyboard.GetValue(state));
            state++;
            return s;
        }
    }
}
