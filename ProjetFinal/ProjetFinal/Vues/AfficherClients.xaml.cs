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
    public sealed partial class AfficherClients : Page
    {
        public AfficherClients()
        {
            InitializeComponent();
            gvClients.ItemsSource = SingletonDB.getInstance().ListeClient;
            SingletonDB.getInstance().getAllClients();
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            Client clientModif = btn.DataContext as Client;
            if (SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(ModifClient), clientModif);
            }
            else
            {
                object[] parametresRetour = new object[] { typeof(ModifClient), clientModif };
                Frame.Navigate(typeof(Connexion), parametresRetour);
            }
        }

        private async void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (!SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(Connexion), typeof(AfficherClients));
                return;
            }
            ContentDialog dialog = new ContentDialog
            {
                XamlRoot = this.XamlRoot,
                Title = "Suppression de client",
                Content = "Êtes-vous sûr de vouloir supprimer ce client?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler",
                DefaultButton = ContentDialogButton.Close
            };

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Button btn = sender as Button;
                Client client = btn.DataContext as Client;
                if (client != null)
                {
                    SingletonDB.getInstance().supprimerClient(client.Id);
                }

            }
        }
    }
}
