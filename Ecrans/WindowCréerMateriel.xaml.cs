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
    /// Logique d'interaction pour WindowCréerMateriel.xaml
    /// </summary>
    public partial class WindowCréerMateriel : Window
    {
        public WindowCréerMateriel(Materiel mat, Mode mode)
        {
            this.DataContext = mat;
            InitializeComponent();
            this.cbCategorie.ItemsSource = ((ApplicationData)this.Owner.DataContext).Categorie_Materiels;
            if (mode == Mode.Update)
            {
                btAjouter.Content = "Modifier";
                this.Title = "Modification catégorie";
                this.cbCategorie.SelectedItem = mat.UneCategorie;
            }
            else if (mode == Mode.Insert)
            {
                btAjouter.Content = "Ajouter";
                this.Title = "Ajout catégorie";

            }
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbNomMat.Text) || String.IsNullOrEmpty(tbRef.Text) || String.IsNullOrEmpty(tbCodeBarre.Text) || cbCategorie.SelectedIndex == -1)
            {
                MessageBox.Show("Erreur : Le nom, le ref et codebarre du Matériel sont obligatoires !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {


                if (Validation.GetHasError((DependencyObject)tbRef) || Validation.GetHasError((DependencyObject)tbCodeBarre) || Validation.GetHasError((DependencyObject)tbNomMat) || Validation.GetHasError((DependencyObject)cbCategorie))
                    MessageBox.Show(this.Owner, "Il y a une erreur !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
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
