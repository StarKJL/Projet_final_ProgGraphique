using Microsoft.UI.Xaml;
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
        ObservableCollection<Employe> listeEmploye;

        ObservableCollection<EmployeProjet> listeProjetEmploye;



        static SingletonDB instance = null;

        internal ObservableCollection<Client> ListeClient { get => listeClient;}
        internal ObservableCollection<Projet> ListeProjet { get => listeProjet; }
        internal ObservableCollection<EmployeProjet> ListeProjetEmploye { get => listeProjetEmploye;}
        internal ObservableCollection<Employe> ListeEmploye { get => listeEmploye; }


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
                commande.CommandText = "Select * from client";
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
                commande.CommandText = "select noprojet, titre, datedebut, description, budget, totalsalaire, statut, idclient, id, nom, adresse, telephone, email,c.nom as nomClient from projet inner join client c on projet.idClient = c.id";
                con.Open();
                using MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    string noProjet = r.GetString("noProjet");
                    string titre = r.GetString("titre");
                    DateTime dateDebut = r.GetDateTime("dateDebut");
                    string description = r.GetString("description");
                    double budget = r.GetDouble("budget");
                    double totalSalaire = r.GetDouble("totalSalaire");
                    int clientId = r.GetInt32("idClient");
                    string statut = r.GetString("statut");
                    string clientNom = r.GetString("nomClient");


                    Projet projet = new Projet(noProjet,titre,dateDebut,description,budget,totalSalaire,clientId,statut,clientNom);
                    listeProjet.Add(projet);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void getAllEmploye()
        {
            listeEmploye.Clear();
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = con.CreateCommand();
                commande.CommandText = "Select * from employe";
                con.Open();
                using MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    string matricule = r.GetString("matricule");

                    string nom = r.GetString("nom");
                    string prenom = r.GetString("prenom");
                    DateTime dateNaissance = r.GetDateTime("dateNaissance");
                    string email = r.GetString("email");
                    string adresse = r.GetString("adresse");
                    DateTime dateEmbauche = r.GetDateTime("dateEmbauche");
                    double tauxHoraire = r.GetDouble("tauxHoraire");
                    string photoId = r.GetString("photoId");
                    string statut = r.GetString("statut");


                    Employe employe = new Employe(matricule,nom,prenom,dateNaissance,email,adresse,dateEmbauche,tauxHoraire,photoId,statut);
                    listeEmploye.Add(employe);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        public void getAllEmployeInfoParProjet(string nombre)
        {
            using MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand commande = new MySqlCommand("employe_de_projet");

            commande.Connection = con;
            listeEmploye.Clear();
            try
            {
             
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("_no",nombre);
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    string matricule = r.GetString("matricule");
                    string nom = r.GetString("nom");
                    string prenom = r.GetString("prenom");
                    DateTime dateNaissance = r.GetDateTime("dateNaissance");
                    string email = r.GetString("email");
                    string adresse = r.GetString("adresse");
                    DateTime dateEmbauche = r.GetDateTime("dateEmbauche");
                    double tauxHoraire = r.GetDouble("tauxHoraire");
                    string photoId = r.GetString("photoId");
                    string statut = r.GetString("statut");


                    Employe employe = new Employe(matricule,nom, prenom, dateNaissance, email, adresse, dateEmbauche, tauxHoraire, photoId, statut);
                    listeEmploye.Add(employe);
                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

        }

        public void getAllEmployeParProjet(string no_Projet)
        {
            listeProjetEmploye.Clear();
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = con.CreateCommand();
                commande.CommandText = "Select * from employeprojet where noProjet = @noProjet";
                commande.Parameters.AddWithValue("@noProjet", $"{no_Projet}%");

                con.Open();
                using MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    int nbrHrs = r.GetInt32("nbrHrs");
                    double salaire = r.GetDouble("salaire");
                    string matricule = r.GetString("matricule");
                    string noProjet = r.GetString("noProjet");
                   


                    EmployeProjet projetEmployes = new EmployeProjet(nbrHrs,salaire,matricule,no_Projet);
                    listeProjetEmploye.Add(projetEmployes);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //Inserts
        public void creeProjet(string titre,DateTime dateDebut,string description,double budget,double totalSalaire,int idClient,string statut)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into projet values(@titre,@dateDebut,@description,@budget,@totalSalaire,@idClient,@statut)  ";
                commande.Parameters.AddWithValue("@titre", titre);
                commande.Parameters.AddWithValue("@dateDebut", dateDebut);
                commande.Parameters.AddWithValue("@description", description);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@totalSalaire", totalSalaire);
                commande.Parameters.AddWithValue("@idClient", idClient);
                commande.Parameters.AddWithValue("@statut", statut);


                con.Open();
                int i = commande.ExecuteNonQuery();
                using MySqlCommand commande2 = new MySqlCommand();
                commande2.Connection = con;
                commande2.CommandText = "select LAST_INSERT_ID() ";
                var res = commande2.ExecuteScalar();
                getAllProjets(); 
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void associerEmployeAProjet(int nbHrs,double salaire,string matricule,string noProjet)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into employeprojet values(@nbHrs,@salaire,@matricule,@noProjet) ";
                commande.Parameters.AddWithValue("@nbHrs", nbHrs);
                commande.Parameters.AddWithValue("@salaire", salaire);
                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@noProjet", noProjet);



                con.Open();
                int i = commande.ExecuteNonQuery();
                using MySqlCommand commande2 = new MySqlCommand();
                commande2.Connection = con;
                commande2.CommandText = "select LAST_INSERT_ID() ";
                var res = commande2.ExecuteScalar();
                getAllProjets();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        public void creeClient(string nom,string adresse, string telephone, string email)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into client values(@nom,@adresse,@telephone,@email) ";
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@adresse", adresse);
                commande.Parameters.AddWithValue("@telephone", telephone);
                commande.Parameters.AddWithValue("@email", email);



                con.Open();
                int i = commande.ExecuteNonQuery();
                using MySqlCommand commande2 = new MySqlCommand();
                commande2.Connection = con;
                commande2.CommandText = "select LAST_INSERT_ID() ";
                var res = commande2.ExecuteScalar();
                getAllProjets();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        public void creeEmploye(string nom,string prenom,DateTime dateNaissance,string email,string adresse,DateTime dateEmbauche,double tauxHoraire,string photoId,string statut)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into employe values(@nom,@prenom,@dateNaissance,@email,@adresse,@dateEmbauche,@tauxHoraire,@photoId,@statut) ";
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);
                commande.Parameters.AddWithValue("@dateNaissance", dateNaissance);
                commande.Parameters.AddWithValue("@email", email);
                commande.Parameters.AddWithValue("@adresse", adresse);
                commande.Parameters.AddWithValue("@dateEmbauche", dateEmbauche);
                commande.Parameters.AddWithValue("@tauxHoraire", tauxHoraire);
                commande.Parameters.AddWithValue("@photoId", photoId);
                commande.Parameters.AddWithValue("@statut", statut);




                con.Open();
                int i = commande.ExecuteNonQuery();
                using MySqlCommand commande2 = new MySqlCommand();
                commande2.Connection = con;
                commande2.CommandText = "select LAST_INSERT_ID() ";
                var res = commande2.ExecuteScalar();
                getAllProjets();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        //Supression
        public void supprimerClient(int id)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "delete from client where id = @id";
                commande.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = commande.ExecuteNonQuery();

                getAllClients(); 
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void supprimerEmploye(string matricule)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "delete from employe where matricule = @matricule";
                commande.Parameters.AddWithValue("@matricule", matricule);
                con.Open();
                int i = commande.ExecuteNonQuery();

                getAllEmploye(); 
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void supprimerProjet(string noProjet)
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "delete from projet where noProjet = @noProjet";
                commande.Parameters.AddWithValue("@noProjet", noProjet);
                con.Open();
                int i = commande.ExecuteNonQuery();

                getAllProjets();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            try
            {
                using MySqlConnection con = new MySqlConnection(connectionString);
                using MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "delete from employeprojet where noProjet = @noProjet";
                commande.Parameters.AddWithValue("@noProjet", noProjet);
                con.Open();
                int i = commande.ExecuteNonQuery();

               getAllEmployeParProjet(noProjet);
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public List<Projet> exporter()
        {
            //var picker = new Windows.Storage.Pickers.FileSavePicker();
            //var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            //WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            //picker.SuggestedFileName = "test";
            //picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });
            ////crée le fichier
            //Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();
            return listeProjet.ToList<Projet>();
            

        // La fonction ToString() de la classe Client retourne: nom;prenom;email
        //if (monFichier != null)
        //        await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.ToString()), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }






    }
}
