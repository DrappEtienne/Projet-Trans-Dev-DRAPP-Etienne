using Projet_Trans_Dev.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.DAO
{
    class EtudeDAO
    {

        public int idEtudeDAO;
        public string titreEtudeDAO;
        public string dateEtudeDAO;
        public int nombrePersonneEtudeDAO;
        public int idUserEtudeDAO;


        public EtudeDAO(int idEtudeDAO, string titreEtudeDAO, string dateEtudeDAO, int nombrePersonneEtudeDAO, int idUserEtudeDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.titreEtudeDAO = titreEtudeDAO;
            this.dateEtudeDAO = dateEtudeDAO;
            this.nombrePersonneEtudeDAO = nombrePersonneEtudeDAO;
            this.idUserEtudeDAO = idUserEtudeDAO;

        }

        public static ObservableCollection<EtudeDAO> listeEtude()
        {
            ObservableCollection<EtudeDAO> l = EtudeDAL.selectEtudes();
            return l;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO u = EtudeDAL.getEtude(idEtude);
            return u;
        }

        public static void updateEtude(EtudeDAO u)
        {
            EtudeDAL.updateEtude(u);
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);
        }

        public static void insertEtude(EtudeDAO u)
        {
            EtudeDAL.insertEtude(u);
        }
    }
}
