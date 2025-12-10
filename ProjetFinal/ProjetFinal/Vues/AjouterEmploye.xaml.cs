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
            dtpkrHire.MinYear = DateTimeOffset.Now.AddYears(-75);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            string regexMail = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
            string regexAdr = "\\d+\\s+[A-Za-zÀ-ÖØ-öø-ÿ'-]+(?:\\s+[A-Za-zÀ-ÖØ-öø-ÿ'-]+)*$";


            if (string.IsNullOrEmpty(tbxPre.Text))
            {
                valide = false;
                tblErrPre.Text = "Prénom absent";
            }
            else if (tbxPre.Text.Length > 50)
            {
                valide = false;
                tblErrPre.Text = "Prénom trop long";
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
            else if (tbxNom.Text.Length > 50)
            {
                valide = false;
                tblErrNom.Text = "Nom trop long";
            }
            else
            {
                tblErrNom.Text = "";
            }

            if (string.IsNullOrEmpty(tbxMail.Text))
            {
                valide = false;
                tblErrMail.Text = "Email absent";
            }
            else if (!Regex.IsMatch(tbxMail.Text, regexMail))
            {
                valide = false;
                tblErrMail.Text = "Format invalide (exemple@mail.com)";
            }
            else
            {
                tblErrMail.Text = "";
            }

            if (string.IsNullOrEmpty(tbxAdr.Text))
            {
                valide = false;
                tblErrAdr.Text = "Adresse absente";
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

            if (dtpkrBirth.SelectedDate == null)
            {
                valide = false;
                tblErrBirth.Text = "Date de naissance non sélectionnée";
            }
            else
            {
                tblErrBirth.Text = "";
            }

            if (dtpkrHire.SelectedDate == null)
            {
                valide = false;
                tblErrHire.Text = "Date d'embauche non sélectionnée";
            }
            else
            {
                tblErrHire.Text = "";
            }

            if (string.IsNullOrEmpty(tbxTaux.Text))
            {
                valide = false;
                tblErrTaux.Text = "Taux horaire absent";
            }
            else if (!Double.TryParse(tbxTaux.Text, out double nbr))
            {
                valide = false;
                tblErrTaux.Text = "Taux horaire non numérique";
            }
            else if (Convert.ToDouble(tbxTaux.Text) < 16)
            {
                valide = false;
                tblErrTaux.Text = "Taux horaire trop bas";
            }
            else if (Convert.ToDouble(tbxTaux.Text) > 50)
            {
                valide = false;
                tblErrTaux.Text = "Taux horaire trop élevé";
            }
            else
            {
                tblErrTaux.Text = "";
            }

            if (string.IsNullOrEmpty(tbxPhoto.Text))
            {
                valide = false;
                tblErrPhoto.Text = "Url de photo absent";
            }
            else if (!Uri.IsWellFormedUriString(tbxPhoto.Text, UriKind.Absolute))
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
                tblErrStatut.Text = "Statut non sélectionné";
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
