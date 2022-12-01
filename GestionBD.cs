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
        int id = 4;
        String typeClient = "555";
        Boolean connect;


        public int Id { get => id; set => id = value; }
        public string TypeClient { get => typeClient; set => typeClient = value; }
        public bool Connect { get => connect; set => connect = value; }

        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=1920518-brice-jérôme-clain;Uid=1920518;Pwd=1920518;");
            id = 3;
            typeClient = "555";
            connect = false;
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

        public void connClient(String email, String mdp)
        {

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "CALL con_client(@email, @mdp) ";

            commande.Parameters.AddWithValue("@email", email);
            commande.Parameters.AddWithValue("@mdp", mdp);

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            r.Read();
            int val = r.GetInt32("res");

            if (val != 0)
            {
                id = r.GetInt32("res");
                typeClient = r.GetString("type") ;
                connect = true;
            }

            r.Close();
            con.Close();
        }

        public int ajouterClient(String nom, String adresse, String prenom, String num, String email, String mdp)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "insert into clients (nom, adresse, prenom, num, email, mdp, type) values(@nom, @adresse, @prenom, @num, @email, MD5( @mdp ), 'client') ";

            commande.Parameters.AddWithValue("@nom", nom);
            commande.Parameters.AddWithValue("@adresse", adresse);
            commande.Parameters.AddWithValue("@prenom", prenom);
            commande.Parameters.AddWithValue("@num", num);
            commande.Parameters.AddWithValue("@email", email);
            commande.Parameters.AddWithValue("@mdp", mdp);


            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }




    }
}
