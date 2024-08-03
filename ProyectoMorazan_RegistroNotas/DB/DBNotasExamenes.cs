using RegistroNotas;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMorazan_RegistroNotas.DB
{
    public static class DBNotasExamenes
    {
        //Funcion para crear la conexion de la base de datos sql lite y crear la tabla en caso de  que no exista.
        public static void CrearBDConexion()
        {
            try
            {
                string connectionString = "Data Source=NotasExamenes.db;Version=3;";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string QueryTablaNotas = @"
                CREATE TABLE IF NOT EXISTS NotasExamenes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NombreEstudiante TEXT,
                    NombreMateria TEXT,
                    NotaPrimerExamen INTEGER,
                    NotaSegundoExamen INTEGER,
                    NotaTercerExamen INTEGER,
                    NotaCuartoExamen INTEGER,
                    NotaAcumulativo INTEGER,
                    PuntosOroNota1 INTEGER,
                    PuntosOroNota2 INTEGER,
                    PuntosOroNota3 INTEGER,
                    PuntosOroNota4 INTEGER,
                    PuntosOroAcumulativo INTEGER,
                    NotaFinal INTEGER,
                    FechaHoraCalculo TEXT
                )";

                    using (var command = new SQLiteCommand(QueryTablaNotas, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(" **************************************************************************");
                Console.WriteLine(" Ha ocurrido un problema en la conexión de la base de datos");
                Console.WriteLine(" **************************************************************************");
                Console.WriteLine("");
                Program.Main(new string[0]);
            }
        }

        //Funcion para almacenar las notas de los exames y calculos en base de datos
        public static void InsertarNotasExamenesBD(string nombreEstudiante,
                                            string nombreMateria,
                                            int notaPrimerExamen,
                                            int notaSegungoExamen,
                                            int notaTercerExamen,
                                            int notaCuartoExamen,
                                            int notaAcumulativo,
                                            int puntosOroNota1,
                                            int puntosOroNota2,
                                            int puntosOroNota3,
                                            int puntosOroNota4,
                                            int puntosOroAcumulativo,
                                            int notaFinal,
                                            string fechaHoraCalculo)
        {
            try
            {
                string connectionString = "Data Source=NotasExamenes.db;Version=3;";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = @"
                INSERT INTO NotasExamenes (
                    NombreEstudiante,
                    NombreMateria,
                    NotaPrimerExamen,
                    NotaSegundoExamen,
                    NotaTercerExamen,
                    NotaCuartoExamen,
                    NotaAcumulativo,
                    PuntosOroNota1,
                    PuntosOroNota2,
                    PuntosOroNota3,
                    PuntosOroNota4,
                    PuntosOroAcumulativo,
                    NotaFinal,
                    FechaHoraCalculo)
                VALUES (@NombreEstudiante,
                    @NombreMateria,
                    @NotaPrimerExamen,
                    @NotaSegundoExamen,
                    @NotaTercerExamen,
                    @NotaCuartoExamen,
                    @NotaAcumulativo,
                    @PuntosOroNota1,
                    @PuntosOroNota2,
                    @PuntosOroNota3,
                    @PuntosOroNota4,
                    @PuntosOroAcumulativo,
                    @NotaFinal,
                    @FechaHoraCalculo)";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NombreEstudiante", nombreEstudiante);
                        command.Parameters.AddWithValue("@NombreMateria", nombreMateria);
                        command.Parameters.AddWithValue("@NotaPrimerExamen", notaPrimerExamen);
                        command.Parameters.AddWithValue("@NotaSegundoExamen", notaSegungoExamen);
                        command.Parameters.AddWithValue("@NotaTercerExamen", notaTercerExamen);
                        command.Parameters.AddWithValue("@NotaCuartoExamen", notaCuartoExamen);
                        command.Parameters.AddWithValue("@NotaAcumulativo", notaAcumulativo);

                        command.Parameters.AddWithValue("@PuntosOroNota1", puntosOroNota1);
                        command.Parameters.AddWithValue("@PuntosOroNota2", puntosOroNota2);
                        command.Parameters.AddWithValue("@PuntosOroNota3", puntosOroNota3);
                        command.Parameters.AddWithValue("@PuntosOroNota4", puntosOroNota4);
                        command.Parameters.AddWithValue("@PuntosOroAcumulativo", puntosOroAcumulativo);

                        command.Parameters.AddWithValue("@NotaFinal", notaFinal);
                        command.Parameters.AddWithValue("@FechaHoraCalculo", fechaHoraCalculo);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine(" **************************************************************************");
                Console.WriteLine(" Ha ocurrido un problema al guardar las notas de los examenes en el sistema");
                Console.WriteLine(" **************************************************************************");
                Console.WriteLine("");
                Program.Main(new string[0]);
            }

        }
    }
}
