using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using ProjetFinal.Classe;
using ProjetFinal.Vues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SingletonDB.getInstance().getCompte();
            if(SingletonDB.getInstance().Compter == 0)
            {
                mainFrame.Navigate(typeof(AjouterCompte));
            }
            else
            {
                mainFrame.Navigate(typeof(AfficherProjets));
            }
            
        }

        private void navView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (mainFrame.CanGoBack)
            {
                if(mainFrame.BackStack.LastOrDefault().SourcePageType == typeof(Connexion))
                {
                    mainFrame.BackStack.Remove(mainFrame.BackStack.LastOrDefault());

                }
                mainFrame.GoBack();
            }
                
        }

        private void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            SingletonDB.getInstance().getCompte();
            if (SingletonDB.getInstance().Compter > 0)
            {
                if (args.InvokedItemContainer is NavigationViewItem item)
                {
                    switch (item.Name)
                    {
                        case "iProjets":
                            mainFrame.Navigate(typeof(AfficherProjets));
                            break;
                        case "iClients":
                            mainFrame.Navigate(typeof(AfficherClients));
                            break;
                        case "iEmployes":
                            mainFrame.Navigate(typeof(AfficherEmployes));
                            break;
                        case "iAsso":
                            mainFrame.Navigate(typeof(AfficheAssign));
                            break;
                        case "iAjoutProjet":
                            if (SingletonDB.getInstance().Compte.Actif)
                            {
                                mainFrame.Navigate(typeof(AjouterProjet));
                            }
                            else
                            {
                                mainFrame.Navigate(typeof(Connexion), typeof(AjouterProjet));
                            }
                            break;
                        case "iAssignProjet":
                            if (SingletonDB.getInstance().Compte.Actif)
                            {
                                mainFrame.Navigate(typeof(AssignerProjet));
                            }
                            else
                            {
                                mainFrame.Navigate(typeof(Connexion), typeof(AssignerProjet));
                            }
                            break;
                        case "iAjoutClient":
                            if (SingletonDB.getInstance().Compte.Actif)
                            {
                                mainFrame.Navigate(typeof(AjouterClient));
                            }
                            else
                            {
                                mainFrame.Navigate(typeof(Connexion), typeof(AjouterClient));
                            }
                            break;
                        case "iAjoutEmploye":
                            if (SingletonDB.getInstance().Compte.Actif)
                            {
                                mainFrame.Navigate(typeof(AjouterEmploye));
                            }
                            else
                            {
                                mainFrame.Navigate(typeof(Connexion), typeof(AjouterEmploye));
                            }
                            break;
                        case "iConnexion":
                            mainFrame.Navigate(typeof(Connexion));
                            break;
                    }
                }
            }
            
        }

        private async void mfiExport_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            picker.SuggestedFileName = "projets";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });
            
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();
            List<string> liste = new List<string>();
            liste.Add("Numéro de projet;Titre;Date de début;Description;Budget;Salaire Total;Client;Statut");
            liste.AddRange(SingletonDB.getInstance().exporter().ConvertAll(x => x.ToString()));
            if (monFichier != null)
            {

                await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            }
                
        }

        private void mfiQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
