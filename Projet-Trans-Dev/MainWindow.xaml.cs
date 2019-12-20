using Projet_Trans_Dev.DAL;
using Projet_Trans_Dev.ORM;
using Projet_Trans_Dev.DAO;
using Projet_Trans_Dev.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_Trans_Dev
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedUserId;
        int selectedEspeceId;
        int selectedDepartementId;
        int selectedCommuneId;
        int selectedPlageId;
        int selectedEtudeId;
        int selectedZoneId;

        UserViewModel myDataObject; // Objet de liaison
        EspeceViewModel myDataEspeceObject;
        DepartementViewModel myDataDepartementObject;
        CommuneViewModel myDataCommuneObject;
        PlageViewModel myDataPlageObject;
        EtudeViewModel myDataEtudeObject;
        Plage_has_EtudeViewModel myDataZoneObject;

        ObservableCollection<UserViewModel> lp;
        ObservableCollection<EspeceViewModel> le;
        ObservableCollection<DepartementViewModel> ld;

        ObservableCollection<CommuneViewModel> lc;

        ObservableCollection<PlageViewModel> lpl;
        ObservableCollection<EtudeViewModel> let;

        ObservableCollection<Plage_has_EtudeViewModel> lh;

        int compteur = 0;

        public MainWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();

            // Initialisation de la liste des Users via la BDD.
            lp = UserORM.listeUsers();
            le = EspeceORM.listeEspeces();
            ld = DepartementORM.listeDepartements();
            lc = CommuneORM.listeCommunes();
            lpl = PlageORM.listePlages();
            let = EtudeORM.listeEtudes();
            lh = Plage_has_EtudeORM.listePlage_has_Etudes();


            WomboCombo.ItemsSource = ld;
            ComboBox.ItemsSource = lc;
            ComboBoxEtude.ItemsSource = lp;
            ComboBoxEt.ItemsSource = let;
            ComboBoxPl.ItemsSource = lpl;


            //LIEN AVEC la VIEW
            //listeUsers.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            //listeEspeces.ItemsSource = le; // bind de la liste avec la source, permettant le binding.
            //listeDepartements.ItemsSource = ld;
            //listeCommunes.ItemsSource = lc;
            listePlages.ItemsSource = lpl;
            //listeEtudes.ItemsSource = let;
            //listePlage_has_Etudes.ItemsSource = lphe;



        }
        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.prenomUserProperty = prenomTextBox.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.nomUserProperty = nomTextBox.Text;
        }

        private void nomPrenomButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObject = new UserViewModel();
            myDataObject.prenomUserProperty = prenomTextBox.Text;
            myDataObject.nomUserProperty = nomTextBox.Text;
            myDataObject.identifiantUserProperty = identifiantTextBox.Text;
            myDataObject.motdepasseUserProperty = MotDePasseTextBox.Text;
            if (AdministrateurCheckBox.IsChecked ?? true)
            {
                myDataObject.administrateurUserProperty = 1;
            }
            else
            {
                myDataObject.administrateurUserProperty = 0;
            }
            
            UserViewModel nouveau = new UserViewModel(myDataObject.idUserProperty, myDataObject.nomUserProperty, myDataObject.prenomUserProperty, myDataObject.identifiantUserProperty, myDataObject.motdepasseUserProperty, myDataObject.administrateurUserProperty);
            lp.Add(nouveau);
            UserORM.insertUser(nouveau);
            //listeUsers.Items.Refresh();
            compteur = lp.Count();
           // myDataObject = new UserViewModel(UserDAL.getMaxIdUser() + 1, "", "", "", "", 0);
        }
        /*private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserViewModel toRemove = (UserViewModel)listeUsers.SelectedItem;
            lp.Remove(toRemove);
            listeUsers.Items.Refresh();
            UserORM.supprimerUser(selectedUserId);
        }
        private void VClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Blue !");
        }
        private void RClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Red !");
        }
        private void BClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Blue !");
        }

        private void listeUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeUsers.SelectedIndex < lp.Count) && (listeUsers.SelectedIndex >= 0))
            {
                selectedUserId = (lp.ElementAt<UserViewModel>(listeUsers.SelectedIndex)).idUserProperty;
            }
        }*/




        /*Pour la classe Espece :*/


        public void nomEspeceChanged(object sender, TextChangedEventArgs e)
        {
            myDataEspeceObject.nomEspeceProperty = nomEspeceTextBox.Text;
        }

        private void nomEspeceButton_Click(object sender, RoutedEventArgs e)
        {
            myDataEspeceObject = new EspeceViewModel();
            myDataEspeceObject.nomEspeceProperty = nomEspeceTextBox.Text;


            EspeceViewModel nouveau = new EspeceViewModel(myDataEspeceObject.idEspeceProperty, myDataEspeceObject.nomEspeceProperty);
            le.Add(nouveau);
            EspeceORM.insertEspece(nouveau);
            //listeEspeces.Items.Refresh();
            compteur = le.Count();
            // myDataObject = new UserViewModel(UserDAL.getMaxIdUser() + 1, "", "", "", "", 0);
        }
       /* private void supprimerEspeceButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EspeceViewModel toRemove = (EspeceViewModel)listeEspeces.SelectedItem;
            le.Remove(toRemove);
            listeEspeces.Items.Refresh();
            EspeceORM.supprimerEspece(selectedEspeceId);
        }

        private void listeEspece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEspeces.SelectedIndex < le.Count) && (listeEspeces.SelectedIndex >= 0))
            {
                selectedEspeceId = (le.ElementAt<EspeceViewModel>(listeEspeces.SelectedIndex)).idEspeceProperty;
            }
        }*/




        /*Pour la classe departement*/
        public void nomDepartementChanged(object sender, TextChangedEventArgs e)
        {
            myDataDepartementObject.nomDepartementProperty = nomDepartementTextBox.Text;
        }
        public void codepostalDepartementChanged(object sender, TextChangedEventArgs e)
        {
            myDataDepartementObject.codepostalDepartementProperty = codepostalDepartementTextBox.Text;
        }

        private void nomDepartementButton_Click(object sender, RoutedEventArgs e)
        {
            myDataDepartementObject = new DepartementViewModel();
            myDataDepartementObject.nomDepartementProperty = nomDepartementTextBox.Text;
            myDataDepartementObject.codepostalDepartementProperty = codepostalDepartementTextBox.Text;


            DepartementViewModel nouveau = new DepartementViewModel(DepartementDAL.getMaxIdDepartement() + 1, myDataDepartementObject.nomDepartementProperty, myDataDepartementObject.codepostalDepartementProperty);
            ld.Add(nouveau);
            DepartementORM.insertDepartement(nouveau);

            WomboCombo.ItemsSource = ld;
            WomboCombo.Items.Refresh();
            //listeDepartements.Items.Refresh();
            compteur = ld.Count();
            

            MessageBox.Show(codepostalDepartementTextBox.Text);
        }
        /*private void supprimerDepartementButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DepartementViewModel toRemove = (DepartementViewModel)listeDepartements.SelectedItem;
            ld.Remove(toRemove);
            listeDepartements.Items.Refresh();
            DepartementORM.supprimerDepartement(selectedDepartementId);
        }


        private void listeDepartement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeDepartements.SelectedIndex < ld.Count) && (listeDepartements.SelectedIndex >= 0))
            {
                selectedDepartementId = (ld.ElementAt<DepartementViewModel>(listeDepartements.SelectedIndex)).idDepartementProperty;
            }
        }
        */

        /*Commune*/

        public void nomCommuneChanged(object sender, TextChangedEventArgs e)
        {
            myDataCommuneObject.nomCommuneProperty = nomCommuneTextBox.Text;
        }
        public void departementCommuneChanged(object sender, TextChangedEventArgs e)
        {
            //ComboBoxItem i = (ComboBoxItem)WomboCombo.SelectedItem;
            


            //myDataCommuneObject.departementCommune = WomboCombo.SelectedItem;
        }

        private void nomCommuneButton_MouseDoubleClick(object sender, RoutedEventArgs e) //System.Windows.Input.MouseButtonEventArgs
        {
            myDataCommuneObject = new CommuneViewModel();
            myDataCommuneObject.nomCommuneProperty = nomCommuneTextBox.Text;
            myDataCommuneObject.departementCommune = (DepartementViewModel)WomboCombo.SelectedItem;


            CommuneViewModel nouveau = new CommuneViewModel(CommuneDAL.getMaxIdCommune() + 1, myDataCommuneObject.nomCommuneProperty, myDataCommuneObject.departementCommune);
            lc.Add(nouveau);
            CommuneORM.insertCommune(nouveau);



            ComboBox.ItemsSource = lc;
            ComboBox.Items.Refresh();
            //listeDepartements.Items.Refresh();
            //listeCommunes.Items.Refresh();
            compteur = lc.Count();
           
            MessageBox.Show("envoyez");
        }
        /*private void supprimerCommuneButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CommuneViewModel toRemove = (CommuneViewModel)listeCommunes.SelectedItem;
            lc.Remove(toRemove);
            listeCommunes.Items.Refresh();
            CommuneORM.supprimerCommune(selectedCommuneId);
        }


        private void listeCommune_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeCommunes.SelectedIndex < lc.Count) && (listeCommunes.SelectedIndex >= 0))
            {
                selectedCommuneId = (lc.ElementAt<CommuneViewModel>(listeCommunes.SelectedIndex)).idCommuneProperty;
            }
        }*/









        /*Plage*/

        public void nomPlageChanged(object sender, TextChangedEventArgs e)
        {
            myDataPlageObject.nomPlageProperty = nomPlageTextBox.Text;
        }
        public void communePlageChanged(object sender, TextChangedEventArgs e)
        {
            //ComboBoxItem i = (ComboBoxItem)WomboCombo.SelectedItem;



            //myDataCommuneObject.departementCommune = WomboCombo.SelectedItem;
        }

        private void nomPlageButton_MouseDoubleClick(object sender, RoutedEventArgs e) //System.Windows.Input.MouseButtonEventArgs
        {
            myDataPlageObject = new PlageViewModel();
            myDataPlageObject.nomPlageProperty = nomPlageTextBox.Text;
            myDataPlageObject.superficiePlageProperty = superficiePlageTextBox.Text;
            myDataPlageObject.CommunePlageProperty = (CommuneViewModel)ComboBox.SelectedItem;


            PlageViewModel nouveau = new PlageViewModel(myDataPlageObject.idPlageProperty, myDataPlageObject.nomPlageProperty, myDataPlageObject.superficiePlageProperty, myDataPlageObject.CommunePlage);
            lpl.Add(nouveau);
            PlageORM.insertPlage(nouveau);
            //listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();
            compteur = lc.Count();

            MessageBox.Show("envoyez");
        }
        private void supprimerPlageButton_Click(object sender, RoutedEventArgs e)
        {
            PlageViewModel toRemove = (PlageViewModel)listePlages.SelectedItem;
            lpl.Remove(toRemove);
            listePlages.Items.Refresh();
            PlageORM.supprimerPlage(selectedPlageId);
        }


        private void listePlage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < lpl.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlageId = (lpl.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
            }
        }



        
        /*Etude*/

       /* public void nomEtudeChanged(object sender, TextChangedEventArgs e)
        {
            myDataPlageObject.nomPlageProperty = nomPlageTextBox.Text;
        }
        public void communeEtudeChanged(object sender, TextChangedEventArgs e)
        {
            //ComboBoxItem i = (ComboBoxItem)WomboCombo.SelectedItem;



            //myDataCommuneObject.departementCommune = WomboCombo.SelectedItem;
        }*/

        private void titreEtudeButton_MouseDoubleClick(object sender, RoutedEventArgs e) //System.Windows.Input.MouseButtonEventArgs
        {
            myDataEtudeObject = new EtudeViewModel();
            myDataEtudeObject.titreEtudeProperty = titreEtudeTextBox.Text;
            myDataEtudeObject.nombrePersonneEtudeProperty = Convert.ToInt32(nombrePersonneEtudeTextBox.Text);
            myDataEtudeObject.dateEtudeProperty = dateEtudeTextBox.Text;

            myDataEtudeObject.userEtudeProperty = (UserViewModel)ComboBoxEtude.SelectedItem;


            EtudeViewModel nouveau = new EtudeViewModel(EtudeDAL.getMaxIdEtude() + 1, myDataEtudeObject.titreEtudeProperty, myDataEtudeObject.dateEtudeProperty, myDataEtudeObject.nombrePersonneEtudeProperty, myDataEtudeObject.userEtudeProperty);
            let.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
           // listeEtudes.Items.Refresh();
            //listePlages.Items.Refresh();
            compteur = lc.Count();

            MessageBox.Show("envoyez");
        }




        /*Zone */


        private void titreZoneButton_Click(object sender, RoutedEventArgs e) 
        {
            myDataZoneObject = new Plage_has_EtudeViewModel();
            myDataZoneObject.Angle1Plage_has_EtudeProperty = Convert.ToDecimal(angle1TextBox.Text);
            myDataZoneObject.Angle2Plage_has_EtudeProperty = Convert.ToDecimal(angle2TextBox.Text);
            myDataZoneObject.Angle3Plage_has_EtudeProperty = Convert.ToDecimal(angle3TextBox.Text);
            myDataZoneObject.Angle4Plage_has_EtudeProperty = Convert.ToDecimal(angle4TextBox.Text);
            myDataZoneObject.DatePlage_has_EtudeProperty = DateTextBox.Text;
            myDataZoneObject.superficieZoneEtudieePlage_has_EtudeProperty = Convert.ToDecimal(SuperficieEtudieeTextBox.Text);


            myDataZoneObject.EtudePlage_has_EtudeProperty = (EtudeViewModel)ComboBoxEt.SelectedItem;
            myDataZoneObject.PlagePlage_has_EtudeProperty = (PlageViewModel)ComboBoxPl.SelectedItem;


            Plage_has_EtudeViewModel nouveau = new Plage_has_EtudeViewModel(Plage_has_EtudeDAL.getMaxnumZone() + 1, myDataZoneObject.EtudePlage_has_EtudeProperty, myDataZoneObject.PlagePlage_has_EtudeProperty, myDataZoneObject.DatePlage_has_EtudeProperty, myDataZoneObject.Angle1Plage_has_EtudeProperty, myDataZoneObject.Angle2Plage_has_EtudeProperty, myDataZoneObject.Angle3Plage_has_EtudeProperty, myDataZoneObject.Angle4Plage_has_EtudeProperty, myDataZoneObject.superficieZoneEtudieePlage_has_EtudeProperty);
            lh.Add(nouveau);
            Plage_has_EtudeORM.insertPlage_has_Etude(nouveau);
            //listeEtudes.Items.Refresh();
            //listePlages.Items.Refresh();
            compteur = lh.Count();

            MessageBox.Show("envoyez");
        }
    }
}
