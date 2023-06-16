using Ecrans.Model;
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

namespace Ecrans
{
    /// <summary>
    /// Logique d'interaction pour WindowMateriel.xaml
    /// </summary>
    public partial class WindowMateriel : Window
    {
        public WindowMateriel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerMateriel winAjouterMateriel = new WindowCréerMateriel(new Categorie_Materiel(), Mode.Insert);
            winAjoutCategorie.Owner = this;

            bool reponse = (bool)winAjoutCategorie.ShowDialog();
            if (reponse == true && winAjoutCategorie.DataContext is CategorieMateriel)
            {
                CategorieMateriel c = (CategorieMateriel)winAjoutCategorie.DataContext;
                c.Create();
            }
        }
    }
}
