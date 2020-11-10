using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Kutya
    {
        private int id;
        private int fajta_id;
        private int nev_id;
        private int eletkor;
        private string vizsgalat;
        public int ID { get { return id; } }
        public int Fajta_ID { get { return fajta_id; } }
        public int Nev_ID { get { return nev_id; } }
        public int Eletkor { get { return eletkor; } }
        public string Vizsgalat { get { return vizsgalat; } }
    public Kutya(int id, int fajta_id, int nev_id, int eletkor, string vizsgalat)
        {
            this.id = id;
            this.fajta_id = fajta_id;
            this.nev_id = nev_id;
            this.eletkor = eletkor;
            this.vizsgalat = vizsgalat;
        }
    }
