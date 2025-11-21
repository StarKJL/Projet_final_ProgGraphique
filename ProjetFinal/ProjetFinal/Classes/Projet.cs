using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Classe
{
    internal class Projet
    {
        string noProjet;
        string titre;
        DateTime dateDebut;
        string description;
        double budget;
        double totalSalaire;
        int clientId;
        string statut;

        Random rand = new Random();

        public Projet(string titre, DateTime dateDebut, string description, double budget, double totalSalaire, int clientId, string statut)
        {
            this.noProjet = clientId+"-"+rand.Next(01, 99)+"-"+dateDebut.Year;
            this.titre = titre;
            this.dateDebut = dateDebut;
            this.description = description;
            this.budget = budget;
            this.totalSalaire = totalSalaire;
            this.clientId = clientId;
            this.statut = statut;
        }

        public string NoProjet { get => noProjet; set => noProjet = value; }
        public string Titre { get => titre; set => titre = value; }
        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public string Description { get => description; set => description = value; }
        public double Budget { get => budget; set => budget = value; }
        public double TotalSalaire { get => totalSalaire; set => totalSalaire = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public string Statut { get => statut; set => statut = value; }

        public override string ToString()
        {
            return $"No Projet: {noProjet}, Titre: {titre}, Date de Debut: {dateDebut.ToShortDateString()}, Description: {description}, Budget: {budget}, Total Salaire: {totalSalaire}, Client ID: {clientId}, Statut: {statut}";
        }
    }
}
