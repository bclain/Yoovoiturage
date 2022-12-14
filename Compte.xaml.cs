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
    public sealed partial class Compte : Page
    {
        public Compte()
        {
            this.InitializeComponent();
            lvPlaces.ItemsSource = GestionBD.getInstance().vueChauffeur();
            nom.Text = GestionBD.getInstance().Nom;
            total.Text = GestionBD.getInstance().Total.ToString();
            double taxe = GestionBD.getInstance().Total * 0.20;
            tax.Text = taxe.ToString();

        }

        private void lvPlaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnConn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Ajout));
        }
    }
}
