using System.Collections.Generic;

namespace FireInspection
{
    public class Inspector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BadgeNumber { get; set; }
        public string Rank { get; set; }
        public string Specialization { get; set; }

        private List<Inspection> conductedInspections = new List<Inspection>();

        // ADDED IN TODO 2: реализация метода
        public void AddInspection(Inspection inspection)
        {
            conductedInspections.Add(inspection);
        }

        // Заглушки для TODO 3
        public void GetWorkStats(out int totalInspections, out int totalViolations, out decimal avgSafetyScore)
        {
            totalInspections = conductedInspections.Count;
            totalViolations = 0;
            avgSafetyScore = 0;
        }

        public int GetActiveViolationsCount() { return 0; }

        public void ShowInspectorInfo()
        {
            Console.WriteLine($"Инспектор: {Name}");
            Console.WriteLine($"Удостоверение: {BadgeNumber}");
            Console.WriteLine($"Звание: {Rank ?? "не указано"}");
            Console.WriteLine($"Специализация: {Specialization ?? "не указана"}");
            Console.WriteLine($"Проведено проверок: {conductedInspections.Count}");
        }
    }
}