using System;

namespace FireInspection
{
    public class Violation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DetectionDate { get; set; }
        public DateTime FixDeadline { get; set; }

        public string ViolationType { get; set; }
        public string Severity { get; set; }

        public bool IsFixed { get; set; }
        public DateTime? FixDate { get; set; }

        public Violation(int id, string description, string type, string severity, DateTime detectionDate, int daysToFix)
        {
            Id = id;
            Description = description;
            DetectionDate = detectionDate;
            ViolationType = type;
            Severity = severity;
            // FixDeadline пока не устанавливаем (TODO 3)
            IsFixed = false;
        }

        // ADDED IN TODO 2: реализация приоритета (с заглушкой IsOverdue)
        public int GetFixPriority()
        {
            bool overdue = IsOverdue(); // пока всегда false

            if (Severity.Equals("критическое", StringComparison.OrdinalIgnoreCase))
                return overdue ? 1 : 2;
            if (Severity.Equals("значительное", StringComparison.OrdinalIgnoreCase))
                return overdue ? 2 : 3;
            // незначительное
            return overdue ? 3 : 4;
        }

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