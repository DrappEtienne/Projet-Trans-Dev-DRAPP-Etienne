using Projet_Trans_Dev.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.ViewModel
{
    public class PlageViewModel : INotifyPropertyChanged
    {
        public int idPlage;
        private string nomPlage;
        private string superficiePlage;
        public CommuneViewModel CommunePlage;
        //private string concat;

        public PlageViewModel() { }

        public PlageViewModel(int id, string nom, string superficie, CommuneViewModel Commune)
        {
            this.idPlage = id;
            this.nomPlageProperty = nom;
            this.superficiePlageProperty = superficie;
            CommunePlage = Commune;
        }
        public int idPlageProperty
        {
            get { return idPlage; }
        }

        public String nomPlageProperty
        {
            get { return nomPlage; }
            set
            {
                nomPlage = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomPlage;
                OnPropertyChanged("nomPlageProperty");
            }

        }

        public String superficiePlageProperty
        {
            get { return superficiePlage; }
            set
            {
                superficiePlage = value;
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

        public CommuneViewModel CommunePlageProperty
        {
            get { return CommunePlage; }
            set
            {
                CommunePlage = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PlageORM.updatePlage(this);
            }
        }
    }
}
