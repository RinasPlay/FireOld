using System;
using System.Collections.Generic;

namespace FireInspection
{
    public class Inspection
    {
        public int Id { get; set; }
        public Enterprise Enterprise { get; set; }
        public Inspector Inspector { get; set; }
        public DateTime InspectionDate { get; set; }

        private List<Violation> violations = new List<Violation>();
        private int nextViolationId = 1;

        public string Result { get; set; }

        public Inspection(int id, Enterprise enterprise, Inspector inspector)
        {
            Id = id;
            Enterprise = enterprise;
            Inspector = inspector;
            InspectionDate = DateTime.Now;
        }

        public void AddViolation(string description, string type, string severity, int daysToFix)
        {
            Violation v = new Violation(nextViolationId++, description, type, severity, InspectionDate, daysToFix);
            violations.Add(v);
        }

        // ADDED IN TODO 3: расчёт балла безопасности
        public decimal CalculateSafetyScore()
        {
            if (violations.Count == 0) return 100;

            int criticalCount = 0;
            foreach (var v in violations)
            {
                if (v.Severity.Equals("критическое", StringComparison.OrdinalIgnoreCase))
                    criticalCount++;
            }

            int score = 100 - (violations.Count * 10) - (criticalCount * 20);
            return score < 0 ? 0 : score;
        }

        // ADDED IN TODO 3: статистика по нарушениям
        public void GetViolationStats(out int total, out int critical, out int overdue)
        {
            total = violations.Count;
            critical = 0;
            overdue = 0;

            foreach (var v in violations)
            {
                if (v.Severity.Equals("критическое", StringComparison.OrdinalIgnoreCase))
                    critical++;
                if (v.IsOverdue())
                    overdue++;
            }
        }

        public List<Violation> GetViolations() { return violations; }

        public void ShowReport()
        {
            Console.WriteLine($"Проверка №{Id} от {InspectionDate:dd.MM.yyyy}");
            Console.WriteLine($"Предприятие: {Enterprise.Name}");
            Console.WriteLine($"Инспектор: {Inspector.Name}");
            Console.WriteLine($"Результат: {Result ?? "не определен"}");
            Console.WriteLine($"Нарушений выявлено: {violations.Count}");
        }
    }
}