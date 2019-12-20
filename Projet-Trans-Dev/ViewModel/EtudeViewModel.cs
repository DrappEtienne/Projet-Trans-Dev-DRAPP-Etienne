using Projet_Trans_Dev.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.ViewModel
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        public int idEtude;
        private string titreEtude;
        public string dateEtude;
        public int nombrePersonneEtude;
        public UserViewModel userEtude;
        //private string concat;

        public EtudeViewModel() { }

        public EtudeViewModel(int id, string titre, string date, int nombrePersonne, UserViewModel userEtude)
        {
            this.idEtude = id;
            this.titreEtudeProperty = titre;
            this.dateEtudeProperty = date;
            this.nombrePersonneEtudeProperty = nombrePersonne;
            this.userEtude = userEtude;
        }
        public int idEtudeProperty
        {
            get { return idEtude; }
        }

        public String titreEtudeProperty
        {
            get { return titreEtude; }
            set
            {
                titreEtude = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + pretitreEtude;
                OnPropertyChanged("titreEtudeProperty");
            }

        }

        public String dateEtudeProperty
        {
            get { return dateEtude; }
            set
            {
                dateEtude = value;
                OnPropertyChanged("dateEtudeProperty");

                
            }

        }

        public int nombrePersonneEtudeProperty
        {
            get { return nombrePersonneEtude; }
            set
            {
                nombrePersonneEtude = value;
                OnPropertyChanged("dateEtudeProperty");


            }

        }

        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }

        public UserViewModel userEtudeProperty
        {
            get { return userEtude; }
            set
            {
                userEtude = value;
            }
        }

        public string nomUserEtudeProperty
        {
            get { return userEtude.nomUserProperty; }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EtudeORM.updateEtude(this);
            }
        }
    }
}
