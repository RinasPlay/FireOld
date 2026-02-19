using System;

namespace FireInspection
{
    public class Violation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DetectionDate { get; set; }
        public DateTime FixDeadline { get; set; }

        // ADDED IN TODO 1
        public string ViolationType { get; set; }
        public string Severity { get; set; }

        public bool IsFixed { get; set; }
        public DateTime? FixDate { get; set; }

        public Violation(int id, string description, string type, string severity, DateTime detectionDate, int daysToFix)
        {
            Id = id;
            Description = description;
            DetectionDate = detectionDate;

            // ADDED IN TODO 1: сохраняем тип и серьёзность
            ViolationType = type;
            Severity = severity;

            // TODO 3 будет добавлен позже
            // FixDeadline = DetectionDate.AddDays(daysToFix); // пока не реализовано

            IsFixed = false;
        }

        // Заглушка для TODO 2
        public int GetFixPriority() { return 1; }

        // Заглушка для TODO 3
        public bool IsOverdue() { return false; }

        public void MarkAsFixed()
        {
            IsFixed = true;
            FixDate = DateTime.Now;
        }

        public override string ToString()
        {
            string status = IsFixed ? "Устранено" : "Не устранено";
            string overdue = IsOverdue() ? " (ПРОСРОЧЕНО)" : "";
            return $"{Description} - {status}{overdue}";
        }
    }
}