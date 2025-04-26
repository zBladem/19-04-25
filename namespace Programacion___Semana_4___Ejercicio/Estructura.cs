
using System;
using System.Collections.Generic;

namespace namespace_Programacion___Semana_4___Ejercicio
{
    abstract class Estructura
    {
        public string Nombre { get; }
        public int TiempoRestante { get; set; }
        public int Costo { get; }

        protected Estructura(string nombre, int tiempo, int costo)
        {
            Nombre = nombre;
            TiempoRestante = tiempo;
            Costo = costo;
        }
    }

    class Granja : Estructura { public Granja() : base("Granja", 3, 50) { } }
    class Torre : Estructura { public Torre() : base("Torre", 4, 100) { } }
    class Casa : Estructura { public Casa() : base("Casa", 2, 50) { } }

    class ConstructionManager
    {
        private readonly TurnManager _tm;
        public List<Estructura> EnConstruccion { get; } = new List<Estructura>();
        public List<Estructura> Construidas { get; } = new List<Estructura>();

        public ConstructionManager(TurnManager tm) => _tm = tm;

        public void Agregar(Estructura e)
        {
            if (_tm.Energia < e.Costo)
            {
                Console.WriteLine($"No hay energía para {e.Nombre} ({e.Costo}).");
                return;
            }
            _tm.Energia -= e.Costo;
            EnConstruccion.Add(e);
            Console.WriteLine($"Construcción de {e.Nombre} iniciada ({e.TiempoRestante} turnos).");
        }

        public void ProcesarTurno()
        {
            for (int i = EnConstruccion.Count - 1; i >= 0; i--)
            {
                var e = EnConstruccion[i];
                e.TiempoRestante--;
                if (e.TiempoRestante == 0)
                {
                    Construidas.Add(e);
                    EnConstruccion.RemoveAt(i);
                    Console.WriteLine($"{e.Nombre} ¡Listo!");
                    if (e is Granja)
                    {
                        _tm.Energia += 5;
                        Console.WriteLine("Granja activa: +5 energía.");
                    }
                }
            }
        }

        // Cantidad de casas terminadas
        public int CasasConstruidas()
        {
            int cnt = 0;
            foreach (var e in Construidas)
                if (e is Casa) cnt++;
            return cnt;
        }
    }
}
