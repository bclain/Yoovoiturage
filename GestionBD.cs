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
        int id_actuel = 0;
        String nom = "";
        double total = 0;
        String typeClient = "555";
        Boolean connect;


        public int Id_actuel { get => id_actuel; set => id_actuel = value; }
        public string TypeClient { get => typeClient; set => typeClient = value; }
        public bool Connect { get => connect; set => connect = value; }
        public string Nom { get => nom; set => nom = value; }
        public double Total { get => total; set => total = value; }
        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=1920518-brice-jérôme-clain;Uid=1920518;Pwd=1920518;");
            id_actuel = 0;
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
                    r.GetString("heure_o"),
                    r.GetString("arreto"),
                    r.GetString("heure_a"),
                    r.GetString("arreta"),
                    r.GetInt32("nbreserve"),
                    r.GetInt32("nbdispo"),
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
                nom = r.GetString("nom");
                total = r.GetDouble("total");
                id_actuel = r.GetInt32("res");
                typeClient = r.GetString("type") ;
                connect = true;

            }

            r.Close();
            con.Close();
        }

        public void deconnClient()
        {
                nom = "";
                total = 0;
                id_actuel = 0 ;
                typeClient = "";
                connect = false;

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

        public int ajouterPlaces(String id_place, String nb_place)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "CALL set_places( @id_client, @id_place,@nb_place);";

            commande.Parameters.AddWithValue("@id_client", id_actuel);
            commande.Parameters.AddWithValue("@id_place", id_place);
            commande.Parameters.AddWithValue("@nb_place", nb_place);


            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }

        public ObservableCollection<Places> PlaceClient()
        {
            ObservableCollection<Places> liste = new ObservableCollection<Places>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "CALL places_client( @id_client);";

            commande.Parameters.AddWithValue("@id_client", id_actuel);


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
                    r.GetString("heure_o"),
                    r.GetString("arreto"),
                    r.GetString("heure_a"),
                    r.GetString("arreta"),
                    r.GetInt32("nbreserve"),
                    r.GetInt32("nbdispo"),
                    r.GetString("statut")
                );

                liste.Add(p);
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int modifPlaces(String id_place, String nb_place)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "CALL remove_places( @id_client, @id_place,@nb_place);";

            commande.Parameters.AddWithValue("@id_client", id_actuel);
            commande.Parameters.AddWithValue("@id_place", id_place);
            commande.Parameters.AddWithValue("@nb_place", nb_place);


            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }

        public ObservableCollection<Trajet> vueChauffeur()
        {
            ObservableCollection<Trajet> liste = new ObservableCollection<Trajet>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "CALL vueChauffeur( @id_chauffeur);";
            commande.Parameters.AddWithValue("@id_chauffeur", id_actuel);


            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                Trajet p = new Trajet(
                    r.GetInt32("id"),
                    r.GetString("date"),
                    r.GetInt32("nb_places"),
                    r.GetString("id_chauffeur"),
                    r.GetInt32("prix"),
                    r.GetString("type"),
                    r.GetString("heure_d"),
                    r.GetString("arretd"),
                    r.GetString("heure_o"),
                    r.GetString("arreto"),
                    r.GetString("heure_a"),
                    r.GetString("arreta")
                );

                liste.Add(p);
            }
            r.Close();
            con.Close();

            return liste;
        }

        public String GetPers(int id_trajet, string type)
        {
            MySqlConnection con2 = new MySqlConnection("Server=cours.cegep3r.info;Database=1920518-brice-jérôme-clain;Uid=1920518;Pwd=1920518;");
            String retour ;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con2;
            commande.CommandText = "CALL placeTrajet( @id_trajet, @type_place);";

            commande.Parameters.AddWithValue("@id_trajet", id_trajet);
            commande.Parameters.AddWithValue("@type_place", type);


            con2.Open();
            MySqlDataReader r = commande.ExecuteReader();
            r.Read();
            retour = r.GetString("res");

            con2.Close();

            return retour;
        }

        public int GetTotal(int id_trajet)
        {
            MySqlConnection con3 = new MySqlConnection("Server=cours.cegep3r.info;Database=1920518-brice-jérôme-clain;Uid=1920518;Pwd=1920518;");
            int retour;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con3;
            commande.CommandText = "CALL TotalTrajet( @id_trajet);";

            commande.Parameters.AddWithValue("@id_trajet", id_trajet);


            con3.Open();
            MySqlDataReader r = commande.ExecuteReader();
            r.Read();
            retour = r.GetInt32("total");

            con3.Close();

            return retour;
        }

        public ObservableCollection<String> GetVilles()
        {
            ObservableCollection<String> liste = new ObservableCollection<String>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from villes";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                liste.Add(r.GetString("ville"));
            }
            r.Close();
            con.Close();


            return liste;
        }

        public int ajoutTrajet( string trajett, string date, string type, string arretd, string heure_d, string arreto, string heure_o, string arreta, string heure_a)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            if(trajett == "long"){
                commande.CommandText = "INSERT INTO trajets (id_chauffeur, date, type, arretd, heure_d, arreto, heure_o, arreta, heure_a)  VALUES(@id_client, @date, @type_voiture , @arretd, @heure_d, @arreto, @heure_o, @arreta, @heure_a); ";

                commande.Parameters.AddWithValue("@id_client", id_actuel);
                commande.Parameters.AddWithValue("@date", date);
                commande.Parameters.AddWithValue("@type_voiture", type);
                commande.Parameters.AddWithValue("@arretd", arretd);
                commande.Parameters.AddWithValue("@heure_d", heure_d);
                commande.Parameters.AddWithValue("@arreto", arreto);
                commande.Parameters.AddWithValue("@heure_o", heure_o);
                commande.Parameters.AddWithValue("@arreta", arreta);
                commande.Parameters.AddWithValue("@heure_a", heure_a);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();
            }
            else if (trajett == "simple")
            {
                commande.CommandText = "INSERT INTO trajets (id_chauffeur, date, type, arretd, heure_d, arreta, heure_a)  VALUES(@id_client, @date, @type_voiture , @arretd, @heure_d, @arreta, @heure_a); ";

                commande.Parameters.AddWithValue("@id_client", id_actuel);
                commande.Parameters.AddWithValue("@date", date);
                commande.Parameters.AddWithValue("@type_voiture", type);
                commande.Parameters.AddWithValue("@arretd", arretd);
                commande.Parameters.AddWithValue("@heure_d", heure_d);
                commande.Parameters.AddWithValue("@arreta", arreta);
                commande.Parameters.AddWithValue("@heure_a", heure_a);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();
            }




            return retour;
        }

    }
}
