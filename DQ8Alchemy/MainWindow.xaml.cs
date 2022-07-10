using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DQ8Alchemy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Main.Content = new Pages.Recipes();
        }

        private void MonstersButton_Click(object sender, RoutedEventArgs e)
        {
            this.Main.Content = new Pages.Monsters();
        }

        private void RecipesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Main.Content = new Pages.Recipes();
        }
    }
}
