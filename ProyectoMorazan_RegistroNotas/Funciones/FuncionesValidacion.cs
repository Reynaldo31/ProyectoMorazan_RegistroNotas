using ProyectoMorazan_RegistroNotas.GestorNotas;
using RegistroNotas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoMorazan_RegistroNotas.Validaciones
{
    public static class FuncionesValidacion
    {
        //Funcion para verificar si la opcion es un numero entero y no culquier otro caracter o letra.
        public static int validarOpcion(string opcion)
        {
            while (true)
            {
                Console.WriteLine(opcion);
                string seleccion = Console.ReadLine();
                if (!int.TryParse(seleccion, out int numero))
                {
                    Console.WriteLine($"La opcion: {seleccion} no es válida. Por favor, ingrese un número.");
                }
                else
                {
                    return numero;
                }
            }
        }

        //Funcion para verificar que el nombre no este vacio y sea en letras.
        public static string validarNombreEstudiante(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string nombre = Console.ReadLine();
                Regex nombreValidacion = new Regex(@"^[a-zA-ZÁÉÍÓÚáéíóúÑñ]+(?:\s[a-zA-ZÁÉÍÓÚáéíóúÑñ]+)*$");

                if (string.IsNullOrEmpty(nombre))
                {
                    Console.WriteLine($"Favor ingresar el nombre del estudiante.");
                }
                else if (!nombreValidacion.IsMatch(nombre))
                {
                    Console.WriteLine($"El nombre: {nombre} no es válido. El nombre solo debe contener letras y un espacio despues de cada nombre y apellido.");
                }
                else
                {
                    return nombre;
                }
            }
        }

        //Funcion para validar si el nombre de la materia es correcto.
        public static string validarNombreMateria(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string materia = Console.ReadLine();
                Regex materiaValidacion = new Regex(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚäëïöüÄËÏÖÜñÑ#_\-\(\)\/]+(?: [a-zA-Z0-9áéíóúÁÉÍÓÚäëïöüÄËÏÖÜñÑ#_\-\(\)\/]+)*$");

                if (string.IsNullOrEmpty(materia))
                {
                    Console.WriteLine($"Favor ingresar el nombre de la materia.");
                }
                else if (!materiaValidacion.IsMatch(materia))
                {
                    Console.WriteLine($"El nombre de la materia: {materia} no es válido.");
                }
                else
                {
                    return materia;
                }
            }
        }

        //Funcion para validar si la nota de examen ingresada es un numero entero y esta dentro del rango de 0 a 100
        public static int ValidarNotaExamen(string texto)
        {
            while (true)
            {
                Console.WriteLine(texto);
                string nota = Console.ReadLine();
                if (int.TryParse(nota, out int notaExamen) && notaExamen >= 0 && notaExamen <= 100 && notaExamen % 1 == 0)
                {
                    return notaExamen;
                }
                else
                {
                    Console.WriteLine($"La nota de examen: {nota} es no es válida. Por favor ingrese una nota de examen entre 0 y 100.");
                }
            }
        }

        //Funcion para validar si seguir ingresando mas registros en el sistema.
        public static void ValidarOpcionRegistro(string texto)
        {
            while (true)
            {
                Console.WriteLine(texto);
                string opcion = Console.ReadLine();
                if (opcion == "si")
                {
                    Console.Clear();
                    RegistroNotasEstudiantes.MetodoRegistroNotas();
                    break;
                }
                else if (opcion == "no")
                {
                    Console.Clear();
                    Console.WriteLine("*******************************************************************************");
                    Console.WriteLine("¡Las notas de los examenes se han guardado correctamente en el sistema!");
                    Console.WriteLine("*******************************************************************************");
                    Console.WriteLine("Las notas ingresadas en el sistema se han almacenado correctamente en el archivo notas.csv en la ruta: C:/morazanfiles/notas.csv");
                    Console.WriteLine("");
                    Console.WriteLine("¿Desea regresar al menú principal?");
                    ReturnMenuPrincipal("Ingrese 'si' o 'no'");
                    break;
                }
                else
                {
                    Console.WriteLine($"");
                }
            }
        }

        //Funcion para retornar o no menu principal.
        public static void ReturnMenuPrincipal(string texto)
        {
            while (true)
            {
                Console.WriteLine(texto);
                string opcion = Console.ReadLine();
                if (opcion == "si")
                {
                    Console.Clear();
                    Program.Main(new string[0]);
                    break;
                }if (opcion == "no")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"");
                }
            }
        }


    }
}
