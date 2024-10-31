using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_32
{
        class Program
        {
            static void Main(string[] args)
            {
                bool repetir = true;

                while (repetir)
                {
                    Estudiante estudiante = new Estudiante();

                    Console.WriteLine("Ingrese el número de créditos del estudiante:");
                    estudiante.Creditos = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el valor por crédito:");
                    estudiante.ValorCredito = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el estrato del estudiante (1, 2 o 3):");
                    estudiante.Estrato = int.Parse(Console.ReadLine());

                    decimal costoMatricula = estudiante.CalcularMatricula();
                    decimal subsidio = estudiante.ObtenerSubsidio();

                    Console.WriteLine($"\nCosto de matrícula: {costoMatricula:C}");
                    Console.WriteLine($"Subsidio: {subsidio:C}\n");

                    Console.WriteLine("¿Desea calcular otra matrícula? (s/n)");
                    repetir = Console.ReadLine().ToLower() == "s";
                }

                Console.WriteLine("Programa finalizado.");
            }
        }

        class Estudiante
        {
            // Propiedades públicas
            public int Creditos {get;set;}
            public decimal ValorCredito { get; set; }
            public int Estrato { get; set; }

            // Método para calcular la matrícula
            public decimal CalcularMatricula()
            {
                decimal costoNormal = Creditos * ValorCredito;
                decimal costoExtra = (Creditos > 20) ? (Creditos - 20) * ValorCredito * 2 : 0;
                decimal total = costoNormal + costoExtra;

                decimal descuento = Estrato switch
                {
                    1 => 0.80m,
                    2 => 0.50m,
                    3 => 0.30m,
                    _ => 0.0m
                };

                return total * (1 - descuento);
            }

            // Método para obtener el subsidio
            public decimal ObtenerSubsidio()
            {
                return Estrato switch
                {
                    1 => 200000,
                    2 => 100000,
                    _ => 0
                };
            }
        }
 
}