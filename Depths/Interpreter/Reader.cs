using Depths.Objects;
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
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (line.Trim() == "" || line == null) continue;
                else if (IsEnemy(line))
                {
                    string[] data = GetDataFromRow(line, "enemy");
                    Enemy e = null;
                    s.AddEnemy(e);
                }
                else if (IsCharacter(line))
                {
                    string[] data = GetDataFromRow(line, "character");
                    NPC n = new NPC(data[0]);
                    s.AddNPC(n);
                }
                else if (IsStoryboard(line))
                {
                    string[] story = line.Split('-');
                    string[] type = story[0].Split(':');

                    if (type.Length < 2)
                    {
                        if (s.GetNpcByName(story[0]) != null &&
                            s.GetEnemyByName(story[0]) != null)
                            throw new AmbigiousCharacterDefinedException(story[0]);
                        NPC c = s.GetNpcByName(story[0]);
                        Enemy e = null;
                        if (c == null) { e = s.GetEnemyByName(story[0]); s.AddStoryBoard(e, story[1]); }
                        else s.AddStoryBoard(c, story[1]);
                    }
                    else if (story[0] == "player")
                    {
                        s.AddStoryBoard(p, story[1]);
                    }
                    else if (type[0] == "enemy")
                    {
                        Enemy c = s.GetEnemyByName(type[1]);
                        s.AddStoryBoard(c, story[1]);
                    }
                    else
                    {
                        NPC c = s.GetNpcByName(type[1]);
                        s.AddStoryBoard(c, story[1]);
                    }
                }

            }
            sr.Close();
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
        #endregion
    }
}
