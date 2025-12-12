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
    public sealed partial class DetailsProjet : Page
    {
        public DetailsProjet()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Projet projet)
            {
                tblTitre.Text = projet.Titre;
                tblDesc.Text = projet.Description;
                tblStatut.Text = projet.Statut;
                tblClient.Text = $"{projet.NoProjet} | {projet.NomClient}";
                tblDate.Text= $"Date de départ: {projet.DateDebut}";
                tblBudget.Text = $"Budget: {projet.Budget.ToString("C")}";
                tblSal.Text = $"Salaire total: {projet.TotalSalaire.ToString("C")}";

                SingletonDB.getInstance().getAllEmployeProjet();
                lvEmployes.ItemsSource = SingletonDB.getInstance().ListeProjetEmploye
                    .Where(emp => emp.ProjetId == projet.NoProjet)
                    .ToList();

            }
        }

        private void lvEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EmployeProjet ep = lvEmployes.SelectedItem as EmployeProjet;
            if (SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(ModifAssign), ep);
            }
            else
            {
                object[] parametresRetour = new object[] { typeof(ModifAssign), ep };
                Frame.Navigate(typeof(Connexion), parametresRetour);
            }
        }
    }
}
