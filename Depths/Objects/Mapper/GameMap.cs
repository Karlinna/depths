using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depths.Objects
{
    class GameMap
    {
        //0 WalkPath 2 Chest 3 Enemy 4 NPC 5 NextMap
        int[,] Map = new int[50, 50];
        private string MapName;


        public GameMap CreateFromFile(string[] map_data, string map_name)
        {
            GameMap gm = new GameMap();

            for (int i = 0; i < map_data.Length; i++)
            {
                string[] map_row = map_data[i].Split(' ');
                for (int j = 0; j < map_row.Length; j++)
                {
                    int y = int.Parse(map_row[j]);
                    Map[i, j] = y;
                }
            }
            return gm;
        } 
        public Direction[] GetDirections(int x, int y)
        {
            int up = -2;
            if (x -1 > 0) up = Map[x - 1, y];
            int down = -2;
            if (x + 1 < 50) down = Map[x + 1, y];
            int left = -2;
            if (y - 1 > 0) left = Map[x, y - 1];
            int right = -2;
            if (y + 1 < 50) right = Map[x, y + 1];
            Direction[] d =
                { up == 0 ? Direction.UP : Direction.NONE,
                  down == 0 ? Direction.UP : Direction.NONE,
                  left == 0 ? Direction.LEFT : Direction.NONE,
                  right == 0 ? Direction.RIGHT : Direction.NONE};
            return d;
        }
        public int this[int row, int colunm]
        {
            get { return Map[row, colunm]; }
            set { Map[row, colunm] = value; }
        }
        
       
    }
}
