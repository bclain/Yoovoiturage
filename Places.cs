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
            string arreta;
            string heure_a;
            int nbPlaces;
            string statut;
            string prix;

        public Places(int id, string date, string typeVoiture, string nom_chauffeur, string heure_d, string arretd, string typePlace, string arreta, string heure_a, int nbPlaces, string statut)
        {
            this.Id = id;
            this.Date = date;
            this.TypeVoiture = typeVoiture;
            this.Nom_chauffeur = nom_chauffeur;
            this.Heure_d = heure_d;
            this.Arretd = arretd;
            this.TypePlace = typePlace;
            this.Arreta = arreta;
            this.Heure_a = heure_a;
            this.NbPlaces = nbPlaces;
            this.Statut = statut;
            if (this.typeVoiture == "VUS")
            {
                this.prix = "15$";
            }
            else if (this.typeVoiture == "Berline") { 
                this.prix = "10$";
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

