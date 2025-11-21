using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Classe
{
    internal class EmployeProjet
    {

       int id;
        Employe employe;
       int heuresTravaillees;
        double salaire;
        int projetId;

        public EmployeProjet(int id, Employe employe, int heuresTravaillees, double salaire, int projetId)
        {
            this.id = id;
            this.employe = employe;
            this.heuresTravaillees = heuresTravaillees;
            this.salaire = employe.TauxHoraire*heuresTravaillees;
            this.projetId = projetId;
        }

        public int Id { get => id; set => id = value; }
        public int HeuresTravaillees { get => heuresTravaillees; set => heuresTravaillees = value; }
        public double Salaire { get => salaire; set => salaire = value; }
        public int ProjetId { get => projetId; set => projetId = value; }
        internal Employe Employe { get => employe; set => employe = value; }
        public override string ToString()
        {
            return $"ID: {id}, Employe: [{employe}], Heures Travaillees: {heuresTravaillees}, Salaire: {salaire}, Projet ID: {projetId}";
        }
    }
}
