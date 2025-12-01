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
    public sealed partial class AssignerProjet : Page
    {
        public AssignerProjet()
        {
            InitializeComponent();
            cmbbxProjet.ItemsSource = SingletonDB.getInstance().ListeProjet;
            SingletonDB.getInstance().getAllProjets();
            cmbbxEmploye.ItemsSource = SingletonDB.getInstance().ListeEmploye;
            SingletonDB.getInstance().getAllEmploye();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if(!int.TryParse(tbxNbrHrs.Text, out int nbr))
            {
                valide = false;
                tblErrHrs.Text = "Nombre d'heures invalide";
            }else if (nbr <= 0)
            {
                valide = false;
                tblErrHrs.Text = "Nombre d'heures invalide";
            }
            else
            {
                tblErrHrs.Text = "";
            }

            if (!double.TryParse(tbxSal.Text, out double dbl))
            {
                valide = false;
                tblErrSal.Text = "Salaire invalide";
            }
            else if (dbl <= 0)
            {
                valide = false;
                tblErrSal.Text = "Salaire invalide";
            }
            else
            {
                tblErrSal.Text = "";
            }

            if (cmbbxProjet.SelectedIndex < 0)
            {
                valide = false;
                tblErrProjet.Text = "Projet invalide";
            }
            else
            {
                tblErrProjet.Text = "";
            }

            if (cmbbxEmploye.SelectedIndex < 0)
            {
                valide = false;
                tblErrEmploye.Text = "Employé invalide";
            }
            else
            {
                tblErrEmploye.Text = "";
            }

            if (valide)
            {
                Employe employe = cmbbxEmploye.SelectedItem as Employe;
                Projet projet = cmbbxProjet.SelectedItem as Projet;
                SingletonDB.getInstance().associerEmployeAProjet(Convert.ToInt32(tbxNbrHrs.Text),Convert.ToDouble(tbxSal.Text),employe.Matricule,projet.NoProjet);
                Frame.Navigate(typeof(AfficheAssign));
            }
        }
    }
}
