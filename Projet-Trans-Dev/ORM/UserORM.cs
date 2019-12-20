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
    public class UserORM
    {
        public static UserViewModel getUser(int idUser)
        {
            UserDAO uDAO = UserDAO.getUser(idUser);
            //int idMetier = pDAO.idMetierUserDAO;
            //MetierViewModel m = MetierORM.getMetier(idMetier);
            UserViewModel u = new UserViewModel(uDAO.idUserDAO, uDAO.nomUserDAO, uDAO.prenomUserDAO, uDAO.identifiantUserDAO, uDAO.motdepasseUserDAO, uDAO.administrateurUserDAO);
            return u;
        }

        public static ObservableCollection<UserViewModel> listeUsers()
        {
            ObservableCollection<UserDAO> lDAO = UserDAO.listeUser();
            ObservableCollection<UserViewModel> l = new ObservableCollection<UserViewModel>();
            foreach (UserDAO element in lDAO)
            {
               // int idMetier = element.idMetierUserDAO;

                //MetierViewModel m = MetierORM.getMetier(idMetier); // Plus propre que d'aller chercher le métier dans la DAO.
                UserViewModel p = new UserViewModel(element.idUserDAO, element.nomUserDAO, element.prenomUserDAO, element.identifiantUserDAO, element.motdepasseUserDAO, element.administrateurUserDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateUser(UserViewModel u)
        {
            UserDAO.updateUser(new UserDAO(u.idUserProperty, u.nomUserProperty, u.prenomUserProperty, u.identifiantUserProperty, u.motdepasseUserProperty, u.administrateurUserProperty));
        }

        public static void supprimerUser(int id)
        {
            UserDAO.supprimerUser(id);
        }

        public static void insertUser(UserViewModel u)
        {
            UserDAO.insertUser(new UserDAO(u.idUserProperty, u.nomUserProperty, u.prenomUserProperty, u.identifiantUserProperty, u.motdepasseUserProperty, u.administrateurUserProperty));
        }
    }
}
