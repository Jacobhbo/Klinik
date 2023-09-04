using Lægeklinik.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lægeklinik.Codes
{
    internal class Patient : Person
    {
        public List<Læge> TildelteLæger { get; } = new List<Læge>();

        public Patient(string fornavn, string efternavn, int tlfnr) : base(fornavn, efternavn, tlfnr)
        {
            TildelteLæger = new List<Læge>();
        }
    }
}