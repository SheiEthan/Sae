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
        public WindowPersonnel(Window owner)
        {
            this.Owner = owner;
            this.DataContext = owner.DataContext;
            InitializeComponent();
        }
        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerPersonnel winAjoutPerso = new WindowCréerPersonnel(new Personnel(), Mode.Insert,this);
            winAjoutPerso.Owner = this;

            bool reponse = (bool)winAjoutPerso.ShowDialog();
            if (reponse == true)
            {
                Personnel p = (Personnel)winAjoutPerso.DataContext;
                p.Create();
                ((ApplicationData)this.DataContext).Personnels.Add(p);
                lvPersonnel.Items.Refresh();
            }

        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerPersonnel winModifPerso = new WindowCréerPersonnel((Personnel)lvPersonnel.SelectedItem, Mode.Update,this);
            winModifPerso.Owner = this;

            bool reponse = (bool)winModifPerso.ShowDialog();
            if (reponse == true)
            {
                Personnel p = (Personnel)winModifPerso.DataContext;
                p.Update();
            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sur de vouloir supprimer " + ((Personnel)lvPersonnel.SelectedItem).NomPersonnel + " " + ((Personnel)lvPersonnel.SelectedItem).PrenomPersonnel + " " + ((Personnel)lvPersonnel.SelectedItem).EmailPersonnel, "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Personnel p = (Personnel)lvPersonnel.SelectedItem;
                p.Delete();
                lvPersonnel.SelectedIndex = 0;                      
             

                foreach (Est_Attribue attrib in ((ApplicationData)this.DataContext).Est_Attribues.ToList<Est_Attribue>() )
                {  if (attrib.FK_IdPersonnel == p.IdPersonnel)
                        ((ApplicationData)this.DataContext).Est_Attribues.Remove(attrib);
                }

                ((ApplicationData)this.DataContext).Personnels.Remove(p);
                lvPersonnel.Items.Refresh();
            }
        }
    }
}

