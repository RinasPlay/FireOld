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

        // ADDED IN TODO 2: реализация метода
        public void AddViolation(string description, string type, string severity, int daysToFix)
        {
            Violation v = new Violation(nextViolationId++, description, type, severity, InspectionDate, daysToFix);
            violations.Add(v);
        }

        // Заглушки для TODO 3
        public decimal CalculateSafetyScore() { return 100; }

        public void GetViolationStats(out int total, out int critical, out int overdue)
        {
            total = violations.Count;
            critical = 0;
            overdue = 0;
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