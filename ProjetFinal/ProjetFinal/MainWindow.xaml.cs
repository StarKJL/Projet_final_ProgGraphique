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
            mainFrame.Navigate(typeof(AfficherProjets));
        }

        private void navView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if(mainFrame.CanGoBack)
                mainFrame.GoBack();
        }

        private void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer is NavigationViewItem item)
            {
                switch (item.Name)
                {
                    case "iProjets":
                        mainFrame.Navigate(typeof(AfficherProjets));
                        break;
                    case "iClients":
                        mainFrame.Navigate(typeof (AfficherClients));
                        break;
                    case "iEmployes":
                        mainFrame.Navigate(typeof(AfficherEmployes));
                        break;
                    case "iAjoutProjet":
                        mainFrame.Navigate (typeof (AjouterProjet));
                        break;
                    case "iAssignProjet":
                        mainFrame.Navigate(typeof(AssignerProjet));
                        break ;
                }
            }
        }

        private async void mfiImport_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".csv");
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync();
            if (monFichier != null)
            {
                /*
                var lignes = await Windows.Storage.FileIO.ReadLinesAsync(monFichier);
                List<Appareil_Electronique> liste = new List<Appareil_Electronique>();
                foreach (var ligne in lignes)
                {
                    var v = ligne.Split(";");
                    if (v.Length > 0)
                    {
                        string code = v[0];
                        string modele = v[1];
                        string appareil = v[2];
                        string categorie = v[3];
                        string couleur = v[4];
                        double prix = Convert.ToDouble(v[5]);
                        liste.Add(new Appareil_Electronique(code, modele, appareil, categorie, couleur, prix));
                    }
                }
                SingletonBD.getInstance().ajouterListe(liste);
                mainFrame.Navigate(typeof(Afficher));*/
            }
        }

        private async void mfiExport_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
            picker.SuggestedFileName = "test";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });
            
            //Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();
            List<Projet> liste = SingletonDB.getInstance().exporter();
           /* liste.Add(new Client("Line", "Savoie", "line.Savoie@mail.com"));
            liste.Add(new Client("Marie", “Marcotte", “marie.marcotte@mail.com"));
            liste.Add(new Client("Liam", "Gélinas", “liam.gelinas@mail.com"));
            if (monFichier != null)
                await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.ToString()), Windows.Storage.Streams.UnicodeEncoding.Utf8);*/
        }

        private void mfiQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
