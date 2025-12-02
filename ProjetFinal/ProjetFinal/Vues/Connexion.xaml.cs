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
    public sealed partial class Connexion : Page
    {
        private Type _pageRetour;
        public Connexion()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Type destinationPageType)
            {
                _pageRetour = destinationPageType;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (string.IsNullOrEmpty(tbxName.Text))
            {
                valide=false;
                tblErrName.Text = "Nom invalide";
            }
            else
            {
                tblErrName.Text = "";
            }

            if (string.IsNullOrEmpty(tbxPass.Text))
            {
                valide = false;
                tblErrPass.Text = "Mot de passe invalide";
            }
            else
            {
                tblErrPass.Text = "";
            }

            if (valide)
            {
                SingletonDB.getInstance().getCompte();
                bool connect = SingletonDB.getInstance().connexion(tbxName.Text, tbxPass.Text);
                if (connect)
                {
                    Frame.Navigate(_pageRetour);
                }
                else
                {
                    tblErrName.Text = "Nom ou mot de passe inexistant";
                    tblErrPass.Text = "Nom ou mot de passe inexistant";
                }
                
            }
        }
    }
}
