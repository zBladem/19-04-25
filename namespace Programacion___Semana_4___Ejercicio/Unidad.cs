// Unidad.cs & ProductionManager.cs
// Módulo 3 – Responsable: Benja
using System;
using System.Collections.Generic;

namespace namespace_Programacion___Semana_4___Ejercicio
{
    abstract class Unidad
    {
        public string Nombre { get; }
        public int Vida { get; protected set; }
        public int Danio { get; protected set; }

        protected Unidad(string nombre) => Nombre = nombre;
    }

    class Soldado : Unidad
    {
        public Soldado() : base("Soldado") { Vida = 30; Danio = 10; }
    }

    class Arquero : Unidad
    {
        public Arquero() : base("Arquero") { Vida = 40; Danio = 15; }
    }

    class ProductionManager
    {
        private readonly TurnManager _tm;
        private readonly ConstructionManager _cm;
        private readonly List<(string tipo, int tiempo)> _cola
            = new List<(string, int)>();

        public List<Unidad> Unidades { get; } = new List<Unidad>();

        public ProductionManager(TurnManager tm, ConstructionManager cm)
        {
            _tm = tm; _cm = cm;
        }

        public void SolicitarSoldado()
        {
            if (_cm.CasasConstruidas() <= Unidades.Count)
            {
                Console.WriteLine("No hay casa libre para Soldado.");
                return;
            }
            _cola.Add(("Soldado", 2));
            Console.WriteLine("Producción Soldado iniciada (2 turnos).");
        }

        public void SolicitarArquero()
        {
            if (_cm.CasasConstruidas() <= Unidades.Count)
            {
                Console.WriteLine("No hay casa libre para Arquero.");
                return;
            }
            if (_tm.Energia < 50)
            {
                Console.WriteLine("Energía insuficiente para Arquero (50).");
                return;
            }
            _tm.Energia -= 50;
            _cola.Add(("Arquero", 2));
            Console.WriteLine("Producción Arquero iniciada (2 turnos).");
        }

        public void ProcesarTurno()
        {
            for (int i = _cola.Count - 1; i >= 0; i--)
            {
                var req = _cola[i];
                req.tiempo--;
                if (req.tiempo == 0)
                {
                    Unidad u = req.tipo == "Soldado"
                              ? (Unidad)new Soldado()
                              : new Arquero();
                    Unidades.Add(u);
                    _cola.RemoveAt(i);
                    Console.WriteLine($"{req.tipo} producido.");
                }
                else
                {
                    _cola[i] = (req.tipo, req.tiempo);
                }
            }
        }
    }
}
