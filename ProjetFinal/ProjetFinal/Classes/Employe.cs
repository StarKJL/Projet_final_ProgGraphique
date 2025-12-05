using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ProjetFinal.Classe
{
    internal class Employe
    {
        string matricule;
        string nom;
        string prenom;
        DateTime dateNaissanceDATE;
        string dateNaissance;
        string email;
        string adresse;
        DateTime dateEmbaucheDATE;
        string dateEmbauche;
        double tauxHoraire;
        string photoIdentite;
        string statut;


        public Employe(string matricule,string nom, string prenom, DateTime dateNaissance, string email, string adresse, DateTime dateEmbauche, double tauxHoraire, string photoIdentite, string statut)
        {

            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance.ToString("d");
            
            this.email = email;
            this.adresse = adresse;
            this.dateEmbauche = dateEmbauche.ToString("d");
            this.tauxHoraire = tauxHoraire;
            this.photoIdentite = photoIdentite;
            this.statut = statut;
        }

        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Email { get => email; set => email = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string DateEmbauche { get => dateEmbauche; set => dateEmbauche = value; }
        public double TauxHoraire { get => tauxHoraire; set => tauxHoraire = value; }
        public string PhotoIdentite { get => photoIdentite; set => photoIdentite = value; }
        public string Statut { get => statut; set => statut = value; }
        public DateTime DateNaissanceDATE { get => dateNaissanceDATE; set => dateNaissanceDATE = value; }
        public DateTime DateEmbaucheDATE { get => dateEmbaucheDATE; set => dateEmbaucheDATE = value; }

        public override string ToString()
        {
            return $"Matricule: {matricule}, Nom: {nom}, Prenom: {prenom}, Date de Naissance: {dateNaissance}, Email: {email}, Adresse: {adresse}, Date d'Embauche: {dateEmbauche}, Taux Horaire: {tauxHoraire}, Statut: {statut}";
        }
    }
}
