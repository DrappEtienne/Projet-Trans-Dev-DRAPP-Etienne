using MySql.Data.MySqlClient;
using Projet_Trans_Dev.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projet_Trans_Dev.DAL
{
    class UserDAL
    {
        private static MySqlConnection connection;
        public UserDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<UserDAO> selectUsers()
        {
            ObservableCollection<UserDAO> l = new ObservableCollection<UserDAO>();
            string query = "SELECT * FROM User;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserDAO p = new UserDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetByte(5));
                    l.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return l;
        }

        public static void updateUser(UserDAO p)
        {
            string query = "UPDATE User set Nom=\"" + p.nomUserDAO + "\", Prenom=\"" + p.prenomUserDAO + "\", Identifiant=\"" + p.identifiantUserDAO + "\", MotDePasse=\"" + p.motdepasseUserDAO + "\", Administrateur=\"" + p.administrateurUserDAO + "\" where idUser=" + p.idUserDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertUser(UserDAO p)
        {
            int id = getMaxIdUser() + 1;
            string query = "INSERT INTO User (idUser,Nom,Prenom,Identifiant,MotDePasse,Administrateur) VALUES (\"" + id + "\",\"" + p.nomUserDAO + "\",\"" + p.prenomUserDAO + "\",\""  + p.identifiantUserDAO + "\",\"" + p.motdepasseUserDAO + "\",\"" + p.administrateurUserDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerUser(int id)
        {
            string query = "DELETE FROM User WHERE idUser = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static int getMaxIdUser()
        {
            string query = "SELECT MAX(idUser) FROM User;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdUser = reader.GetInt32(0);
            reader.Close();
            return maxIdUser;
        }

        public static UserDAO getUser(int idUser)
        {
            string query = "SELECT * FROM User WHERE idUser=" + idUser + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UserDAO pers = new UserDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetByte(5));
            reader.Close();
            return pers;
        }
    }
}
