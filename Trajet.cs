using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Trajet
    {
        int id;
        string date;
        string id_chauffeur;
        int prix;
        string typeVoiture;
        int nb_places;
        string arretd;
        string heure_d;
        string arreto;
        string heure_o;
        string arreta;
        string heure_a;
        string typeTrajet;
        string tpers;
        string dpers;
        string fpers;
        string logo;

        public Trajet(int id, string date, int nb_places, string id_chauffeur, int prix, string typeVoiture, string heure_d, string arretd, string arreto, string heure_o, string arreta, string heure_a)
        {
            this.id = id;
            this.date = date;
            this.nb_places = nb_places;
            this.id_chauffeur = id_chauffeur;
            this.prix = GestionBD.getInstance().GetTotal(id);
            this.typeVoiture = typeVoiture;
            this.heure_d = heure_d;
            this.arretd = arretd;
            this.arreto = arreto;
            this.heure_o = heure_o;
            this.arreta = arreta;
            this.heure_a = heure_a;

            if (arreto == " ")
            {
                this.typeTrajet = "Collapsed";
                this.logo = "img/direct.png";
                this.tpers = GestionBD.getInstance().GetPers(id, "tout");
                this.dpers = "";
                this.fpers = "";
            }
            else
            {

                this.logo = "img/tout.png";
                this.typeTrajet = "Visible";
                this.tpers = GestionBD.getInstance().GetPers(id, "tout");
                this.dpers = GestionBD.getInstance().GetPers(id, "debut");
                this.fpers = GestionBD.getInstance().GetPers(id, "fin");
            }
        }



        public int Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string Id_chauffeur { get => id_chauffeur; set => id_chauffeur = value; }
        public int Prix { get => prix; set => prix = value; }
        public string TypeVoiture { get => typeVoiture; set => typeVoiture = value; }
        public string Arretd { get => arretd; set => arretd = value; }
        public string Arreto { get => arreto; set => arreto = value; }
        public string Heure_o { get => heure_o; set => heure_o = value; }
        public string Arreta { get => arreta; set => arreta = value; }
        public string Heure_a { get => heure_a; set => heure_a = value; }
        public string TypeTrajet { get => typeTrajet; set => typeTrajet = value; }
        public string Tpers { get => tpers; set => tpers = value; }
        public string Dpers { get => dpers; set => dpers = value; }
        public string Fpers { get => fpers; set => fpers = value; }
        public string Heure_d { get => heure_d; set => heure_d = value; }
        public int Nb_places { get => nb_places; set => nb_places = value; }
        public string Logo { get => logo; set => logo = value; }
    }
}
