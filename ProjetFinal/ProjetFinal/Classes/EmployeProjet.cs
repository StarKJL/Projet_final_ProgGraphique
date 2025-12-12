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
        string matriculeId;
        int heuresTravaillees;
        double salaire;
        string projetId;
        string prenomEmploye;
        string nomEmploye;
        string titreProjet;

        public EmployeProjet( int id,int heuresTravaillees, double salaire, string matricule, string projetId,string prenomEmploye,string nomEmploye,string titreProjet)
        {
            this.id = id;
            this.matriculeId = matricule;
            this.heuresTravaillees = heuresTravaillees;
            this.salaire = salaire;
            this.projetId = projetId;
            this.prenomEmploye = prenomEmploye;
            this.nomEmploye = nomEmploye;
            this.titreProjet = titreProjet;
        }

        public int Id { get => id; set => id = value; }
        public string MatriculeId { get => matriculeId; set => matriculeId = value; }
        public int HeuresTravaillees { get => heuresTravaillees; set => heuresTravaillees = value; }
        public double Salaire { get => salaire; set => salaire = value; }
        public string ProjetId { get => projetId; set => projetId = value; }
        public string PrenomEmploye { get => prenomEmploye; set => prenomEmploye = value; }
        public string NomEmploye { get => nomEmploye; set => nomEmploye = value; }
        public string TitreProjet { get => titreProjet; set => titreProjet = value; }


        public override string ToString()
        {
            return $"Employe: [{matriculeId}], Heures Travaillees: {heuresTravaillees}, Salaire: {salaire}, Projet ID: {projetId}";
        }
    }
}
