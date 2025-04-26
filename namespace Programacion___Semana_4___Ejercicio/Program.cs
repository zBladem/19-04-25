
using System;

namespace namespace_Programacion___Semana_4___Ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            var tm = new TurnManager();
            var cm = new ConstructionManager(tm);
            var pm = new ProductionManager(tm, cm);
            var combat = new CombatManager(tm, cm, pm);

            while (true)
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Ver base");
                Console.WriteLine("2. Construir estructura");
                Console.WriteLine("3. Producir unidad");
                Console.WriteLine("4. Iniciar combate y pasar turno");
                Console.WriteLine("5. Pasar turno sin combate");
                Console.WriteLine("6. Salir");
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine($"Turno: {tm.TurnoActual} | Energía: {tm.Energia}");
                        Console.WriteLine($"En construcción: {cm.EnConstruccion.Count} | Terminadas: {cm.Construidas.Count}");
                        Console.WriteLine($"Unidades disponibles: {pm.Unidades.Count}");
                        break;

                    case "2":
                        Console.WriteLine("Elige estructura: 1) Granja  2) Torre  3) Casa");
                        var e = Console.ReadKey(true).KeyChar;
                        if (e == '1') cm.Agregar(new Granja());
                        else if (e == '2') cm.Agregar(new Torre());
                        else if (e == '3') cm.Agregar(new Casa());
                        break;

                    case "3":
                        Console.WriteLine("Elige unidad: 1) Soldado  2) Arquero");
                        var u = Console.ReadKey(true).KeyChar;
                        if (u == '1') pm.SolicitarSoldado();
                        else if (u == '2') pm.SolicitarArquero();
                        break;

                    case "4":
                        combat.IniciarCombate();
                        tm.PasarTurno();
                        cm.ProcesarTurno();
                        pm.ProcesarTurno();
                        break;

                    case "5":
                        tm.PasarTurno();
                        cm.ProcesarTurno();
                        pm.ProcesarTurno();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
