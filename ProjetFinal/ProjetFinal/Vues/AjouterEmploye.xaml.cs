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
using System.Security.Policy;
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
    public sealed partial class AjouterEmploye : Page
    {
        public AjouterEmploye()
        {
            InitializeComponent();
            dtpkrBirth.MaxYear=DateTimeOffset.Now.AddYears(-18);
            dtpkrHire.MaxYear = DateTimeOffset.Now;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            string regexMail = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(tbxPre.Text))
            {
                valide= false;
                tblErrPre.Text = "Prénom invalide";
            }
            else
            {
                tblErrPre.Text = "";
            }

            if (string.IsNullOrEmpty(tbxNom.Text))
            {
                valide = false;
                tblErrNom.Text = "Nom invalide";
            }
            else
            {
                tblErrNom.Text = "";
            }

            if(string.IsNullOrEmpty(tbxMail.Text) || !Regex.IsMatch(tbxMail.Text, regexMail))
            {
                valide = false;
                tblErrMail.Text = "Email invalide";
            }
            else
            {
                tblErrMail.Text = "";
            }

            if (string.IsNullOrEmpty(tbxAdr.Text))
            {
                valide = false;
                tblErrAdr.Text = "Adresse invalide";
            }
            else
            {
                tblErrAdr.Text = "";
            }

            if(dtpkrBirth.SelectedDate == null)
            {
                valide = false;
                tblErrBirth.Text = "Date de naissance invalide";
            }
            else
            {
                tblErrBirth.Text = "";
            }

            if (dtpkrHire.SelectedDate == null)
            {
                valide = false;
                tblErrHire.Text = "Date d'embauche invalide";
            }
            else
            {
                tblErrHire.Text = "";
            }

            if(string.IsNullOrEmpty(tbxTaux.Text) || !Double.TryParse(tbxTaux.Text, out double nbr))
            {
                valide = false;
                tblErrTaux.Text = "Taux horaire invalide (Format: 12.34)";
            }
            else
            {
                tblErrTaux.Text = "";
            }

            if(string.IsNullOrEmpty(tbxPhoto.Text) || !Uri.IsWellFormedUriString(tbxPhoto.Text, UriKind.Absolute))
            {
                valide = false;
                tblErrPhoto.Text = "Url de photo invalide";
            }
            else
            {
                tblErrPhoto.Text = "";
            }

            if (cmbbxStatut.SelectedIndex == -1)
            {
                valide = false;
                tblErrStatut.Text = "Statut invalide";
            }
            else
            {
                tblErrStatut.Text = "";
            }

            if (valide)
            {
                DateTime naissance = new DateTime(dtpkrBirth.Date.Year, dtpkrBirth.Date.Month, dtpkrBirth.Date.Day);
                DateTime embauche = new DateTime(dtpkrHire.Date.Year, dtpkrHire.Date.Month, dtpkrHire.Date.Day);
                SingletonDB.getInstance().creeEmploye(tbxNom.Text, tbxPre.Text, naissance, tbxMail.Text, tbxAdr.Text, embauche, Convert.ToDouble(tbxTaux.Text), tbxPhoto.Text, cmbbxStatut.SelectedValue.ToString());
                Frame.Navigate(typeof(AfficherEmployes));
            }
        }
    }
}
