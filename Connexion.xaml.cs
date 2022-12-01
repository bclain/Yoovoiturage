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
using System.Text.RegularExpressions;

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

        private MainPage MainPage
        {
            get { return (Window.Current.Content as Frame)?.Content as MainPage; }
        }

        private void btnCon_Click(object sender, RoutedEventArgs e)
        {
            btnIns.Style = (Style)this.Resources["ButtonNactive"];
            btnCon.Style = (Style)this.Resources["ButtonActive"];
            in1.Visibility = Visibility.Collapsed;
            in2.Visibility = Visibility.Collapsed;
            btnCreer.Visibility = Visibility.Collapsed;
            btnConn.Visibility = Visibility.Visible;
            tbNomErr.Text = "";
            tbAdresseErr.Text = "";
            tbPrenomErr.Text = "";
            tbMailErr.Text = "";
            tbNumErr.Text = "";
            tbMdpErr.Text = "";
        }

        private void btnIns_Click(object sender, RoutedEventArgs e)
        {
            btnCon.Style = (Style)this.Resources["ButtonNactive"];
            btnIns.Style = (Style)this.Resources["ButtonActive"];
            in1.Visibility = Visibility.Visible;
            in2.Visibility = Visibility.Visible;
            btnCreer.Visibility = Visibility.Visible;
            btnConn.Visibility = Visibility.Collapsed;
            tbNomErr.Text = "";
            tbAdresseErr.Text = "";
            tbPrenomErr.Text = "";
            tbMailErr.Text = "";
            tbNumErr.Text = "";
            tbMdpErr.Text = "";
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Trajets));
        }

        private void btnConn_Click(object sender, RoutedEventArgs e)
        {
            string strMail = tbMail.Text;
            string strMdp = tbMdp.Text;
            int valid = 0;
            Regex emailValid = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            tbMailErr.Text = "";
            tbMdpErr.Text = "";

            if (strMail.Trim().Equals(""))
            {
                tbMailErr.Text = "Champ Requis.";
            }
            else
            {
                if (emailValid.Match(strMail).Success)
                {
                    valid += 1;
                }
                else
                {
                    tbMailErr.Text = "Veillez entrer une adresse valide";
                }
            }

            if (strMdp.Trim().Equals(""))
            {
                tbMdpErr.Text = "Champ Requis.";
            }
            else
            {
                valid += 1;
            }



            if (valid == 2)
            {
                GestionBD.getInstance().connClient(strMail.ToString(), strMdp.ToString());
                Boolean connect = GestionBD.getInstance().Connect;
                if (connect == true)
                {
                    Frame.Navigate(typeof(Trajets));
                    MainPage.CheckConn();
                }
                else
                {
                    tbMailErr.Text = "Informations incorrectes";
                };

            }

        }

        private void btnCreer_Click(object sender, RoutedEventArgs e)
        {
            tbNomErr.Text = "";
            tbAdresseErr.Text = "";
            tbPrenomErr.Text = "";
            tbMailErr.Text = "";
            tbNumErr.Text = "";
            tbMdpErr.Text = "";
            int valid = 0;
            Regex emailValid = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex nameValid = new Regex(@"^[a-zA-Z\u00C0-\u00FF ]*$");
            Regex numValid = new Regex(@"^\d{10}$");
            Regex mdpValid = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$");


            if (tbNom.Text.Trim().Equals(""))
            {
                tbNomErr.Text = "Champ Requis.";
            }
            else
            {
                if (nameValid.Match(tbNom.Text).Success)
                {
                    valid += 1;
                }
                else
                {
                    tbNomErr.Text = "Veillez entrer un nom valide.";
                }
            }

            if (tbPrenom.Text.Trim().Equals(""))
            {
                tbPrenomErr.Text = "Champ Requis.";
            }
            else
            {
                if (nameValid.Match(tbPrenom.Text).Success)
                {
                    valid += 1;
                }
                else
                {
                    tbPrenomErr.Text = "Veillez entrer un nom valide.";
                }
            }


            if (tbAdresse.Text.Trim().Equals(""))
            {
                tbAdresseErr.Text = "Champ Requis.";
            }
            else
            {
              valid += 1;
            }


            if (tbNum.Text.Trim().Equals(""))
            {
                tbNumErr.Text = "Champ Requis.";
            }
            else
            {
                if (numValid.Match(tbNum.Text).Success)
                {
                    valid += 1;
                }
                else
                {
                    tbNumErr.Text = "Veillez entrer un numéro valide (10 chiffres).";
                }
            }

            if (tbMail.Text.Trim().Equals(""))
            {
                tbMailErr.Text = "Champ Requis.";
            }
            else
            {
                if (emailValid.Match(tbMail.Text).Success)
                {
                    valid += 1;
                }
                else
                {
                    tbMailErr.Text = "Veillez entrer une adresse email valide.";
                }
            }

            if (tbMdp.Text.Trim().Equals(""))
            {
                tbMdpErr.Text = "Champ Requis.";
            }
            else
            {
                if (mdpValid.Match(tbMdp.Text).Success)
                {
                    valid += 1;
                }
                else
                {
                    tbMdpErr.Text = "Veillez entrer au moins 6 caractères, une majuscule et un chiffre.";
                }
            }


            if (valid == 6)
            {
                GestionBD.getInstance().ajouterClient(tbNom.Text, tbAdresse.Text, tbPrenom.Text, tbNum.Text, tbMail.Text, tbMdp.Text);
                btnIns.Style = (Style)this.Resources["ButtonNactive"];
                btnCon.Style = (Style)this.Resources["ButtonActive"];
                in1.Visibility = Visibility.Collapsed;
                in2.Visibility = Visibility.Collapsed;
                btnCreer.Visibility = Visibility.Collapsed;
                btnConn.Visibility = Visibility.Visible;
                tbNomErr.Text = "";
                tbAdresseErr.Text = "";
                tbPrenomErr.Text = "";
                tbMailErr.Text = "";
                tbNumErr.Text = "";
                tbMdpErr.Text = "";
                tbMdp.Text = "";
                tbCree.Visibility = Visibility.Visible;
            }


        }
    }
}
