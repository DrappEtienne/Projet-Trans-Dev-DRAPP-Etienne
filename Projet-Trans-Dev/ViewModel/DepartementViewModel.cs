using Projet_Trans_Dev.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.ViewModel
{
    public class DepartementViewModel : INotifyPropertyChanged
    {
        public int idDepartement;
        private string nomDepartement;
        public string codepostalDepartement;
        //private string concat;

        public DepartementViewModel() { }

        public DepartementViewModel(int id, string nom, string codepostal)
        {
            this.idDepartement = id;
            this.nomDepartementProperty = nom;
            this.codepostalDepartementProperty = codepostal;
        }
        public int idDepartementProperty
        {
            get { return idDepartement; }
        }

        public String nomDepartementProperty
        {
            get { return nomDepartement; }
            set
            {
                nomDepartement = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomDepartement;
                OnPropertyChanged("nomDepartementProperty");
            }

        }

        public String codepostalDepartementProperty
        {
            get { return codepostalDepartement; }
            set
            {
                codepostalDepartement = value;
                OnPropertyChanged("codepostalDepartementProperty");

                
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

        /*public MetierViewModel MetierDepartement
        {
            get { return metierDepartement; }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DepartementORM.updateDepartement(this);
            }
        }
    }
}
