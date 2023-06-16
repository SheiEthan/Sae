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
    /// Logique d'interaction pour WindowSeConnecter.xaml
    /// </summary>
    public partial class WindowSeConnecter : Window
    {
        public WindowSeConnecter()
        {
            InitializeComponent();
        }

        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            if (VerifSaisie())
                this.Close();
            else
                MessageBox.Show("Vous devez renseigner votre login et votre mot de passe.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool VerifSaisie()
        {
            bool login = !String.IsNullOrEmpty(tbLogin.Text);
            bool mdp = !String.IsNullOrEmpty(tbMdp.Text);

            if (login && mdp)
                return true;
            else
                return false;
        }

    }
}
