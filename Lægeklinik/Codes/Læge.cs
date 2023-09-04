using Lægeklinik.Interface;
using System;
using System.Collections.Generic;

namespace Lægeklinik.Codes
{
    internal class Læge : Person, IPerson
    {
        public string Specialitet { get; }
        public List<Patient> TildeltePatienter { get; } = new List<Patient>();  // List to store associated patients

        public Læge(string fornavn, string efternavn, int tlfnr, string specialitet) : base(fornavn, efternavn, tlfnr)
        {
            Specialitet = specialitet;
        }

        public void TildelPatient(Patient patient)
        {
            // Tjek antallet af patienter tildelt lægen
            if (TildeltePatienter.Count >= 3)
            {
                Console.WriteLine("Advarsel: Lægen har allerede 3 eller flere patienter.");
                return;
            }

            // Tjek for kombinationen af Kirurgi og Onkologi
            if (TildeltePatienter.Exists(p => p.TildelteLæger.Exists(l => l.Specialitet == "Kirurgi" || l.Specialitet == "Onkologi")) &&
                (patient.TildelteLæger.Exists(l => l.Specialitet == "Kirurgi" || l.Specialitet == "Onkologi")))
            {
                Console.WriteLine("Advarsel: En patient kan ikke have Kirurgi og Onkologi samtidig.");
                return;
            }

            TildeltePatienter.Add(patient);
        }
    }
}
