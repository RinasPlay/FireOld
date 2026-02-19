using System.Collections.Generic;
using System.Linq; // ADDED IN TODO 3 для LINQ

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

        public void AddInspection(Inspection inspection)
        {
            conductedInspections.Add(inspection);
        }

        // ADDED IN TODO 3: реализация статистики
        public void GetWorkStats(out int totalInspections, out int totalViolations, out decimal avgSafetyScore)
        {
            totalInspections = conductedInspections.Count;
            totalViolations = 0;
            avgSafetyScore = 0;

            if (totalInspections == 0) return;

            decimal sumSafety = 0;
            foreach (var insp in conductedInspections)
            {
                totalViolations += insp.GetViolations().Count;
                sumSafety += insp.CalculateSafetyScore();
            }
            avgSafetyScore = sumSafety / totalInspections;
        }

        // ADDED IN TODO 3: реализация подсчёта активных нарушений
        public int GetActiveViolationsCount()
        {
            int count = 0;
            foreach (var insp in conductedInspections)
            {
                count += insp.GetViolations().Count(v => !v.IsFixed);
            }
            return count;
        }

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