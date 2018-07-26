using Depths.Objects;
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

namespace Depths
{
    /// <summary>
    /// Interaction logic for MapEditor.xaml
    /// </summary>
    public partial class MapEditor : Window
    {
        GameMap map = new GameMap();
        int row = 0;
        int col = 0;
        public MapEditor()
        {
            InitializeComponent();
            atBox.Text = String.Format("[{0} - {1}]", row, col);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            map[row, col] = int.Parse(valueBox.Text);
            if (col < 49) col++;
            else
            {
                col = 0;
                if (row < 49) row++;
                else return;
            }
            atBox.Text = String.Format("[{0} - {1}]", row, col);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("map01.map");
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    sw.WriteLine(map[i, j].ToString());
                }
            }
            sw.Close();
        }
    }
}
