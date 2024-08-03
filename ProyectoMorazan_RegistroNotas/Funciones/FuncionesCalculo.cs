using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMorazan_RegistroNotas.Funciones
{
    public static class FuncionesCalculo
    {
        //Funcion para calcular los puntos oro de las notas de los examenes
        public static Tuple<int, int, int, int, int> CalculoPuntosOro(int notaPrimerExamen,
                                                                int notaSegungoExamen,
                                                                int notaTercerExamen,
                                                                int notaCuartoExamen,
                                                                int notaAcumulativo)
        {
            Tuple<int, int, int, int, int> tupleCalculos = new Tuple<int, int, int, int, int>(0,0,0,0,0);

            int puntosOroNota1 = (int)Math.Round(notaPrimerExamen * (15 / (double)100), MidpointRounding.AwayFromZero);
            int puntosOroNota2 = (int)Math.Round(notaSegungoExamen * (15 / (double)100), MidpointRounding.AwayFromZero);
            int puntosOroNota3 = (int)Math.Round(notaTercerExamen * (15 / (double)100), MidpointRounding.AwayFromZero);
            int puntosOroNota4 = (int)Math.Round(notaCuartoExamen * (15 / (double)100), MidpointRounding.AwayFromZero);
            int puntosOroAcumulativo = (int)Math.Round(notaAcumulativo * (40 / (double)100), MidpointRounding.AwayFromZero);

            return tupleCalculos = new Tuple<int, int, int, int, int>(puntosOroNota1, puntosOroNota2, puntosOroNota3, puntosOroNota4, puntosOroAcumulativo);
        }

        public static int CalculoNotaFinal(int puntosOroNota1, int puntosOroNota2, int puntosOroNota3, int puntosOroNota4, int puntosOroAcumulativo)
        {
            int notaFinal = 0;
            return notaFinal = puntosOroNota1 + puntosOroNota2 + puntosOroNota3 + puntosOroNota4 + puntosOroAcumulativo;
        }

    }
}
