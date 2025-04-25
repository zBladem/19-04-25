using System;

namespace namespace_Programacion___Semana_4___Ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            var gestor = new TurnManager();
            Console.WriteLine("Presiona Enter para pasar turno, o 'q' para salir.");

            while (true)
            {
                var tecla = Console.ReadKey(true).KeyChar;
                if (tecla == 'q' || tecla == 'Q')
                    break;

                gestor.PasarTurno();
            }
        }
    }
}