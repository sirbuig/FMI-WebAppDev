/*Cerința: Două clase 'Angajat', 'Proiect'
         Atribute 'Angajat': nume, prenume, salariu lista de proiecte la care lucreaza
         Atribute 'Proiect': nume, durata
         Se cere lista de Angajati, fiecare cu mai multe proiecte la care lucreaza si sa se afiseze 
         informatii despre angajati si proiectele lor*/

using Lab1_Tema;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Angajat angajat1 = new Angajat("Popescu", "Ion", 6000);
        angajat1.Proiecte.Add(new Proiect("Aplicatie A", 6));
        angajat1.Proiecte.Add(new Proiect("Aplicatie B", 3));

        Angajat angajat2 = new Angajat("Ionescu", "Ana", 8700);
        angajat2.Proiecte.Add(new Proiect("Aplicatie C", 8));

        Angajat angajat3 = new Angajat();
        angajat3.Nume = "John";
        angajat3.Prenume = "Smith";
        angajat3.Salariu = 4000;
        angajat3.Proiecte.Add(new Proiect("Aplicatie D", 2));

        List<Angajat> listaAngajati = new List<Angajat>
        {
            angajat1,
            angajat2,
            angajat3
        };

        foreach(var angajat in listaAngajati)
        {
            angajat.PrintProiecte();
            Console.WriteLine();
        }
    }
}