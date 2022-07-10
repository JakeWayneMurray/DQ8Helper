using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
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

namespace DQ8Alchemy
{
    /// <summary>
    /// Interaction logic for MonsterWindow.xaml
    /// </summary>
    public partial class MonsterWindow : Window
    {
        Monster monster { get; set; }
        public MonsterWindow(Monster currentMonster)
        {
            monster = currentMonster;
            InitializeComponent();
            if (monster.Link != null || monster.Link != "")
            {
                try
                {
                    #pragma warning disable SYSLIB0014 // Type or member is obsolete
                    var request = WebRequest.Create(monster.Link);
                    #pragma warning restore SYSLIB0014 // Type or member is obsolete
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        ImageHolder.Source = DataAccess.ToImageSource(Bitmap.FromStream(stream), ImageFormat.Png);
                    }
                }
                catch(System.UriFormatException e)
                {
                    Console.Write("oh no, theres no link");
                }
            }
            NameTextBlock.Text = monster.Name;
            SpeciesTextBlock.Text = monster.Species;
            CoinTypeTextBlock.Text = monster.CoinType;
            HPTextBlock.Text = monster.HP;
            MPTextBlock.Text = monster.MP;
            EXPTextBlock.Text = monster.EXP;
            GOLDTextBlock.Text = monster.Gold;
            ConditionTextBlock.Text = monster.Condition;
            PerksTextBlock.Text = monster.Perks;
            DEFTextBlock.Text = monster.DEF;
            ATKTextBlock.Text = monster.ATK;  
            TeamsTextBlock.Text = monster.Teams;
            RegionsTextBlock.Text = monster.Regions;
            AGLTextBlock.Text = monster.AGL;

        }
    }
}
