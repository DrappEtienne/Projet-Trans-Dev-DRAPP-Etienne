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
    public class EspeceORM
    {
        public static EspeceViewModel getEspece(int idEspece)
        {
            EspeceDAO uDAO = EspeceDAO.getEspece(idEspece);
            //int idMetier = pDAO.idMetierEspeceDAO;
            //MetierViewModel m = MetierORM.getMetier(idMetier);
            EspeceViewModel u = new EspeceViewModel(uDAO.idEspeceDAO, uDAO.nomEspeceDAO);
            return u;
        }


        public static ObservableCollection<EspeceViewModel> listeEspeces()
        {
            ObservableCollection<EspeceDAO> lDAO = EspeceDAO.listeEspece();
            ObservableCollection<EspeceViewModel> l = new ObservableCollection<EspeceViewModel>();
            foreach (EspeceDAO element in lDAO)
            {
               // int idMetier = element.idMetierEspeceDAO;

                //MetierViewModel m = MetierORM.getMetier(idMetier); // Plus propre que d'aller chercher le métier dans la DAO.
                EspeceViewModel p = new EspeceViewModel(element.idEspeceDAO, element.nomEspeceDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateEspece(EspeceViewModel u)
        {
            EspeceDAO.updateEspece(new EspeceDAO(u.idEspeceProperty, u.nomEspeceProperty));
        }

        public static void supprimerEspece(int id)
        {
            EspeceDAO.supprimerEspece(id);
        }

        public static void insertEspece(EspeceViewModel u)
        {
            EspeceDAO.insertEspece(new EspeceDAO(u.idEspeceProperty, u.nomEspeceProperty));
        }
    }
}
