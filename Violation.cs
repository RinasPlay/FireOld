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

            // ADDED IN TODO 3: установка срока устранения
            FixDeadline = DetectionDate.AddDays(daysToFix);

            IsFixed = false;
        }

        public int GetFixPriority()
        {
            bool overdue = IsOverdue();

            if (Severity.Equals("критическое", StringComparison.OrdinalIgnoreCase))
                return overdue ? 1 : 2;
            if (Severity.Equals("значительное", StringComparison.OrdinalIgnoreCase))
                return overdue ? 2 : 3;
            return overdue ? 3 : 4;
        }

        // ADDED IN TODO 3: реализация проверки просрочки
        public bool IsOverdue()
        {
            return !IsFixed && DateTime.Now > FixDeadline;
        }

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