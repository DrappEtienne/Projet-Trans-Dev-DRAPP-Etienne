using Projet_Trans_Dev.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.ViewModel
{
    public class EspeceViewModel : INotifyPropertyChanged
    {
        private int idEspece;
        private string nomEspece;
        //private string concat;

        public EspeceViewModel() { }

        public EspeceViewModel(int id, string nom)
        {
            this.idEspece = id;
            this.nomEspeceProperty = nom;
        }
        public int idEspeceProperty
        {
            get { return idEspece; }
        }

        public String nomEspeceProperty
        {
            get { return nomEspece; }
            set
            {
                nomEspece = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomEspece;
                OnPropertyChanged("nomEspeceProperty");
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

        /*public MetierViewModel MetierEspece
        {
            get { return metierEspece; }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EspeceORM.updateEspece(this);
            }
        }
    }
}
