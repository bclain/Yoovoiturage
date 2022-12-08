using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class Ajout : Page
    {
        String type;
        public ObservableCollection<string> Villes { get; set; } = GestionBD.getInstance().GetVilles();
        public Ajout()
        {
            this.InitializeComponent();
            DataContext = this;
            dater.MinDate = DateTime.Today;
            type = "VUS";
            tbDepart.Text = "";
            tbArrive.Text = "";
            tbArret.Text = "";
            tbDate.Text = "";
            arretsec.Visibility = Visibility.Collapsed;
        }


        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Compte));
        }

        private void btnCreer_Click(object sender, RoutedEventArgs e)
        {
            tbDepart.Text = "";
            tbArrive.Text = "";
            tbArret.Text ="";
            tbDate.Text = "";


            int valid = 0;
            int validT = 0 ;
            String trajet = "simple";

            if (departTimePicker.SelectedTime.ToString().Equals("") || villed.SelectedIndex == -1)
            {
                tbDepart.Text = "Veillez entrez toutes les informations du départ";
            }
            else
            {
                valid += 1;
            }

            if(dater.Date.ToString() == "")
            {
                tbDate.Text = "Veillez entrez une date";
            }
            else
            {
                valid += 1;
            }

            if (arrivalTimePicker.SelectedTime.ToString().Equals("") || villea.SelectedIndex == -1)
            {
                tbArrive.Text = "Veillez entrez toutes les informations du départ";
            }
            else
            {
                if (arrivalTimePicker.SelectedTime < departTimePicker.SelectedTime)
                {
                    tbArrive.Text = "L'heure d'arrivée doit être après l'heure de départ";
                }
                else if (villed.SelectedItem.ToString() == villea.SelectedItem.ToString() || villed.SelectedItem.ToString() == villeo.SelectedItem.ToString())
                {
                    tbArrive.Text = "La ville de départ doit être différente des autres";
                }
                else{

                    valid += 1;
                }
            }

            if (cb1.IsChecked == true) {
                validT = 4;
                trajet = "long";
                if (optionTimePicker.SelectedTime.ToString().Equals("") || villeo.SelectedIndex == -1)
                {
                    tbArret.Text = "Veillez entrez toutes les informations de l'arrêt";
                }
                else
                {
                    if (!((arrivalTimePicker.SelectedTime > optionTimePicker.SelectedTime) && (optionTimePicker.SelectedTime > departTimePicker.SelectedTime)))
                    {
                        tbArret.Text = "L'heure de l'arrêt doit être entre l'heure de départ et d'arrivée";
                    }
                    else if (villed.SelectedItem.ToString() == villeo.SelectedItem.ToString() || villeo.SelectedItem.ToString() == villea.SelectedItem.ToString())
                    {
                        tbArret.Text = "La ville d'arrêt doit être différente des autres";
                    }
                    else
                    {

                        valid += 1;
                    }
                }
            }
            else
            {
                validT = 3;
            }

            if (valid == validT)
            {
                var date = dater.Date;
                DateTime time = date.Value.DateTime;
                var formatedtime = time.ToString("yyyy-MM-dd");
                System.Diagnostics.Debug.WriteLine(formatedtime);
                if (trajet == "long")
                {
                    GestionBD.getInstance().ajoutTrajet(trajet, formatedtime, type, villed.SelectedItem.ToString(), departTimePicker.SelectedTime.ToString(), villeo.SelectedItem.ToString(), optionTimePicker.SelectedTime.ToString(), villea.SelectedItem.ToString(), arrivalTimePicker.SelectedTime.ToString());
                }
                else if (trajet == "simple")
                {
                    GestionBD.getInstance().ajoutTrajet(trajet, formatedtime, type, villed.SelectedItem.ToString(), departTimePicker.SelectedTime.ToString(), "","", villea.SelectedItem.ToString(), arrivalTimePicker.SelectedTime.ToString());
                }
                Frame.Navigate(typeof(Compte));
            }
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            arretsec.Visibility = Visibility.Visible;
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            arretsec.Visibility = Visibility.Collapsed;
            tbArret.Text = "";
        }

        private void btnVUS_Click(object sender, RoutedEventArgs e)
        {
            btnBerline.Style = (Style)this.Resources["ButtonNactive"];
            btnVUS.Style = (Style)this.Resources["ButtonActive"];
            type = "VUS";
        }

        private void btnBerline_Click(object sender, RoutedEventArgs e)
        {
            btnVUS.Style = (Style)this.Resources["ButtonNactive"];
            btnBerline.Style = (Style)this.Resources["ButtonActive"];
            type = "Berline";
        }
    }
}
