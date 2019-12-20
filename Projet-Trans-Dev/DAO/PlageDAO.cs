using Projet_Trans_Dev.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.DAO
{
    class PlageDAO
    {

        public int idPlageDAO;
        public string nomPlageDAO;
        public string superficiePlageDAO;
        public int idCommunePlageDAO;


        public PlageDAO(int idPlageDAO, string nomPlageDAO, string superficiePlageDAO, int idCommunePlageDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.superficiePlageDAO = superficiePlageDAO;
            this.idCommunePlageDAO = idCommunePlageDAO;

        }

        public static ObservableCollection<PlageDAO> listePlage()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlages();
            return l;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO u = PlageDAL.getPlage(idPlage);
            return u;
        }

        public static void updatePlage(PlageDAO u)
        {
            PlageDAL.updatePlage(u);
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageDAO u)
        {
            PlageDAL.insertPlage(u);
        }
    }
}
