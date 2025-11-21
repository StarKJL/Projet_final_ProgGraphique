using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Classe
{
    internal class Employe
    {
        string matricule;
        string nom;
        string prenom;
        DateTime dateNaissance;
        string email;
        string adresse;
        DateTime dateEmbauche;
        double tauxHoraire;
        string photoIdentite;
        string statut;

        Random rand = new Random(); //Juste pour generer un nombre aleatoire

        public Employe(string nom, string prenom, DateTime dateNaissance, string email, string adresse, DateTime dateEmbauche, double tauxHoraire, string photoIdentite, string statut)
        {

            
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
            this.matricule = nom.Substring(0,2)+"-"+dateNaissance.Year+"-"+rand.Next(10,99);
            this.email = email;
            this.adresse = adresse;
            this.dateEmbauche = dateEmbauche;
            this.tauxHoraire = tauxHoraire;
            this.photoIdentite = photoIdentite;
            this.statut = statut;
        }

        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Email { get => email; set => email = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public DateTime DateEmbauche { get => dateEmbauche; set => dateEmbauche = value; }
        public double TauxHoraire { get => tauxHoraire; set => tauxHoraire = value; }
        public string PhotoIdentite { get => photoIdentite; set => photoIdentite = value; }
        public string Statut { get => statut; set => statut = value; }

        public override string ToString()
        {
            return $"Matricule: {matricule}, Nom: {nom}, Prenom: {prenom}, Date de Naissance: {dateNaissance.ToShortDateString()}, Email: {email}, Adresse: {adresse}, Date d'Embauche: {dateEmbauche.ToShortDateString()}, Taux Horaire: {tauxHoraire}, Statut: {statut}";
        }
    }
}
