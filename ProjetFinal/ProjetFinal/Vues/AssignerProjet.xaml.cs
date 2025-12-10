using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ProjetFinal.Classe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal.Vues
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AssignerProjet : Page
    {
        public AssignerProjet()
        {
            InitializeComponent();

            SingletonDB.getInstance().getAllProjets();
            var projetsEnCours = SingletonDB.getInstance().ListeProjet
            .Where(p => p.Statut == "En cours")
            .ToList();

            cmbbxProjet.ItemsSource = projetsEnCours;

            var projetsEnCoursNo = SingletonDB.getInstance().ListeProjet
            .Where(p => p.Statut == "En cours")
            .Select(p => p.NoProjet)
            .ToList();

            SingletonDB.getInstance().getAllEmployeProjet();
            var matriculesAssignés = SingletonDB.getInstance().ListeProjetEmploye
                .Where(ep => projetsEnCoursNo.Contains(ep.ProjetId))
                .Select(ep => ep.MatriculeId)
                .Distinct()
                .ToList();

            SingletonDB.getInstance().getAllEmploye();
            var employesLibres = SingletonDB.getInstance().ListeEmploye
                .Where(emp => !matriculesAssignés.Contains(emp.Matricule))
                .ToList();

            cmbbxEmploye.ItemsSource = employesLibres;

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (!int.TryParse(tbxNbrHrs.Text, out int nbr))
            {
                valide = false;
                tblErrHrs.Text = "Nombre d'heures non numérique";
            }
            else if (nbr <= 0)
            {
                valide = false;
                tblErrHrs.Text = "Nombre d'heures négatif ou nul";
            }
            else
            {
                tblErrHrs.Text = "";
            }

            if (cmbbxProjet.SelectedIndex < 0)
            {
                valide = false;
                tblErrProjet.Text = "Projet non sélectionné";
            }
            else
            {
                tblErrProjet.Text = "";
            }

            if (cmbbxEmploye.SelectedIndex < 0)
            {
                valide = false;
                tblErrEmploye.Text = "Employé non sélectionné";
            }
            else
            {
                tblErrEmploye.Text = "";
            }

            if (valide)
            {
                Employe employe = cmbbxEmploye.SelectedItem as Employe;
                Projet projet = cmbbxProjet.SelectedItem as Projet;
                SingletonDB.getInstance().associerEmployeAProjet(Convert.ToInt32(tbxNbrHrs.Text),employe.Matricule,projet.NoProjet);
                Frame.Navigate(typeof(AfficheAssign));
            }
        }
    }
}
