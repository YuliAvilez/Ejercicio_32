using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_32
{
    public class CalculoMatricula
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool repetir = true;

                while (repetir)
                {
                    Console.WriteLine("Ingrese el número de créditos del estudiante:");
                    int creditos = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el valor por crédito:");
                    decimal valorCredito = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el estrato del estudiante (1, 2 o 3):");
                    int estrato = int.Parse(Console.ReadLine());

                    // Crear una instancia de la clase Estudiante
                    Estudiante estudiante = new Estudiante(creditos, valorCredito, estrato);

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
            // Propiedades privadas
            private int creditos;
            private decimal valorCredito;
            private int estrato;

            // Constructor de la clase Estudiante
            public Estudiante(int creditos, decimal valorCredito, int estrato)
            {
                this.creditos = creditos;
                this.valorCredito = valorCredito;
                this.estrato = estrato;
            }

        }
}
