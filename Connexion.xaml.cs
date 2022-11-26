using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetFinal
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Connexion : Page
    {
        public Connexion()
        {
            this.InitializeComponent();
        }

        private void btnCon_Click(object sender, RoutedEventArgs e)
        {
            btnIns.Style = (Style)this.Resources["ButtonNactive"];
            btnCon.Style = (Style)this.Resources["ButtonActive"];
            in1.Visibility = Visibility.Collapsed;
            in2.Visibility = Visibility.Collapsed;
            btnCreer.Visibility = Visibility.Collapsed;
            btnConn.Visibility = Visibility.Visible;

        }

        private void btnIns_Click(object sender, RoutedEventArgs e)
        {
            btnCon.Style = (Style)this.Resources["ButtonNactive"];
            btnIns.Style = (Style)this.Resources["ButtonActive"];
            in1.Visibility = Visibility.Visible;
            in2.Visibility = Visibility.Visible;
            btnCreer.Visibility = Visibility.Visible;
            btnConn.Visibility = Visibility.Collapsed;
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Trajets));
        }
    }
}
