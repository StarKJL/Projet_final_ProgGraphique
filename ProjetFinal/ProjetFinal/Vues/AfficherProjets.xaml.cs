using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ProjetFinal.Classe;
using ProjetFinal.Vues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AfficherProjets : Page
    {
        public AfficherProjets()
        {
            InitializeComponent();
            gvProjets.ItemsSource = SingletonDB.getInstance().ListeProjet;
            SingletonDB.getInstance().updateTotalSalaire();
            SingletonDB.getInstance().getAllProjets();
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            Button btn  = sender as Button;

            Projet projetModif = btn.DataContext as Projet;
            if (SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(ModifProjet), projetModif);
            }
            else
            {
                object[] parametresRetour = new object[] { typeof(ModifProjet), projetModif };
                Frame.Navigate(typeof(Connexion), parametresRetour);
            }
            
        }

        private async void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (!SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(Connexion), typeof(AfficherProjets));
                return;
            }
            ContentDialog dialog = new ContentDialog
            {
                XamlRoot = this.XamlRoot,
                Title = "Suppression de projet",
                Content = "Êtes-vous sûr de vouloir supprimer ce projet?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler",
                DefaultButton = ContentDialogButton.Close
            };

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Button btn = sender as Button;
                Projet projet = btn.DataContext as Projet;
                if (projet != null)
                {
                    SingletonDB.getInstance().supprimerProjet(projet.NoProjet);
                }

            }
        }

        private void gvProjets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(DetailsProjet), gvProjets.SelectedItem as Projet);
        }
    }
}
