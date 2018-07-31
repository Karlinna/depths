using Depths.Interpreter;
using Depths.Objects;
using Depths.Objects.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Depths
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameMap gm = new GameMap();
        Player p = null;
        Reader r;
        Story s = new Story();
        public GameWindow(Player p)
        {
            InitializeComponent();
            LoadMap();
            this.p = p;
            playerName.Text = this.p.Name;
            playerImage.Source = new BitmapImage(new Uri(p.image_name,UriKind.RelativeOrAbsolute));
            p.LocX = 1;
            p.LocY = 1;
            Direction[] d = gm.GetDirections(p.LocX, p.LocY);
            MovedPlayer();
            r = new Reader(this.p);
            s = r.ReadFromFile("enemyTest.txt");


        }
        private void MovedPlayer()
        {
            s.AutoEngage();
            if (s.FirstEngaged && s.Engaged)
            {
                WriteText(s.GetNextStoryBoard());
                s.StateChange();

            }
            dirBox.Text = "";
            coords.Text = String.Format("{0}-{1}", p.LocX, p.LocY);
            Direction[] d = gm.GetDirections(p.LocX, p.LocY);
            if (d.FirstOrDefault(y => y == Direction.UP) != Direction.NONE)
            {
                dirBox.Text += "UP \n";

            }
            if (d.FirstOrDefault(y => y == Direction.DOWN) != Direction.NONE)
            {
                dirBox.Text += "DOWN \n";

            }
            if (d.FirstOrDefault(y => y == Direction.LEFT) != Direction.NONE)
            {
                dirBox.Text += "LEFT \n";

            }
            if (d.FirstOrDefault(y => y == Direction.RIGHT) != Direction.NONE)
            {
                dirBox.Text += "RIGHT \n";
            }
            
        }

        public void LoadMap()
        {
            StreamReader sr = new StreamReader("map.map");
            int j = 0;

            while (!sr.EndOfStream)
            {
                string[] split = sr.ReadLine().Split('\t');
                for (int i = 0; i < split.Length; i++)
                {
                    gm[j, i] = int.Parse(split[i]);
                }
                j++;
            }
            sr.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (s.Engaged == true) return;
            
            Button b = (Button)sender;
            string dir = (string)b.Content;

            Direction[] d =  gm.GetDirections(p.LocX, p.LocY);

            if(d.FirstOrDefault(y => y == Direction.UP) != Direction.NONE)
            {
                if(dir == "Up")
                {
                    p.LocX -= 1;
                }
            }
            if (d.FirstOrDefault(y => y == Direction.DOWN) != Direction.NONE)
            {
                if (dir == "Down") p.LocX += 1;
            }
            if (d.FirstOrDefault(y => y == Direction.LEFT) != Direction.NONE)
            {
                if (dir == "Left") p.LocY -= 1;
            }
            if (d.FirstOrDefault(y => y == Direction.RIGHT) != Direction.NONE)
            {
                if (dir == "Right") p.LocY += 1;
            }
            MovedPlayer();

        }

        private void actButtonClick(object sender, RoutedEventArgs e)
        {
            if (s.OpenedMap != null) WriteText(s.GetNextStoryBoard());
            s.StateChange();
        }
        public void WriteText(string s)
        {
            if (s.Trim() == "") return;
            storyBox.Text += s + "\n";
        }
    }
}
