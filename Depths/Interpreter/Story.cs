using Depths.Objects;
using Depths.Objects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Depths.Interpreter
{
    class Story
    {
        private Dialogue<ITalk, string> Storyboard = new Dialogue<ITalk, string>();
        private List<Enemy> enemies = new List<Enemy>();
        private List<NPC> npcs = new List<NPC>();
        private int state = 0;
        public ITalk p;
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
            if (state > Storyboard.Count) return "";
            string s = "";
            s = string.Format("{0} - '{1}'", Storyboard.GetKey(state).Name, Storyboard.GetValue(state));
            state++;
            return s;
        }

        public void FormatText()
        {
            Regex r = new Regex("%[player]*%");
            Regex c = new Regex("%[class]*%");
            for (int i = 0; i < Storyboard.Count; i++)
            {
                if (r.IsMatch(Storyboard.GetValue(i)))
                {
                   string s = Regex.Replace(Storyboard.GetValue(i),
                       "%[player]*%", p.Name);
                    Storyboard.SetValue(i, s);
                }
                else if (c.IsMatch(Storyboard.GetValue(i)))
                {
                    Player player = (Player)p;
                    string s = Regex.Replace(Storyboard.GetValue(i),
                        "%[class]*%", Enum.GetName(typeof(PlayerClass), player.PlayerClass).ToLower());
                    Storyboard.SetValue(i, s);
                }
            }
            
        }
    }
}
