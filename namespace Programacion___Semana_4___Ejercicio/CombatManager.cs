using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namespace_Programacion___Semana_4___Ejercicio
{
    internal class CombatManager
    {
            private readonly TurnManager _tm;
            private readonly ConstructionManager _cm;
            private readonly ProductionManager _pm;
            private readonly List<Unidad> _enemigas = new List<Unidad>();
            private int _contIA, _fibPrev = 0, _fib = 1;
            public int EnemigosMuertos { get; private set; }

            public CombatManager(TurnManager tm, ConstructionManager cm, ProductionManager pm)
            {
                _tm = tm; _cm = cm; _pm = pm;
            }

            public void IniciarCombate()
            {
                // Jugador ataca 1:1
                while (_pm.Unidades.Count > 0 && _enemigas.Count > 0)
                {
                    _pm.Unidades.RemoveAt(0);
                    _enemigas.RemoveAt(0);
                    EnemigosMuertos++;
                    Console.WriteLine("Enemigo abatido.");
                }

                // IA crea según Fibonacci cada 2 turnos tras turno 10
                _contIA++;
                if (_contIA > 10 && _contIA % 2 == 0)
                {
                    int n = _fibPrev;
                    (_fibPrev, _fib) = (_fib, _fib + _fibPrev);
                    for (int i = 0; i < n; i++)
                        _enemigas.Add(new Soldado());
                    Console.WriteLine($"IA creó {n} unidades.");
                }

                // IA ataca
                bool atacó = false;
                // 1) a unidades
                for (int i = 0; i < _enemigas.Count && _pm.Unidades.Count > 0; i++)
                {
                    _pm.Unidades.RemoveAt(0);
                    Console.WriteLine("Perdiste una unidad.");
                    atacó = true;
                }
                // 2) si quedan enemigas, destruye 1 torre
                if (!atacó && _cm.Construidas.Exists(e => e is Torre))
                {
                    for (int i = 0; i < _cm.Construidas.Count; i++)
                    {
                        if (_cm.Construidas[i] is Torre)
                        {
                            _cm.Construidas.RemoveAt(i);
                            Console.WriteLine("Perdiste una torre.");
                            break;
                        }
                    }
                }

                // 3) verificar derrota
                if (_cm.Construidas.Count == 0)
                {
                    Console.WriteLine("¡DERROTA!");
                    Console.WriteLine(
                      $"Turnos: {_tm.TurnoActual}, Enemigos abatidos: {EnemigosMuertos}, " +
                      $"Estructuras: {_cm.Construidas.Count}, Unidades: {_pm.Unidades.Count}");
                    Environment.Exit(0);
                }
            }
        
    }
}
