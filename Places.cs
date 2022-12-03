using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace ProjetFinal
    {
        class Places
        {
            int id;
            string date;
            string typeVoiture;
            string nom_chauffeur;
            string heure_d;
            string arretd;
            string typePlace;
            string arreto;
            string heure_o;
            string arreta;
            string heure_a;
            int nbPlaces;
            int nbPlacesr;
            int nbPlacesm;
            string statut;
            string prix;

        public Places(int id, string date, string typeVoiture, string nom_chauffeur, string heure_d, string arretd, string typePlace, string heure_o, string arreto, string heure_a, string arreta, int nbPlacesr,  int nbPlaces, string statut)
        {
            this.Id = id;
            this.Date = date;
            this.TypeVoiture = typeVoiture;
            this.Nom_chauffeur = nom_chauffeur;
            this.Heure_d = heure_d;
            this.Arretd = arretd;
            this.typePlace = "img/" + typePlace + ".png";
            this.arreto = arreto;
            this.heure_o = heure_o;
            this.Arreta = arreta;
            this.Heure_a = heure_a;
            this.NbPlacesr = nbPlacesr;
            this.NbPlaces = nbPlaces;
            this.NbPlacesm = nbPlaces + nbPlacesr;
            this.Statut = statut;
            if (this.typeVoiture == "VUS")
            {
                this.prix = "15$";
            }
            else if (this.typeVoiture == "Berline") { 
                this.prix = "10$";
            }



            if (typePlace == "debut")
            {
                this.arreto = " ";
                this.heure_o = " ";
                this.Arreta = arreto;
                this.Heure_a = heure_o;
            }
            else if (typePlace == "fin")
            {
                this.arreto = " ";
                this.heure_o = " ";
                this.Heure_d = heure_o;
                this.Arretd = arreto;
            }

            if (arreto == " ")
            {
                this.typePlace = "img/debut.png";
            }
        }

            public int Id { get => id; set => id = value; }
            public string Date { get => date; set => date = value; }
            public string TypeVoiture { get => typeVoiture; set => typeVoiture = value; }
            public string Nom_chauffeur { get => nom_chauffeur; set => nom_chauffeur = value; }
            public string Heure_d { get => heure_d; set => heure_d = value; }
            public string Arretd { get => arretd; set => arretd = value; }
            public string TypePlace { get => typePlace; set => typePlace = value; }
            public string Arreta { get => arreta; set => arreta = value; }
            public string Heure_a { get => heure_a; set => heure_a = value; }
            public int NbPlaces { get => nbPlaces; set => nbPlaces = value; }
            public string Statut { get => statut; set => statut = value; }
            public string Prix { get => prix; set => prix = value; }
            public string Arreto { get => arreto; set => arreto = value; }
            public string Heure_o { get => heure_o; set => heure_o = value; }
        public int NbPlacesr { get => nbPlacesr; set => nbPlacesr = value; }
        public int NbPlacesm { get => nbPlacesm; set => nbPlacesm = value; }

        public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }
    }

