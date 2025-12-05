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
    public sealed partial class AjouterClient : Page
    {
        public AjouterClient()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            string regexMail = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
            string regexTel = "^[0-9]{3}-[0-9]{3}-[0-9]{4}$";

            if (string.IsNullOrEmpty(tbxNom.Text))
            {
                valide= false;
                tblErrNom.Text= "Nom invalide";
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
            else
            {
                tblErrAdr.Text = "";
            }

            if (string.IsNullOrEmpty(tbxTel.Text) || !Regex.IsMatch(tbxTel.Text,regexTel))
            {
                valide = false;
                tblErrTel.Text = "Numéro de téléphone invalide (123-456-7890)";
            }
            else
            {
                tblErrTel.Text = "";
            }

            if (string.IsNullOrEmpty(tbxMail.Text) || !Regex.IsMatch(tbxMail.Text, regexMail))
            {
                valide = false;
                tblErrMail.Text = "Email invalide";
            }
            else
            {
                tblErrMail.Text = "";
            }

            if (valide)
            {
                SingletonDB.getInstance().creeClient(tbxNom.Text, tbxAdr.Text, tbxTel.Text, tbxMail.Text);
                Frame.Navigate(typeof(AfficherClients));
            }
        }
    }
}
