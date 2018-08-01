using Depths.Objects;
using Depths.Objects.Gameplay;
using Depths.Objects.Mapper;
using Depths.Objects.Player;
using Depths.Objects.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Depths.Interpreter
{
    class Reader
    {
        private Player p;

        public Reader(Player player)
        {
            p = player;
        }
        public Story ReadFromFile(string file)
        {
            Story s = new Story();
            StreamReader sr = new StreamReader(file);
            s.p = p;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (line.Trim() == "" || line == null) continue;
                else if (IsEnemy(line))
                {
                    string[] data = GetDataFromRow(line, "enemy");
                    Enemy e = new Enemy(data[0], int.Parse(data[1]),
                        int.Parse(data[2]), bool.Parse(data[3]), int.Parse(data[4]),
                        int.Parse(data[5]), double.Parse(data[6]));
                    s.AddEnemy(e);
                }
                else if (IsCharacter(line))
                {
                    string[] data = GetDataFromRow(line, "character");
                    Character n = new Character(data[0],
                        data[1] == "M" ? Gender.MALE : data[1] == "F" ? Gender.FEMALE : Gender.OTHER);
                    s.AddNPC(n);
                }    
                else if (line.Split('-')[0] == "target")
                {
                    throw new Exception("Target was called but no mapcondition");
                }
                else if (IsMapCondition(line))
                {
                    string[] data = GetConditonData(line);
                    string[] charac = data[0].Split(':');
                    Enemy e = null;
                    Enemy x = null;
                    Character n = null;
                    Character p = null;
                    int lever = -1;
                    if (charac[0] == "enemy")
                    {
                        lever = 0;
                        e = s.GetEnemyByName(charac[1]);
                        if (e.LocX != 0)
                        {
                            x = (Enemy)e.Clone();
                            x.LocX = int.Parse(data[1]);
                            x.LocY = int.Parse(data[2]);
                        }
                        else
                        {
                            e.LocX = int.Parse(data[1]);
                            e.LocY = int.Parse(data[2]);
                        }
                    }
                    else if(charac[0] == "character")
                    {
                        lever = 1;
                        n = s.GetNpcByName(charac[1]);
                        if (n.LocX != 0)
                        {
                            p = (Character)n.Clone();
                            p.LocX = int.Parse(data[1]);
                            p.LocY = int.Parse(data[2]);
                        }
                        else
                        {
                            n.LocX = int.Parse(data[1]);
                            n.LocY = int.Parse(data[2]);
                        }
                    }
                    int startIndex = s.Count;
                    bool bracket = true;
                    int count = 0;
                    while (bracket)
                    {
                        string read = sr.ReadLine();
                        if (read == "map_cond_end") bracket = false;
                        else if (read == "engage_battle()")
                        {
                            Battle b = new Battle((Player)s.p, x ?? e);
                            s.AddStoryBoard(b, "Battle");
                        }
                        else
                        {                      
                            string[] story = read.Split('-');
                            if (story[0] == "player")
                            {                               

                                Regex t = new Regex("%[target]*%");
                                if (t.IsMatch(story[1]))
                                {
                                   switch(lever)
                                    {
                                        case 0:
                                            ITalk target = x ?? e;
                                           story[1] =  Regex.Replace(story[1], "%[target]*%", target.Name);
                                            break;
                                        case 1:
                                            ITalk target2 = p ?? n;
                                            story[1] = Regex.Replace(story[1], "%[target]*%", target2.Name);
                                            break;
                                    }
                                }

                                s.AddStoryBoard(s.p, story[1]);
                                count++;
                            }
                            else if(story[0] == "target")
                            {
                                s.AddStoryBoard(p ?? n, story[1]);
                                count++;
                            }                  
                            else
                            {
                                s.AddStoryBoard(x ?? e, story[1]);
                                count++;
                            }
                           
                        }
                    }
                    MapCondition mc = null;
                    switch (lever)
                    {
                        case 0:
                            mc = new MapCondition(x ?? e, startIndex, startIndex + count - 1);
                            s.AddMapCondition(mc);
                            break;
                        case 1:
                            mc = new MapCondition(p ?? n, startIndex, startIndex + count - 1);
                            s.AddMapCondition(mc);
                            break;
                    }
                    
                    
                }
            }
            sr.Close();
            s.FormatText();
            return s;
        }
        #region Interpreter Methods
        private bool IsEnemy(string line)
        {
            if (!line.Contains("enemy")) return false;
            string[] split = line.Split(':');
            return split.Length < 2 ? true : false;
        }
        private bool IsCharacter(string line)
        {
            if (!line.Contains("character")) return false;
            string[] split = line.Split(':');
            return split.Length < 2 ? true : false;
        }
        private bool IsStoryboard(string line)
        {            
            string[] story = line.Split('-');
            if (story.Length < 2) return false;
            string speak = story[1];
            return speak.Contains("\"");
        }
        /// <summary>
        /// Used for DEFINE type of rows
        /// </summary>
        /// <param name="line"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string[] GetDataFromRow(string line, string type)
        {
            string cuttedline = line.Replace(type, "");
            cuttedline = cuttedline.Replace("(", "");
            cuttedline = cuttedline.Replace(")", "");
            cuttedline = cuttedline.Trim();
            string[] data = cuttedline.Split(',');

            return data;
        }
        private bool IsMapCondition(string line)
        {
            if (!line.Contains("map_cond")) return false;

            return true;
        }
        private string[] GetConditonData(string line)
        {
            string cuttedline = line.Replace("map_cond", "");
            cuttedline = cuttedline.Replace("(", "");
            cuttedline = cuttedline.Replace(")", "");
            cuttedline = cuttedline.Trim();
            string[] data = cuttedline.Split(',');
            return data;
        }
        #endregion
    }
}
