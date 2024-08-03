using CsvHelper;
using ProyectoMorazan_RegistroNotas.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMorazan_RegistroNotas.GestorNotas
{

    public static class RegistroNotasCSV
    {
        //Funcion para poder almacenar los registro de notas de los estudiantes en un archivo csv.
        public static void GuardarNotasExamesCsv(string nombreEstudiante,
                                                string nombreMateria,
                                                int notaExamen1,
                                                int notaExamen2,
                                                int notaExamen3,
                                                int notaExamen4,
                                                int notaAcumulativo,
                                                int notaFinal,
                                                DateTime fechaRegistro)
        {
            string csvPath = @"C:\morazanfiles\notas.csv";
            Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

            bool existeCSV = File.Exists(csvPath);

            using (var writer = new StreamWriter(csvPath, append: true, System.Text.Encoding.UTF8))
            using (var csv = new CsvWriter(writer, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                if (!existeCSV)
                {
                    csv.WriteHeader<RegistroNotasModel>();
                    csv.NextRecord();
                }

                csv.WriteRecord(new
                {
                    NombreEstudiante = nombreEstudiante,
                    NombreMateria = nombreMateria,
                    NotaExamen1 = notaExamen1,
                    NotaExamen2 = notaExamen2,
                    NotaExamen3 = notaExamen3,
                    NotaExamen4 = notaExamen1,
                    NotaAcumulativo = notaAcumulativo,
                    NotaFinal = notaFinal,
                    FechaHoraCalculo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });
                csv.NextRecord();
            }
        }
    }
}
