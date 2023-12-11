using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sicilylines.DAL;
using Sicilylines.Modele;
using MySql.Data.MySqlClient;

namespace Sicilylines.Controleur
{
    class Mg
    {
        LiaisonDAO liaison1 = new LiaisonDAO();
        TarifierDAO tarifDao = new TarifierDAO();

        public List<Liaison> chargementLiaison()
        {
            return (liaison1.GetLiaison());
        }

        public List<Tarifier> chargementTarif(Liaison ll)
        {

            return (tarifDao.getTarifier(ll));

        }

        public void SupprimerLiaison(int id)
        {
            liaison1.SupprimerLiaison(id);
        }

        public void AjouterLiaisons(int duree, int secteur, int port_arrive, int port_depart)
        {
            liaison1.AjouterLiaisons(duree, secteur, port_arrive, port_depart);
        }

        public void modifLiaison(Liaison modifL)
        {
            liaison1.modifLiaison(modifL);
        }


    }
}
