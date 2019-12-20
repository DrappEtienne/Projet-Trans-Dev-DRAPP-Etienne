using Projet_Trans_Dev.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Trans_Dev.DAO
{
    class UserDAO
    {

        public int idUserDAO;
        public string nomUserDAO;
        public string prenomUserDAO;
        public string identifiantUserDAO;
        public string motdepasseUserDAO;
        public byte administrateurUserDAO;

        public UserDAO(int idUserDAO, string nomUserDAO, string prenomUserDAO, string identifiantUserDAO, string motdepasseUserDAO, byte administrateurUserDAO)
        {
            this.idUserDAO = idUserDAO;
            this.nomUserDAO = nomUserDAO;
            this.prenomUserDAO = prenomUserDAO;
            this.identifiantUserDAO = identifiantUserDAO;
            this.motdepasseUserDAO = motdepasseUserDAO;
            this.administrateurUserDAO = administrateurUserDAO;
        }

        public static ObservableCollection<UserDAO> listeUser()
        {
            ObservableCollection<UserDAO> l = UserDAL.selectUsers();
            return l;
        }

        public static UserDAO getUser(int idUser)
        {
            UserDAO u = UserDAL.getUser(idUser);
            return u;
        }

        public static void updateUser(UserDAO u)
        {
            UserDAL.updateUser(u);
        }

        public static void supprimerUser(int id)
        {
            UserDAL.supprimerUser(id);
        }

        public static void insertUser(UserDAO u)
        {
            UserDAL.insertUser(u);
        }
    }
}
