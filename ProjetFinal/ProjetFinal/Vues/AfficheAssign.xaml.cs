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
    public sealed partial class AfficheAssign : Page
    {
        public AfficheAssign()
        {
            InitializeComponent();
            gvAssign.ItemsSource=SingletonDB.getInstance().ListeProjetEmploye;
            SingletonDB.getInstance().updateSalaire();
            SingletonDB.getInstance().getAllEmployeProjet();
            SingletonDB.getInstance().updateTotalSalaire();
        }

        private async void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (!SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(Connexion), typeof(AfficheAssign));
                return;
            }

            ContentDialog dialog = new ContentDialog
            {
                XamlRoot = this.XamlRoot,
                Title = "Suppression d'assignation",
                Content = "Êtes-vous sûr de vouloir supprimer cette assignation?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler",
                DefaultButton = ContentDialogButton.Close
            };

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Button btn = sender as Button;
                EmployeProjet ep = btn.DataContext as EmployeProjet;
                if (ep != null)
                {
                    SingletonDB.getInstance().supprimerEmployeProjet(ep.Id);
                    SingletonDB.getInstance().updateTotalSalaire();
                }

            }
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            EmployeProjet ep = btn.DataContext as EmployeProjet;
            if (SingletonDB.getInstance().Compte.Actif)
            {
                Frame.Navigate(typeof(ModifAssign), ep);
            }
            else
            {
                object[] parametresRetour = new object[] { typeof(ModifAssign), ep };
                Frame.Navigate(typeof(Connexion), parametresRetour);
            }
        }
    }
}
