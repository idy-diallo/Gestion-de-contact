using Model;
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
using Model;
namespace View_ {
    /// <summary>
    /// Logique d'interaction pour PageAjout.xaml
    /// </summary>
    public partial class PageAjout : Window {
        public PageAjout() {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            Contacts contacts = new Contacts();
            if (Prenom.Text.Length == 0) {
                this.lb_.Content = "*Champs prenom obligatoire";
            }
            else if (Nom.Text.Length == 0) {
                this.lb_.Content = "*Champs nom obligatoire";
            }
            else if (Tel.Text.Length == 0) {
                this.lb_.Content = "*Champs téléphone obligatoire";
            }
            else {
                //if(Tel.Text.IsM)
                contacts.Prenom = Prenom.Text;
                contacts.Nom = Nom.Text;
                contacts.Tel = Tel.Text;
                contacts.Favorie = (Favorie.IsChecked == true) ? true : false;
                contacts.Favorie = (Favorie.IsChecked == true) ? true : false;
                if (BLL.Manager.AjouterContact(contacts)) {
                    this.lb_.Content = "Contact ajouter avec succés";
                }
            }
        }
    }
}
