using Projet_Trans_Dev.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public int idUser;
        public string nomUser;
        private string prenomUser;
        //private string concat;
        private string identifiantUser;
        private string motdepasseUser;
        private byte administrateurUser;

        public UserViewModel() { }

        public UserViewModel(int id, string nom, string prenom,string identifiant, string motdepasse, byte administrateur)
        {
            this.idUser = id;
            this.nomUserProperty = nom;
            this.prenomUserProperty = prenom;
            this.identifiantUserProperty = identifiant;
            this.motdepasseUserProperty = motdepasse;
            this.administrateurUserProperty = administrateur;
        }
        public int idUserProperty
        {
            get { return idUser; }
        }

        public String nomUserProperty
        {
            get { return nomUser; }
            set
            {
                nomUser = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomUser;
                OnPropertyChanged("nomUserProperty");
            }

        }
        public String prenomUserProperty
        {
            get { return prenomUser; }
            set
            {
                this.prenomUser = value;
                this.concatProperty = this.nomUser + " " + value;
                OnPropertyChanged("prenomUserProperty");
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
        public String identifiantUserProperty
        {
            get { return identifiantUser; }
            set
            {
                this.identifiantUser = value;
                //this.concatProperty = this.nomUser + " " + value;
                OnPropertyChanged("identifiantUserProperty");
            }
        }
        public String motdepasseUserProperty
        {
            get { return motdepasseUser; }
            set
            {
                this.motdepasseUser = value;
                //this.concatProperty = this.nomUser + " " + value;
                OnPropertyChanged("motdepasseUserProperty");
            }
        }
        public byte administrateurUserProperty
        {
            get { return administrateurUser; }
            set
            {
                OnPropertyChanged("administrateurUserProperty");
            }
        }

        /*public MetierViewModel MetierUser
        {
            get { return metierUser; }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                UserORM.updateUser(this);
            }
        }
    }
}
