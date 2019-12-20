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
    public class CommuneORM
    {
        public static CommuneViewModel getCommune(int idCommune)
        {
            CommuneDAO uDAO = CommuneDAO.getCommune(idCommune);
            int idDepartement = uDAO.idDepartementCommuneDAO;
            DepartementViewModel d = DepartementORM.getDepartement(idDepartement);
            CommuneViewModel u = new CommuneViewModel(uDAO.idCommuneDAO, uDAO.nomCommuneDAO, d);
            return u;
        }


        public static ObservableCollection<CommuneViewModel> listeCommunes()
        {
            ObservableCollection<CommuneDAO> lDAO = CommuneDAO.listeCommune();
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in lDAO)
            {
                int idDepartement = element.idDepartementCommuneDAO;

                DepartementViewModel d = DepartementORM.getDepartement(idDepartement); // Plus propre que d'aller chercher le métier dans la DAO.
                CommuneViewModel p = new CommuneViewModel(element.idCommuneDAO, element.nomCommuneDAO, d);
                l.Add(p);
            }
            return l;
        }


        public static void updateCommune(CommuneViewModel u)
        {
            CommuneDAO.updateCommune(new CommuneDAO(u.idCommuneProperty, u.nomCommuneProperty, u.departementCommune.idDepartement));
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }

        public static void insertCommune(CommuneViewModel u)
        {
            CommuneDAO.insertCommune(new CommuneDAO(u.idCommuneProperty, u.nomCommuneProperty, u.departementCommune.idDepartement));
        }
    }
}
