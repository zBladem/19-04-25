
using System;

namespace namespace_Programacion___Semana_4___Ejercicio
{
    /// <summary>
    /// Gestiona el avance de turnos y la energía.
    /// </summary>
    class TurnManager
    {
        public int TurnoActual { get; private set; }
        public int Energia { get; private set; }

        public TurnManager(int energiaInicial = 0)
        {
            TurnoActual = 0;
            Energia = energiaInicial;
        }

        /// <summary>
        /// Aumenta el turno y añade 20 de energía.
        /// </summary>
        public void PasarTurno()
        {
            TurnoActual++;
            Energia += 20;
            Console.WriteLine($"Turno {TurnoActual} completado. Energía: {Energia}");
        }
    }
}
