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
    public sealed partial class AjouterProjet : Page
    {
        public AjouterProjet()
        {
            InitializeComponent();
            cmbbxClient.ItemsSource = SingletonDB.getInstance().ListeClient;
            SingletonDB.getInstance().getAllClients();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (string.IsNullOrEmpty(tbxTitre.Text))
            {
                valide = false;
                tblErrTitre.Text = "Titre invalide";
            }
            else
            {
                tblErrTitre.Text = "";
            }

            if (string.IsNullOrEmpty(tbxDesc.Text))
            {
                valide = false;
                tblErrDesc.Text = "Description invalide";
            }
            else
            {
                tblErrDesc.Text = "";
            }

            if (string.IsNullOrEmpty(tbxBudget.Text))
            {
                valide = false;
                tblErrBudget.Text = "Budget invalide";
            }
            else
            {
                tblErrTitre.Text = "";
            }

            if (string.IsNullOrEmpty(tbxSal.Text) || !double.TryParse(tbxSal.Text, out double res))
            {
                valide = false;
                tblErrSal.Text = "Salaire total invalide";
            }
            else
            {
                tblErrSal.Text = "";
            }

            if (cmbbxClient.SelectedIndex < 0)
            {
                valide = false;
                tblErrClient.Text = "Client invalide";
            }
            else
            {
                tblErrClient.Text = "";
            }

            if (valide)
            {
                Client client = cmbbxClient.SelectedItem as Client;

                SingletonDB.getInstance().creeProjet(tbxTitre.Text, DateTime.Now,tbxDesc.Text,Convert.ToDouble(tbxBudget.Text), Convert.ToDouble(tbxSal.Text),client.Id,"En cours");
                Frame.Navigate(typeof(AfficherProjets));
            }
        }
    }
}
