using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetFinal.Classe
{
    internal class Projet
    {
        string noProjet;
        string titre;
        DateTime dateDebutDATE;
        string dateDebut;

        string description;
        double budget;
        double totalSalaire;
        int clientId;
        string statut;
        string nomClient;

        Random rand = new Random();

    
        public Projet(string noProjet,string titre, DateTime dateDebutDATE, string description, double budget, double totalSalaire, int clientId, string statut,string nomClient)
        {
            this.noProjet = noProjet;
            this.titre = titre;
            dateDebut = dateDebutDATE.ToString("d");
            this.description = description;
            this.budget = budget;
            this.totalSalaire = totalSalaire;
            this.clientId = clientId;
            this.statut = statut;
            this.nomClient = nomClient;
        }

        public string NoProjet { get => noProjet; set => noProjet = value; }
        public string Titre { get => titre; set => titre = value; }
        public string DateDebut { get => dateDebut;}

        public string Description { get => description; set => description = value; }
        public double Budget { get => budget; set => budget = value; }
        public double TotalSalaire { get => totalSalaire; set => totalSalaire = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public string Statut { get => statut; set => statut = value; }
        public string NomClient { get => nomClient; set => nomClient = value; }
        public DateTime DateDebutDATE { get => dateDebutDATE; set => dateDebutDATE = value; }

        public override string ToString()
        {
            return $"No Projet: {noProjet}, Titre: {titre}, Date de Debut: {dateDebut}, Description: {description}, Budget: {budget}, Total Salaire: {totalSalaire}, Client ID: {clientId}, Statut: {statut}";
        }
    }
}
