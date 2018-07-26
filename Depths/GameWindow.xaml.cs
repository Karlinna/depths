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
        Player p = new Player(1,1,false,1,1,1,PlayerClass.MAGE,Gender.FEMALE);
        DispatcherTimer dt = new DispatcherTimer();
        public GameWindow()
        {
            InitializeComponent();
            p.LocX = 1;
            p.LocY = 1;
            dt.Interval = TimeSpan.FromMilliseconds(100);
            dt.Tick += Dt_Tick;
            Direction[] d = gm.GetDirections(p.LocX, p.LocY);
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            dirBox.Text = "";
            Direction[] d = gm.GetDirections(p.LocX, p.LocY);
            if (d.First(y => y == Direction.UP) != Direction.NONE)
            {
                dirBox.Text += "UP \n";

            }
            if (d.First(y => y == Direction.DOWN) != Direction.NONE)
            {
                dirBox.Text += "DOWN \n";

            }
            if (d.First(y => y == Direction.LEFT) != Direction.NONE)
            {
                dirBox.Text += "LEFT \n";

            }
            if (d.First(y => y == Direction.RIGHT) != Direction.NONE)
            {
                dirBox.Text += "RIGHT \n";

            }
        }

        public void LoadMap()
        {
            StreamReader sr = new StreamReader("map.map");
            while (!sr.EndOfStream)
            {
                int j = 0;
                string[] split = sr.ReadLine().Split(' ');
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
            Button b = (Button)sender;
            string dir = (string)b.Content;

           Direction[] d =  gm.GetDirections(p.LocX, p.LocY);

            if(d.First(y => y == Direction.UP) != Direction.NONE)
            {
                dirBox.Text += "UP \n";
                if(dir == "Up")
                {
                    p.LocY -= 1;
                }
            }
            if (d.First(y => y == Direction.DOWN) != Direction.NONE)
            {
                dirBox.Text += "DOWN \n";
                if (dir == "Down") p.LocY += 1;
            }
            if (d.First(y => y == Direction.LEFT) != Direction.NONE)
            {
                dirBox.Text += "LEFT \n";
                if (dir == "Left") p.LocY -= 1;
            }
            if (d.First(y => y == Direction.RIGHT) != Direction.NONE)
            {
                dirBox.Text += "RIGHT \n";
                if (dir == "Right") p.LocY += 1;
            }

            
        }
    }
}
