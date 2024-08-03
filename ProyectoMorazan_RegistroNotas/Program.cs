
using CsvHelper;
using ProyectoMorazan_RegistroNotas.Validaciones;
using System.Data.SQLite;
using System.Globalization;
using ProyectoMorazan_RegistroNotas.Validaciones;
using ProyectoMorazan_RegistroNotas.Funciones;
using ProyectoMorazan_RegistroNotas.DB;
using ProyectoMorazan_RegistroNotas.GestorNotas;

namespace RegistroNotas
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" ********************************************************************************");
            Console.WriteLine("|                      [Sistema de Registro de Notas]                           |");
            Console.WriteLine(" ********************************************************************************");

            Console.WriteLine("                             [Menu Principal]                                      ");
            Console.WriteLine(" --------------------------------------------------------------------------------");
            Console.WriteLine("1. Registro de notas de estudiantes.");
            Console.WriteLine("2. Ver historial de notas registradas.");
            Console.WriteLine("3. Salir.");
            Console.WriteLine("");

            bool salir = false;

            while (!salir) {
                //Llamado de funcion para verificar si la opcion es un numero entero y no culquier otro caracter o letra.
                var opcion = FuncionesValidacion.validarOpcion("Seleccione una opción del menú:");

                switch (opcion)
                {
                    case 1:
                        //Llamado de metodor para gestionar el registro de las notas de los estudiantes.
                        Console.Clear();
                        RegistroNotasEstudiantes.MetodoRegistroNotas();
                        break;
                    case 2:
                        //Llamado de funcion para poder mostrar los registros que se han almacenado en base de datos.
                        Console.Clear();
                        HistorialNotasRegistradas.MostrarHistorialNotas();
                        break;
                    case 3:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción no es válida. Por favor, ingrese una opción del 1 al 3.");
                        break;
                }
            }
           


        }




        public static void DisplayNotesTable()
        {
            string connectionString = "Data Source=NotasExamenes.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM NotasExamenes";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Crear una tabla en la consola
                    Console.WriteLine("ID | Nombre Estudiante | Nombre Materia | Examen  | Examen 2 | Examen 3 | Examen 4 | Acumulativo | Fecha y Hora | Nota Final");
                    Console.WriteLine(new string('-', 100)); // Línea divisoria

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombreEstudiante = reader.GetString(1);
                        string nombreMateria = reader.GetString(2);
                        int notaExamen1 = reader.GetInt32(3);
                        int notaExamen2 = reader.GetInt32(4);
                        int notaExamen3 = reader.GetInt32(5);
                        int notaExamen4 = reader.GetInt32(6);
                        int notaAcumulativo = reader.GetInt32(7);
                        string fechaHoraCalculo = reader.GetString(8);
                        int notaFinal = reader.GetInt32(9);

                        Console.WriteLine($"{id,-2} | {nombreEstudiante,-17} | {nombreMateria,-14} | {notaExamen1,8} | {notaExamen2,8} | {notaExamen3,8} | {notaExamen4,8} | {notaAcumulativo,11} | {fechaHoraCalculo,-19} | {notaFinal,10}");
                    }
                }
            }
        }
    }
}