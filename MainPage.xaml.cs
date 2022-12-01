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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjetFinal
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            GestionBD.getInstance().GetPlaces();
            this.InitializeComponent();
            mainFrame.Navigate(typeof(Trajets));
        }

        private void Button_Click_trajets(object sender, RoutedEventArgs e)
        {
            GestionBD.getInstance().GetPlaces();
            btnCompte.Style = (Style)this.Resources["ButtonMenNonActive"];
            btnTrajets.Style = (Style)this.Resources["ButtonMenActive"];
            this.mainFrame.Navigate(typeof(Trajets));
        }

        private void Button_Click_compte(object sender, RoutedEventArgs e)
        {
            btnTrajets.Style = (Style)this.Resources["ButtonMenNonActive"];
            btnCompte.Style = (Style)this.Resources["ButtonMenActive"];
            this.mainFrame.Navigate(typeof(Compte));

        }

        public void CheckConn()
        {
            Boolean connect = GestionBD.getInstance().Connect;
            if (connect == true)
            {
                connected.Visibility = Visibility.Visible;
            }

        }


    }
}
