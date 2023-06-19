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
    /// Logique d'interaction pour WindowCategorie.xaml
    /// </summary>
    public partial class WindowCategorie : Window
    {
        public WindowCategorie(Window owner)
        {
            this.Owner = owner;
            this.DataContext = owner.DataContext;
            InitializeComponent();

        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerCatégorie winAjoutCategorie = new WindowCréerCatégorie(new Categorie_Materiel(), Mode.Insert,this);
            winAjoutCategorie.Owner = this;

            bool reponse = (bool)winAjoutCategorie.ShowDialog();
            if (reponse == true)
            {
                Categorie_Materiel c = (Categorie_Materiel)winAjoutCategorie.DataContext;
                c.Create();
                ((ApplicationData)this.DataContext).Categorie_Materiels.Add(c);
                lvCategorie.Items.Refresh();
            }

        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerCatégorie winModifCate = new WindowCréerCatégorie((Categorie_Materiel)lvCategorie.SelectedItem, Mode.Update,this);
            winModifCate.Owner = this;

            bool reponse = (bool)winModifCate.ShowDialog();
            if (reponse == true)
            {
                Categorie_Materiel c = (Categorie_Materiel)winModifCate.DataContext;
                c.Update();
            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sur de vouloir supprimer " + ((Categorie_Materiel)lvCategorie.SelectedItem).NomCategorie, "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Categorie_Materiel c = (Categorie_Materiel)lvCategorie.SelectedItem;
                c.Delete();
                lvCategorie.SelectedIndex = 0;
                ((ApplicationData)this.DataContext).Categorie_Materiels.Remove(c);
                lvCategorie.Items.Refresh();
            }
        }
    }
}
