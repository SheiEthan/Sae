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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Ecrans.WindowCréerCatégorie;

namespace Ecrans
{
    /// <summary>
    /// Logique d'interaction pour WindowCréerCatégorie.xaml
    /// </summary>
    public enum Mode { Insert, Update };
    public partial class WindowCréerCatégorie : Window
    {        
        public WindowCréerCatégorie(Categorie_Materiel cate, Mode mode, Window owner)
        {
            this.Owner = owner;
            this.DataContext = cate;
            InitializeComponent();
            if (mode == Mode.Update)
            {
                btAjouter.Content = "Modifier";
                this.Title = "Modification catégorie";
            }
            else if (mode == Mode.Insert)
            {
                btAjouter.Content = "Ajouter";
                this.Title = "Ajout catégorie";
            }
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbCategorie.Text))
                MessageBox.Show("Erreur : un nom de catégorie est attendu !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {                
                this.tbCategorie.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                if (Validation.GetHasError((DependencyObject)tbCategorie))
                    MessageBox.Show(this.Owner, "Problème : Impossible", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    DialogResult = true;
                }
            }
        }

        private void btAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
