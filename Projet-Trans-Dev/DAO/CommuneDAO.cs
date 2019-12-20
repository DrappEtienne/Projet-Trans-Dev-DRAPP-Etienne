using Projet_Trans_Dev.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.DAO
{
    class CommuneDAO
    {

        public int idCommuneDAO;
        public string nomCommuneDAO;
        public int idDepartementCommuneDAO;


        public CommuneDAO(int idCommuneDAO, string nomCommuneDAO, int idDepartementCommuneDAO)
        {
            this.idCommuneDAO = idCommuneDAO;
            this.nomCommuneDAO = nomCommuneDAO;
            this.idDepartementCommuneDAO = idDepartementCommuneDAO;

        }

        public static ObservableCollection<CommuneDAO> listeCommune()
        {
            ObservableCollection<CommuneDAO> l = CommuneDAL.selectCommunes();
            return l;
        }

        public static CommuneDAO getCommune(int idCommune)
        {
            CommuneDAO u = CommuneDAL.getCommune(idCommune);
            return u;
        }

        public static void updateCommune(CommuneDAO u)
        {
            CommuneDAL.updateCommune(u);
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAL.supprimerCommune(id);
        }

        public static void insertCommune(CommuneDAO u)
        {
            CommuneDAL.insertCommune(u);
        }
    }
}
