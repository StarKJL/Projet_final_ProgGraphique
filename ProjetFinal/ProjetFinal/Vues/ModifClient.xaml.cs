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
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal.Vues
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifClient : Page
    {
        Client _clientModif;
        public ModifClient()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Client client)
            {
                _clientModif = client;

                tbxNom.Text = _clientModif.Nom;
                tbxMail.Text = _clientModif.Email;
                tbxTel.Text = _clientModif.Telephone;
                tbxAdr.Text = _clientModif.Adresse;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            string regexMail = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
            string regexTel = "^[0-9]{3}-[0-9]{3}-[0-9]{4}$";
            string regexAdr = "^\\d+\\s[A-ZÀÂÄÇÉÈÊËÎÏÔÖÙÛÜŸ][a-zàâäçéèêëîïôöùûüÿA-ZÀÂÄÇÉÈÊËÎÏÔÖÙÛÜŸ'-]+\\s[A-ZÀÂÄÇÉÈÊËÎÏÔÖÙÛÜŸ][a-zàâäçéèêëîïôöùûüÿA-ZÀÂÄÇÉÈÊËÎÏÔÖÙÛÜŸ'-]+$";
            string regexNom = "^[A-ZÀÂÄÇÉÈÊËÎÏÔÖÙÛÜŸ][a-zàâäçéèêëîïôöùûüÿA-ZÀÂÄÇÉÈÊËÎÏÔÖÙÛÜŸ'-]+ [A-ZÀÂÄÇÉÈÊËÎÏÔÖÙÛÜŸ][a-zàâäçéèêëîïôöùûüÿA-ZÀÂÄÇÉÈÊËÎÏÔÖÙÛÜŸ'-]+$";

            if (string.IsNullOrEmpty(tbxNom.Text))
            {
                valide = false;
                tblErrNom.Text = "Nom absent";
            }
            else if (!Regex.IsMatch(tbxNom.Text, regexNom))
            {
                valide = false;
                tblErrNom.Text = "Format invalide (Prénom Nom)";
            }
            else if (tbxNom.Text.Length > 100)
            {
                valide = false;
                tblErrNom.Text = "Nom trop long";
            }
            else
            {
                tblErrNom.Text = "";
            }

            if (string.IsNullOrEmpty(tbxAdr.Text))
            {
                valide = false;
                tblErrAdr.Text = "Adresse invalide";
            }
            else if (!Regex.IsMatch(tbxAdr.Text, regexAdr))
            {
                valide = false;
                tblErrAdr.Text = "Format invalide (123 Rue Exemple)";
            }
            else
            {
                tblErrAdr.Text = "";
            }

            if (string.IsNullOrEmpty(tbxTel.Text))
            {
                valide = false;
                tblErrTel.Text = "Numéro de téléphone absent";
            }
            else if (!Regex.IsMatch(tbxTel.Text, regexTel))
            {
                valide = false;
                tblErrTel.Text = "Format invalide (123-456-7890)";
            }
            else
            {
                tblErrTel.Text = "";
            }

            if (string.IsNullOrEmpty(tbxMail.Text))
            {
                valide = false;
                tblErrMail.Text = "Email absent";
            }
            else if (!Regex.IsMatch(tbxMail.Text, regexMail))
            {
                valide = false;
                tblErrMail.Text = "Format invalide";
            }
            else if (tbxMail.Text.Length > 100)
            {
                valide = false;
                tblErrMail.Text = "Email trop long";
            }
            else
            {
                tblErrMail.Text = "";
            }

            if (valide)
            {
                SingletonDB.getInstance().modifierClient(_clientModif.Id,tbxNom.Text, tbxAdr.Text, tbxTel.Text, tbxMail.Text);
                Frame.Navigate(typeof(AfficherClients));
            }
        }
    }
}
