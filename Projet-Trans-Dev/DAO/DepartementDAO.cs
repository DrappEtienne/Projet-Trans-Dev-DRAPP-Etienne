using Projet_Trans_Dev.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.DAO
{
    class DepartementDAO
    {

        public int idDepartementDAO;
        public string nomDepartementDAO;
        public string codepostalDepartementDAO;


        public DepartementDAO(int idDepartementDAO, string nomDepartementDAO, string codepostalDepartementDAO)
        {
            this.idDepartementDAO = idDepartementDAO;
            this.nomDepartementDAO = nomDepartementDAO;
            this.codepostalDepartementDAO = codepostalDepartementDAO;

        }

        public static ObservableCollection<DepartementDAO> listeDepartement()
        {
            ObservableCollection<DepartementDAO> l = DepartementDAL.selectDepartements();
            return l;
        }

        public static DepartementDAO getDepartement(int idDepartement)
        {
            DepartementDAO u = DepartementDAL.getDepartement(idDepartement);
            return u;
        }

        public static void updateDepartement(DepartementDAO u)
        {
            DepartementDAL.updateDepartement(u);
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAL.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementDAO u)
        {
            DepartementDAL.insertDepartement(u);
        }
    }
}
