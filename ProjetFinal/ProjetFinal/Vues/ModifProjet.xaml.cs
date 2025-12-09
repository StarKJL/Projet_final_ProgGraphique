using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;
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
    public sealed partial class ModifProjet : Page
    {
        Projet _projetModif;
        public ModifProjet()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if(e.Parameter is Projet projet)
            {
                SingletonDB.getInstance().getAllClients();

                cmbbxClient.ItemsSource = SingletonDB.getInstance().ListeClient;

                _projetModif = projet;
                tbxTitre.Text = _projetModif.Titre;
                tbxDesc.Text = _projetModif.Description;
                tbxBudget.Text = _projetModif.Budget.ToString();
                cmbbxStatut.SelectedItem = _projetModif.Statut;
                Client clientSelectionne = SingletonDB.getInstance().ListeClient
                    .FirstOrDefault(c => c.Id == projet.ClientId);

                if (clientSelectionne != null)
                {
                    cmbbxClient.SelectedItem = clientSelectionne;
                }
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (string.IsNullOrEmpty(tbxTitre.Text))
            {
                valide = false;
                tblErrTitre.Text = "Titre absent";
            }
            else if(tbxTitre.Text.Length > 100)
            {
                valide = false;
                tblErrTitre.Text = "Titre trop long";
            }
            else
            {
                tblErrTitre.Text = "";
            }

            if (string.IsNullOrEmpty(tbxDesc.Text))
            {
                valide = false;
                tblErrDesc.Text = "Description absente";
            }
            else
            {
                tblErrDesc.Text = "";
            }

            if (string.IsNullOrEmpty(tbxBudget.Text))
            {
                valide = false;
                tblErrBudget.Text = "Budget absent";
            }
            else if(!double.TryParse(tbxBudget.Text, out double budget) || budget < 0)
            {
                valide = false;
                tblErrBudget.Text = "Valeur non numérique";
            }
            else
            {
                tblErrBudget.Text = "";
            }

            if (cmbbxClient.SelectedIndex < 0)
            {
                valide = false;
                tblErrClient.Text = "Client non sélectionné";
            }
            else
            {
                tblErrClient.Text = "";
            }

            if (cmbbxStatut.SelectedIndex < 0)
            {
                valide = false;
                tblErrClient.Text = "Statut non sélectionné";
            }
            else
            {
                tblErrClient.Text = "";
            }

            if (valide)
            {
                Client client = cmbbxClient.SelectedItem as Client;

                SingletonDB.getInstance().modifieProjet(_projetModif.NoProjet,tbxTitre.Text, DateTime.Now,tbxDesc.Text,Convert.ToDouble(tbxBudget.Text),client.Id,cmbbxStatut.SelectedValue.ToString());
                Frame.Navigate(typeof(AfficherProjets));
            }
        }
    }
}
