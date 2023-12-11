using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Sicilylines.Modele;

namespace Sicilylines.DAL
{
    [Serializable]
   public class LiaisonDAO
    {
        private ConnexionSql maConnexionSql;
        
        private MySqlCommand Ocom;

        public Liaison getLiaison(int idLiaison)
        {

            try
            {
                Liaison liaison = new Liaison();



                maConnexionSql = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("Select * from Liaison where numero = " + idLiaison);


                MySqlDataReader reader = Ocom.ExecuteReader();


                while (reader.Read())
                {

                    idLiaison = (int)reader.GetValue(0);
                     string secteur = (string)reader.GetValue(1);
                     string duree = (string)reader.GetValue(2);
                    string portArrivee = (string)reader.GetValue(3);
                    string portDepart = (string)reader.GetValue(1);


                    liaison = new Liaison(idLiaison, secteur, portArrivee, duree, portDepart);




                }


                reader.Close();

                maConnexionSql.closeConnection();


                return (liaison);

            }

            catch (Exception emp)
            {

                throw (emp);
            }
        }


        public List<Liaison> GetLiaison()
        {
            List<Liaison> lc = new List<Liaison>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("SELECT liaison.id,duree ,dep.nom,arriv.nom FROM liaison inner join port dep on liaison.port_depart_id = dep.id inner join secteur s on secteur_id = s.id inner join port arriv on port_arrive_id=arriv.id");


                MySqlDataReader reader = Ocom.ExecuteReader();

                Liaison lc1;




                while (reader.Read())
                {

                   int  idLiaison = (int)reader.GetValue(0);
                    string duree = (string)reader.GetValue(1);
                    string portDepart = (string)reader.GetValue(2);
                    string portArrivee = (string)reader.GetValue(3);
                    
                    string secteur = (string)reader.GetValue(4);





                    lc1 = new  Liaison(idLiaison,duree,portDepart,portArrivee,secteur);

                    lc.Add(lc1);


                }



                reader.Close();

                maConnexionSql.closeConnection();


            }




            catch (Exception emp)
            {

                MessageBox.Show(emp.Message);

            }
           
            return (lc);
        }


        public void SupprimerLiaison(int id)
        {
            


            MySqlCommand mysqlCom = new MySqlCommand();
            maConnexionSql.openConnection();
            mysqlCom = maConnexionSql.reqExec("delete from Liaison where id =" + id);

           
                mysqlCom.ExecuteNonQuery();
                MessageBox.Show(" Suppression reussi");
                maConnexionSql.closeConnection();

            

           

            

        }

        public void AjouterLiaisons(int duree, int secteur, int port_arrive, int port_depart)
        {



            MySqlCommand mysqlCom = new MySqlCommand();
            maConnexionSql.openConnection();
            mysqlCom = maConnexionSql.reqExec("insert into Liaison(duree,secteur_id,port_arrive_id,port_depart_id) values('" + duree + "','" + secteur + "', '" + port_arrive + " ','" + port_depart + "')");

            mysqlCom.ExecuteNonQuery();
            MessageBox.Show(" L'ajout est reussi");
            maConnexionSql.closeConnection();

        }


        public void modifLiaison(Liaison modifL)
        {

            try
            {




                maConnexionSql = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("update client set duree = '" + modifL.Duree + "' where id = " + modifL.idLiaisons);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }
        }




    }
}
