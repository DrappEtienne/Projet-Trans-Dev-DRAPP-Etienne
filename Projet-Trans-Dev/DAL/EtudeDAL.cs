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
    class EtudeDAL
    {
        private static MySqlConnection connection;
        public EtudeDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<EtudeDAO> selectEtudes()
        {
            ObservableCollection<EtudeDAO> l = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * FROM Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EtudeDAO p = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
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

        public static void updateEtude(EtudeDAO p)
        {
            string query = "UPDATE Etude set Titre =\"" + p.titreEtudeDAO + "\", Date=\"" + p.dateEtudeDAO + "\", nombrePersonne=\"" + p.nombrePersonneEtudeDAO + "\", User_idUser=\"" + p.idUserEtudeDAO + "\" where idEtude=" + p.idEtudeDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static void insertEtude(EtudeDAO p)
        {
            int id = getMaxIdEtude() + 1;
            string query = "INSERT INTO Etude VALUES (@ID,@Titre,@Date,@nombrePersonne,@idUser);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Titre", p.titreEtudeDAO);
            cmd.Parameters.AddWithValue("@Date", p.dateEtudeDAO);
            cmd.Parameters.AddWithValue("@nombrePersonne", p.nombrePersonneEtudeDAO);
            cmd.Parameters.AddWithValue("@idUser", p.idUserEtudeDAO);


            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM Etude WHERE idEtude = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static int getMaxIdEtude()
        {
            string query = "SELECT IFNULL(MAX(idEtude),0) FROM Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM Etude WHERE idEtude=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EtudeDAO pers = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
            reader.Close();
            return pers;
        }
    }
}
