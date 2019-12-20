using Projet_Trans_Dev.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.ViewModel
{
    public class CommuneViewModel : INotifyPropertyChanged
    {
        public int idCommune;
        private string nomCommune;
        public DepartementViewModel departementCommune;

        //private string concat;

        public CommuneViewModel() { }

        public CommuneViewModel(int id, string nom, DepartementViewModel departement)
        {
            this.idCommune = id;
            this.nomCommuneProperty = nom;
            departementCommune = departement;

        }
        public int idCommuneProperty
        {
            get { return idCommune; }
        }

        public String nomCommuneProperty
        {
            get { return nomCommune; }
            set
            {
                nomCommune = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomCommune;
                OnPropertyChanged("nomCommuneProperty");
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

        public DepartementViewModel DepartementCommuneProperty
        {
            get { return departementCommune; }
        }

        public string nomDepartementCommuneProperty
        {
            get { return departementCommune.nomDepartementProperty; }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                CommuneORM.updateCommune(this);
            }
        }
    }
}
