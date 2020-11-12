using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    static List<KutyaNev> kutyaNevek = new List<KutyaNev>();
    static List<KutyaFajta> kutyaFajtak = new List<KutyaFajta>();
    static List<Kutya> kutyaLista = new List<Kutya>();
    static Dictionary<string, int> orvosi = new Dictionary<string, int>();
    static Dictionary<string, int> datum = new Dictionary<string, int>();
    static Dictionary<string, int> nevek = new Dictionary<string, int>();
    static void Beolvasas()
    {
        StreamReader be = new StreamReader("KutyaNevek.csv");
        be.ReadLine();
        while (!be.EndOfStream)
        {
            string[] adat = be.ReadLine().Split(';');
            kutyaNevek.Add(new KutyaNev(Convert.ToInt32(adat[0]), adat[1]));
        }
        be.Close();
    }
    static void Harmadik()
    {
        Console.WriteLine("3. feladat: Kutyanevek száma: {0}", kutyaNevek.Count);
    }
    static void BeolvasasKutyaFajta()
    {
        StreamReader olvas = new StreamReader("KutyaFajtak.csv");
        olvas.ReadLine();
        while (!olvas.EndOfStream)
        {
            string[] adat = olvas.ReadLine().Split(';');
            kutyaFajtak.Add(new KutyaFajta(int.Parse(adat[0]),adat[1],adat[2]));
        }
        olvas.Close();
        //Console.WriteLine(kutyaFajtak.Count);
    }
    static void BeolvasasKutyak()
    {
        StreamReader olvas = new StreamReader("Kutyak.csv");
        olvas.ReadLine();
        while (!olvas.EndOfStream)
        {
            string[] adat = olvas.ReadLine().Split(';');
            kutyaLista.Add(new Kutya(int.Parse(adat[0]), int.Parse(adat[1]), int.Parse(adat[2]), 
                int.Parse(adat[3]), adat[4]));
        }
        olvas.Close();
    }
    static void AtlagEletkor()
    {
        //2 tizedesre az átlagéletkort
        double atlag;
        double sum = 0;
        foreach (var i in kutyaLista)
        {
            sum = sum + i.Eletkor;
        }
        atlag = Math.Round(sum / kutyaLista.Count,2);
        Console.WriteLine($"6. feladat: A kutyák átlagéletkora: {atlag}");
    }
    static void LegidosebbKutya()
    {
        int max = 0;
        int index = 0;
        int nev_index = 0;
        foreach (var i in kutyaLista)
        {
            if (i.Eletkor > max)
            {
                max = i.Eletkor;
                index = i.Fajta_ID;
                nev_index = i.Nev_ID;
            }
        }
        Console.WriteLine(max+" "+index);
        string nev = "";
        string fajta = "";
        foreach (var i in kutyaFajtak)
        {  
          if (index==i.ID)
             {              
                 fajta = i.Nev;
             }
        }
        foreach (var i in kutyaNevek)
        {
            if (nev_index==i.ID)
            {
                nev = i.Nev;
            }
        }
        //Console.WriteLine(index);
        Console.WriteLine($"7. feladat: a Legidősebb kutya neve és fajtája: {nev}, {fajta}");
    }
    static void Nyolcadik()
    {
        //2018.01.10 fajtánként
        int index = 0;
        foreach (var i in kutyaLista)
        {
            foreach (var k in kutyaFajtak)
            {
                if (i.Vizsgalat.Contains("2018.01.10"))
                {
                    index = i.Fajta_ID;
                }
                if (index == k.ID)
                {
                    if (!orvosi.ContainsKey(k.Nev))
                    {
                        orvosi.Add(k.Nev, 0);
                    }
                }
            }
        }
        foreach (var i in kutyaFajtak)
        {
            if (orvosi.ContainsKey(i.Nev))
            {
                orvosi[i.Nev]++;
            }
        }
        Console.WriteLine("8. feladat: Január 10.én vizsgált kutya fajták:");
        foreach (var i in orvosi)
        {
            Console.WriteLine($"\t {i.Key}: {i.Value} kutya");
        }
    }
    static void Kilencedik()
    {
        //legjobban leterhelt nap: vizsgálat dátuma ugyanaz akkor ++ végén maximum és annak adatai (Kutyak.csv)
        foreach (var i in kutyaLista)
        {
            if (!datum.ContainsKey(i.Vizsgalat))
            {
                datum.Add(i.Vizsgalat, 0);
            }
        }
        foreach (var d in kutyaLista)
        {
            if (datum.ContainsKey(d.Vizsgalat))
            {
                datum[d.Vizsgalat]++;
            }
        }
        //Console.WriteLine(datum.Count);
        int max = 0;
        string nap = "";
        foreach (var i in datum)
        {
            if (i.Value > max)
            {
                max = i.Value;
                nap = i.Key;
            }
        }
        Console.WriteLine($"9. feladat: A legjobban leterhelt nap: {nap}: {max} kutya");
    }
    static void Tizes()
    {
        //kutyák neve, fajta alapján hány darab van belőle csőkkenőben
        //Szofi idje(244 KUTYANEVEK) A KUTYÁK.CSV-ben 244(szofi-->230 kutyaid) 230 id -->Lakeland terrier (KUTYAFAJTÁK.CSV)
        foreach (var i in kutyaNevek)
        {
            if (!nevek.ContainsKey(i.Nev))
            {
                nevek.Add(i.Nev, 1);
            }
        }
        foreach (var i in kutyaLista)
        {
            foreach (var k in kutyaNevek)
            {
                if (i.Nev_ID == k.ID)
                {
                    nevek[k.Nev]++;
                }
            }
        }
        foreach (var i in kutyaNevek)
        {
            nevek[i.Nev]--;
            if (nevek[i.Nev] == 0)
            {
                nevek[i.Nev] = 1;
            }
        }
        //foreach (var i in nevek)
        //{
        //    Console.WriteLine("{0} {1}",i.Value,i.Key);
        //}
        Console.WriteLine("10. feladat: névstatisztika.txt");
        StreamWriter iro = new StreamWriter("névstatisztika.txt");
        //Ezt a neten találtam remélem nem baj, nem bonyolult azért mertem így hagyni :D
        //A diksöneri jó feltöltése nagyon krumplis elnézést érte, de működik az a lényeg  
        foreach (KeyValuePair<string, int> i in nevek.OrderByDescending(key => key.Value))
        {
            iro.WriteLine("{0},{1}", i.Key, i.Value);
        }
        iro.Close();
    }
    public static void Main(string[] args)
    {
        Beolvasas();
        Harmadik();
        BeolvasasKutyaFajta();
        BeolvasasKutyak();
        AtlagEletkor();
        LegidosebbKutya();
        Nyolcadik();
        Kilencedik();
        Tizes();
        Console.ReadKey();
    }
}