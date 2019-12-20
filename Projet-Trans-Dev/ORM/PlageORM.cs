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
    public class PlageORM
    {
        public static PlageViewModel getPlage(int idPlage)
        {
            PlageDAO uDAO = PlageDAO.getPlage(idPlage);
            int idCommune = uDAO.idCommunePlageDAO;
            CommuneViewModel d = CommuneORM.getCommune(idCommune);
            PlageViewModel u = new PlageViewModel(uDAO.idPlageDAO, uDAO.nomPlageDAO, uDAO.superficiePlageDAO, d);
            return u;
        }


        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlage();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                int idCommune = element.idCommunePlageDAO;

                CommuneViewModel d = CommuneORM.getCommune(idCommune); // Plus propre que d'aller chercher le métier dans la DAO.
                PlageViewModel p = new PlageViewModel(element.idPlageDAO, element.nomPlageDAO, element.superficiePlageDAO, d);
                l.Add(p);
            }
            return l;
        }


        public static void updatePlage(PlageViewModel u)
        {
            PlageDAO.updatePlage(new PlageDAO(u.idPlageProperty, u.nomPlageProperty, u.superficiePlageProperty, u.CommunePlage.idCommune));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAO.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel u)
        {
            PlageDAO.insertPlage(new PlageDAO(u.idPlageProperty, u.nomPlageProperty, u.superficiePlageProperty, u.CommunePlage.idCommune));
        }
    }
}
