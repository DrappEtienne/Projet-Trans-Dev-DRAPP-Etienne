using Projet_Trans_Dev.DAO;
using Projet_Trans_Dev.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.ORM
{
    public class DepartementORM
    {
        public static DepartementViewModel getDepartement(int idDepartement)
        {
            DepartementDAO uDAO = DepartementDAO.getDepartement(idDepartement);

            DepartementViewModel u = new DepartementViewModel(uDAO.idDepartementDAO, uDAO.nomDepartementDAO, uDAO.codepostalDepartementDAO);
            return u;
        }


        public static ObservableCollection<DepartementViewModel> listeDepartements()
        {
            ObservableCollection<DepartementDAO> lDAO = DepartementDAO.listeDepartement();
            ObservableCollection<DepartementViewModel> l = new ObservableCollection<DepartementViewModel>();
            foreach (DepartementDAO element in lDAO)
            {
              
                DepartementViewModel p = new DepartementViewModel(element.idDepartementDAO, element.nomDepartementDAO, element.codepostalDepartementDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateDepartement(DepartementViewModel u)
        {
            DepartementDAO.updateDepartement(new DepartementDAO(u.idDepartementProperty, u.nomDepartementProperty, u.codepostalDepartementProperty));
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAO.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementViewModel u)
        {
            DepartementDAO.insertDepartement(new DepartementDAO(u.idDepartementProperty, u.nomDepartementProperty, u.codepostalDepartementProperty));
        }
    }
}
