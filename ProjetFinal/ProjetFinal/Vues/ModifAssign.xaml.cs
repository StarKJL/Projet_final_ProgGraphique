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
    public sealed partial class ModifAssign : Page
    {
        EmployeProjet _ep;
        public ModifAssign()
        {
            InitializeComponent();
            cmbbxProjet.ItemsSource = SingletonDB.getInstance().ListeProjet;
            SingletonDB.getInstance().getAllProjets();
            cmbbxEmploye.ItemsSource = SingletonDB.getInstance().ListeEmploye;
            SingletonDB.getInstance().getAllEmploye();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if(e.Parameter is EmployeProjet ep)
            {
                _ep = ep;

                tbxNbrHrs.Text = _ep.HeuresTravaillees.ToString();
                cmbbxProjet.SelectedValue = _ep.TitreProjet;
                cmbbxEmploye.SelectedValue = _ep.NomEmploye;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if(!int.TryParse(tbxNbrHrs.Text, out int nbr))
            {
                valide = false;
                tblErrHrs.Text = "Nombre d'heures non numérique";
            }else if (nbr <= 0)
            {
                valide = false;
                tblErrHrs.Text = "Nombre d'heures négatif";
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
                SingletonDB.getInstance().ModifierassociationEmployeAProjet(_ep.Id,Convert.ToInt32(tbxNbrHrs.Text),employe.Matricule,projet.NoProjet);
                Frame.Navigate(typeof(AfficheAssign));
            }
        }
    }
}
