using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.Classe
{
    internal class EmployeProjet
    {

        string matriculeId;
       int heuresTravaillees;
        double salaire;
        string projetId;

        public EmployeProjet( int heuresTravaillees, double salaire, string matricule, string projetId)
        {
            this.matriculeId = matricule;
            this.heuresTravaillees = heuresTravaillees;
            this.salaire = salaire;
            this.projetId = projetId;
        }

        public string MatriculeId { get => matriculeId; set => matriculeId = value; }
        public int HeuresTravaillees { get => heuresTravaillees; set => heuresTravaillees = value; }
        public double Salaire { get => salaire; set => salaire = value; }
        public string ProjetId { get => projetId; set => projetId = value; }

        public override string ToString()
        {
            return $"Employe: [{matriculeId}], Heures Travaillees: {heuresTravaillees}, Salaire: {salaire}, Projet ID: {projetId}";
        }
    }
}
