// TODO:
// 1. Реализовать систему классификации нарушений
// 2. Реализовать оценку серьезности нарушения
// 3. Реализовать систему учета сроков устранения

using System;

namespace FireInspection
{
    public class Violation
    {
        public int Id { get; set; }                    // Номер нарушения
        public string Description { get; set; }        // Описание нарушения
        public DateTime DetectionDate { get; set; }    // Дата обнаружения
        public DateTime FixDeadline { get; set; }      // Срок устранения

        // TODO 1: Добавить свойство ViolationType (тип: пожарные выходы, огнетушители, проводка и т.д.)
        // TODO 1: Добавить свойство Severity (серьезность: критическое, значительное, незначительное)

        public bool IsFixed { get; set; }              // Устранено ли нарушение
        public DateTime? FixDate { get; set; }         // Дата устранения (если устранено)

        public Violation(int id, string description, string type, string severity, DateTime detectionDate, int daysToFix)
        {
            Id = id;
            Description = description;
            DetectionDate = detectionDate;

            // TODO 1: Сохранить тип и серьезность нарушения

            // TODO 3: Установить срок устранения (DetectionDate + daysToFix дней)

            IsFixed = false;
        }

        // TODO 2: Получить приоритет исправления
        public int GetFixPriority()
        {
            // Вернуть числовой приоритет на основе серьезности и просрочки
            // Критическое + просрочено = 1 (самый высокий)
            // Незначительное + не просрочено = 3 (низкий)
            return 1;
        }

        // TODO 3: Проверить просрочку
        public bool IsOverdue()
        {
            // Вернуть true если текущая дата позже FixDeadline и нарушение не устранено
            return false;
        }

        // Отметить как устраненное
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