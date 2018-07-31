using Depths.Objects;
using Depths.Objects.Mapper;
using Depths.Objects.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                        int.Parse(data[5]), double.Parse(data[5]));
                    s.AddEnemy(e);
                }
                else if (IsCharacter(line))
                {
                    string[] data = GetDataFromRow(line, "character");
                    NPC n = new NPC(data[0],
                        data[1] == "M" ? Gender.MALE : data[1] == "F" ? Gender.FEMALE : Gender.OTHER);
                    s.AddNPC(n);
                }
                else if (IsStoryboard(line))
                {
                    string[] story = line.Split('-');
                    string[] type = story[0].Split(':');

                    if(story[0] == "player")
                    {
                        s.AddStoryBoard(p, story[1]);           
                    }

                    if (type.Length < 2)
                    {
                        if (story[0] == "player") continue;
                        if (s.GetNpcByName(story[0]) != null &&
                            s.GetEnemyByName(story[0]) != null)
                            throw new AmbigiousCharacterDefinedException(story[0]);
                        NPC c = s.GetNpcByName(story[0]);
                        Enemy e = null;
                        if (c == null) { e = s.GetEnemyByName(story[0]); s.AddStoryBoard(e, story[1]); }
                        else s.AddStoryBoard(c, story[1]);
                    }     
                    if(type[0] == "enemy")
                    {
                        Enemy e = s.GetEnemyByName(type[1]);
                        s.AddStoryBoard(e, story[1]);
                    }
                    if(type[0] == "character")
                    {
                        NPC e = s.GetNpcByName(type[1]);
                        s.AddStoryBoard(e, story[1]);
                    }
                }

                else if (IsMapCondition(line))
                {
                    string[] data = GetConditonData(line);
                    string[] charac = data[0].Split(':');
                    Enemy e = s.GetEnemyByName(charac[1]);
                    Enemy x = null;
                    if(e.LocX != 0)
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

                    int startIndex = s.Count;
                    bool bracket = true;
                    int count = 0;
                    while (bracket)
                    {
                        string read = sr.ReadLine();
                        if (read == "map_cond_end") bracket = false;
                        else
                        {
                            string[] story = read.Split('-');
                            if (story[0] == "player")
                            {
                                s.AddStoryBoard(p, story[1]);
                                count++;
                            }
                            else
                            {
                                s.AddStoryBoard(e, story[1]);
                                count++;
                            }
                           
                        }
                    }

                    MapCondition mc = new MapCondition(x != null ? x : e, startIndex, startIndex + count -1);
                    s.AddMapCondition(mc);
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
