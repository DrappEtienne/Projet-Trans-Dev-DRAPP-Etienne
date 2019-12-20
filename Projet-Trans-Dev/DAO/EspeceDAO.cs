using Projet_Trans_Dev.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.DAO
{
    class EspeceDAO
    {

        public int idEspeceDAO;
        public string nomEspeceDAO;


        public EspeceDAO(int idEspeceDAO, string nomEspeceDAO)
        {
            this.idEspeceDAO = idEspeceDAO;
            this.nomEspeceDAO = nomEspeceDAO;

        }

        public static ObservableCollection<EspeceDAO> listeEspece()
        {
            ObservableCollection<EspeceDAO> l = EspeceDAL.selectEspeces();
            return l;
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            EspeceDAO u = EspeceDAL.getEspece(idEspece);
            return u;
        }

        public static void updateEspece(EspeceDAO u)
        {
            EspeceDAL.updateEspece(u);
        }

        public static void supprimerEspece(int id)
        {
            EspeceDAL.supprimerEspece(id);
        }

        public static void insertEspece(EspeceDAO u)
        {
            EspeceDAL.insertEspece(u);
        }
    }
}
