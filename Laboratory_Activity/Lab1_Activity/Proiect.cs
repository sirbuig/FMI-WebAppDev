using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Activity
{
    public class Proiect
    {
        public string Nume {  get; set; }
        public int Durata { get; set; }

        public Proiect() { }
        public Proiect(string nume, int durata) 
        {
            Nume = nume;
            Durata = durata;
        }
    }
}
