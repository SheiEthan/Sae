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

namespace Ecrans
{
    /// <summary>
    /// Logique d'interaction pour WindowCréerPersonnel.xaml
    /// </summary>
    public partial class WindowCréerPersonnel : Window
    {
        public WindowCréerPersonnel(Personnel perso, Mode mode, Window owner)
        {
            this.Owner = owner;
            this.DataContext = perso;
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
            if (String.IsNullOrEmpty(tbNomPerso.Text) || String.IsNullOrEmpty(tbPrenomPerso.Text) || String.IsNullOrEmpty(tbEmail.Text))
                MessageBox.Show("Erreur : un nom de catégorie est attendu !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                this.tbNomPerso.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.tbPrenomPerso.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.tbEmail.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                if (Validation.GetHasError((DependencyObject)tbNomPerso) || Validation.GetHasError((DependencyObject)tbPrenomPerso) || Validation.GetHasError((DependencyObject)tbEmail))
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
