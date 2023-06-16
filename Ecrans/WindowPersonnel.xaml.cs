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
    /// Logique d'interaction pour WindowPersonnel.xaml
    /// </summary>
    public partial class WindowPersonnel : Window
    {
        public WindowPersonnel()
        {
            InitializeComponent();
        }
        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerPersonnel winAjoutPerso = new WindowCréerPersonnel(new Personnel(), Mode.Insert);
            winAjoutPerso.Owner = this;

            bool reponse = (bool)winAjoutPerso.ShowDialog();
            if (reponse == true)
            {
                Personnel c = (Personnel)winAjoutPerso.DataContext;
                c.Create();
            }

        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerPersonnel winModifPerso = new WindowCréerPersonnel((Personnel)lvPersonnel.SelectedItem, Mode.Update);
            winModifPerso.Owner = this;

            bool reponse = (bool)winModifPerso.ShowDialog();
            if (reponse == true)
            {
                Personnel c = (Personnel)winModifPerso.DataContext;
                c.Update();
            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sur de vouloir supprimer " + ((Personnel)lvPersonnel.SelectedItem).NomPersonnel + " " + ((Personnel)lvPersonnel.SelectedItem).PrenomPersonnel + " " + ((Personnel)lvPersonnel.SelectedItem).EmailPersonnel, "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Personnel c = (Personnel)lvPersonnel.SelectedItem;
                c.Delete();
                lvPersonnel.SelectedIndex = 0;
            }
        }
    }
}

