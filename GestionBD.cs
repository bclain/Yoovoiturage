using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetFinal
{
    class GestionBD
    {
        MySqlConnection con;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=1920518-brice-jérôme-clain;Uid=1920518;Pwd=1920518;"); ;
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public ObservableCollection<Places> GetPlaces()
        {
            ObservableCollection<Places> liste = new ObservableCollection<Places>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from vueAcc";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                Places p = new Places(
                    r.GetInt32("id"),
                    r.GetString("date"),
                    r.GetString("typeVoiture"),
                    r.GetString("nom_chauffeur"),
                    r.GetString("heure_d"),
                    r.GetString("arretd"),
                    r.GetString("typePlace"),
                    r.GetString("heure_a"),
                    r.GetString("arreta"),
                    r.GetInt32("nbPlaces"),
                    r.GetString("statut")
                );

                liste.Add(p);
            }
            r.Close();
            con.Close();


            return liste;
        }


    }
}
