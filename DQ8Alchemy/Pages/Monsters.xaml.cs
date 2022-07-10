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

namespace DQ8Alchemy.Pages
{
    /// <summary>
    /// Interaction logic for Monsters.xaml
    /// </summary>
    public partial class Monsters : Page
    {
        public DataAccess da { get; set; }
        public List<Monster> currentMonsters { get; set; }
        public Monsters()
        {
            currentMonsters = new List<Monster>();
            da = new DataAccess();
            InitializeComponent();
            DG.ItemsSource = da.getMonsters();

        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textInput = SearchTextBox.Text;
            currentMonsters.Clear();
            foreach (Monster monster in da.getMonsters().Where(r =>
                r.Name.ToLower().Contains(textInput.ToLower()) || r.CoinType.ToLower().Contains(textInput.ToLower()) ||
                r.Species.ToLower().Contains(textInput.ToLower()) ||
                r.Regions.ToLower().Contains(textInput.ToLower())))
            {
                currentMonsters.Add(monster);
            }
            DG.ItemsSource = null;
            DG.ItemsSource = currentMonsters;

        }

        private void DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Monster? selected = (Monster)DG.SelectedCells.FirstOrDefault().Item;
            if (selected != null)
            {
                MonsterWindow window = new MonsterWindow(selected);
                window.ShowDialog();
            }
        }
    }
}
