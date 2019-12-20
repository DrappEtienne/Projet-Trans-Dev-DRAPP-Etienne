using Projet_Trans_Dev.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.ViewModel
{
    public class Plage_has_EtudeViewModel : INotifyPropertyChanged
    {
        public int numZonePlage_has_Etude;
        public EtudeViewModel EtudePlage_has_Etude;
        public PlageViewModel PlagePlage_has_Etude;
        public string DatePlage_has_Etude;
        public decimal Angle1Plage_has_Etude;
        public decimal Angle2Plage_has_Etude;
        public decimal Angle3Plage_has_Etude;
        public decimal Angle4Plage_has_Etude;
        public decimal superficieZoneEtudieePlage_has_Etude;

        public Plage_has_EtudeViewModel() { }

        public Plage_has_EtudeViewModel(int id,EtudeViewModel EtudePlage_has_Etude, PlageViewModel PlagePlage_has_Etude, string DatePlage_has_Etude, decimal Angle1Plage_has_Etude, decimal Angle2Plage_has_Etude, decimal Angle3Plage_has_Etude, decimal Angle4Plage_has_Etude, decimal superficieZoneEtudieePlage_has_Etude)
        {
            this.numZonePlage_has_Etude = id;
            this.EtudePlage_has_Etude = EtudePlage_has_Etude;
            this.PlagePlage_has_Etude = PlagePlage_has_Etude;
            this.DatePlage_has_Etude = DatePlage_has_Etude;
            this.Angle1Plage_has_Etude = Angle1Plage_has_Etude;
            this.Angle2Plage_has_Etude = Angle2Plage_has_Etude;
            this.Angle3Plage_has_Etude = Angle3Plage_has_Etude;
            this.Angle4Plage_has_Etude = Angle4Plage_has_Etude;
            this.superficieZoneEtudieePlage_has_Etude = superficieZoneEtudieePlage_has_Etude;
        }
        public int numZonePlage_has_EtudeProperty
        {
            get { return numZonePlage_has_Etude; }
        }

        public string DatePlage_has_EtudeProperty
        {
            get { return DatePlage_has_Etude; }
            set
            {
                DatePlage_has_Etude = value;
            }

        }

        public decimal Angle1Plage_has_EtudeProperty
        {
            get { return Angle1Plage_has_Etude; }
            set
            {
                Angle1Plage_has_Etude = value;
            }

        }

        public decimal Angle2Plage_has_EtudeProperty
        {
            get { return Angle2Plage_has_Etude; }
            set
            {
                Angle2Plage_has_Etude = value;
            }

        }

        public decimal Angle3Plage_has_EtudeProperty
        {
            get { return Angle3Plage_has_Etude; }
            set
            {
                Angle3Plage_has_Etude = value;
            }

        }

        public decimal Angle4Plage_has_EtudeProperty
        {
            get { return Angle4Plage_has_Etude; }
            set
            {
                Angle4Plage_has_Etude = value;
            }

        }

        public decimal superficieZoneEtudieePlage_has_EtudeProperty
        {
            get { return superficieZoneEtudieePlage_has_Etude; }
            set
            {
                superficieZoneEtudieePlage_has_Etude = value;
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

        public EtudeViewModel EtudePlage_has_EtudeProperty
        {
            get { return EtudePlage_has_Etude; }
            set
            {
                EtudePlage_has_Etude = value;
            }
        }

        public PlageViewModel PlagePlage_has_EtudeProperty
        {
            get { return PlagePlage_has_Etude; }
            set
            {
                PlagePlage_has_Etude = value;
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                Plage_has_EtudeORM.updatePlage_has_Etude(this);
            }
        }
    }
}
