using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicilylines.Modele
{
    public class Tarifier
    {
        private int idPeriode;

        private int idType;
        private int idLiaisons;

        public int IdPeriode { get => idPeriode; set => idPeriode = value; }
        public int IdType { get => idType; set => idType = value; }
        public int IdLiaisons { get => idLiaisons; set => idLiaisons = value; }

        public Tarifier(int idPeriode,  int idType, int idLiaisons)
        {
            this.IdPeriode = idPeriode;
            
            this.IdType= idType;
            this.IdLiaisons = idLiaisons;

        }

        public virtual string Description()
        {
            return (this.IdLiaisons + "" + this.IdType + " " + this.IdPeriode);
        }
    }
}
