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
    public class Plage_has_EtudeORM
    {
        public static Plage_has_EtudeViewModel getPlage_has_Etude(int numZone)
        {
            Plage_has_EtudeDAO uDAO = Plage_has_EtudeDAO.getPlage_has_Etude(numZone);

            int idEtude = uDAO.idEtudePlage_has_EtudeDAO;
            EtudeViewModel d = EtudeORM.getEtude(idEtude);

            int idPlage = uDAO.idPlagePlage_has_EtudeDAO;
            PlageViewModel i = PlageORM.getPlage(idPlage);

            Plage_has_EtudeViewModel u = new Plage_has_EtudeViewModel(uDAO.numZonePlage_has_EtudeDAO, d, i, uDAO.DatePlage_has_EtudeDAO, uDAO.Angle1Plage_has_EtudeDAO, uDAO.Angle2Plage_has_EtudeDAO, uDAO.Angle3Plage_has_EtudeDAO, uDAO.Angle4Plage_has_EtudeDAO, uDAO.superficieZoneEtudieePlage_has_EtudeDAO );
            return u;
        }


        public static ObservableCollection<Plage_has_EtudeViewModel> listePlage_has_Etudes()
        {
            ObservableCollection<Plage_has_EtudeDAO> lDAO = Plage_has_EtudeDAO.listePlage_has_Etude();
            ObservableCollection<Plage_has_EtudeViewModel> l = new ObservableCollection<Plage_has_EtudeViewModel>();
            foreach (Plage_has_EtudeDAO element in lDAO)
            {
                int idEtude = element.idEtudePlage_has_EtudeDAO;
                EtudeViewModel d = EtudeORM.getEtude(idEtude); // Plus propre que d'aller chercher le métier dans la DAO.

                int idPlage = element.idPlagePlage_has_EtudeDAO;
                PlageViewModel i = PlageORM.getPlage(idPlage);

                Plage_has_EtudeViewModel p = new Plage_has_EtudeViewModel(element.numZonePlage_has_EtudeDAO, d, i, element.DatePlage_has_EtudeDAO, element.Angle1Plage_has_EtudeDAO, element.Angle2Plage_has_EtudeDAO, element.Angle3Plage_has_EtudeDAO, element.Angle4Plage_has_EtudeDAO, element.superficieZoneEtudieePlage_has_EtudeDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updatePlage_has_Etude(Plage_has_EtudeViewModel u)
        {
            Plage_has_EtudeDAO.updatePlage_has_Etude(new Plage_has_EtudeDAO(u.numZonePlage_has_EtudeProperty, u.PlagePlage_has_EtudeProperty.idPlageProperty, u.EtudePlage_has_Etude.idEtudeProperty, u.DatePlage_has_EtudeProperty, u.Angle1Plage_has_EtudeProperty, u.Angle2Plage_has_EtudeProperty, u.Angle3Plage_has_EtudeProperty, u.Angle4Plage_has_EtudeProperty, u.superficieZoneEtudieePlage_has_Etude));
        }

        public static void supprimerPlage_has_Etude(int id)
        {
            Plage_has_EtudeDAO.supprimerPlage_has_Etude(id);
        }

        public static void insertPlage_has_Etude(Plage_has_EtudeViewModel u)
        {
            Plage_has_EtudeDAO.insertPlage_has_Etude(new Plage_has_EtudeDAO(u.numZonePlage_has_EtudeProperty, u.PlagePlage_has_EtudeProperty.idPlageProperty, u.EtudePlage_has_Etude.idEtudeProperty, u.DatePlage_has_EtudeProperty, u.Angle1Plage_has_EtudeProperty, u.Angle2Plage_has_EtudeProperty, u.Angle3Plage_has_EtudeProperty, u.Angle4Plage_has_EtudeProperty, u.superficieZoneEtudieePlage_has_Etude));
        }
    }
}
