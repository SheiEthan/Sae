using Ecrans.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Logique d'interaction pour WindowCréerAttribution.xaml
    /// </summary>
    public partial class WindowCréerAttribution : Window
    {
        public WindowCréerAttribution(Est_Attribue attribu, Mode mode, Window owner)
        {
            this.Owner = owner;
            this.DataContext = attribu;
            attribu.DateAttribution = DateTime.Today;
            InitializeComponent();
            this.cbMateriel.ItemsSource = ((ApplicationData)this.Owner.DataContext).Materiels;
            this.cbPersonnel.ItemsSource = ((ApplicationData)this.Owner.DataContext).Personnels;
            if (mode == Mode.Update)
            {
                btAjouter.Content = "Modifier";
                this.Title = "Modification Attribution";
                this.cbMateriel.SelectedItem = attribu.UnMateriel;
                this.cbPersonnel.SelectedItem = attribu.UnPersonnel;
            }
            else if (mode == Mode.Insert)
            {
                btAjouter.Content = "Ajouter";
                this.Title = "Ajout Attribution";
            }

        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (cbMateriel.SelectedIndex == -1 || cbPersonnel.SelectedIndex == -1)
            {
                MessageBox.Show("Erreur : Le materiel, le personnel et date sont attendus !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Validation.GetHasError((DependencyObject)cbMateriel) || Validation.GetHasError((DependencyObject)cbPersonnel) || Validation.GetHasError((DependencyObject)dpAttribution))
                    MessageBox.Show(this.Owner, "Création impossible !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    DialogResult = true;    
                }
            }
        }

        private void btAnnuler_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
