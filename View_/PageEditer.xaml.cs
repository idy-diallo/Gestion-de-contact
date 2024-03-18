using BLL;
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
    /// Logique d'interaction pour PageEditer.xaml
    /// </summary>
    public partial class PageEditer : Window {
        public bool fav = false;
        public PageEditer() {
            InitializeComponent();
        }

        private void Editer(object sender, RoutedEventArgs e) {
            Manager.Editer(nomEdit.Text, PrenomEdit.Text, NumEdit.Text, fav);
        }

        private void changeValue(object sender, RoutedEventArgs e) {
            fav = !fav;
        }
    }
}
