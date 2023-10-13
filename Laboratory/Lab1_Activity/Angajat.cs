using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Activity
{
    public class Angajat
    {
        public string Nume {  get; set; }
        public string Prenume { get; set; }
        public double Salariu {  get; set; }
        public List<Proiect> Proiecte { get; set; }

        public Angajat() {
            Proiecte = new List<Proiect>();
        }

        public Angajat(string nume, string prenume, double salariu) 
        {
            Nume = nume;
            Prenume = prenume;
            Salariu = salariu;
            Proiecte = new List<Proiect>();
        }

        public void PrintProiecte()
        {
            Console.WriteLine($"Angajat: {Nume} {Prenume}");
            Console.WriteLine($"Salariu: {Salariu:C}");
            Console.WriteLine("Proiecte:");

            foreach (var proiect in Proiecte)
            {
                Console.WriteLine($"- {proiect.Nume} (Durata: {proiect.Durata} luni)");
            }
        }
    }
}
