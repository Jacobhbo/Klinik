using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lægeklinik.Codes
{
    abstract class Person
    {
        public string? ForNavn { get; set; }
        public string? EfterNavn { get; set; }
        public int TlfNr { get; set; }

        public Person(string? fornavn, string? efternavn, int tlfnr)
        {
            ForNavn = fornavn;
            EfterNavn = efternavn;
            TlfNr = tlfnr;
        }
    }
}