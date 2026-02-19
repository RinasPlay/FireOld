// TODO:
// 1. Реализовать учет данных инспектора
// 2. Реализовать статистику работы инспектора
// 3. Реализовать систему специализации инспектора

using System.Collections.Generic;

namespace FireInspection
{
    public class Inspector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BadgeNumber { get; set; }        // Номер удостоверения
        
        // TODO 1: Добавить свойство Rank (звание: инспектор, старший инспектор, главный инспектор)
        // TODO 1: Добавить свойство Specialization (специализация: промышленность, торговля, жилье)
        
        private List<Inspection> conductedInspections = new List<Inspection>();
        
        // TODO 2: Добавить проведенную проверку
        public void AddInspection(Inspection inspection)
        {
            // Добавить проверку в список conductedInspections
        }
        
        // TODO 3: Получить статистику работы
        public void GetWorkStats(out int totalInspections, out int totalViolations, out decimal avgSafetyScore)
        {
            totalInspections = conductedInspections.Count;
            totalViolations = 0;
            avgSafetyScore = 0;
            
            // Пройти по всем проверкам, посчитать общее количество нарушений
            // Рассчитать средний балл безопасности
        }
        
        // TODO 3: Получить количество активных нарушений
        public int GetActiveViolationsCount()
        {
            int count = 0;
            
            // Пройти по всем проверкам и всем нарушениям
            // Посчитать нарушения, которые еще не устранены
            return count;
        }
        
        // Показать информацию об инспекторе
        public void ShowInspectorInfo()
        {
            Console.WriteLine($"Инспектор: {Name}");
            Console.WriteLine($"Удостоверение: {BadgeNumber}");
            // TODO 1: Вывести звание и специализацию
            Console.WriteLine($"Проведено проверок: {conductedInspections.Count}");
        }
    }
}