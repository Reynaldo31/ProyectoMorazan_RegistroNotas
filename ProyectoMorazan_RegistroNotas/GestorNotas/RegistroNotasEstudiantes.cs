using ProyectoMorazan_RegistroNotas.DB;
using ProyectoMorazan_RegistroNotas.Funciones;
using ProyectoMorazan_RegistroNotas.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMorazan_RegistroNotas.GestorNotas
{
    public static class RegistroNotasEstudiantes
    {
        public static void MetodoRegistroNotas()
        {
            string nombreEstudiante,
                   nombreMateria;

            int notaPrimerExamen,
                notaSegungoExamen,
                notaTercerExamen,
                notaCuartoExamen,
                notaAcumulativo,
                notaFinal;

            DateTime fechaHoraCalculo = DateTime.Now;

            //Llamado de funcion para crear la conexion de la base de datos sql lite y crear la tabla en caso de  que no exista.
            DBNotasExamenes.CrearBDConexion();

            Console.WriteLine("");
            Console.WriteLine(" *********************************************************************************");
            Console.WriteLine("|                             [Registro Notas Estudiante]                         |");
            Console.WriteLine(" *********************************************************************************");
            Console.WriteLine("");
            //Llamado de funcion para el nombre del estudiante.
            nombreEstudiante = FuncionesValidacion.validarNombreEstudiante("Ingrese el nombre del estudiante:");

            //Llamado de funcion para el nombre de la materia.
            nombreMateria = FuncionesValidacion.validarNombreMateria("Ingrese el nombre de la materia:");

            //Llamado de funcion para validar si las notas de los examenes son numero enteros y en el rango de 1 a 100.
            notaPrimerExamen = FuncionesValidacion.ValidarNotaExamen("Ingrese la nota del primer examen en base a 100:");
            notaSegungoExamen = FuncionesValidacion.ValidarNotaExamen("Ingrese la nota del segundo examen en base a 100:");
            notaTercerExamen = FuncionesValidacion.ValidarNotaExamen("Ingrese la nota del tercer examen en base a 100:");
            notaCuartoExamen = FuncionesValidacion.ValidarNotaExamen("Ingrese la nota del cuarto examen en base a 100:");
            notaAcumulativo = FuncionesValidacion.ValidarNotaExamen("Ingrese la nota del acumulativo en base a 100:");


            //Llamado de funcion para el calculo de nota de examenes en puntos oro redondeado a enteros.
            Tuple<int, int, int, int, int> TupleCalculoNotas = FuncionesCalculo.CalculoPuntosOro(notaPrimerExamen, notaSegungoExamen, notaTercerExamen, notaCuartoExamen, notaAcumulativo);

            //Llamado de funcion para la suma aritmetica del total de los puntos oro calculados.
            notaFinal = FuncionesCalculo.CalculoNotaFinal(TupleCalculoNotas.Item1, TupleCalculoNotas.Item2, TupleCalculoNotas.Item3, TupleCalculoNotas.Item4, TupleCalculoNotas.Item5);

            //LLamado de funcion para insertar en BD las notas de examenes y calculos
            DBNotasExamenes.InsertarNotasExamenesBD(nombreEstudiante,
                                    nombreMateria,
                                    notaPrimerExamen,
                                    notaSegungoExamen,
                                    notaTercerExamen,
                                    notaCuartoExamen,
                                    notaAcumulativo,
                                    TupleCalculoNotas.Item1,
                                    TupleCalculoNotas.Item2,
                                    TupleCalculoNotas.Item3,
                                    TupleCalculoNotas.Item4,
                                    TupleCalculoNotas.Item5,
                                    notaFinal,
                                    fechaHoraCalculo.ToString("yyyy-MM-dd HH:mm:ss"));

            //Llamado de Funcion para registras las notas de los estidiantes en un archivo csv.
            RegistroNotasCSV.GuardarNotasExamesCsv(nombreEstudiante,
                                                   nombreMateria,
                                                   TupleCalculoNotas.Item1,
                                                   TupleCalculoNotas.Item2,
                                                   TupleCalculoNotas.Item3,
                                                   TupleCalculoNotas.Item4,
                                                   TupleCalculoNotas.Item5,
                                                   notaFinal,
                                                   fechaHoraCalculo);


            Console.WriteLine("");
            Console.WriteLine("***********************************************************************************************************");
            Console.WriteLine($"¡Las notas del estudiante: {nombreEstudiante} se han registrado correctamente en el sistema!");
            Console.WriteLine("***********************************************************************************************************");
            Console.WriteLine("");

            Console.WriteLine("¿Desea ingresar un nuevo registro de notas de examenes?");

            //Llamado de funcion para validar si seguir ingresando mas registros en el sistema.
            FuncionesValidacion.ValidarOpcionRegistro("Ingrese 'si' o 'no'");


        }


    }
}
