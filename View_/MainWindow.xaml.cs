using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
namespace View_ {
    
    public partial class MainWindow : Window {
        private string selectedText;
        public MainWindow() {
            InitializeComponent();
        }

        private void Ajouter(object sender, RoutedEventArgs e) {
            PageAjout a = new PageAjout();
            a.Visibility = Visibility.Visible;
        }

        private void Afficher(object sender, RoutedEventArgs e) {
            this.Lcontact.Content = "";
            List<Contacts>  list = Manager.Afficher();
            for (int i = 0; i < list.Count; i++) {
                this.Lcontact.Content += list[i].Prenom + "    " + list[i].Nom + "    " + list[i].Tel + "     " + list[i].Favorie + "\n" + "\n" + "\n";
            }
        }

        private void Supprimer(object sender, RoutedEventArgs e) {
            PageSupprimer a = new PageSupprimer();
            a.Visibility = Visibility.Visible;
        }

        private void Editer(object sender, RoutedEventArgs e) {
            PageEditer a = new PageEditer();
            a.Visibility = Visibility.Visible;  
        }

        private void Alphabetique(object sender, RoutedEventArgs e) {
            this.Lcontact.Content = "";
            List<Contacts> list = Manager.Regroupement(1);
            for (int i = 0; i < list.Count; i++) {
                this.Lcontact.Content += list[i].Prenom + "    " + list[i].Nom + "    " + list[i].Tel + "     " + list[i].Favorie + "\n" + "\n" + "\n";
            }
        }

        private void favoris(object sender, RoutedEventArgs e) {
            this.Lcontact.Content = "";
            List<Contacts> list = Manager.Regroupement(2);
            for (int i = 0; i < list.Count; i++) {
                this.Lcontact.Content += list[i].Prenom + "    " + list[i].Nom + "    " + list[i].Tel + "     " + list[i].Favorie + "\n" + "\n" + "\n";
            }
        }

        private void Critere_Selected(object sender, RoutedEventArgs e) {
            if (this.Critere.SelectedItem != null) {
                ComboBoxItem cbi = (ComboBoxItem)Critere.SelectedItem;
                selectedText = cbi.Content.ToString();
            }
        }
        private void Click_Rechercher(object sender, RoutedEventArgs e) {
            if (selectedText == null || selectedText == "") {
                string chaineRecherchee = Rechercher.Text;
                List<Contacts> liste = BLL.Manager.ChercherContacts(chaineRecherchee);
                if (liste != null) {
                    string cont = "";
                    foreach (Contacts contact in liste) {
                        cont += contact + "\n";
                    }
                    this.Lcontact.Content = cont;
                }
            }
            else if (selectedText.Equals("Prenom")) {
                string prenom = Rechercher.Text;
                List<Contacts> liste = BLL.Manager.ChercherContactsParPrenom(prenom);
                if (liste != null) {
                    string cont = "";
                    foreach (Contacts contact in liste) {
                        cont += contact + "\n";
                    }
                    this.Lcontact.Content = cont;
                }

            }
            else if (selectedText.Equals("Nom")) {
                string nom = Rechercher.Text;
                List<Contacts> liste = BLL.Manager.ChercherContactsParNom(nom);
                if (liste != null) {
                    string cont = "";
                    foreach (Contacts contact in liste) {
                        cont += contact + "\n";
                    }
                    this.Lcontact.Content = cont;
                }
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e) {
            
        }
    }
}
