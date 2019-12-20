using Projet_Trans_Dev.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.DAO
{
    class Plage_has_EtudeDAO
    {
        public int numZonePlage_has_EtudeDAO;

        public int idEtudePlage_has_EtudeDAO;
        public int idPlagePlage_has_EtudeDAO;
        public string DatePlage_has_EtudeDAO;
        public decimal Angle1Plage_has_EtudeDAO;
        public decimal Angle2Plage_has_EtudeDAO;
        public decimal Angle3Plage_has_EtudeDAO;
        public decimal Angle4Plage_has_EtudeDAO;
        public decimal superficieZoneEtudieePlage_has_EtudeDAO;


        public Plage_has_EtudeDAO(int numZonePlage_has_EtudeDAO, int idEtudePlage_has_EtudeDAO, int idPlagePlage_has_EtudeDAO, string DatePlage_has_EtudeDAO,  decimal Angle1Plage_has_EtudeDAO, decimal Angle2Plage_has_EtudeDAO, decimal Angle3Plage_has_EtudeDAO, decimal Angle4Plage_has_EtudeDAO, decimal superficieZoneEtudieePlage_has_EtudeDAO)
        {
            this.idEtudePlage_has_EtudeDAO = idEtudePlage_has_EtudeDAO;
            this.idPlagePlage_has_EtudeDAO = idPlagePlage_has_EtudeDAO;
            this.DatePlage_has_EtudeDAO = DatePlage_has_EtudeDAO;
            this.numZonePlage_has_EtudeDAO = numZonePlage_has_EtudeDAO;
            this.Angle1Plage_has_EtudeDAO = Angle1Plage_has_EtudeDAO;
            this.Angle2Plage_has_EtudeDAO = Angle2Plage_has_EtudeDAO;
            this.Angle3Plage_has_EtudeDAO = Angle3Plage_has_EtudeDAO;
            this.Angle4Plage_has_EtudeDAO = Angle4Plage_has_EtudeDAO;
            this.superficieZoneEtudieePlage_has_EtudeDAO = superficieZoneEtudieePlage_has_EtudeDAO;

        }

        public static ObservableCollection<Plage_has_EtudeDAO> listePlage_has_Etude()
        {
            ObservableCollection<Plage_has_EtudeDAO> l = Plage_has_EtudeDAL.selectPlage_has_Etudes();
            return l;
        }

        public static Plage_has_EtudeDAO getPlage_has_Etude(int numZone)
        {
            Plage_has_EtudeDAO u = Plage_has_EtudeDAL.getPlage_has_Etude(numZone);
            return u;
        }

        public static void updatePlage_has_Etude(Plage_has_EtudeDAO u)
        {
            Plage_has_EtudeDAL.updatePlage_has_Etude(u);
        }

        public static void supprimerPlage_has_Etude(int id)
        {
            Plage_has_EtudeDAL.supprimerPlage_has_Etude(id);
        }

        public static void insertPlage_has_Etude(Plage_has_EtudeDAO u)
        {
            Plage_has_EtudeDAL.insertPlage_has_Etude(u);
        }
    }
}
