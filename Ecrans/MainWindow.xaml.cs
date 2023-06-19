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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            WindowSeConnecter fenetre = new WindowSeConnecter();
            fenetre.ShowDialog();

            this.lbPseudo.Content = fenetre.tbLogin.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCategorie fenetreCategorie = new WindowCategorie(this);
            fenetreCategorie.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowMateriel fenetreMateriel = new WindowMateriel(this);
            fenetreMateriel.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowPersonnel fenetrePersonnel = new WindowPersonnel(this);
            fenetrePersonnel.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowAttribution fenetreAttribution = new WindowAttribution(this);
            fenetreAttribution.ShowDialog();
        }
    }
}
