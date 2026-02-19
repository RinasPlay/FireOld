using System;
using System.Collections.Generic;
using System.Linq; // ADDED IN TODO 2

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

            inspectors.Add(new Inspector { Id = 1, Name = "Иванов А.С.", BadgeNumber = "ФП-001", Rank = "старший инспектор", Specialization = "промышленность" });
            inspectors.Add(new Inspector { Id = 2, Name = "Петрова М.И.", BadgeNumber = "ФП-002", Rank = "инспектор", Specialization = "торговля" });
        }

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

        // ADDED IN TODO 2: реализация ConductInspection
        public void ConductInspection()
        {
            Console.WriteLine("=== ПРОВЕДЕНИЕ ПРОВЕРКИ ===");

            Enterprise selectedEnterprise = SelectEnterprise();
            if (selectedEnterprise == null) return;

            Inspector selectedInspector = SelectInspector();
            if (selectedInspector == null) return;

            Inspection inspection = new Inspection(nextInspectionId++, selectedEnterprise, selectedInspector);

            bool addingViolations = true;
            while (addingViolations)
            {
                Console.WriteLine("\nДобавление нарушения (или оставьте пустым для завершения):");
                Console.Write("Описание нарушения: ");
                string desc = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(desc))
                {
                    addingViolations = false;
                    continue;
                }

                Console.Write("Тип нарушения (Пожарные выходы/Огнетушители/Проводка/...): ");
                string type = Console.ReadLine();

                Console.Write("Серьезность (критическое/значительное/незначительное): ");
                string severity = Console.ReadLine();

                Console.Write("Срок устранения (дней): ");
                if (!int.TryParse(Console.ReadLine(), out int days))
                {
                    Console.WriteLine("Неверное число, нарушение не добавлено.");
                    continue;
                }

                inspection.AddViolation(desc, type, severity, days);
                Console.WriteLine("Нарушение добавлено.");
            }

            inspections.Add(inspection);
            selectedInspector.AddInspection(inspection);

            Console.WriteLine($"\nПроверка завершена. Добавлено нарушений: {inspection.GetViolations().Count}");
        }

        // Заглушки для TODO 3
        public void MonitorViolations() { Console.WriteLine("Мониторинг нарушений (заглушка)"); }
        public void MarkViolationAsFixed() { Console.WriteLine("Отметка устранения (заглушка)"); }

        public void ShowMainMenu()
        {
            // ... (без изменений) ...
        }

        private void ShowInspectionStats()
        {
            // ... (без изменений) ...
        }

        // ADDED IN TODO 2: вспомогательные методы выбора
        private Enterprise SelectEnterprise()
        {
            if (enterprises.Count == 0)
            {
                Console.WriteLine("Нет предприятий в базе.");
                return null;
            }

            Console.WriteLine("Список предприятий:");
            foreach (var e in enterprises)
                Console.WriteLine($"{e.Id}. {e.Name}");

            Console.Write("Выберите ID предприятия: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ввод.");
                return null;
            }

            var selected = enterprises.FirstOrDefault(e => e.Id == id);
            if (selected == null)
                Console.WriteLine("Предприятие не найдено.");
            return selected;
        }

        private Inspector SelectInspector()
        {
            if (inspectors.Count == 0)
            {
                Console.WriteLine("Нет инспекторов.");
                return null;
            }

            Console.WriteLine("Список инспекторов:");
            foreach (var i in inspectors)
                Console.WriteLine($"{i.Id}. {i.Name} ({i.Rank})");

            Console.Write("Выберите ID инспектора: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ввод.");
                return null;
            }

            var selected = inspectors.FirstOrDefault(i => i.Id == id);
            if (selected == null)
                Console.WriteLine("Инспектор не найден.");
            return selected;
        }
    }
}