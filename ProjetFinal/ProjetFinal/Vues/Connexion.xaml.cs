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
        private object _modif;
        public Connexion()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is object[] parameters && parameters.Length >= 1)
            {
                // Le premier élément est le Type de la page de retour
                _pageRetour = parameters[0] as Type;

                // Si un deuxième élément existe (votre Projet), nous le stockons.
                if (parameters.Length >= 2)
                {
                    _modif = parameters[1];
                }
            }
            else if (e.Parameter is Type destinationPageType)
            {
                // Cas de base où seul le Type est passé
                _pageRetour = destinationPageType;
                _modif = null;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (string.IsNullOrEmpty(tbxName.Text))
            {
                valide=false;
                tblErrName.Text = "Nom absent";
            }
            else
            {
                tblErrName.Text = "";
            }

            if (string.IsNullOrEmpty(tbxPass.Password))
            {
                valide = false;
                tblErrPass.Text = "Mot de passe absent";
            }
            else
            {
                tblErrPass.Text = "";
            }

            if (valide)
            {
                SingletonDB.getInstance().getCompte();
                int connect = SingletonDB.getInstance().connexion(tbxName.Text, tbxPass.Password);
                if (connect>0)
                {
                    if(_modif != null)
                    {
                        Frame.Navigate(_pageRetour, _modif);
                    }
                    else
                    {
                        Frame.Navigate(_pageRetour);
                    }
                }
                else if(connect == -3)
                {
                    tblErrName.Text = "Nom invalide";
                    tblErrPass.Text = "Mot de passe invalide";
                }
                else if(connect == -1)
                {
                    tblErrName.Text = "Nom invalide";
                }
                else if(connect == -2)
                {
                    tblErrPass.Text = "Mot de passe invalide";
                }
                
            }
        }
    }
}
