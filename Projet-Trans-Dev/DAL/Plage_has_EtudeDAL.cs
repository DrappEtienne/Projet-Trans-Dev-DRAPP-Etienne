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
    class Plage_has_EtudeDAL
    {
        private static MySqlConnection connection;
        public Plage_has_EtudeDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<Plage_has_EtudeDAO> selectPlage_has_Etudes()
        {
            ObservableCollection<Plage_has_EtudeDAO> l = new ObservableCollection<Plage_has_EtudeDAO>();
            string query = "SELECT * FROM Plage_has_Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Plage_has_EtudeDAO p = new Plage_has_EtudeDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetDecimal(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8));
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

        public static void updatePlage_has_Etude(Plage_has_EtudeDAO p)
        {
            string query = "UPDATE Plage_has_Etude set Etude_idEtudePlage_has_Etude=@etude,Plage_idPlagePlage_has_Etude=@plage,Date=@date,Angle1=@angle1,Angle2=@angle2,Angle3=@angle3, Angle4=@angle4, superficieZoneEtudiee=@superficie where numZone=@IDZone;";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            cmd2.Parameters.AddWithValue("@IDZone", p.numZonePlage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@etude", p.idEtudePlage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@plage", p.idPlagePlage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@date", p.DatePlage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@angle1", p.Angle1Plage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@angle2", p.Angle2Plage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@angle3", p.Angle3Plage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@angle4", p.Angle4Plage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@superficie", p.superficieZoneEtudieePlage_has_EtudeDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void insertPlage_has_Etude(Plage_has_EtudeDAO p)
        {
            int id = getMaxnumZone() + 1;
            string query = "INSERT INTO Plage_has_Etude ( numZone,Etude_idEtude, Plage_idPlage, Date, Angle1, Angle2, Angle3, Angle4, superficieZoneEtudiee) VALUES (@IDZone, @etude, @plage, @date, @angle1, @angle2, @angle3, @angle4, @Superficie);";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            cmd2.Parameters.AddWithValue("@IDZone", id);
            cmd2.Parameters.AddWithValue("@etude", p.idEtudePlage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@plage", p.idPlagePlage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@date", p.DatePlage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@angle1", p.Angle1Plage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@angle2", p.Angle2Plage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@angle3", p.Angle3Plage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@angle4", p.Angle4Plage_has_EtudeDAO);
            cmd2.Parameters.AddWithValue("@Superficie", p.superficieZoneEtudieePlage_has_EtudeDAO);

            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }

        public static void supprimerPlage_has_Etude(int id)
        {
            string query = "DELETE FROM Plage_has_Etude WHERE numZone = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static int getMaxnumZone()
        {
            string query = "SELECT IFNULL(MAX(numZone),0) FROM Plage_has_Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxnumZone = reader.GetInt32(0);
            reader.Close();
            return maxnumZone;
        }

        /*public static int getMaxnumZone()
        {
            string query = "SELECT IFNULL(MAX(Etude_idEtude, Plage_idPlage),0,0,0) FROM Plage_has_Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxnumZone = reader.GetInt32(0);
            reader.Close();
            return maxnumZone;
        }*/

        public static Plage_has_EtudeDAO getPlage_has_Etude(int numZone)
        {
            string query = "SELECT * FROM Plage_has_Etude WHERE id=" + numZone + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Plage_has_EtudeDAO pers = new Plage_has_EtudeDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetDecimal(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8));
            reader.Close();
            return pers;
        }
    }
}
