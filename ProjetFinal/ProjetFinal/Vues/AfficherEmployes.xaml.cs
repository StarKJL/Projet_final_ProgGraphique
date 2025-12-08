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
    public sealed partial class AfficherEmployes : Page
    {
        public AfficherEmployes()
        {
            InitializeComponent();
            gvEmployes.ItemsSource = SingletonDB.getInstance().ListeEmploye;
            SingletonDB.getInstance().getAllEmploye();
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            Employe employeModif = btn.DataContext as Employe;
            if (SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(ModifEmploye), employeModif);
            }
            else
            {
                object[] parametresRetour = new object[] { typeof(ModifEmploye), employeModif };
                Frame.Navigate(typeof(Connexion), parametresRetour);
            }
        }

        private async void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (!SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(Connexion), typeof(AfficherEmployes));
                return;
            }
            ContentDialog dialog = new ContentDialog
            {
                XamlRoot = this.XamlRoot,
                Title = "Suppression d'employé",
                Content = "Êtes-vous sûr de vouloir supprimer cet employé?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler",
                DefaultButton = ContentDialogButton.Close
            };

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Button btn = sender as Button;
                Employe employe = btn.DataContext as Employe;
                if (employe != null)
                {
                    SingletonDB.getInstance().supprimerEmploye(employe.Matricule);
                }

            }
        }
    }
}
