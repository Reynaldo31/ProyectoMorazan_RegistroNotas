using ProyectoMorazan_RegistroNotas.Validaciones;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMorazan_RegistroNotas.GestorNotas
{
    public static class HistorialNotasRegistradas
    {
        //Funcion para poder mostrar los registros que se han almacenado en base de datos
        public static void MostrarHistorialNotas()
        {
            string connectionString = "Data Source=NotasExamenes.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM NotasExamenes ORDER BY FechaHoraCalculo DESC";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("");
                    Console.WriteLine(" *********************************************************************************************************************");
                    Console.WriteLine("|                                              Historial Notas Estudiantes                                            |");
                    Console.WriteLine(" *********************************************************************************************************************");
                    Console.WriteLine("ID | Nombre Estudiante | Nombre Materia | Examen 1 | Examen 2 | Examen 3 | Examen 4 | Acumulativo | Puntos Oro 1 | Puntos Oro 2 | Puntos Oro 3 | Puntos Oro 4 | Puntos Oro Acumulativo | Nota Final | Fecha/Hora Calculo");
                    Console.WriteLine(new string('-', 110));

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombreEstudiante = reader.GetString(1);
                        string nombreMateria = reader.GetString(2);
                        int notaPrimerExamen = reader.GetInt32(3);
                        int notaSegundoExamen = reader.GetInt32(4);
                        int notaTercerExamen = reader.GetInt32(5);
                        int notaCuartoExamen = reader.GetInt32(6);
                        int notaAcumulativo = reader.GetInt32(7);
                        int puntosOroNota1 = reader.GetInt32(8);
                        int puntosOroNota2 = reader.GetInt32(9);
                        int puntosOroNota3 = reader.GetInt32(10);
                        int puntosOroNota4 = reader.GetInt32(11);
                        int puntosOroAcumulativo = reader.GetInt32(12);
                        int notaFinal = reader.GetInt32(13);
                        string fechaHoraCalculo = reader.GetString(14);

                        Console.WriteLine($"{id,-2} | {nombreEstudiante,-17} | {nombreMateria,-14} | {notaPrimerExamen,8} | {notaSegundoExamen,8} | {notaTercerExamen,8} | {notaCuartoExamen,8} | {notaAcumulativo,11} | {puntosOroNota1,6} | {puntosOroNota2,6} | {puntosOroNota3,6} | {puntosOroNota4,6} | {puntosOroAcumulativo,15} | {notaFinal,10} | {fechaHoraCalculo,-19}");
                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine("¿Desea regresar al menú principal?");

            //Llamado de funcion para retornar o no menu principal.
            FuncionesValidacion.ReturnMenuPrincipal("Ingrese 'si' o 'no'");
        }
    }
}
