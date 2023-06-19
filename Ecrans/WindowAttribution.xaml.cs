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
    /// Logique d'interaction pour WindowAttribution.xaml
    /// </summary>
    public partial class WindowAttribution : Window
    {
        public WindowAttribution(Window owner)
        {
            this.Owner = owner;
            this.DataContext = owner.DataContext;
            InitializeComponent();
        }

        private void btCreer_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerAttribution winAjouterAttribution = new WindowCréerAttribution(new Est_Attribue(), Mode.Insert, this);


            bool reponse = (bool)winAjouterAttribution.ShowDialog();
            if (reponse == true && winAjouterAttribution.DataContext is Est_Attribue)
            {
                Est_Attribue ea = (Est_Attribue)winAjouterAttribution.DataContext;
                ea.Create();
                ((ApplicationData)this.DataContext).Est_Attribues.Add(ea);
                lvAttribution.Items.Refresh();
            }
        }

        private void btModifier_Click(object sender, RoutedEventArgs e)
        {
            WindowCréerAttribution WindowAjouterAttribution = new WindowCréerAttribution((Est_Attribue)lvAttribution.SelectedItem, Mode.Update, this);
            WindowAjouterAttribution.Owner = this;

            bool reponse = (bool)WindowAjouterAttribution.ShowDialog();
            if (reponse == true)
            {
                Est_Attribue ea = (Est_Attribue)lvAttribution.SelectedItem;
                ea.Update();
            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(" Vous êtes sur de vouloir supprimer cette attribution ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Est_Attribue ea = (Est_Attribue)lvAttribution.SelectedItem;
                ea.Delete();
                lvAttribution.SelectedIndex = 0;
                ((ApplicationData)this.DataContext).Est_Attribues.Remove(ea);
                lvAttribution.Items.Refresh();
            }
        }
    }
}
