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
            enterprises.Add(new Enterprise(1, "ООО 'Прогресс'", "ул. Промышленная, 15", 2, 80, "Производство"));
            enterprises.Add(new Enterprise(2, "ТЦ 'Европа'", "пр. Мира, 25", 4, 150, "Торговля"));
            enterprises.Add(new Enterprise(3, "Офис 'ТехноСофт'", "ул. Программистов, 10", 1, 30, "Офис"));

            // ADDED IN TODO 1: звания и специализация для инспекторов
            inspectors.Add(new Inspector { Id = 1, Name = "Иванов А.С.", BadgeNumber = "ФП-001", Rank = "старший инспектор", Specialization = "промышленность" });
            inspectors.Add(new Inspector { Id = 2, Name = "Петрова М.И.", BadgeNumber = "ФП-002", Rank = "инспектор", Specialization = "торговля" });
        }

        // ADDED IN TODO 1: реализация ShowEnterprises
        public void ShowEnterprises()
        {
            Console.WriteLine("=== БАЗА ПРЕДПРИЯТИЙ ===");
            foreach (var e in enterprises)
            {
                Console.WriteLine($"ID: {e.Id}");
                Console.WriteLine($"Название: {e.Name}");
                Console.WriteLine($"Адрес: {e.Address}");
                Console.WriteLine($"Этажей: {e.FloorCount}");
                Console.WriteLine($"Сотрудников: {e.EmployeeCount}");
                Console.WriteLine($"Тип: {e.EnterpriseType}");
                Console.WriteLine($"Категория риска: {e.GetRiskCategory()}");
                Console.WriteLine(new string('-', 30));
            }
        }

        // Заглушки для остальных методов
        public void ConductInspection() { Console.WriteLine("Проведение проверки (заглушка)"); }
        public void MonitorViolations() { Console.WriteLine("Мониторинг нарушений (заглушка)"); }
        public void MarkViolationAsFixed() { Console.WriteLine("Отметка устранения (заглушка)"); }

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
                    case "1": ShowEnterprises(); break;
                    case "2": ConductInspection(); break;
                    case "3": MonitorViolations(); break;
                    case "4": MarkViolationAsFixed(); break;
                    case "5": ShowInspectionStats(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }

                if (running && choice != "6")
                {
                    Console.WriteLine("\nНажмите Enter...");
                    Console.ReadLine();
                }
            }
        }

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
                // activeViolations будет подсчитано позже (TODO 3)
            }

            Console.WriteLine($"Всего нарушений: {totalViolations}");
            Console.WriteLine($"Активных нарушений: {activeViolations}");
        }
    }
}