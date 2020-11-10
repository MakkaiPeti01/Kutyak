using System;
using System.IO;
using System.Collections.Generic;

class MainClass
{
    static List<KutyaNev> kutyaNevek = new List<KutyaNev>();
    public static void Main(string[] args)
    {
        StreamReader be = new StreamReader("KutyaNevek.csv");
        be.ReadLine();
        while (!be.EndOfStream)
        {
            string[] adat = be.ReadLine().Split(';');
            kutyaNevek.Add(new KutyaNev(Convert.ToInt32(adat[0]), adat[1]));
        }
        be.Close();
        /*foreach (var k in kutyaNevek)
        {
            Console.WriteLine(k.Nev);
        }*/
        Console.WriteLine("3. feladat: Kutyanevek száma: {0}", kutyaNevek.Count);
        Console.ReadKey();
    }
}