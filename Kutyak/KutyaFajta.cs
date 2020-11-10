using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class KutyaFajta
    {
        private int id;
        private string nev;
        private string eredetinev;
        public int ID { get { return id; } }
        public string Nev { get { return nev; } }
        public string EredetiNev { get { return eredetinev; } }
        public KutyaFajta(int id, string nev, string eredetinev)
        {
            this.id = id;
            this.nev = nev;
            this.eredetinev = eredetinev;
        }
    }

