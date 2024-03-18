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
    /// Logique d'interaction pour PageSupprimer.xaml
    /// </summary>
    public partial class PageSupprimer : Window {
        public PageSupprimer() {
            InitializeComponent();
        }

        private void Supprimer(object sender, RoutedEventArgs e) {
            Manager.Supprimer(l_sup.Text);
        }
    }
}
