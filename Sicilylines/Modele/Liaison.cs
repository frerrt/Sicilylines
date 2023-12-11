using Sicilylines.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sicilylines.Modele
{
    [Serializable]
    public class Liaison
    {
        public int idLiaisons;
        private string portDepart;
        private string duree;
        private string portArrivee;
        
        public string secteur;
        private List<Tarifier> comptes = new List<Tarifier>();



        public Liaison(int idLiaisons, string portArrivee, string portDepart,string duree,string secteur)
        {
            this.idLiaisons = idLiaisons;
            this.portDepart = portDepart;
            this.PortArrivee = portArrivee;
            this.secteur = secteur;
            this.duree = duree;

        }

        public Liaison()
        {
            

        }

        public int IdLiaison { get => idLiaisons; set => idLiaisons = value; }
       
        public string Secteur { get => secteur; set => secteur = value; }
        public string PortDepart { get => portDepart; set => portDepart = value; }
        public string PortArrivee { get => portArrivee; set => portArrivee = value; }
        public string Duree { get => duree; set => duree = value; }

        public override string ToString()
        {
            return (this.idLiaisons + "" + this.portArrivee+ "" + this.duree+ ""+this.portDepart + " " + this.secteur);
    }
    }

   

}
