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
    public sealed partial class Trajets : Page
    {
        public Trajets()
        {
            this.InitializeComponent();

            lvPlaces.ItemsSource = GestionBD.getInstance().GetPlaces();
            lvPlacesClient.ItemsSource = GestionBD.getInstance().PlaceClient();

            Boolean connect = GestionBD.getInstance().Connect;
            if (connect == true)
            {
                btnConn.Visibility = Visibility.Collapsed;
                btnReserves.Visibility = Visibility.Visible;
            }
            else
            {
                btnReserves.Visibility = Visibility.Collapsed;
                btnConn.Visibility = Visibility.Visible;
            }
        }

        private void btnConn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Connexion));
        }

        private void btnReserves_Click(object sender, RoutedEventArgs e)
        {
            
            if(lvPlacesClient.Visibility == Visibility.Collapsed)
            {
              lvPlacesClient.Visibility = Visibility.Visible;
              lvPlaces.Visibility = Visibility.Collapsed;
                
                btnReserves.Style = (Style)this.Resources["ButtonActive"];
            }
            else if(lvPlacesClient.Visibility == Visibility.Visible)
            {
                btnReserves.Style = (Style)this.Resources["ButtonNactive"];
                lvPlacesClient.Visibility = Visibility.Collapsed;
                lvPlaces.Visibility = Visibility.Visible;
            }
            
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            Boolean connect = GestionBD.getInstance().Connect;
            if (connect == true)
            {
                var button = sender as Button;
                string nb_place = ((Button)sender).Tag.ToString();
                string id_place = ((Button)sender).CommandParameter.ToString();
                GestionBD.getInstance().ajouterPlaces(id_place, nb_place);
                lvPlaces.ItemsSource = GestionBD.getInstance().GetPlaces();
                lvPlacesClient.ItemsSource = GestionBD.getInstance().PlaceClient();
            }
            else
            {
                Frame.Navigate(typeof(Connexion));
            }


        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            Boolean connect = GestionBD.getInstance().Connect;
            if (connect == true)
            {
                var button = sender as Button;
                string nb_place = ((Button)sender).Tag.ToString();
                string id_place = ((Button)sender).CommandParameter.ToString();
                GestionBD.getInstance().modifPlaces(id_place, nb_place);
                lvPlacesClient.ItemsSource = GestionBD.getInstance().PlaceClient();
                lvPlaces.ItemsSource = GestionBD.getInstance().GetPlaces();
            }
            else
            {
                Frame.Navigate(typeof(Connexion));
            }


        }



    }
}
