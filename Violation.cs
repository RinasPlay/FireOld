using System;

namespace FireInspection
{
    public class Violation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DetectionDate { get; set; }
        public DateTime FixDeadline { get; set; }

        // Добавлено
        public string ViolationType { get; set; }
        public string Severity { get; set; }

        public bool IsFixed { get; set; }
        public DateTime? FixDate { get; set; }

        public Violation(int id, string description, string type, string severity, DateTime detectionDate, int daysToFix)
        {
            Id = id;
            Description = description;
            DetectionDate = detectionDate;

            // Сохранение типа и серьёзности
            ViolationType = type;
            Severity = severity;

            // TODO 3 будет реализован позже
            // FixDeadline = DetectionDate.AddDays(daysToFix);

            IsFixed = false;
        }

        public int GetFixPriority() => 1; // пока заглушка

        public bool IsOverdue() => false; // пока заглушка

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