using Depths.Objects;
using Depths.Objects.Gameplay;
using Depths.Objects.Mapper;
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
        private List<Character> npcs = new List<Character>();
        private List<MapCondition> Conditions = new List<MapCondition>();
        private int state = 0;
        public MapCondition OpenedMap;
        public ITalk p;
        public bool Engaged { get; set; }
        public bool FirstEngaged { get; private set; }
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
        public void AddNPC(Character n)
        {
            if(!npcs.Exists(y => y.Name == n.Name))
                npcs.Add(n);
            //else: Double Defined ? Exception ? 
        }

        public Enemy GetEnemy(int i)
        {
            return enemies[i];
        }
        public Character GetNpcByName(string name)
        {
            return npcs.Find(n => n.Name == name);
        }
        public Enemy GetEnemyByName(string name)
        {
            return enemies.Find(n => n.Name == name);

        }
        public void AddMapCondition(MapCondition mc)
        {
            Conditions.Add(mc);
        }
        public string GetNextStoryBoard()
        {
            string s = "";
           
            if (OpenedMap != null) { 
                
                    if (OpenedMap.EndIndex >= state)
                    {
                    if (state > Count - 1) return s;
                    FirstEngaged = false;
                        return String.Format("{0} - {1}", Storyboard.GetKey(state).Name,
                       Storyboard.GetValue(state));
                    }
                    else
                    {

                        int index = Conditions.FindIndex(y => y == OpenedMap);
                        OpenedMap = null;
                        state = 0;
                        Conditions[index].Exists = false;
                        Engaged = false;
                    }
                }
     
            return s;
        }

        public void FormatText()
        {
            Regex pl = new Regex("%[player]*%");
            Regex c = new Regex("%[class]*%");
            for (int i = 0; i < Storyboard.Count; i++)
            {
                if (pl.IsMatch(Storyboard.GetValue(i)))
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

        public int Count => Storyboard.Count;

        public void AutoEngage()
        {
            Engaged = false;
         
            if (OpenedMap != null) return;
            foreach (MapCondition item in Conditions)
            {
                Player player = (Player)p;
                if (item.ConditionMet(player.LocX, player.LocY) && item.Exists)
                {
                    state = item.StartIndex;
                    OpenedMap = item;
                    Engaged = true;
                    FirstEngaged = true;
                }
            }
        }
        public void StateChange()
        {
            state++;
        }

        public Battle GetBattle()
        {
            if(state > Count - 1) return null;
            return (Battle)Storyboard.GetKey(state);
        }
        public bool IsBattle()
        {
            if (state > Count - 1) return false;
            return Storyboard.GetKey(state) is Battle;

        }
    }
}
