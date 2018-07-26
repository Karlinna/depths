using Depths.Objects.Player;
using System;
using System.Collections.Generic;
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

namespace Depths.Interpreter
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Window
    {
        public CharacterCreation()
        {
            InitializeComponent();
            InitBoxes();

            
        }
        public void InitBoxes()
        {
            string[] genders = Enum.GetNames(typeof(Gender));
            string[] classes = Enum.GetNames(typeof(PlayerClass));

            for (int i = 0; i < genders.Length; i++)
            {
                gender_Combo.Items.Add(genders[i]);
            }
            for (int i = 0; i < classes.Length; i++)
            {
                class_Combo.Items.Add(classes[i]);
            }
        }

        private void create_Button_Click(object sender, RoutedEventArgs e)
        {
            int genderIndex = gender_Combo.SelectedIndex;
            int classIndex = class_Combo.SelectedIndex;
            if (genderIndex < 0) { MessageBox.Show("No gender selected!"); return; }
            if (classIndex < 0) { MessageBox.Show("No class selected!"); return; }

            Gender g = (Gender)Enum.Parse(typeof(Gender), gender_Combo.Items[genderIndex].ToString());
            PlayerClass pc = (PlayerClass)Enum.Parse(typeof(PlayerClass), class_Combo.Items[classIndex].ToString());

            Player p = new Player(25, 25, false, 25, 10, 1.0, pc, g);
            p.InitPlayer();
        }

    }
}
