using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class KutyaNev
    {
        private int id;
        private string nev;
        public int ID
        {
        get { return id; }
        }
        public string Nev
        {
            get { return nev; }
        }
        public KutyaNev(int id, string nev)
        {
            this.id = id;
            this.nev = nev;
        }
    }