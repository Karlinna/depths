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

namespace Depths
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Window
    {
        List<BitmapImage> images = null;

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
            if (name_Box.Text.Length < 4) { MessageBox.Show("Character name min. 3 character."); return; }


            Gender g = (Gender)Enum.Parse(typeof(Gender), gender_Combo.Items[genderIndex].ToString());
            PlayerClass pc = (PlayerClass)Enum.Parse(typeof(PlayerClass), class_Combo.Items[classIndex].ToString());

            Player p = new Player(name_Box.Text,25, 25, false, 25, 10, 1.0, pc, g);
            p.InitPlayer();
            p.image_name = images[0].UriSource.AbsolutePath;
            GameWindow gw = new GameWindow(p);
            gw.Show();
            Close();
        }

        void LoadImages(Gender g, PlayerClass pc)
        {
            if (g == Gender.FEMALE)
            {
                if (pc == PlayerClass.ROGUE)
                {
                    images = new List<BitmapImage>();
                    
                    images.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,
                        "depths_images", "female", "human_female_rogue.gif"),
                        UriKind.RelativeOrAbsolute)));

                }
                if (pc == PlayerClass.WARRIOR)
                {
                    images = new List<BitmapImage>();
                    images.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,
                         "depths_images", "female", "human_female_warrior.gif"),
                         UriKind.RelativeOrAbsolute)));
                }

            }
            else
            {
                if (pc == PlayerClass.MAGE)
                {
                    images = new List<BitmapImage>();
                    images.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,
                                           "depths_images", "male", "human_male_mage.gif"),
                                           UriKind.RelativeOrAbsolute)));
                }
                if (pc == PlayerClass.WARRIOR)
                {
                    images = new List<BitmapImage>();
                    images.Add(new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,
                                           "depths_images", "male", "human_male_warrior.gif"),
                                           UriKind.RelativeOrAbsolute)));
                }
            }
        }

        private void portrait_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int genderIndex = gender_Combo.SelectedIndex;
            int classIndex = class_Combo.SelectedIndex;

            if (genderIndex < 0) { return; }
            if (classIndex < 0) { return; }



            Gender g = (Gender)Enum.Parse(typeof(Gender), gender_Combo.Items[genderIndex].ToString());
            PlayerClass pc = (PlayerClass)Enum.Parse(typeof(PlayerClass), class_Combo.Items[classIndex].ToString());

            LoadImages(g, pc);
            portraitImage.Source = images[0];

        }
    }
}
