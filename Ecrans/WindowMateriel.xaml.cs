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
     
        public WindowMateriel(Window owner)
        {
            this.Owner = owner;
            this.DataContext = owner.DataContext;
            InitializeComponent();
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerMateriel WindowAjouterMateriel = new WindowCréerMateriel(new Materiel(), Mode.Insert, this);
           


            bool Reponse = (bool)WindowAjouterMateriel.ShowDialog();
            if (Reponse == true && WindowAjouterMateriel.DataContext is Materiel)
            {
               Materiel m = (Materiel)WindowAjouterMateriel.DataContext;
                m.Create();
                ((ApplicationData)this.DataContext).Materiels.Add(m);
                lvMateriel.Items.Refresh();
                }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerMateriel WindowAjouterMateriel = new WindowCréerMateriel((Materiel)lvMateriel.SelectedItem, Mode.Update, this);
            WindowAjouterMateriel.Owner = this;

            bool reponse = (bool)WindowAjouterMateriel.ShowDialog();
            if (reponse == true)
            {
                Materiel m = (Materiel)lvMateriel.SelectedItem; // (Materiel)winAjoutMateriel.DataContext;
                m.Update(); 
            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir supprimer " + ((Materiel)lvMateriel.SelectedItem).NomMateriel, "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Materiel m = (Materiel)lvMateriel.SelectedItem;
                m.Delete();
                lvMateriel.SelectedIndex = 0;
                ((ApplicationData)this.DataContext).Materiels.Remove(m);
                lvMateriel.Items.Refresh();
            }
        }
    }
}
