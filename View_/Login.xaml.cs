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

namespace View_ {
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window {
        public Login() {
            InitializeComponent();
            //MainWindow accueil = new MainWindow();
            //accueil.Visibility = Visibility.Visible;
        }
        private void button_Click(object sender, RoutedEventArgs e) {
            string name = nom.Text;
            string passw = (string)password.Password;
            if (BLL.Manager.VerifierConnexion(name, passw)) {
                MainWindow accueil = new MainWindow();
                this.Hide();
                accueil.Visibility = Visibility.Visible;
            }
            else {
                this.lbl.Content = "Vérifier les paramétre";
            }
        }
    }
}
