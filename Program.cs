using System;

namespace FireInspection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ПОЖАРНАЯ ИНСПЕКЦИЯ 'ОГНЕЩИТ' ===\n");

            InspectionMenu menu = new InspectionMenu();
            menu.ShowMainMenu();

            Console.WriteLine("\nБезопасность - наша общая забота!");
            Console.ReadKey();
        }
    }
}