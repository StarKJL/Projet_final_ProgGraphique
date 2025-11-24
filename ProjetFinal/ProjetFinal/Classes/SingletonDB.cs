using Microsoft.WindowsAppSDK.Runtime.Packages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Classe
{
    internal class SingletonDB
    {
        string connectionString;
        ObservableCollection<Client> listeClient;
        ObservableCollection<Projet> listeProjet;
        ObservableCollection<EmployeProjet> listeProjetEmploye;



        static SingletonDB instance = null;

        internal ObservableCollection<Client> ListeClient { get => listeClient;}
        internal ObservableCollection<Projet> ListeProjet { get => listeProjet; }
        internal ObservableCollection<EmployeProjet> ListeProjetEmploye { get => listeProjetEmploye;}

        private SingletonDB()
        {
            connectionString = "Server=cours.cegep3r.info;Database=a2025_420335-345ri_greq5;Uid=2486924;Pwd=2486924;";
            listeClient = new ObservableCollection<Client>();
            listeProjet = new ObservableCollection<Projet>();
            listeProjetEmploye = new ObservableCollection<EmployeProjet>();

        }

        public static SingletonDB getInstance()
        {
            if (instance == null)
                instance = new SingletonDB();
            return instance;
        }
        public void getAllClients() //charge la liste avec tous les clients
        {
            listeClient.Clear(); //permet de vider la liste avant de la recharger
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = con.CreateCommand();
                commande.CommandText = "Select * from clients";
                con.Open();
                using MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    string nom = r.GetString("nom");
                    string adresse = r.GetString("adresse");
                    string telephone = r.GetString("telephone");
                    string email = r.GetString("email");


                    Client client = new Client(nom,adresse,telephone,email);
                    listeClient.Add(client);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void getAllProjets() 
        {
            listeProjet.Clear();
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = con.CreateCommand();
                commande.CommandText = "Select * from projets";
                con.Open();
                using MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    string titre = r.GetString("titre");
                    DateTime dateDebut = r.GetDateTime("dateDebut");
                    string description = r.GetString("description");
                    double budget = r.GetDouble("budget");
                    double totalSalaire = r.GetDouble("totalSalaire");
                    int clientId = r.GetInt32("clientId");
                    string statut = r.GetString("statut");


                    Projet projet = new Projet(titre,dateDebut,description,budget,totalSalaire,clientId,statut);
                    listeProjet.Add(projet);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


    }
}
