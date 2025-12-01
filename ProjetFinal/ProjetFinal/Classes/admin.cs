using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Classes
{
    internal class admin
    {
        int id;
        string username;
        string password;
        bool actif;

        public admin(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.actif = false;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool Actif { get => actif; set => actif = value; }
    }
}
