// TODO:
// 1. Реализовать просмотр базы предприятий
// 2. Реализовать процесс проведения проверки
// 3. Реализовать мониторинг устранения нарушений

using System;
using System.Collections.Generic;

namespace FireInspection
{
    public class InspectionMenu
    {
        private List<Enterprise> enterprises = new List<Enterprise>();
        private List<Inspector> inspectors = new List<Inspector>();
        private List<Inspection> inspections = new List<Inspection>();
        
        private int nextEnterpriseId = 1;
        private int nextInspectionId = 1;
        
        public InspectionMenu()
        {
            InitializeData();
        }
        
        private void InitializeData()
        {
            // Инициализация тестовых данных
            enterprises.Add(new Enterprise(1, "ООО 'Прогресс'", "ул. Промышленная, 15", 2, 80, "Производство"));
            enterprises.Add(new Enterprise(2, "ТЦ 'Европа'", "пр. Мира, 25", 4, 150, "Торговля"));
            enterprises.Add(new Enterprise(3, "Офис 'ТехноСофт'", "ул. Программистов, 10", 1, 30, "Офис"));
            
            inspectors.Add(new Inspector { Id = 1, Name = "Иванов А.С.", BadgeNumber = "ФП-001" });
            inspectors.Add(new Inspector { Id = 2, Name = "Петрова М.И.", BadgeNumber = "ФП-002" });
        }
        
        // TODO 1: Показать все предприятия
        public void ShowEnterprises()
        {
            Console.WriteLine("=== БАЗА ПРЕДПРИЯТИЙ ===");
            
            // Вывести все предприятия с их данными и категорией риска
            // Использовать enterprise.GetRiskCategory()
        }
        
        // TODO 2: Провести проверку
        public void ConductInspection()
        {
            Console.WriteLine("=== ПРОВЕДЕНИЕ ПРОВЕРКИ ===");
            
            // 1. Выбрать предприятие из списка
            // 2. Выбрать инспектора
            // 3. Создать новую проверку Inspection
            // 4. В цикле добавлять нарушения:
            //    - Описание нарушения
            //    - Тип нарушения
            //    - Серьезность
            //    - Срок устранения
            // 5. Рассчитать и вывести результат проверки
            // 6. Добавить проверку в список inspections
            // 7. Инспектору добавить проведенную проверку
        }
        
        // TODO 3: Мониторинг нарушений
        public void MonitorViolations()
        {
            Console.WriteLine("=== МОНИТОРИНГ НАРУШЕНИЙ ===");
            
            // Вывести все непроверенные предприятия
            // Для каждого предприятия с проверками:
            //   - Вывести количество нарушений
            //   - Вывести количество просроченных нарушений
            //   - Вывести общий балл безопасности
            // Вывести инспекторов с их статистикой
        }
        
        // TODO 3: Отметить устранение нарушения
        public void MarkViolationAsFixed()
        {
            Console.WriteLine("=== УСТРАНЕНИЕ НАРУШЕНИЯ ===");
            
            // 1. Выбрать предприятие
            // 2. Показать все нарушения предприятия
            // 3. Выбрать нарушение для отметки
            // 4. Отметить как устраненное через violation.MarkAsFixed()
        }
        
        // Готовый метод - главное меню
        public void ShowMainMenu()
        {
            bool running = true;
            
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== ПОЖАРНАЯ ИНСПЕКЦИЯ 'ОГНЕЩИТ' ===");
                Console.WriteLine("1. База предприятий");
                Console.WriteLine("2. Провести проверку");
                Console.WriteLine("3. Мониторинг нарушений");
                Console.WriteLine("4. Отметить устранение");
                Console.WriteLine("5. Статистика инспекции");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите: ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        ShowEnterprises();
                        break;
                    case "2":
                        ConductInspection();
                        break;
                    case "3":
                        MonitorViolations();
                        break;
                    case "4":
                        MarkViolationAsFixed();
                        break;
                    case "5":
                        ShowInspectionStats();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
                
                if (running)
                {
                    Console.WriteLine("\nНажмите Enter...");
                    Console.ReadLine();
                }
            }
        }
        
        // Метод для показа статистики
        private void ShowInspectionStats()
        {
            Console.WriteLine("=== СТАТИСТИКА ИНСПЕКЦИИ ===");
            Console.WriteLine($"Всего предприятий: {enterprises.Count}");
            Console.WriteLine($"Всего проверок: {inspections.Count}");
            
            int totalViolations = 0;
            int activeViolations = 0;
            
            foreach (var inspection in inspections)
            {
                totalViolations += inspection.GetViolations().Count;
                // Подсчитать активные нарушения
            }
            
            Console.WriteLine($"Всего нарушений: {totalViolations}");
            Console.WriteLine($"Активных нарушений: {activeViolations}");
        }
    }
}