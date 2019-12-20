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
    public class EtudeORM
    {
        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO uDAO = EtudeDAO.getEtude(idEtude);
            int idUser = uDAO.idUserEtudeDAO;
            UserViewModel d = UserORM.getUser(idUser);
            EtudeViewModel u = new EtudeViewModel(uDAO.idEtudeDAO, uDAO.titreEtudeDAO, uDAO.dateEtudeDAO, uDAO.nombrePersonneEtudeDAO, d);
            return u;
        }


        public static ObservableCollection<EtudeViewModel> listeEtudes()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtude();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {
                int idUser = element.idUserEtudeDAO;
                UserViewModel d = UserORM.getUser(idUser);
                EtudeViewModel p = new EtudeViewModel(element.idEtudeDAO, element.titreEtudeDAO, element.dateEtudeDAO, element.nombrePersonneEtudeDAO, d);
                l.Add(p);
            }
            return l;
        }


        public static void updateEtude(EtudeViewModel u)
        {
            EtudeDAO.updateEtude(new EtudeDAO(u.idEtudeProperty, u.titreEtudeProperty, u.dateEtudeProperty, u.nombrePersonneEtudeProperty, u.userEtude.idUser));
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAO.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel u)
        {
            EtudeDAO.insertEtude(new EtudeDAO(u.idEtudeProperty, u.titreEtudeProperty, u.dateEtudeProperty, u.nombrePersonneEtudeProperty, u.userEtude.idUser));
        }
    }
}
