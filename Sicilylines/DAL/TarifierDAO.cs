using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sicilylines.DAL;
using Sicilylines.Modele;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Sicilylines.DAL
 
{
    class TarifierDAO
    {
        private Liaison liaisons;

        private ConnexionSql maConnexionSql;
        List<Tarifier> ltl = new List<Tarifier>();




        private MySqlCommand Ocom;

        private LiaisonDAO liaisondao;


        public List<Tarifier> getTarifier(Liaison liaison)
        {

           

            try
            {

                maConnexionSql = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("Select periode_id,liaison_id,type_id from Tarifer  where liaison_id  = " + liaison.idLiaisons);


                MySqlDataReader reader1 = Ocom.ExecuteReader();

                 liaisondao = new LiaisonDAO();

                while (reader1.Read())
                {
                    int idPeriode = (int)reader1.GetValue(0);
                    int idType  = (int)reader1.GetValue(1);
                    int idLiaisons = (int)reader1.GetValue(2);
                   

          //      liaisons = liaisondao.getLiaison(idLiaisons);


                    Tarifier t = new Tarifier(idPeriode,idType,liaison.idLiaisons);

                    ltl.Add(t);
                   




                }

                reader1.Close();

                maConnexionSql.closeConnection();


            }




            catch (Exception emp)
            {

                MessageBox.Show(emp.Message);

            }

            return ltl;



        }











    }
}