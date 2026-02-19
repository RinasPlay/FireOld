using System.Collections.Generic;

namespace FireInspection
{
    public class Inspector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BadgeNumber { get; set; }

        // ADDED IN TODO 1
        public string Rank { get; set; }
        public string Specialization { get; set; }

        private List<Inspection> conductedInspections = new List<Inspection>();

        // Заглушка для TODO 2
        public void AddInspection(Inspection inspection) { }

        // Заглушка для TODO 3
        public void GetWorkStats(out int totalInspections, out int totalViolations, out decimal avgSafetyScore)
        {
            totalInspections = conductedInspections.Count;
            totalViolations = 0;
            avgSafetyScore = 0;
        }

        // Заглушка для TODO 3
        public int GetActiveViolationsCount() { return 0; }

        public void ShowInspectorInfo()
        {
            Console.WriteLine($"Инспектор: {Name}");
            Console.WriteLine($"Удостоверение: {BadgeNumber}");
            // ADDED IN TODO 1: вывод звания и специализации
            Console.WriteLine($"Звание: {Rank ?? "не указано"}");
            Console.WriteLine($"Специализация: {Specialization ?? "не указана"}");
            Console.WriteLine($"Проведено проверок: {conductedInspections.Count}");
        }
    }
}