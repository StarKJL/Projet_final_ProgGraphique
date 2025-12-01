using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Classe
{
    internal class Client
    {
        int id;
        string nom;
        string adresse;
        string telephone;
        string email;

        Random rand = new Random(); 
<<<<<<< Updated upstream
        public Client(int id, string nom, string adresse, string telephone, string email)
=======
        public Client(int id,string nom, string adresse, string telephone, string email)
>>>>>>> Stashed changes
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.telephone = telephone;
            this.email = email;
           
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public override string ToString()
        {
            return $"ID: {id}, Nom: {nom}, Adresse: {adresse}, Telephone: {telephone}, Email: {email}";
        }
    }
}
