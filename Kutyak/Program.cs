using System;
using System.IO;
using System.Collections.Generic;

class MainClass
{
    static List<KutyaNev> kutyaNevek = new List<KutyaNev>();
    static List<KutyaFajta> kutyaFajtak = new List<KutyaFajta>();
    static List<Kutya> kutyaLista = new List<Kutya>();
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
        foreach (var i in kutyaLista)
        {
            Console.WriteLine(i.Eletkor);
        }
    }
    static void AtlagEletkor()
    {
        //2 tizedesre az átlagéletkort
        double atlag;
        int sum = 0;
        foreach (var i in kutyaLista)
        {
        }
    }
    public static void Main(string[] args)
    {
        Beolvasas();
        Harmadik();
        BeolvasasKutyaFajta();
        BeolvasasKutyak();
        AtlagEletkor();
        Console.ReadKey();
    }
}