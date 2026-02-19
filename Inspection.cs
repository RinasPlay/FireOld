// TODO:
// 1. Реализовать систему проведения проверок предприятий
// 2. Реализовать учет выявленных нарушений
// 3. Реализовать оценку результатов проверки

using System;
using System.Collections.Generic;

namespace FireInspection
{
    public class Inspection
    {
        public int Id { get; set; }                    // Номер проверки
        public Enterprise Enterprise { get; set; }     // Проверяемое предприятие
        public Inspector Inspector { get; set; }       // Проверяющий инспектор
        public DateTime InspectionDate { get; set; }   // Дата проверки
        
        private List<Violation> violations = new List<Violation>();
        private int nextViolationId = 1;
        
        // TODO 1: Добавить свойство Result (результат: соответствует, не соответствует, с нарушениями)
        
        public Inspection(int id, Enterprise enterprise, Inspector inspector)
        {
            Id = id;
            Enterprise = enterprise;
            Inspector = inspector;
            InspectionDate = DateTime.Now;
        }
        
        // TODO 2: Добавить нарушение
        public void AddViolation(string description, string type, string severity, int daysToFix)
        {
            // Создать новое нарушение с уникальным ID (nextViolationId)
            // Установить все параметры
            // Добавить нарушение в список violations
            // Увеличить nextViolationId
        }
        
        // TODO 3: Рассчитать общую оценку безопасности
        public decimal CalculateSafetyScore()
        {
            // Если нарушений нет - вернуть 100
            // Иначе: 100 - (количество нарушений * 10) - (количество критических * 20)
            // Не ниже 0
            return 100;
        }
        
        // TODO 3: Получить статистику по нарушениям
        public void GetViolationStats(out int total, out int critical, out int overdue)
        {
            total = violations.Count;
            critical = 0;
            overdue = 0;
            
            // Посчитать критические нарушения
            // Посчитать просроченные нарушения
        }
        
        // Получить все нарушения (готовый метод)
        public List<Violation> GetViolations()
        {
            return violations;
        }
        
        // Показать отчет о проверке
        public void ShowReport()
        {
            Console.WriteLine($"Проверка №{Id} от {InspectionDate:dd.MM.yyyy}");
            Console.WriteLine($"Предприятие: {Enterprise.Name}");
            Console.WriteLine($"Инспектор: {Inspector.Name}");
            // TODO 1: Вывести результат проверки
            Console.WriteLine($"Нарушений выявлено: {violations.Count}");
        }
    }
}