﻿using Depths.Interpreter;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Depths
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void newGame_Button_Click(object sender, RoutedEventArgs e)
        {
            CharacterCreation cc = new CharacterCreation();
            cc.Show();
        }

        private void options_Button_Click(object sender, RoutedEventArgs e)
        {
            MapEditor me = new MapEditor();
            me.Show();
        }
    }
}
