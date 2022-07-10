using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Recipes.xaml
    /// </summary>
    public partial class Recipes : Page
    {

        public DataAccess da { get; set; }
        public List<Recipe> currentRecipes { get; set; }
        public Recipes()
        {
            currentRecipes = new List<Recipe>();
            da = new DataAccess();
            InitializeComponent();
            DG.ItemsSource = da.getRecipes();
        }



        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textInput = SearchTextBox.Text;
            currentRecipes.Clear();
            foreach (Recipe recipe in da.getRecipes().Where(r =>
                r.Name.ToLower().Contains(textInput.ToLower()) || r.IngredientTwo.ToLower().Contains(textInput.ToLower()) || r.IngredientOne.ToLower().Contains(textInput.ToLower())))
            {
                currentRecipes.Add(recipe);
            }
            DG.ItemsSource = null;
            DG.ItemsSource = currentRecipes;

        }

        private void RecipeListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string selectedIndex = "";
                switch (DG.SelectedCells.FirstOrDefault().Column.Header.ToString())
                {
                    case "Name":
                        selectedIndex = ((Recipe)DG.SelectedCells.FirstOrDefault().Item).Name;
                        break;
                    case "Ingredient 1":
                        selectedIndex = ((Recipe)DG.SelectedCells.FirstOrDefault().Item).IngredientOne;
                        break;
                    case "Ingredient 2":
                        selectedIndex = ((Recipe)DG.SelectedCells.FirstOrDefault().Item).IngredientTwo;
                        break;
                    case "Ingredient 3":
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        selectedIndex = ((Recipe)DG.SelectedCells.FirstOrDefault().Item).IngredientThree;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                        break;
                    default:
                        selectedIndex = "";
                        break;

                }
                if (selectedIndex != "" || selectedIndex != null)
                {
                    string url = $"https://dragon-quest.org/wiki/{selectedIndex.Replace(' ', '_')}";
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
            }catch(NullReferenceException)
            {
                Console.WriteLine("The user clicked the column name");
            }
        }
    }
}
