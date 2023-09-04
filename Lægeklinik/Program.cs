using Lægeklinik.Codes;
using Lægeklinik.Interface;
using System;
using System.Collections.Generic;

namespace Lægeklinik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tilføjer Læger til listen
            Læge øjenlæge = new Læge("Peter", "Hansen", 11111111, "Øjenlæge");
            Læge radiologi = new Læge("Martin", "Jensen", 22222222, "Radiologi");
            Læge kirurgi = new Læge("Thomas", "Olsen", 33333333, "Kirurgi");
            Læge onkologi = new Læge("Ole", "Nielsen", 44444444, "Onkologi");

            List<Læge> læger = new List<Læge> { øjenlæge, radiologi, kirurgi, onkologi };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Velkommen til Lægeklinikken");
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("\nVælg en af de her læger som du ville tilføje patienter til eller skriv 'afslut' for at få vist lægen og patienterne");

                foreach (Læge læge in læger)
                {
                    Console.WriteLine($"{læge.Specialitet}: {læge.ForNavn} {læge.EfterNavn}");
                }



                Console.Write("Skriv lægens specialitet: ");
                string? valgtLægeNavn = Console.ReadLine();



                if (valgtLægeNavn.ToLower() == "afslut")
                {
                    foreach (Læge læge in læger)
                    {
                        Console.WriteLine($"\n{læge.Specialitet}: {læge.ForNavn} {læge.EfterNavn}");
                        Console.WriteLine("Tilknyttede patienter:");
                        foreach (Patient patient in læge.TildeltePatienter)
                        {
                            Console.WriteLine($"Patient: {patient.ForNavn} {patient.EfterNavn} - Tlf.nr.: {patient.TlfNr}");
                        }
                    }
                    break;
                }



                Læge valgtLæge = null;

                switch (valgtLægeNavn.ToLower())
                {
                    case "øjenlæge":
                        valgtLæge = øjenlæge;
                        break;
                    case "radiologi":
                        valgtLæge = radiologi;
                        break;
                    case "kirurgi":
                        valgtLæge = kirurgi;
                        break;
                    case "onkologi":
                        valgtLæge = onkologi;
                        break;
                    default:
                        Console.WriteLine("Ugyldigt lægenavn.");
                        break;
                }

                if (valgtLæge == null)
                {
                    continue;
                }


                Console.WriteLine("\nIndtast patientens oplysninger:");
                Console.Write("Patient fornavn: ");
                string? fornavn = Console.ReadLine();

                Console.Write("Patient efternavn: ");
                string? efternavn = Console.ReadLine();

                Console.Write("Patient tlf.nr.: ");
                string? tlfnrInput = Console.ReadLine();
                if (!int.TryParse(tlfnrInput, out int tlfnr))
                {
                    Console.WriteLine("Ugyldigt Telefonnummer.");
                    continue;
                }

                try
                {
                    Patient patient = new Patient(fornavn, efternavn, tlfnr);
                    valgtLæge.TildelPatient(patient);



                    // DISPLAY
                    Console.Clear();
                    Console.WriteLine($"\nPatienten er tildelt lægen {valgtLæge.ForNavn} ");
                    Console.WriteLine($"Tildelt læge:       {valgtLæge.ForNavn} {valgtLæge.EfterNavn}");
                    Console.WriteLine($"Specialitet:        {valgtLæge.Specialitet}");
                    Console.WriteLine($"Patient fornavn:    {patient.ForNavn}");
                    Console.WriteLine($"Patient efternavn:  {patient.EfterNavn}");
                    Console.WriteLine($"Patient tlf.nr.:    {patient.TlfNr}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}");
                }
            }
        }
    }
}